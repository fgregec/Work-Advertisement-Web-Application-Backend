using Core.Entities;

namespace Core.Interfaces
{
    public interface IMestarRepository
    {
        Task<IReadOnlyList<Natjecaj>> ListResolvedNatjecaja(Guid mestarID);
    }
}
