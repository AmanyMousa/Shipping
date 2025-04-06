namespace Shipping.Data.Entities
{
    public class PermissionRole
    {
        public int PermissionId { get; set; } // Foreign key from Permission
        public int RoleId { get; set; } // Foreign key from Role
        public virtual Permission? Permission { get; set; }
        public virtual Role? Role { get; set; }
    }
}
