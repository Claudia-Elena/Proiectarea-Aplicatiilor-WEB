using Microsoft.EntityFrameworkCore;
using JueriShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace JueriShop.Models.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DbSet<Category> categories { get; set; }
        public DbSet<Jewelry> jewels { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }

        public DbSet<OrderStatus> orderStatuses { get; set; }

        public DbSet<User> users { get; set; }

        public DbSet<UserOrder> userOrders{get;set;}




    }
}
