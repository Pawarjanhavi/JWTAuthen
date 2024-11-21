using Microsoft.EntityFrameworkCore;

namespace ModelBindingDemo.Models
{
    public class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext() { }

        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>()
                .Property(x => x.FirstName)
                .HasColumnType("data")
                .HasColumnName("FIrstName");

            modelBuilder.Entity<Student>()
                .HasKey(x => x.StudentId);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-KSF152Q\\SQLEXPRESS;Database=EFCoreDemo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

            //base.OnConfiguring(optionsBuilder);


            //use json file for bdconnection
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var configSection = configBuilder.GetSection("ConnectionStrings");
            var conStr = configSection["ConStr"] ?? null;

            optionsBuilder.UseSqlServer(conStr);


        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Branch> Branches { get; set; }
    }
}
