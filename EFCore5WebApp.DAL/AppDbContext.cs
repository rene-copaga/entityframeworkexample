using EFCore5WebApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFCore5WebApp.DAL
{
    public class AppDbContext: DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<LookUp> LookUps { get; set; }

        public AppDbContext() : base()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LookUp>().HasData(new List<LookUp>()
            {
            new LookUp() { Code = "AL", Description = "Alabama", LookUpType =
            LookUpType.State}
            });
        }
    }
}
