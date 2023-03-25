using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MestarRepository : IMestarRepository
    {
        private readonly ApplicationContext _applicationContext;

        public MestarRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;            
        }

        public void Add(Mestar mestar)
        {
            _applicationContext.Mestri.Add(mestar);
            _applicationContext.SaveChanges();
        }

        public void Delete(Mestar mestar)
        {
            _applicationContext.Mestri.Remove(mestar);
            _applicationContext.SaveChanges();
        }

        public void Update(Mestar mestar)
        {
            _applicationContext.Mestri.Update(mestar);
            _applicationContext.SaveChanges();
        }

        public async Task<Mestar> GetByIdAsync(Guid id)
        {
            return await _applicationContext.Mestri.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<Mestar>> ListAllAsync()
        {
            return await _applicationContext.Mestri.AsNoTracking().ToListAsync().ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<Natjecaj>> ListResolvedNatjecaja(Guid mestarID)
        {
            return await _applicationContext.Natjecaji.AsNoTracking().Where(x => x.MestarID == mestarID).ToListAsync().ConfigureAwait(false);
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
