using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace TrazimMestra.Controllers
{
    public class MestarController : BaseApiController
    {
        private readonly IGenericRepository<Mestar> _mestarRepository;
        private readonly NatjecajRepository _natjecajRepository;

        public MestarController(IGenericRepository<Mestar> mestarRepository, NatjecajRepository natjecajRepository)
        {
            _mestarRepository = mestarRepository;
            _natjecajRepository = natjecajRepository;
        }

        [HttpPost]
        public IActionResult Add(Mestar mestar)
        {
            _mestarRepository.Add(mestar);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var mestar = await _mestarRepository.GetByIdAsync(id);
            
            if (mestar == null)
                return NotFound();
            
            _mestarRepository.Delete(mestar);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Mestar mestar)
        {            
            _mestarRepository.Update(mestar);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mestar>> GetByIdAsync(Guid id)
        {
            var mestar = await _mestarRepository.GetByIdAsync(id);
            if (mestar == null)
            {
                return NotFound();
            }

            return Ok(mestar);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IReadOnlyList<Mestar>>> ListAllAsync()
        {
            var mestri = await _mestarRepository.ListAllAsync();
            return Ok(mestri);
        }

        [HttpGet("resolved-natjecaji/{mestarID}")]
        public async Task<ActionResult<IReadOnlyList<Natjecaj>>> ListResolvedNatjecaja(Guid mestarID)
        {
            var mestarNatjecaji = await _natjecajRepository.ListResolvedNatjecaja(mestarID);
            return Ok(mestarNatjecaji);
        }
    }

}
