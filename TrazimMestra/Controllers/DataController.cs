using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrazimMestra.Attributes;

namespace TrazimMestra.Controllers
{
    public class DataController : BaseApiController
    {
        private readonly ApplicationContext _context;

        public DataController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("cities")]
        public async Task<ActionResult<string>> GetAllCity()
        {
            var cities = await _context.Cities.ToListAsync();
            return Ok(cities);
        }

        [HttpGet("counties")]
        public async Task<ActionResult<string>> GetAllCounty()
        {
            var counties = await _context.Counties.ToListAsync();
            return Ok(counties);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<string>> GetAllCategory()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }
    }
}
