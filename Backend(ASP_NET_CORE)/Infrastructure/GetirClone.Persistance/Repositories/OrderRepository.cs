using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using GetirClone.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace GetirClone.Persistance.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GetirCloneContext _context;

        public OrderRepository(GetirCloneContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersWithNavProps(Guid customerId, int year, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.Where(o => o.Date.Year == DateTime.UtcNow.Year && o.CustomerId == customerId).
                Include(o => o.Payment).
                Include(o => o.Shipment).
                Include(o => o.OrderItems).
                ThenInclude(oi => oi.Product).
                ToListAsync(cancellationToken);


            return orders;
        }
    }
}
