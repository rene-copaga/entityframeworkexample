﻿using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

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

        [Test]
        public void CountPersons()
        {
            int personCount = _context.Persons.Count();
            Assert.AreEqual(2, personCount);
        }

        [Test]
        public void CountPersonsWithFilter()
        {
            int personCount = _context.Persons.Count(x => x.FirstName == "John" &&
            x.LastName == "Smith");
            Assert.AreEqual(1, personCount);
        }
    }
}