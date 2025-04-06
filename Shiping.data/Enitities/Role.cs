using System.ComponentModel.DataAnnotations;

namespace Shipping.Data.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PermissionRole>? PermissionRoles { get; set; }

    }
}
