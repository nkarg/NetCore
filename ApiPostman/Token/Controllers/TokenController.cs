using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Token.Core;

namespace Token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        // GET api/values
        [AllowAnonymous]
        [HttpPost]
        [Route("obtener")]
        public ActionResult Obtener([FromBody] TokenRequest tokenRequest)
        {
            if (Validate(tokenRequest))
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, tokenRequest.UserName)
                };

                var secret = "Prode-WebApi-API-super-secret-@DiplomadoASP.NET-Core"; ;
                //Servidor que emite el token
                var issuer = "http://localhost:50475";
                var audience = "WebApi";

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: issuer, //"http://localhost:50475"
                    audience: audience, //"WebApi"
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials);

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest("Invalid UserName or Password");
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private bool Validate(TokenRequest tokenRequest)
        {
            var test = Reverse(tokenRequest.Password);
            return tokenRequest.UserName.Equals(Reverse(tokenRequest.Password));
        }

        private string Reverse(string value)
        {
            char[] array = value.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
