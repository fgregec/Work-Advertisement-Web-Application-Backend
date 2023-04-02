using Core.Entities;
using Core.interfaces;
using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace TrazimMestra.Controllers
{
    public class MestarController : BaseApiController
    {
        private readonly IGenericRepository<Mestar> _repository;
        private readonly INatjecajRepository _natjecajRepository;
        private readonly IMestarRepository _mestarRepository;

        public MestarController(IGenericRepository<Mestar> repository, INatjecajRepository natjecajRepository, IMestarRepository mestarRepository)
        {
            _repository = repository;
            _natjecajRepository = natjecajRepository;
            _mestarRepository = mestarRepository;
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

            if (mestarNatjecaji == null)
            { 
                return NotFound(); 
            }

            return Ok(mestarNatjecaji);
        }

        [HttpGet("{byName}")]
        public async Task<ActionResult<IReadOnlyList<Mestar>>> ListByName(string mestar_name)
        {
            if (string.IsNullOrWhiteSpace(mestar_name))
            {
                return BadRequest("Mestar name cannot be empty or null!");
            }

            var mestri = await _mestarRepository.GetMestarByName(mestar_name);
            return Ok(mestri);
        }

        [HttpGet("{byFilters}")]
        public async Task<ActionResult<IReadOnlyList<Mestar>>> ListByFilters(IEnumerable<Category> categories, City? city)
        {
            if (city == null &&  categories == null)
            {
                return Ok(_repository.ListAllAsync());
            }

            var mestri = await _mestarRepository.GetMestarListByFilters(categories, city);
            return Ok(mestri);
        }        
    }
}
