using BasicWebApi.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BasicWebApi.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult AuthenticateUser([FromBody]AuthenticateUserRequestBody requestBody)
        {
            if(requestBody.Email == "ashwin@gmail.com" && requestBody.Password == "password-1")
            {
                IEnumerable<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, requestBody.Email)
                };
                string jwt = GenerateJwt(claims, DateTime.Now.AddDays(8), _configuration.GetSection("SecretKey").Value);
                return new OkObjectResult(jwt);
            }
            else
            {
                return new UnauthorizedResult();
            }
        }

        private string GenerateJwt(IEnumerable<Claim> claims, DateTime expiry, string key)
        {
            var keyBytes = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expiry,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
