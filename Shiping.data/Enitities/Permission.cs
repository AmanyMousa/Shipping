using System.ComponentModel.DataAnnotations;

namespace Shipping.Data.Entities
{
    public class Permission
    {
        [Key]
        public int Id { get; set; } // Primary key
        public bool View { get; set; }
        public bool Add { get; set; }
        public bool Delete { get; set; }
        public bool Edit { get; set; }
        public virtual ICollection<PermissionRole>? PermissionRoles { get; set; }
    }
}
