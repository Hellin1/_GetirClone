using GetirClone.Domain.Entities;

namespace GetirClone.Application.Interfaces
{
    public interface IOrderRepository
    {

        Task<List<Order>> GetOrdersWithNavProps(Guid customerId, int year, CancellationToken cancellationToken);
    }
}
