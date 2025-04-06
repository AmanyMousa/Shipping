namespace Shipping.Data.Entities
{
    public class UserBranch
    {
        public int UserId { get; set; } // Foreign key from User
        public int BranchId { get; set; } // Foreign key from Branch
        public virtual User? User { get; set; }
        public virtual Branch? Branch { get; set; }
    }
}
