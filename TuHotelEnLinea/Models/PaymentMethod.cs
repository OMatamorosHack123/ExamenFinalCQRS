using System.ComponentModel.DataAnnotations;

namespace TuHotelEnLinea.Models
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }

        [Required]
        [StringLength(100)]
        public string PaymentMethodName { get; set;}

        public IEnumerable<Sale> Sales { get; set; }
    }
}
