using Core.Entities;
using Core.Models;

namespace Core.interfaces
{
    public interface IAnalyticsRepository
    {
        Task<MestarProfitModel> GetMestarProfit(MestarProfitModel profitModel);
    }
}
