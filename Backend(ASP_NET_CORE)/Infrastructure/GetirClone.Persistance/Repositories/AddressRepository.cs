using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using GetirClone.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace GetirClone.Persistance.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly GetirCloneContext _context;

        public AddressRepository(GetirCloneContext context)
        {
            _context = context;
        }

        public async Task<List<Address>> GetAddresses(Guid customerId, CancellationToken cancellationToken)
        {
            var addresses = await _context.Addresses.Where(a => a.CustomerId == customerId).
                OrderByDescending(a => a.IsPrimary).
                ThenByDescending(a => a.LastPrimaryDate).
                Take(100).
                ToListAsync(cancellationToken);

            return addresses;
        }
    }
}
