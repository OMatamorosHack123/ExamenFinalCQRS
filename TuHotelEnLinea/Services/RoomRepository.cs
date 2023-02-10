using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Services
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        private readonly TuHotelEnLineaContext _context;
        public RoomRepository(TuHotelEnLineaContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Room>> GetAllAsync()
        {
            var tuHotelEnLineaContext = _context.Room.Include(r => r.CategoryRoom);
            return await tuHotelEnLineaContext.ToListAsync();
        }
        public override async Task<Room> GetByIdAsync(int id)
        {
            return await _dbSet.Include(r => r.CategoryRoom).FirstOrDefaultAsync(m => m.RoomId == id);
        }
    }
}
