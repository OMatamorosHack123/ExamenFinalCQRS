namespace TuHotelEnLinea.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public double SaleTotal { get; set;}

        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
