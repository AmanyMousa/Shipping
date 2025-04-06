using System.ComponentModel.DataAnnotations;

namespace Shipping.Data.Entities
{
    public class Branch
    {
        [Key]
        public int Bid { get; set; } // Primary key
        public string Status { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
        public string Location { get; set; }
        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<UserBranch>? UserBranches { get; set; }
    }
}
