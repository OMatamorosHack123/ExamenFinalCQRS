
using TuHotelEnLinea.Configuration;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.CommandHandler
{

    public class UpdateCommandHandler : ICommandHandler<Customer>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
        public CommandResult Execute(Customer customer)
        {
            _unitOfWork.CustomerRepository.Update(customer);
            _unitOfWork.Commit();
            return new CommandResult { Status = true, Message = "Product actualizado succesfully" };
        }
    }
}
