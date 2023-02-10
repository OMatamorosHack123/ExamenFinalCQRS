using TuHotelEnLinea.Data;
using TuHotelEnLinea.Services;

namespace TuHotelEnLinea.Configuration
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly TuHotelEnLineaContext _context;
        public IExtraRepository ExtraRepository { get; private set;}

        public ICategoryRoomRepository CategoryRoomRepository { get; private set; }

        public IBookingRepository BookingRepository { get; private set; }

        public ICustomerRepository CustomerRepository { get; private set; }

        public ICustomerXRoomRepository CustomerXRoomRepository { get; private set; }

        public IPackageExtraRepository PackageExtraRepository { get; private set; }

        public IPackageRepository PackageRepository { get; private set; }

        public IPaymentMethodRepository PaymentMethodRepository { get; private set; }

        public IRoomRepository RoomRepository { get; private set; }

        public ISalesRepository SalesRepository { get; private set; }

        public UnitOfWork(TuHotelEnLineaContext context)
        {
            _context = context;
            ExtraRepository = new ExtraRepository(_context);
            CategoryRoomRepository = new CategoryRoomRepository(_context); 
            BookingRepository = new BookingRepository(_context);
            CustomerRepository = new CustomerRepository(_context);
            CustomerXRoomRepository = new CustomerXRoomRepository(_context);
            PackageExtraRepository= new PackageExtraRepository(_context);
            PackageRepository= new PackageRepository(_context);
            PaymentMethodRepository= new PaymentMethodRepository(_context);
            RoomRepository= new RoomRepository(_context);
            SalesRepository = new SalesRepository(_context);

        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
