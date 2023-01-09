using ApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
            .HasMany(b => b.products)
            .WithOne()
            .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<User>()
            .HasMany(b => b.Notes)
            .WithOne()
            .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Buyer>()
            .HasMany(b => b.Invoices)
            .WithOne();

            modelBuilder.Entity<Order>()
            .HasMany(b => b.Products)
            .WithOne()
            .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Buyer>()
            .HasMany(b => b.Orders)
            .WithOne();
        }
    }
}
