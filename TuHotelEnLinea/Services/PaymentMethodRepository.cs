using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Services
{
    public class PaymentMethodRepository : GenericRepository<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(TuHotelEnLineaContext context) : base(context)
        {
        }
        public override async Task<PaymentMethod>GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.PaymentMethodId == id);
        }
    }
}
