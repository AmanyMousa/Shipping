using System.ComponentModel.DataAnnotations;

namespace Shipping.Data.Entities
{
    public class ShippingType
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Type { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        // Navigation property
        public virtual User? User { get; set; }
    }
}

