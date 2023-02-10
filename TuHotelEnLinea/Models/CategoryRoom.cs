using System.ComponentModel.DataAnnotations;

namespace TuHotelEnLinea.Models
{
    public class CategoryRoom
    {
        public int CategoryRoomId { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryRoomName { get; set; }

        [Required]
        [StringLength(300)]
        public string CategoryRoomDescription { get; set; }


        public IEnumerable<Room> Rooms { get; set; }
    }
}
