using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrazimMestra.Controllers
{
    public class MestarController : BaseApiController
    {
        private readonly MestarRepository _mestarRepository;

        public MestarController(MestarRepository mestarRepository)
        {
            _mestarRepository = mestarRepository;
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
            {
                return NotFound();
            }
            
            _mestarRepository.Delete(mestar);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Mestar mestar)
        {            
            _mestarRepository.Update(mestar);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mestar>> GetById(Guid id)
        {
            var mestar = await _mestarRepository.GetByIdAsync(id);
            if (mestar == null)
            {
                return NotFound();
            }

            return Ok(mestar);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Mestar>>> ListAll()
        {
            var mestri = await _mestarRepository.ListAllAsync();
            return Ok(mestri);
        }

        [HttpGet("resolved-natjecaji/{mestarID}")]
        public async Task<ActionResult<IReadOnlyList<Natjecaj>>> ListResolvedNatjecaja(Guid mestarID)
        {
            var natjecaji = await _mestarRepository.ListResolvedNatjecaja(mestarID);
            return Ok(natjecaji);
        }
    }

}
