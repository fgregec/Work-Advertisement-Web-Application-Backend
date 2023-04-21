using Core.Entities;

namespace Core.Interfaces
{
    public interface INatjecajRepository
    {
        Task<IEnumerable<Natjecaj>> GetListResolvedNatjecaja(Guid id);
        Task<IEnumerable<Natjecaj>> GetNatjecajs();
        Task<IEnumerable<Natjecaj>> GetFilteredNatjecajs(string? category, string? county, string? city);

    }
}
