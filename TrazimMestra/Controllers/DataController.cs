using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrazimMestra.Attributes;

namespace TrazimMestra.Controllers
{
    public class DataController : BaseApiController
    {
        private readonly IGenericRepository<City> _cityRepo;
        private readonly IGenericRepository<County> _countyRepo;

        public DataController(IGenericRepository<City> cityRepo, IGenericRepository<County> countyRepo)
        { 
            _cityRepo = cityRepo;
            _countyRepo = countyRepo;
        }

        [HttpGet("cities")]
        public async Task<ActionResult<City>> GetCities(Guid countyId)
        {
            var city = await _cityRepo.ListAllAsync();     
            var filtered = city.Where(c => c.CountyID == countyId).ToList();
            if (city == null)
            {
                return NotFound();
            }

            return Ok(filtered);
        }

        [HttpGet("counties")]
        public async Task<ActionResult<County>> GetCounties()
        {
            var counties = await _countyRepo.ListAllAsync();

            if (counties == null)
            {
                return NotFound();
            }

            return Ok(counties);
        }

    }
}
