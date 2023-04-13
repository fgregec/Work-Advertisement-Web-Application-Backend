using Core.Dto;
using Core.Entities;
using Core.interfaces;
using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        [HttpGet]
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

        [HttpGet("search")]
        public async Task<ActionResult<IReadOnlyList<Mestar>>> ListByFilters(SearchMestarDto search, PaginationDto pagination)
        {
            var mestri = await _mestarRepository.Search(search);

            if (!mestri.Any())
                return NotFound();

            PaginationFilter<Mestar> filterData = new PaginationFilter<Mestar>
            {
                PageIndex = pagination.CurrentPage,
                PageSize = pagination.PageSize,
                Data = mestri.Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                             .Take(pagination.PageSize)
                             .ToList()
            };

            return Ok(filterData);
        }        
    }
}
