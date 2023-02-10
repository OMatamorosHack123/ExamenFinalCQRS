using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Services
{
    public class ExtraRepository : GenericRepository<Extra>, IExtraRepository
    {

        public ExtraRepository(TuHotelEnLineaContext context) : base(context)
        {
        }

        public override async Task<Extra> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.ExtraId == id);
        }
    }
}
