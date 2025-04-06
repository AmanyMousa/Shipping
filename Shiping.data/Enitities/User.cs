using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Data.Entities
{
    
    public class User :IdentityUser
    {
        [Key]
        //public int Id { get; set; }
        public string Name { get; set; }
      
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
      
      
        
        // Navigation properties
        public virtual ICollection<Delivery>? Deliveries { get; set; }

        public virtual ICollection<UserBranch>? UserBranches { get; set; }

        public virtual ICollection<Marchant>? Marchants { get; set; }

       
    }
}
