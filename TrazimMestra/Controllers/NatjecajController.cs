using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using TrazimMestra.Dtos;

namespace TrazimMestra.Controllers
{
    public class NatjecajController : BaseApiController
    {
        private readonly IGenericRepository<Natjecaj> _repository;
        private readonly IMapper _mapper;
        private readonly INatjecajRepository _natjecajRepository;
        public NatjecajController(IGenericRepository<Natjecaj> repo, IMapper mapper, INatjecajRepository natjecajRepository)
        {
            _repository = repo;
            _mapper = mapper;
            _natjecajRepository = natjecajRepository;
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
            return Ok();
        }

        [HttpGet("allnatjecajs")]
        public async Task<ActionResult<IReadOnlyList<NatjecajListingDto>>> ListAllNatjecaj()
        {
            var natjecaji = await _natjecajRepository.GetNatjecajs();

            IList<NatjecajListingDto> list = new List<NatjecajListingDto>();

            _mapper.Map(natjecaji, list);

            return Ok(list);
        }

        [HttpGet("filterednatjecajs")]
        public async Task<ActionResult<IReadOnlyList<NatjecajListingDto>>> FilterNatjecajs(string? category, string? county, string? city)
        {
            var natjecaji = await _natjecajRepository.GetFilteredNatjecajs(category, county, city);

            IList<NatjecajListingDto> list = new List<NatjecajListingDto>();

            _mapper.Map(natjecaji, list);

            return Ok(list);
        }

    }
}
