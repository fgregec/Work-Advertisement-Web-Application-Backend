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
        public async Task<IEnumerable<Mestar>> GetMestarByName(string input_value)
        {
            if (string.IsNullOrEmpty(input_value))
            {
                throw new ArgumentNullException("input_value");
            }

            return await _context.Mestri.Where(x =>
                   x.FirstName.ToLower().Contains(input_value.ToLower()) ||
                   x.LastName.ToLower().Contains(input_value.ToLower())).ToListAsync();
        }

        public async Task<IEnumerable<Mestar>> GetMestarListByCategories(string[] categories) // add location as optional
        {
            if (categories == null || categories.Length == 0)
            {
                throw new ArgumentNullException(nameof(categories));
            }

            return await _context.Mestri.Where(mestar =>
                   mestar.Categories.Any(category =>
                   categories.Contains(category.Name))).ToListAsync();
        }
    }
}
