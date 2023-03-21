using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace TrazimMestra.Controllers
{
    public class WeatherForecastController : BaseApiController
    {
        private MestarContext _context;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, MestarContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetCountries")]
        public IEnumerable<Country> GetCountries()
        {
            _context.Countries.Add(new Country()
            {
                Id = Guid.NewGuid(),
                Name = "Croatia"
            });
            return _context.Countries.ToList();
        }
    }
}