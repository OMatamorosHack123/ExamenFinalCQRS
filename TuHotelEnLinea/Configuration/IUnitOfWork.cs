using TuHotelEnLinea.Services;

namespace TuHotelEnLinea.Configuration
{
    public interface IUnitOfWork
    {
        IExtraRepository ExtraRepository { get; }
        ICategoryRoomRepository CategoryRoomRepository { get; }
        IBookingRepository BookingRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        ICustomerXRoomRepository CustomerXRoomRepository { get; }
        IPackageExtraRepository PackageExtraRepository { get; }
        IPackageRepository PackageRepository { get; }
        IPaymentMethodRepository PaymentMethodRepository { get; }
        IRoomRepository RoomRepository { get; }

        ISalesRepository SalesRepository { get; }
        void Commit();
        void Dispose();
    }
}
