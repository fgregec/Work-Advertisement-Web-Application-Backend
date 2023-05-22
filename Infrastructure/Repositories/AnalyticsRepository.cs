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

        public async Task<List<Natjecaj>> GetMestarProfit(Guid mestarID, DateTime? dateFrom, DateTime? dateUntil)
        {
            var natjecajList = _context.Natjecaji.Where(m => m.MestarID == mestarID);

            if (dateFrom != null)
            {
                natjecajList = natjecajList.Where(mp => mp.Finished >= dateFrom);
            }
            if (dateUntil != null)
            {
                natjecajList = natjecajList.Where(mp => mp.Finished <= dateUntil);
            }

            return await natjecajList.ToListAsync();
        }
    }
}
