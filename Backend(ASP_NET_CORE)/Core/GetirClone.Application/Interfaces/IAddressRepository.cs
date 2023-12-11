using GetirClone.Domain.Entities;

namespace GetirClone.Application.Interfaces
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAddresses(Guid customerId, CancellationToken cancellationToken);
    }
}
