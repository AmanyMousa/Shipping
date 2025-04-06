using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Data.Entities
{
    public class Delivery
    {
        [Key,ForeignKey("user")]
        public string UserId { get; set; } // Primary key and foreign key from User
        public string SaleType { get; set; }
        public decimal SalePresent { get; set; }
        [ForeignKey ("User")]
        public string EmpId { get; set; } // Foreign key from User

        // Navigation properties
        public virtual User? User { get; set; }
        public virtual User? Employee { get; set; }
    }
}
