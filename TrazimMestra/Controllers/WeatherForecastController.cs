using Core;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace TrazimMestra.Controllers
{
    public class WeatherForecastController : BaseApiController
    {
        private IGenericRepository<Country> _countryRepo;
      
        public WeatherForecastController(IGenericRepository<Country> countryRepo)
        {
            _countryRepo = countryRepo;
        }

        [HttpGet]
        public async Task<IReadOnlyList<Country>> GetCountryAsync()
        {
            return await _countryRepo.ListAllAsync();
        }

       
    }
}