using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Data.Entities
{
    public class City
    {
        [Key]
        public int Cid { get; set; } // Primary key
        public decimal Price { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey ("Gov")]
        public int GovId { get; set; }
        public virtual ICollection<User>? Users { get; set; }
        public virtual Government? Gov { get; set; }
    }
}
