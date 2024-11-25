using Microsoft.EntityFrameworkCore;
using FrontEndDemo.Models;

namespace FrontEndDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("name=ConnectionStrings:DefaultConnection;TrustServerCertificate=true;");
        //    }
        //}


        //public DbSet<User> Users { get; set; } = null!;
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }

    }
}
