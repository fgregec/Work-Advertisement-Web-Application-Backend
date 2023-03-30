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
    }
}
