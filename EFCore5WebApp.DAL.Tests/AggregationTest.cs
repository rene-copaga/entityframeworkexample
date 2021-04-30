using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EFCore5WebApp.DAL.Tests
{
    [TestFixture]
    public class AggregationTests
    {
        private AppDbContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfCore5WebApp; Trusted_Connection = True; MultipleActiveResultSets = true")
                  .Options);
        }
    }
}
