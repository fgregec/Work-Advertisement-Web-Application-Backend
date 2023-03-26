using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TrazimMestra.Controllers
{
    public class MestarController : BaseApiController
    {
        private readonly IGenericRepository<Mestar> _mestarRepository;
        private readonly IMestarRepository _repo;

        public MestarController(IGenericRepository<Mestar> mestarRepository, IMestarRepository repo)
        {
            _mestarRepository = mestarRepository;
            _repo = repo;
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

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Mestar>>> ListAllAsync()
        {
            var mestri = await _mestarRepository.ListAllAsync();
            return Ok(mestri);
        }

        [HttpGet("resolved-natjecaji/{mestarID}")]
        public async Task<ActionResult<IReadOnlyList<Natjecaj>>> ListResolvedNatjecaja(Guid mestarID)
        {
            var natjecaji = await _repo.ListResolvedNatjecaja(mestarID);
            return Ok(natjecaji);
        }
    }

}
