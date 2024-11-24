using Microsoft.EntityFrameworkCore;
using WebApi_EFCore.Models;

namespace WebApi_EFCore.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(){ }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() {EmployeeId=1 ,FirstName = "zahabiya", LastName = "kapadia", Email = "zahabiya@gmail.com", Phone = "9182734561", DateOfBirth = new DateOnly(2001, 05, 12) },
                new Employee() {EmployeeId=2, FirstName = "tanya", LastName = "patel", Email = "tanya@gmail.com", Phone = "8192736545", DateOfBirth = new DateOnly(2002, 07, 10) }

                );

            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
