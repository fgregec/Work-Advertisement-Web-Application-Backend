using Core.Dto;
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
        public async Task<IEnumerable<Mestar>> GetMestarByName(string mestarName)
        {
            PaginationFilter filter = new PaginationFilter();

            return await _context.Mestri.Where(x =>
                   x.FirstName.ToLower().Contains(mestarName) ||
                   x.LastName.ToLower().Contains(mestarName))
                   .Skip((filter.PageIndex - 1) * filter.PageSize)
                   .Take(filter.PageSize)
                   .ToListAsync();
        }

        public async Task<IEnumerable<Mestar>> GetMestarListByFilters(SearchMestarDto search)
        {
            var mestri = await _context.Mestri.Where(mestar =>
                         mestar.Categories.Any(category =>
                         search.Categories.Contains(category))).ToListAsync();

            if (search.City != null)
            {
                return mestri.Where(mestar => mestar.City.Name == search.City.Name);
            }

            return mestri;
        }
    }
}
