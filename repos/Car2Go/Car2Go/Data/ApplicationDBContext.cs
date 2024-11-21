using Car2Go.Models;
using ModelBindingDemo.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;



namespace Car2Go.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() { }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasMaxLength(15);

            modelBuilder.Entity<Car>()
                .Property(c => c.PricePerDay)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Review>()
                .Property(r => r.Rating)
                .HasMaxLength(5);

            modelBuilder.Entity<Reservation>()
                .Property(res => res.Amount)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Payment>()
               .Property(p => p.PaymentAmount)
               .HasColumnType("decimal(10,2)");

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var configSection = configBuilder.GetSection("ConnectionStrings");
            var conn = configSection["DBConnStr"];

            optionsBuilder.UseSqlServer(conn);

            base.OnConfiguring(optionsBuilder);
        }

        DbSet<User> Users { get; set; }
        DbSet<Car> Cars { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Reservation> Reservations { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Payment> Payment { get; set; }
    }
}
