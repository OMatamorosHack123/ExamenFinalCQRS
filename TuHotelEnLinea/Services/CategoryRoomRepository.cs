using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Services
{
    public class CategoryRoomRepository : GenericRepository<CategoryRoom>, ICategoryRoomRepository
    {
        public CategoryRoomRepository(TuHotelEnLineaContext context) : base(context)
        {
        }
        public override async Task<CategoryRoom> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.CategoryRoomId == id);
        }
    }
}
