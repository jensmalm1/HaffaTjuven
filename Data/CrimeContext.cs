using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CrimeContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public CrimeContext(DbContextOptions<CrimeContext> context) : base(context)
        {
        }

    }
}
