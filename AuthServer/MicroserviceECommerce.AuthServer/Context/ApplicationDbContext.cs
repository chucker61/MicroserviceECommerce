using Microsoft.EntityFrameworkCore;

namespace MicroserviceECommerce.AuthServer.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
