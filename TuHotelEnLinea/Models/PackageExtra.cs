namespace TuHotelEnLinea.Models
{
    public class PackageExtra
    {
        public int PackageExtraId { get; set; } 
        public int PackageId { get; set; }
        public Package Package { get; set; }

        public int ExtraId { get; set; }
        public Extra Extra { get; set; }
    }
}
