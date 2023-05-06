using Core.Entities;
using Core.Models;

namespace Core.interfaces
{
    public interface IMestarRepository
    {
        Task<IEnumerable<Mestar>> Search(MestarFilter search);
        Task<MestarProfitModel> GetMestarProfit(MestarProfitModel profitModel);
        Task AddMestarProfit(MestarProfit mestarProfit);
    }
}
