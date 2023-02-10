using System.ComponentModel.DataAnnotations;

namespace TuHotelEnLinea.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int PackageId { get; set; }
        public Package Package { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string BookingDate { get; set; }

        public IEnumerable<Sale> Sales { get; set; }
    }
}
