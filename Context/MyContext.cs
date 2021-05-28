using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<University> Universities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Account)
                .WithOne(a => a.Person)
                .HasForeignKey<Account>(a => a.NIK);
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Profiling)
                .WithOne(r => r.Account)
                .HasForeignKey<Profiling>(r => r.NIK);
            modelBuilder.Entity<Education>()
                .HasMany(e => e.Profiling)
                .WithOne(r => r.Education);
            modelBuilder.Entity<Education>()
                .HasOne(e => e.University)
                .WithMany(u => u.Education);
            
        }


    }
}
