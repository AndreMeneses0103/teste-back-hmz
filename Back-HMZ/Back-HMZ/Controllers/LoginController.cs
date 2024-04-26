using Back_HMZ.Context;
using Back_HMZ.Forms;
using Back_HMZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace Back_HMZ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public ActionResult<object> Login([FromBody] LoginForm log)
        {
            var user = _context.Logins.SingleOrDefault(u => u.Username == log.LoginName || u.Email == log.LoginName);

            if (user != null && user.Password == log.Password)
            {
                var claims = new[]
                {
                    new Claim("UserId", user.UserId.ToString())
                };

                var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("724959134517249591345172495913451"));

                var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(issuer: "hmz", audience: "API", claims: claims, expires: DateTime.Now.AddHours(1), signingCredentials: credencial);

                return new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                };
            }

            return Unauthorized("Nome ou senha invalidos");
        }

        [HttpPut("{id}")]
        public ActionResult<object> LoginPut(int id, [FromBody] LoginUpdateForm log)
        {
            if (log.Username != null && log.Password == null)
            {
                return BadRequest();
            }

            var loginEx = _context.Logins.Find(id);
            if (loginEx == null)
            {
                return BadRequest();
            }

            var updatedAt = DateTime.UtcNow;

            if (log.Username != null)
            {
                loginEx.Username = log.Username;
            }
            if (log.Password != null)
            {
                loginEx.Password = log.Password;
            }

            _context.Entry(loginEx).State = EntityState.Modified;
            _context.SaveChanges();

            return new
            {
                updatedAt = updatedAt
            };
        }

    }
}
