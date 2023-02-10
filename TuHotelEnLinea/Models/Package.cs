using System.ComponentModel.DataAnnotations;

namespace TuHotelEnLinea.Models
{
    public class Package
    {
        public int PackageId { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        [Required]
        [StringLength(50)]
        public string PackageName { get; set; }

        [Required]
        public double PackagePrice { get; set; }

        [Required]
        public int PackageQdays { get; set; }

        public IEnumerable<Booking> Bookings { get; set; }
        public IEnumerable<PackageExtra> PackageExtras { get; set; }
    }
}
