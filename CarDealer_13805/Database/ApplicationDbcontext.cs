using CarDealer_13805.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealer_13805.Database
{
   
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PaymentDetails>(eb =>
                {
                    eb.HasNoKey();
                    eb.ToView("View_PaymentDetails");
                });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentDetails> PaymentsDetails { get; set; }
    }
}

