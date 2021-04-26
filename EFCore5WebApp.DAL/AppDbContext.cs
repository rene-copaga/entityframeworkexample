using Microsoft.EntityFrameworkCore;

namespace EFCore5WebApp.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext() : base()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
