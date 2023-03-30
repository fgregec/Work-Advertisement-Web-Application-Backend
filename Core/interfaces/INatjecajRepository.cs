using Core.Entities;

namespace Core.Interfaces
{
    public interface INatjecajRepository
    {
        Task<IEnumerable<Natjecaj>> GetListResolvedNatjecaja(Guid id);
    }
}
