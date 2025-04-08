using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Data.Entities
{
    public class Delivery
    {

        [ForeignKey("user"), Key]
        public string UserId { get; set; } // foreign key from User
        //enum (fixed ,presentage )
        public string SaleType { get; set; }
        public decimal SalePresentage { get; set; }
        [ForeignKey ("User")]
        public string EmpId { get; set; } // Foreign key from User

        // Navigation properties
        public virtual User? User { get; set; }
        public virtual User? Employee { get; set; }
    }
}
