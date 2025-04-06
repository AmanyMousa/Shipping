using System.ComponentModel.DataAnnotations;

namespace Shipping.Data.Entities
{
    public class Government
    {
        [Key]
        public int Id { get; set; } // Primary key
        public string Name { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<City>? Cities { get; set; }
    }
}
