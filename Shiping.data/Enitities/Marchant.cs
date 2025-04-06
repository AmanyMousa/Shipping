using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Data.Entities
{
    public class Marchant
    {
     
        [ ForeignKey("user"),Key]
        public string  UserId { get; set; } //foreign key from User
        public string Address { get; set; }
        public decimal Cost_Rejection { get; set; }
        public decimal bickup { get; set; }

        public virtual User? User { get; set; }
    }
}
