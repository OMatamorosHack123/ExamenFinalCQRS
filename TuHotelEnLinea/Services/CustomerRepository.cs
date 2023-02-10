using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Services
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(TuHotelEnLineaContext context) : base(context)
        {
        }

        public override async Task<Customer> GetByIdAsync(int id)
        {
           return await _dbSet.FirstOrDefaultAsync(m => m.CustomerId == id);
        }
    }
}
