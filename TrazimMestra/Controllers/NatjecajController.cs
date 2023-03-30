using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace TrazimMestra.Controllers
{
    public class NatjecajController : BaseApiController
    {
        private readonly IGenericRepository<Natjecaj> _repository;

        public NatjecajController(IGenericRepository<Natjecaj> repo)
        {
            _repository = repo;
        }

        [HttpPost]
        public IActionResult Add(Natjecaj natjecaj)
        {
            _repository.Add(natjecaj);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var natjecaj = await _repository.GetByIdAsync(id);
            if (natjecaj == null)
            {
                return NotFound();
            }

            _repository.Delete(natjecaj);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Natjecaj natjecaj)
        {
            _repository.Update(natjecaj);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Natjecaj>> GetById(Guid id)
        {
            var natjecaj = await _repository.GetByIdAsync(id);

            if (natjecaj == null)
            {
                return NotFound();
            }

            return Ok(natjecaj);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Natjecaj>>> ListAll()
        {
            var natjecaji = await _repository.ListAllAsync();
            return Ok(natjecaji);
        }
    }
}
