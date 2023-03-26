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
        public async Task<IReadOnlyList<Natjecaj>> ListResolvedNatjecaja(Guid mestarID)
        {
            return await _applicationContext.Natjecaji.AsNoTracking().Where(x => x.MestarID == mestarID).ToListAsync();
        }

    }
}
