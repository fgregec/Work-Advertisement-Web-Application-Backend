using Core.interfaces;
using Core.Models;
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

        public async Task<MestarProfitModel> GetMestarProfit(MestarProfitModel profitModel)
        {
            var mestarProfitList = _context.MestarProfit
                                           .Where(mp => mp.MestarID == profitModel.MestarID
                                                  && mp.TimeOfProfit >= profitModel.From
                                                  && mp.TimeOfProfit <= profitModel.Until)
                                           .ToList();

            profitModel.Profit = mestarProfitList.Sum(mp => mp.Profit);

            return profitModel;
        }
    }
}
