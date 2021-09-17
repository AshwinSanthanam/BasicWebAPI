using BasicWebApi.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApi.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult AuthenticateUser([FromBody]AuthenticateUserRequestBody requestBody)
        {
            if(requestBody.Email == "ashwin@gmail.com" && requestBody.Password == "password-1")
            {
                return new OkResult();
            }
            else
            {
                return new UnauthorizedResult();
            }
        }
    }
}
