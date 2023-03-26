using Core.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace TrazimMestra.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            _userRepository.Add(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _userRepository.Delete(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(User user)
        {
            _userRepository.Update(user);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<User>>> ListAllAsync()
        {
            var users = await _userRepository.ListAllAsync();
            return Ok(users);
        }

        [HttpGet("resolved-natjecaji/{userID}")]
        public async Task<ActionResult<IReadOnlyList<Natjecaj>>> ListResolvedNatjecaja(Guid userID)
        {
            var userNatjecaji = await _userRepository.ListResolvedNatjecaja(userID);
            return Ok(userNatjecaji);
        }
    }
}
