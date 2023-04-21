using Core.Entities;
using Core.Interfaces;
using Core.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        public async Task<IEnumerable<Natjecaj>> GetFilteredNatjecajs(NatjecajFilter filter)
        {
            var query = _context.Natjecaji
                .Include(n => n.User)
                .Include(n => n.City).ThenInclude(c => c.County)
                .Include(n => n.Category)
                .Where(n => n.MestarID == Guid.Empty && n.Price == 0);

            if (!string.IsNullOrEmpty(filter.Category))
            {
                query = query.Where(n => n.Category.Name == filter.Category);
            }

            if (!string.IsNullOrEmpty(filter.County))
            {
                query = query.Where(n => n.City.County.Name == filter.County);
            }

            if (!string.IsNullOrEmpty(filter.City))
            {
                query = query.Where(n => n.City.Name == filter.City);
            }
            if (filter.Emergency)
            {
                query = query.Where(n => n.IsEmergency);
            }

            return await query.ToListAsync();
        }
    }
}
