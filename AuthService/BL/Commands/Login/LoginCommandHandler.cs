using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AuthService.BL.Responses;
using AuthService.DAL.Models;
using AuthService.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthService.BL.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenBuilder _tokenBuilder;
        
        public LoginCommandHandler(
            SignInManager<User> signInManager, 
            ITokenBuilder tokenBuilder)
        {
            _signInManager = signInManager;
            _tokenBuilder = tokenBuilder;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

            if (!result.Succeeded)
            {
                throw new Exception("Username and/or password incorrect");
            }
            
            var user = await _signInManager.UserManager.FindByNameAsync(request.Username);

            var clams = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            
            var accessToken = _tokenBuilder.GenerateAccessToken(clams);
            
            var loginResponse = new LoginResponse
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                AccessToken = accessToken
            };
            
            return loginResponse;
        }
    }
}