using BasicWebApi.ApiResource.Auth;
using Microsoft.AspNetCore.Authorization;
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
        [HttpPost]
        public IActionResult Login([FromBody]LoginRequest loginRequest)
        {
            if(loginRequest.Email == "ashwin@gmail.com" && loginRequest.Password == "password")
            {
                IEnumerable<Claim> claims = new List<Claim> 
                {
                    new Claim(ClaimTypes.Email, loginRequest.Email)
                };
                string token = GenerateJwt(claims, DateTime.Now.AddDays(1), "this is a secret key");
                return new OkObjectResult(token);
            }
            else
            {
                return new UnauthorizedResult();
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult SecureMethod()
        {
            return new OkObjectResult("Secure method is called");
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
