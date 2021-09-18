using BasicWebApi.ApiResource.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BasicWebApi.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody]LoginRequest loginRequest)
        {
            if(loginRequest.Email == "ashwin@gmail.com" && loginRequest.Password == "password")
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
