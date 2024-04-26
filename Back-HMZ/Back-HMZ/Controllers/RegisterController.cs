using Back_HMZ.Context;
using Back_HMZ.Forms;
using Back_HMZ.Models;
using Microsoft.AspNetCore.Mvc;

namespace Back_HMZ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegisterController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpPost]
        public ActionResult Post([FromBody] RegisterForm reg)
        {
            try
            {
                var newUser = CreateUser(reg);
                var newLogin = CreateLogin(reg, newUser.Id);

                return StatusCode(201, new { id = newUser.Id });
            }
            catch (Exception err)
            {
                return StatusCode(500, err.Message);
            }
        }

        private User CreateUser(RegisterForm reg)
        {
            var newUser = new User
            {
                avatar = null,
                first_name = null,
                last_name = null,
                email = reg.Email
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return newUser;
        }

        private Login CreateLogin(RegisterForm reg, int userId)
        {
            var newLogin = new Login
            {
                Email = reg.Email,
                Username = reg.Username,
                Password = reg.Password,
                UserId = userId
            };

            _context.Logins.Add(newLogin);
            _context.SaveChanges();

            return newLogin;
        }

        
    }
}
