using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace EFCore5WebApp.DAL.Tests
{
    [TestFixture]
    public class StoredProceduresTests
    {
        private AppDbContext _context;
        [SetUp]
        public void SetUp()
        {
            _context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfCore5WebApp; Trusted_Connection = True; MultipleActiveResultSets = true")
            .Options);
        }

        [Test]
        public void GetPersonsByStateInterpolated()
        {
            string state = "IL";
            var persons = _context.Persons.FromSqlInterpolated($"GetPersonsByState{state}").ToList();
            Assert.AreEqual(2, persons.Count);
        }

        [Test]
        public void GetPersonsByStateRaw()
        {
            string state = "IL";
            var persons = _context.Persons.FromSqlRaw($"GetPersonsByState @p0", new[] { state }).ToList();
            Assert.AreEqual(2, persons.Count);
        }
    }
}
