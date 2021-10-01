using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactsApi.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Contact>().HasData(
                  new Contact() { Id = new Guid("31b9ba25-d213-44b5-a0ea-1dc7d9ca6300"), Email = "nalvarez23@live.com.ar", FirstName = "Nahuel", LastName = "Alvarez", Company = "DevWorking", PhoneNumber = "+543794637353" },
                  new Contact() { Id = Guid.NewGuid(), Email = "test@gmail.com", FirstName = "Test", LastName = "Test", Company = "Development", PhoneNumber = "+1111121111111" },
                  new Contact() { Id = Guid.NewGuid(), Email = "anothertest@gmail.com", FirstName = "Test2", LastName = "Test2", Company = "Development2", PhoneNumber = "+12211111111111" }
                  );
        }

    }
}
