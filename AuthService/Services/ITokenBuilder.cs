using System.Security.Claims;
using AuthService.DAL.Models;

namespace AuthService.Services
{
    public interface ITokenBuilder
    {
        string GenerateAccessToken(Claim[] clams);
    }
}