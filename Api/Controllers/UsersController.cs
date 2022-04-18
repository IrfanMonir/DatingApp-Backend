using Api.Data;
using Api.Entities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers() => _context.Users.ToList();

        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id) => _context.Users.Find(id);
    }
}
