using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace TrazimMestra.Controllers
{
    public class AccountController : BaseApiController
    {
        private MestarContext _context;
        public AccountController(MestarContext context)
        {
            _context = context;
        }

        [HttpGet("getuser")]
        public async Task<ActionResult<BaseUser>> GetCurrentUser(Guid id)
        {
            var baseUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if(baseUser == null) 
            {
                return NotFound();   
            }

            return baseUser;
        }

        [HttpGet("checkemail")]
        public async Task<bool> CheckEmail(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        [HttpGet("login")]
        public async Task<bool> Login(string email, string password)
        {
            var baseUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (baseUser == null) 
            {
                return false;
            }

            return baseUser.Password == password ? true:false;
        }

        [HttpGet("register")]
        public async Task<bool> Register([FromQuery]BaseUser user) 
        {
            if (ModelState.IsValid)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

    }
}
