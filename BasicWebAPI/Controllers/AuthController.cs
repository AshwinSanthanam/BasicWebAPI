using BasicWebApi.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApi.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public string AuthenticateUser([FromBody]AuthenticateUserRequestBody requestBody)
        {
            if(requestBody.Email == "ashwin@gmail.com" && requestBody.Password == "password-1")
            {
                return "Login success";
            }
            else
            {
                return "Login failed";
            }
        }
    }
}
