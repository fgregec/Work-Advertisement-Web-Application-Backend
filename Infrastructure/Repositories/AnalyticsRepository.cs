using Core.Entities;
using Core.interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AnalyticsRepository : IAnalyticsRepository
    {
        private readonly ApplicationContext _context;        

        public AnalyticsRepository(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }

        public async Task<List<Natjecaj>> GetMestarProfit(Guid mestarID, DateTime? from, DateTime? until)
        {
            var natjecajList = _context.Natjecaji.Where(m => m.MestarID == mestarID);

            if (from != null)
            {
                natjecajList = natjecajList.Where(mp => mp.Finished >= from);
            }
            if (until != null)
            {
                natjecajList = natjecajList.Where(mp => mp.Finished <= until);
            }

            return await natjecajList.ToListAsync();
        }
    }
}
