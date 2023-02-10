using System.ComponentModel.DataAnnotations;

namespace TuHotelEnLinea.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        public int CategoryRoomId {get; set;}
        public CategoryRoom CategoryRoom { get; set; }

        [Required]
        public int RoomNum { get; set; }

        [Required]
        public int RoomFloor { get; set; }

        [Required]
        public int RoomQuota { get; set; }

        public IEnumerable<Package> Packages { get; set; }
        public IEnumerable<CustomerXRoom> CustomerXRooms { get; set; }
    }
}
