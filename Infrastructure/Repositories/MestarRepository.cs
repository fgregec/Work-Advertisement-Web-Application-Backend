using Core.Entities;
using Core.interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MestarRepository : IMestarRepository
    {
        private readonly ApplicationContext _context;
        public MestarRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Mestar>> GetMestarByName(string mestar_name)
        {
            return await _context.Mestri.Where(x =>
                   x.FirstName.ToLower().Contains(mestar_name.ToLower()) ||
                   x.LastName.ToLower().Contains(mestar_name.ToLower()))
                   .OrderBy(x => x.LastName)   // later will be by review
                   .ToListAsync();
        }

        public async Task<IEnumerable<Mestar>> GetMestarListByFilters(IEnumerable<Category> categories, City? city = null)
        {
            var mestri = await _context.Mestri.Where(mestar =>
                         mestar.Categories.Any(category =>
                         categories.Contains(category))).ToListAsync();

            if (city != null)
            {
                return mestri.Where(mestar => mestar.City.Name == city.Name);
            }

            return mestri;
        }
    }
}
