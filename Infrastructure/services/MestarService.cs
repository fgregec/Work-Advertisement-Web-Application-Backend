using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class MestarService : IMestarService
    {
        private readonly ApplicationContext _context;

        public MestarService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Natjecaj>> ListResolvedNatjecaja(Guid mestarID)
        {
            return await _context.Natjecaji
                     .Include(n => n.Mestar)
                     .Include(n => n.City)
                     .Include(n => n.Category)
                     .Include(n => n.User)
                     .ToListAsync();
        }
    }
}
