using System.ComponentModel.DataAnnotations;

namespace TuHotelEnLinea.Models
{
    public class CustomerXRoom
    {
        public int CustomerXRoomId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string CustomerCreatedAt { get; set; }
    }
}
