using TuHotelEnLinea.Configuration;
using TuHotelEnLinea.DTOs;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.CommandHandler
{
    public class AddCustomerCommandHandler: ICommandHandler<CustomerDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        public CommandResult Execute(CustomerDTO customer) 
        {
            var newCustomer = new Customer()
            {
                CustomerId = customer.CustomerId,
                CustomerName= customer.CustomerName,
                CustomerLastName = customer.CustomerLastName,
                CustomerIdCard = customer.CustomerIdCard,
                CustomerPhone= customer.CustomerPhone,
                
            };
            _unitOfWork.CustomerRepository.Add(newCustomer);
            _unitOfWork.Commit();
            return new CommandResult { Status = true, Message = "Permission added succesfully" };
        } 
    }
}
