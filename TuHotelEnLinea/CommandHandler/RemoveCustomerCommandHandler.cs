using TuHotelEnLinea.Commands;
using TuHotelEnLinea.Configuration;

namespace TuHotelEnLinea.CommandHandler
{
    public class RemoveCustomerCommandHandler : ICommandHandler<RemoveByIdCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CommandResult Execute(RemoveByIdCommand command)
        {
            _unitOfWork.CustomerRepository.Delete(command.Id);
            _unitOfWork.Commit();
            return new CommandResult { Status = true, Message = "Permission added succesfully" };
        }

    }
}
