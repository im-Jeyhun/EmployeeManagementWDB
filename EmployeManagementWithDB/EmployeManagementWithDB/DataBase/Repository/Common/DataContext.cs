using Microsoft.EntityFrameworkCore;
using EmployeManagementWithDB.Employee.Models;

namespace EmployeManagementWithDB.DataBase.Repository.Common
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-43LALNQ;Database=Employee;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Employees> Employees { get; set; }
    }

}

