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

        [Test]
        public void MinPersonAge()
        {
            var minPersonAge = _context.Persons.Min(x => x.Age);
            Assert.AreEqual(20, minPersonAge);
        }

        [Test]
        public void MaxPersonAge()
        {
            var maxPersonAge = _context.Persons.Max(x => x.Age);
            Assert.Greater(maxPersonAge, 20);
        }

        [Test]
        public void AveragePersonAge()
        {
            var average = _context.Persons.Average(x => x.Age);
            Assert.AreEqual(25, average);
        }

        [Test]
        public void SumPersonAge()
        {
            var sumAge = _context.Persons.Sum(x => x.Age);
            Assert.AreEqual(50, sumAge);
        }

        [Test]
        public void GroupAddressesByState()
        {
            var expectedILAddressesCount = _context.Addresses.Where(x => x.State == "IL").Count();
            var expectedCAAddressesCount = _context.Addresses.Where(x => x.State == "CA").Count();
            var groupedAddresses = (from a in _context.Addresses.ToList()
                                    group a by a.State into g
                                    select new
                                    {
                                        State = g.Key,
                                        Addresses =
                                    g.Select(x => x)
                                    }).ToList();
            Assert.AreEqual(expectedILAddressesCount, groupedAddresses.Single(x =>
            x.State == "IL").Addresses.Count());
            Assert.AreEqual(expectedCAAddressesCount, groupedAddresses.Single(x =>
            x.State == "CA").Addresses.Count());
        }

        [Test]
        public void GroupAddressesByStateCount()
        {
            var expectedILAddressesCount = _context.Addresses.Where(x => x.State == "IL").Count();
            var expectedCAAddressesCount = _context.Addresses.Where(x => x.State == "CA").Count();
            var groupedAddresses = (from a in _context.Addresses
                                    group a by a.State into g
                                    select new
                                    {
                                        State = g.Key,
                                        Count = g.Count()
                                    }).ToList();
            Assert.AreEqual(expectedILAddressesCount, groupedAddresses.Single(x =>
            x.State == "IL").Count);
            Assert.AreEqual(expectedCAAddressesCount, groupedAddresses.Single(x =>
            x.State == "CA").Count);
        }
    }
}
