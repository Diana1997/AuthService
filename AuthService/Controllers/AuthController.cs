using System.Threading.Tasks;
using AuthService.BL.Commands.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
   
    public class AuthController : ApiBaseController
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult>  Login(LoginCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}