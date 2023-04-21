﻿using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Models;
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

        [HttpGet("filterednatjecajs")]
        public async Task<ActionResult<Pagination<NatjecajListingDto>>> FilterNatjecajs([FromQuery]NatjecajFilter filter)
        {
            var natjecaji = await _natjecajRepository.GetFilteredNatjecajs(filter);

            IList<NatjecajListingDto> list = new List<NatjecajListingDto>();

            _mapper.Map(natjecaji, list);

            var paginated = new Pagination<NatjecajListingDto>
            {
                Count = natjecaji.Count(),
                Data = list.Skip((filter.PageIndex - 1) * filter.PageSize).Take(filter.PageSize).ToList()
            };

            return Ok(paginated);
        }

    }
}
