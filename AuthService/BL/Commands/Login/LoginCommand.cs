using AuthService.BL.Responses;
using MediatR;

namespace AuthService.BL.Commands.Login
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Username { set; get; }
        public string Password { set; get; }
    }
}