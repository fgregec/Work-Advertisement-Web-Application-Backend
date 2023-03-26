using Core;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace TrazimMestra.Controllers
{
    public class WeatherForecastController : BaseApiController { 

        private IUnitOfWork _uow;

        public WeatherForecastController(IGenericRepository<City> countryRepo, IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost]
        public async Task AddCIty(City city)
        {
            var repo = _uow.Repository<City>();
            repo.Add(city);
            await _uow.CommitChangesAsync();
        }

       
    }
}