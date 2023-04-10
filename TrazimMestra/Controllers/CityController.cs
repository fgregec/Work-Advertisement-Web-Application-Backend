using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrazimMestra.Attributes;

namespace TrazimMestra.Controllers
{
    public class CityController : BaseApiController
    {
        private readonly ApplicationContext _context;

        public CityController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<string>> GetAllCity()
        {
            var cities = await _context.Cities.ToListAsync();
            return Ok(cities);
        }
    }
}
