using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace TrazimMestra.Controllers
{
    public class MestarController : BaseApiController
    {
        private readonly IGenericRepository<Mestar> _repository;
        private readonly INatjecajRepository _natjecajRepository;

        public MestarController(IGenericRepository<Mestar> repository, INatjecajRepository natjecajRepository)
        {
            _repository = repository;
            _natjecajRepository = natjecajRepository;
        }

        [HttpPost]
        public IActionResult Add(Mestar mestar)
        {
            _repository.Add(mestar);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var mestar = await _repository.GetByIdAsync(id);
            
            if (mestar == null)
                return NotFound();
            
            _repository.Delete(mestar);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Mestar mestar)
        {            
            _repository.Update(mestar);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mestar>> GetByIdAsync(Guid id)
        {
            var mestar = await _repository.GetByIdAsync(id);
            if (mestar == null)
            {
                return NotFound();
            }

            return Ok(mestar);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IReadOnlyList<Mestar>>> ListAllAsync()
        {
            var mestri = await _repository.ListAllAsync();
            return Ok(mestri);
        }

        [HttpGet("resolved-natjecaji/{mestarID}")]
        public async Task<ActionResult<IReadOnlyList<Natjecaj>>> ListResolvedNatjecaja(Guid mestarID)
        {
            var mestarNatjecaji = await _natjecajRepository.GetListResolvedNatjecaja(mestarID);
            return Ok(mestarNatjecaji);
        }
    }

}
