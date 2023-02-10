using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Services
{
    public class PackageExtraRepository : GenericRepository<PackageExtra>, IPackageExtraRepository
    {
        private readonly TuHotelEnLineaContext _context;
        public PackageExtraRepository(TuHotelEnLineaContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<PackageExtra>> GetAllAsync()
        {
            var tuHotelEnLineaContext = _context.PackageExtra.Include(p => p.Extra).Include(p => p.Package);
            return await tuHotelEnLineaContext.ToListAsync();
        }
        public override async Task<PackageExtra> GetByIdAsync(int id)
        {
            return await _dbSet.Include(p => p.Extra).Include(p => p.Package).FirstOrDefaultAsync(m => m.PackageExtraId == id);
        }

    }
}
