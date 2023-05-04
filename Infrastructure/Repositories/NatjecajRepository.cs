using Core.Entities;
using Core.Interfaces;
using Core.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
            IQueryable<Natjecaj> query = _context.Natjecaji
                .Include(n => n.User)
                .Include(n => n.City).ThenInclude(c => c.County)
                .Include(n => n.Category);

            if (filter.Category != null)
            {
                query = query.Where(n => filter.Category.Contains(n.CategoryID));
            }

            if (filter.County != null)
            {
                query = query.Where(n => filter.County.Contains(n.City.CountyID));
            }

            if (filter.City != null)
            {
                query = query.Where(n => filter.City.Contains(n.City.Id));
            }

            if (filter.Emergency)
            {
                query = query.Where(n => n.IsEmergency);
            }

            return await query.ToListAsync();
        }
    }
}
