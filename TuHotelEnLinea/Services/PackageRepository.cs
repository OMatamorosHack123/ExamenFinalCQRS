using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Services
{
    public class PackageRepository : GenericRepository<Package>, IPackageRepository
    {
        private readonly TuHotelEnLineaContext _context;
        public PackageRepository(TuHotelEnLineaContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Package>> GetAllAsync()
        {
            var tuHotelEnLineaContext = _context.Package.Include(p => p.Room);
            return await tuHotelEnLineaContext.ToListAsync();
        }
        public override async Task<Package>GetByIdAsync(int id)
        {
            return await _dbSet.Include(p => p.Room).FirstOrDefaultAsync(m => m.PackageId == id);
        }
    }
}
