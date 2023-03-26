using Core.Entities;

namespace Core.Interfaces
{
    public interface IMestarService
    {
        Task<IReadOnlyList<Natjecaj>> ListResolvedNatjecaja(Guid mestarID);
    }
}
