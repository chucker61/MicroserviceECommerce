using MicroserviceECommerce.Cargo.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceECommerce.Cargo.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        DbSet<CargoCompany> CargoCompanies { get; set; }
        DbSet<CargoCustomer> CargoCustomers { get; set; }
        DbSet<CargoDetail> CargoDetails { get; set; }
        DbSet<CargoOperation> CargoOperations { get; set; }

    }
}
