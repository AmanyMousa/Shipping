namespace Shipping.Data.Entities
{
    public class UserPermission
    {
        public int PermissionId { get; set; } // Foreign key from Permission
        public string userId { get; set; } // Foreign key from Role
        public virtual Permission? Permission { get; set; }
        public virtual User? user { get; set; }
    }
}
