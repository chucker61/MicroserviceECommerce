using Microsoft.EntityFrameworkCore;

namespace MicroserviceECommerce.Cargo.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


    }
}
