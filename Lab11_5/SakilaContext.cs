using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Lab11_5
{
    class SakilaContext : DbContext
    {
        public DbSet<Film> Film { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;database=sakila;Trusted_Connection=True;");
        }
    }
}
