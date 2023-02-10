using System.ComponentModel.DataAnnotations;

namespace TuHotelEnLinea.Models
{
    public class Extra
    {
        public int ExtraId { get; set; }
        [Required]
        [StringLength(50)]
        public string ExtraName { get; set; }
        [Required]
        [StringLength(400)]
        public string ExtraDescription { get; set; }

        public IEnumerable<PackageExtra> PackageExtras { get; set; }

    }
}
