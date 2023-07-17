using AuthService.DAL.Models;

namespace AuthService.Services
{
    public interface ITokenBuilder
    {
        string GenerateToken(User user);
    }
}