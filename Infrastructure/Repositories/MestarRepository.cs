using Core.Entities;
using Core.Interfaces;
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

        public void Add(Mestar mestar)
        {
            _context.Mestri.Add(mestar);
            _context.SaveChanges();
        }

        public void Delete(Mestar mestar)
        {
            _context.Mestri.Remove(mestar);
            _context.SaveChanges();
        }

        public void Update(Mestar mestar)
        {
            _context.Mestri.Update(mestar);
            _context.SaveChanges();
        }

        public async Task<Mestar> GetByIdAsync(Guid id)
        {
            return await _context.Mestri.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Mestar>> ListAllAsync()
        {
            return await _context.Mestri.AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<Natjecaj>> ListResolvedNatjecaja(Guid mestarID)
        {
            return await _context.Natjecaji.AsNoTracking().Where(x => x.MestarID == mestarID).ToListAsync();
        }

        public Task<IReadOnlyList<Mestar>> ListAsyncWithSpec()
        {
            throw new NotImplementedException();
        }

        public Task<Mestar> GetEntityWithSpec()
        {
            throw new NotImplementedException();
        }
    }
}
