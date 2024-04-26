using Back_HMZ.Context;
using Back_HMZ.Forms;
using Back_HMZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back_HMZ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<object> GetPerPage([FromQuery] int perpage, [FromQuery] int page)
        {
            if (perpage < 0)
            {
                return BadRequest("O número de usuários por página deve ser maior que 0");
            }

            var totalUsers = _context.Users.Count();
            var totalPages = (perpage == 0) ? 1 : (int)Math.Ceiling((double)totalUsers / perpage);

            int inicio;
            if (page <= 0 || page > totalPages)
            {
                inicio = 0;
                page = 1;
            }
            else
            {
                inicio = (page - 1) * perpage;
            }

            var users = (perpage == 0) ? _context.Users.Take(6).ToList() : _context.Users.Skip(inicio).Take(perpage).ToList();

            if (users.Count == 0)
            {
                return BadRequest("A página selecionada não existe");
            }

            if(perpage == 0)
            {
                perpage = users.Count;
            }

            return new
            {
                Page = page,
                Perpage = perpage,
                TotalUsers = totalUsers,
                TotalPages = totalPages,
                Users = users
            };
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult<User> Get(int id)
        {
            var user = _context.Users.Find(id);
            if(user == null)
            {
                return NotFound();
            }
            return user;
        }


        [HttpPut("{id}")]
        public ActionResult<object> Put(int id, [FromBody] UpdateForm req)
        {
            if (req.email != null && req.first_name == null && req.last_name == null && req.avatar == null)
            {
                return BadRequest();
            }

            var usuarioEx = _context.Users.Find(id);
            var login = _context.Logins.FirstOrDefault(l => l.UserId == id);
            if (usuarioEx == null)
            {
                return BadRequest();
            }

            var updatedAt = DateTime.UtcNow;

            if (req.email != null)
            {
                usuarioEx.email = req.email;
                if (login != null)
                {
                    login.Email = req.email;
                }
            }
            if (req.first_name != null)
            {
                usuarioEx.first_name = req.first_name;
            }
            if (req.last_name != null)
            {
                usuarioEx.last_name = req.last_name;
            }
            if (req.avatar != null)
            {
                usuarioEx.avatar = req.avatar;
            }

            _context.Entry(usuarioEx).State = EntityState.Modified;
            _context.SaveChanges();

            return new
            {
                updatedAt = updatedAt
            };
        }

        

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            var userlog = _context.Logins.Find(id);
            if(user == null && userlog == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.Logins.Remove(userlog);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
