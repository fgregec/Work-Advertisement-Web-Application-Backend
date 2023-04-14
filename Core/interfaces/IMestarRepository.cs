using Core.Entities;
using Core.Models;

namespace Core.interfaces
{
    public interface IMestarRepository
    {
        Task<Pagination<Mestar>> Search(MestarFilter search);
    }
}
