using Core.Dto;
using Core.Entities;

namespace Core.interfaces
{
    public interface IMestarRepository
    {
        Task<IEnumerable<Mestar>> Search(SearchMestarDto search);
    }
}
