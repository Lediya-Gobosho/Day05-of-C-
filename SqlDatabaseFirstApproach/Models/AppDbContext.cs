using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDatabaseFirstApproach.Models
{
    internal class AppDbContext:DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Volleyball;Integrated Security = True; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
            new Person { Id = 1, FirstName = "John", LastName = "Doe" },
            new Person { Id = 2, FirstName = "Jane", LastName = "Doe" }
            );
        }
    }
}

