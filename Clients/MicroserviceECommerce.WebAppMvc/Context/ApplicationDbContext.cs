using Microsoft.EntityFrameworkCore;

namespace MicroserviceECommerce.WebAppMvc.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
