using AutoMapper;
using Core.Entities;
using Core.interfaces;
using Core.Interfaces;
using Core.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using TrazimMestra.Dtos;

namespace TrazimMestra.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IGenericRepository<User> _repository;
        private readonly INatjecajRepository _natjecajRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IGenericRepository<User> repository, INatjecajRepository natjecajRepository, IUserRepository userRepository, IMapper mapper)
        {
            _repository = repository;
            _natjecajRepository = natjecajRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            _repository.Add(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _repository.Delete(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(User user)
        {
            _repository.Update(user);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetByIdAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<User>>> ListAllAsync()
        {
            var users = await _repository.ListAllAsync();
            return Ok(users);
        }

        [HttpGet("resolved-natjecaji/{userID}")]
        public async Task<ActionResult<IReadOnlyList<Natjecaj>>> ListResolvedNatjecaja(Guid userID)
        {
            var userNatjecaji = await _natjecajRepository.GetListResolvedNatjecaja(userID);
            return Ok(userNatjecaji);
        }

        [HttpGet("search")]
        public async Task<IReadOnlyList<BasicUserDto>> Search(string input)
        {
            var users = await _userRepository.Search(input);

            var result = new List<BasicUserDto>();
            _mapper.Map<IReadOnlyList<User>, IReadOnlyList<BasicUserDto>>(users, result);

            return result;
        }
    }
}
