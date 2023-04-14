using Core.Entities;
using Core.interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Infrastructure.Repositories
{
    public class MestarRepository : IMestarRepository
    {
        private readonly ApplicationContext _context;
        public MestarRepository(ApplicationContext context)
        {
            _context = context;
        }        

        public async Task<Pagination<Mestar>> Search(MestarFilter search)
        {
            var mestri = await _context.Mestri.ToListAsync();

            if (search.CategoryID.HasValue)
                mestri.Where(m => m.Categories.Any(m => m.Id == search.CategoryID));

            if (search.CityID.HasValue)
                mestri.Where(m => m.CityID == search.CityID);            

            if (!string.IsNullOrWhiteSpace(search.Name))
                mestri.Where(m => m.FirstName.ToLower().Contains(search.Name.ToLower()) ||
                                  m.LastName.ToLower().Contains(search.Name.ToLower()));

            var paginatedData = new Pagination<Mestar>
            {
                PageIndex = search.CurrentPage,
                PageSize = search.PageSize,
                Data = mestri.Skip((search.CurrentPage - 1) * search.PageSize)
                             .Take(search.PageSize)
                             .ToList()
            };

            return paginatedData;
        }
    }
}
