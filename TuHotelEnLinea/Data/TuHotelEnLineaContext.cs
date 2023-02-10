using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Data
{
    public class TuHotelEnLineaContext : DbContext
    {
        public TuHotelEnLineaContext(DbContextOptions<TuHotelEnLineaContext> options)
            : base(options)
        {
        }



        public DbSet<TuHotelEnLinea.Models.PaymentMethod> PaymentMethod { get; set; } = default!;

        public DbSet<TuHotelEnLinea.Models.Customer> Customer { get; set; }

        public DbSet<TuHotelEnLinea.Models.Extra> Extra { get; set; }

        public DbSet<TuHotelEnLinea.Models.CategoryRoom> CategoryRoom { get; set; }

        public DbSet<TuHotelEnLinea.Models.Room> Room { get; set; }

        public DbSet<TuHotelEnLinea.Models.Package> Package { get; set; }

        public DbSet<TuHotelEnLinea.Models.Booking> Booking { get; set; }

        public DbSet<TuHotelEnLinea.Models.Sale> Sale { get; set; }

        public DbSet<TuHotelEnLinea.Models.CustomerXRoom> CustomerXRoom { get; set; }

        public DbSet<TuHotelEnLinea.Models.PackageExtra> PackageExtra { get; set; }
    }
}
