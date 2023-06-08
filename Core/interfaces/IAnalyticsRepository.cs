using Core.Entities;

namespace Core.interfaces
{
    public interface IAnalyticsRepository
    {
        Task<List<Natjecaj>> GetMestarProfit(Guid mestarID, DateTime? dateFrom, DateTime? dateUntil);
    }
}
