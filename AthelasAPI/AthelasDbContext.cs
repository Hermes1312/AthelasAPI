using AthelasAPI.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthelasAPI
{
    public class AthelasDbContext : DbContext
    {
        public AthelasDbContext(DbContextOptions<AthelasDbContext> options) : base(options) { }

        public DbSet<Appointment>   Appointments    { get; set; }
        public DbSet<Client>        Clients         { get; set; }
        public DbSet<Employee>      Employees       { get; set; }
        public DbSet<Service>       Services        { get; set; }
        public DbSet<User>          Users           { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().Property(a => a.ClientId).IsRequired();
            modelBuilder.Entity<Appointment>().Property(a => a.EmployeeId).IsRequired();
            modelBuilder.Entity<Appointment>().Property(a => a.ServiceId).IsRequired();

            modelBuilder.Entity<Client>().Property(c => c.FirstName).IsRequired();
            modelBuilder.Entity<Client>().Property(c => c.LastName).IsRequired();
            modelBuilder.Entity<Client>().Property(c => c.PhoneNumber).IsRequired().HasMaxLength(11);

            modelBuilder.Entity<Employee>().Property(e => e.FirstName).IsRequired();
            modelBuilder.Entity<Employee>().Property(e => e.LastName).IsRequired();
            
            modelBuilder.Entity<User>().Property(e => e.Username).IsRequired();
        }
    }
}
