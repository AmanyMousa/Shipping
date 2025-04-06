using System.ComponentModel.DataAnnotations;

namespace Shipping.Data.Entities
{
    public class ShippingType
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        //enum
        public string Type { get; set; }
        public decimal Cost { get; set; }

        public int numberofday  { get; set; }
       

        // Navigation property
        public virtual ICollection< Order>?  Order { get; set; }
    }
}

