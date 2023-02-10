using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Services
{
    public class CustomerXRoomRepository : GenericRepository<CustomerXRoom>, ICustomerXRoomRepository
    {
        private readonly TuHotelEnLineaContext _context;
        public CustomerXRoomRepository(TuHotelEnLineaContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<CustomerXRoom>> GetAllAsync()
        {
            var tuHotelEnLineaContext = _context.CustomerXRoom.Include(c => c.Customer).Include(c => c.Room);
            return await tuHotelEnLineaContext.ToListAsync();
        }

        public override async Task<CustomerXRoom> GetByIdAsync(int id)
        {
            return await  _dbSet.Include(c => c.Customer).Include(c => c.Room).FirstOrDefaultAsync(m => m.CustomerXRoomId == id);
        }
    }
}
