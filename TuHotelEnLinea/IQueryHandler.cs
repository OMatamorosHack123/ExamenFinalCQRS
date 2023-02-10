using TuHotelEnLinea.Models;

namespace TuHotelEnLinea
{
    public interface IQueryHandler<M, C> where M: class where C: class
    {
        Task<IEnumerable<M>> GetAll();
        Task<Customer> GetOne(C query);     
    }
}
