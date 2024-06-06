using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class OMAContext : DbContext
    {


        // db set for each entity
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }

        // initial context
        public OMAContext(DbContextOptions<OMAContext> options) : base(options)
        {
        }

        // override on model creating to use dummy data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    ContactNumber = "4055552413",
                    Email = "jondoe@something.com",
                    IsDeleted = false,
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    ContactNumber = "4055552463",
                    Email = "janedoe@something.com",
                    IsDeleted = false,
                }
            );
            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    CustomerId = 1,
                    AddressLine1 = "1234 Elm St",
                    City = "Oklahoma City",
                    State = "OK",
                    Country = "USA"
                },
                new Address
                {
                    Id = 2,
                    CustomerId = 2,
                    AddressLine1 = "5678 Oak St",
                    City = "Oklahoma City",
                    State = "OK",
                    Country = "USA"
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    CustomerId = 1,
                    Orderdate = new DateTime(2024, 6, 1),
                    Description = "Order 1",
                    TotalAmount = 100,
                    DepositAmount = 10,
                    IsDelivery = true,
                    Status = Status.Pending,
                    OtherNotes = "This is a note",
                    IsDeleted = false,
                },
                new Order
                {
                    Id = 2,
                    CustomerId = 2,
                    Orderdate = new DateTime(2024, 6, 1),
                    Description = "Order 2",
                    TotalAmount = 200,
                    DepositAmount = 10,
                    IsDelivery = false,
                    Status = Status.Draft,
                    OtherNotes = "This is a note for order 2",
                    IsDeleted = false,
                }
            );
        }
    }
}