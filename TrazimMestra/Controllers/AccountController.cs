using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;
using TrazimMestra.Dtos;

namespace TrazimMestra.Controllers
{
    public class AccountController : BaseApiController
    {
        private ApplicationContext _repo;
        private readonly ITokenService _tokenService;
        public AccountController(ApplicationContext context, ITokenService tokenService)
        {
            _repo = context;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetCurrentUser(Guid id)
        {
            var baseUser = await _repo.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (baseUser == null)
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
        public async Task<ActionResult<string>> Login(string email, string password)
        {
            var baseUser = await _repo.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (baseUser == null)
            {
                return BadRequest("User does not exist");
            }

            return Ok(_tokenService.CreateToken(baseUser));
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register([FromQuery] RegisterDto registerUser)
        {

            User user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = registerUser.FirstName,
                LastName = registerUser.LastName,
                Email = registerUser.Email,
                Password = registerUser.Password,
                CityID = registerUser.CityID
            };

            await _repo.Users.AddAsync(user);
            await _repo.SaveChangesAsync();
            return Ok(_tokenService.CreateToken(user));

        }

        [HttpPost("update")]
        public async Task<ActionResult> Update([FromQuery] UpdateUserDto user)
        {
            User mappedUser = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CityID = user.CityID
            };

            if (!string.IsNullOrEmpty(user.Password))
                mappedUser.Password = user.Password;

            _repo.Users.Update(mappedUser);
            await _repo.SaveChangesAsync();
            return Ok();

        }

    }
}
