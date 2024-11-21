using Microsoft.EntityFrameworkCore;
using WebApiEFCore.Models;

namespace WebApiEFCore.Data
{
    public class EmpDBContext : DbContext
    {
        public EmpDBContext() { }

        public EmpDBContext(DbContextOptions<EmpDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee {EmployeeId = 1, FirstName = "Janhavi", LastName = "Pawar", Email = "JP@gmail.com", Phone = "9021798504", DateOfBirth = new DateOnly(2003, 03, 26) },
                new Employee { EmployeeId = 2, FirstName = "Purva", LastName = "Pawar", Email = "PurvaP@gmail.com", Phone = "9089889076", DateOfBirth = new DateOnly(2003, 05, 29) }
                );
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
