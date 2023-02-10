using System.ComponentModel.DataAnnotations;

namespace TuHotelEnLinea.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerLastName { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerIdCard { get; set; }

        [Required]
        [StringLength(45)]
        public string CustomerPhone { get; set;}

        public IEnumerable<Booking> Bookings { get; set; }
        public IEnumerable<CustomerXRoom> CustomerXRooms { get; set; }
    }
}
