using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class NatjecajRepository : INatjecajRepository
    {
        private readonly ApplicationContext _context;
        public NatjecajRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Natjecaj>> GetListResolvedNatjecaja(Guid userID)
        {
            return await _context.Natjecaji.AsNoTracking().Where(x => x.UserID == userID).ToListAsync();
        }

        public async Task<IEnumerable<Natjecaj>> GetNatjecajs()
        {
            return await _context.Natjecaji
                .Include(n => n.User)
                .Include(n => n.City).ThenInclude(c => c.County)
                .Include(n => n.Category)
                .Where(n => n.MestarID == Guid.Empty && n.Price == 0).ToListAsync();
        }

        public async Task<IEnumerable<Natjecaj>> GetFilteredNatjecajs(string? category, string? county, string? city)
        {
            var query = _context.Natjecaji
                .Include(n => n.User)
                .Include(n => n.City).ThenInclude(c => c.County)
                .Include(n => n.Category)
                .Where(n => n.MestarID == Guid.Empty && n.Price == 0);

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(n => n.Category.Name == category);
            }

            if (!string.IsNullOrEmpty(county))
            {
                query = query.Where(n => n.City.County.Name == county);
            }

            if (!string.IsNullOrEmpty(city))
            {
                query = query.Where(n => n.City.Name == city);
            }
            return await query.ToListAsync();
        }
    }
}
