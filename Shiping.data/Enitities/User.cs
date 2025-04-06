using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Data.Entities
{
    public enum UserType
    {
        Admin,
        Employee,
        Merchant,
        Delivery,
    }
    public class User :IdentityUser
    {
        [Key]
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
      
        public int ? RoleId { get; set; }
        public UserType Type { get; set; }

        // Navigation properties
        public virtual ICollection<Delivery>? Deliveries { get; set; }

        public virtual ICollection<UserBranch>? UserBranches { get; set; }

        public virtual ICollection<Marchant>? Marchants { get; set; }

        public virtual Role ? Role { get; set; }
    }
}
