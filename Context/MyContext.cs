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
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountRole> accountRoles { get; set; }

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
            modelBuilder.Entity<Profiling>()
                .HasOne(r => r.Education)
                .WithMany(e => e.Profiling);
            modelBuilder.Entity<Education>()
                .HasOne(e => e.University)
                .WithMany(u => u.Education);
            modelBuilder.Entity<AccountRole>()
                .HasKey(ar => new { ar.NIK, ar.Roleid });
            modelBuilder.Entity<Role>()
                .HasMany(r => r.AccountRole)
                .WithOne(ar => ar.Role)
                .HasForeignKey(r => r.Roleid);
            modelBuilder.Entity<AccountRole>()
                .HasOne(ar => ar.Account)
                .WithMany(a => a.AccountRole)
                .HasForeignKey(a => a.NIK);          
        }
    }
}
