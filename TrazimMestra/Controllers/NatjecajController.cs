using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace TrazimMestra.Controllers
{
    public class NatjecajController : BaseApiController
    {
        private readonly NatjecajRepository _natjecajRepository;

        public NatjecajController(NatjecajRepository natjecajRepository)
        {
            _natjecajRepository = natjecajRepository;
        }

        [HttpPost]
        public IActionResult Add(Natjecaj natjecaj)
        {
            _natjecajRepository.Add(natjecaj);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var natjecaj = await _natjecajRepository.GetByIdAsync(id);
            if (natjecaj == null)
            {
                return NotFound();
            }

            _natjecajRepository.Delete(natjecaj);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Natjecaj natjecaj)
        {
            _natjecajRepository.Update(natjecaj);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Natjecaj>> GetById(Guid id)
        {
            var natjecaj = await _natjecajRepository.GetByIdAsync(id);

            if (natjecaj == null)
            {
                return NotFound();
            }

            return Ok(natjecaj);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Natjecaj>>> ListAll()
        {
            var natjecaji = await _natjecajRepository.ListAllAsync();
            return Ok(natjecaji);
        }
    }
}
