using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Services
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private readonly TuHotelEnLineaContext _context;
        public BookingRepository(TuHotelEnLineaContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Booking>> GetAllAsync()
        {
            var tuHotelEnLineaContext = _context.Booking.Include(b => b.Customer).Include(b => b.Package);
            return await tuHotelEnLineaContext.ToListAsync();
        }

        public override async Task<Booking> GetByIdAsync(int id)
        {
            return await _dbSet.Include(b => b.Customer).Include(b => b.Package).FirstOrDefaultAsync(m => m.BookingId == id);
        }
    }
}
