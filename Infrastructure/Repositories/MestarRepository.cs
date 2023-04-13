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

        public async Task<IEnumerable<Mestar>> Search(SearchMestarDto search)
        {
            var mestri = await _context.Mestri.ToListAsync();

            if (search.CategoryID.HasValue)
                mestri.Where(m => m.Categories.Any(m => m.Id == search.CategoryID));

            if (search.CityID.HasValue)
                mestri.Where(m => m.CityID == search.CityID);            

            if (!string.IsNullOrWhiteSpace(search.MestarName))
                mestri.Where(m => m.FirstName.ToLower().Contains(search.MestarName.ToLower()) ||
                                  m.LastName.ToLower().Contains(search.MestarName.ToLower()));

            return mestri;
        }
    }
}
