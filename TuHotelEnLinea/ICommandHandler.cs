namespace TuHotelEnLinea
{
    public interface ICommandHandler<T> where T: class
    {
        CommandResult Execute(T command);
    }
}
