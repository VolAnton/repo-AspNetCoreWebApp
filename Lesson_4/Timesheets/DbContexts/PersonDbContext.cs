using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Models;

namespace Timesheets.DbContexts
{
    public sealed class PersonDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; } = null!;


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=vma-postgres;Port=5432;Database=vma;Username=postgres;Password=sudo");
        //}

        public PersonDbContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureCreated();  // первое создание базы данных
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Ignore(x => x.Comment);
        }

    }
}
