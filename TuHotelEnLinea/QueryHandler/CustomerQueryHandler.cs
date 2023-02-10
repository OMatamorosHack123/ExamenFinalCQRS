using TuHotelEnLinea.Commands;
using TuHotelEnLinea.Configuration;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.QueryHandler
{
    public class CustomerQueryHandler: IQueryHandler<Customer, QueryByIdCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _unitOfWork.CustomerRepository.GetAllAsync();
        }

        public async Task<Customer> GetOne(QueryByIdCommand query)
        {
            return await _unitOfWork.CustomerRepository.GetByIdAsync(query.Id);
        }
    }
}
