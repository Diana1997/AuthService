using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthService.DAL.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AuthService.Services
{
    public class TokenBuilder : ITokenBuilder
    {
        private readonly IConfiguration _configuration;

        public TokenBuilder(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateAccessToken(Claim[] clams)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetValue<string>("Key")));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: jwtSettings.GetValue<string>("Issuer"),
                audience: jwtSettings.GetValue<string>("Audience"),
                claims: clams,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            
            
         return tokenString;
        }
    }
}