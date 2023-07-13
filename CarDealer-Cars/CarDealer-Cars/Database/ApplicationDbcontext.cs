using CarDealer_Car.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CarDealer_Car.Database
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
                    eb.ToView(nameof(PaymentDetails));
                });
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentDetails> PaymentsDetails { get; set; }
    }
}

