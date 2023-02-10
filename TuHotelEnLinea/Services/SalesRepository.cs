using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Services
{
    public class SalesRepository : GenericRepository<Sale>, ISalesRepository
    {
        private readonly TuHotelEnLineaContext _context;
        public SalesRepository(TuHotelEnLineaContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Sale>> GetAllAsync()
        {
            var tuHotelEnLineaContext = _context.Sale.Include(s => s.Booking).Include(s => s.PaymentMethod);
            return await tuHotelEnLineaContext.ToListAsync();
        }

        public override async Task<Sale> GetByIdAsync(int id)
        {
            return await _dbSet.Include(s => s.Booking).Include(s => s.PaymentMethod).FirstOrDefaultAsync(m => m.SaleId == id);
        }
    }
}
