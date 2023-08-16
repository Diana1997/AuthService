using System.Threading.Tasks;
using AuthService.BL.Commands.Login;
using AuthService.BL.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
   
    public class AuthController : ApiBaseController
    {
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginResponse),StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult>  Login(LoginCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}