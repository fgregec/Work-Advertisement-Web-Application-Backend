using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TrazimMestra.Controllers
{
    public class AccountController : BaseApiController
    {
        private ApplicationContext _repo;
        public AccountController(ApplicationContext context)
        {
            _repo = context;
        }

        [HttpGet("getuser")]
        public async Task<ActionResult<BaseUser>> GetCurrentUser(Guid id)
        {
            var baseUser = await _repo.Users.FirstOrDefaultAsync(u => u.Id == id);

            if(baseUser == null) 
            {
                return NotFound();
            }

            return Ok(baseUser);
        }

        [HttpGet("checkemail")]
        public async Task<ActionResult<bool>> CheckEmail(string email)
        {
            return Ok(await _repo.Users.AnyAsync(u => u.Email == email));
        }

        [HttpGet("login")]
        public async Task<ActionResult<bool>> Login(string email, string password)
        {
            var baseUser = await _repo.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (baseUser == null) 
            {
                return Ok(false);
            }

            return Ok(baseUser.Password == password ? true:false);
        }

        [HttpGet("register")]
        public async Task<ActionResult<bool>> Register([FromQuery]User user) 
        {
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                await _repo.Users.AddAsync(user);
                await _repo.SaveChangesAsync();
                return Ok(true);
            }

            return Ok(false);
        }
    }
}
