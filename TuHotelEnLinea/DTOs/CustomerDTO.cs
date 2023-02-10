namespace TuHotelEnLinea.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }

        //[Required]
        //[StringLength(50)]
        public string CustomerName { get; set; }

        //[Required]
        //[StringLength(50)]
        public string CustomerLastName { get; set; }

        //[Required]
        //[StringLength(50)]
        public string CustomerIdCard { get; set; }

        //[Required]
        //[StringLength(45)]
        public string CustomerPhone { get; set; }

    }
}
