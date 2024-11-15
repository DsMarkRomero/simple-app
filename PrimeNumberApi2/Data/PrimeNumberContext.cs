using Microsoft.EntityFrameworkCore;
using PrimeNumberApi2.Models;
using System.Collections.Generic;

namespace PrimeNumberApi2.Data
{
    public class PrimeNumberContext : DbContext
    {
        public PrimeNumberContext(DbContextOptions<PrimeNumberContext> options) : base(options) { }

        public DbSet<PrimeCheck> PrimeChecks { get; set; }
    }
}
