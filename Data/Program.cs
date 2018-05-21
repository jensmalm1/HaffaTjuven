using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CrimeContext : DbContext
    {
        public DbSet<User> Customer { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = EfCrime; Trusted_Connection = True; ");
        }


    }
}
