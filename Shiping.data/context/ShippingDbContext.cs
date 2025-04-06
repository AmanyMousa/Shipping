using Microsoft.EntityFrameworkCore;
using Shipping.Data.Entities;

namespace Shipping.Data
{
    public class ShippingDbContext : DbContext
    {
        public ShippingDbContext(DbContextOptions<ShippingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Government> Governments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<WeightPrice> WeightPrices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShippingType> ShippingTypes { get; set; }
        public DbSet<ProdOrder> ProdOrders { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Marchant> Marchants { get; set; }
        public DbSet<UserBranch> UserBranches { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionRole> PermissionRoles { get; set; }
        public DbSet<RejectionOrder> RejectionOrders { get; set; }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // Configure composite keys
            modelBuilder.Entity<ProdOrder>()
                .HasKey(po => new { po.ProductId, po.OrderId });

            modelBuilder.Entity<UserBranch>()
                .HasKey(ub => new { ub.UserId, ub.BranchId });

            modelBuilder.Entity<PermissionRole>()
                .HasKey(pr => new { pr.PermissionId, pr.RoleId });
            // Configure relationships
            modelBuilder.Entity<Order>()
        .HasOne(o => o.Branch)
        .WithMany()
        .HasForeignKey(o => o.BranchId)
        .OnDelete(DeleteBehavior.Restrict); // Changed to Restrict

            modelBuilder.Entity<Order>()
                .HasOne(o => o.City)
                .WithMany()
                .HasForeignKey(o => o.CityId)
                .OnDelete(DeleteBehavior.Restrict); // Changed to Restrict

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Gov)
                .WithMany()
                .HasForeignKey(o => o.GovId)
                .OnDelete(DeleteBehavior.Restrict); // Changed to Restrict

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.User)
                .WithMany(u => u.Deliveries)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.Employee)
                .WithMany()
                .HasForeignKey(d => d.EmpId);

            modelBuilder.Entity<Marchant>()
                .HasOne(m => m.User)
                .WithOne()
                .HasForeignKey<Marchant>(m => m.UserId);

            modelBuilder.Entity<RejectionOrder>()
                .HasOne(ro => ro.Order)
                .WithMany(o => o.RejectionOrders)
                .HasForeignKey(ro => ro.OrderId);

            base.OnModelCreating(modelBuilder);

        }




    }
}
