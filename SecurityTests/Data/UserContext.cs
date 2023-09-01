using Microsoft.EntityFrameworkCore;
using SecurityTests.Models;
using System.Collections.Generic;

namespace SecurityTests.Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=SecurityTests;Integrated Security=True");
        }
    }
}