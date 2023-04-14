using AutoMapper;
using Core.Entities;
using Core.interfaces;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using TrazimMestra.Dtos;

namespace TrazimMestra.Controllers
{
    public class MestarController : BaseApiController
    {
        private readonly IGenericRepository<Mestar> _repository;
        private readonly INatjecajRepository _natjecajRepository;
        private readonly IMestarRepository _mestarRepository;
        private readonly IMapper _mapper;

        public MestarController(IGenericRepository<Mestar> repository, INatjecajRepository natjecajRepository, IMestarRepository mestarRepository, IMapper mapper)
        {
            _repository = repository;
            _natjecajRepository = natjecajRepository;
            _mestarRepository = mestarRepository;
            _mapper = mapper;
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
        public async Task<ActionResult<IReadOnlyList<Mestar>>> ListByFilters(MestarFilter searchOptions)
        {
            var mestri = await _mestarRepository.Search(searchOptions);                       

            return Ok(mestri);
        }        
    }
}
