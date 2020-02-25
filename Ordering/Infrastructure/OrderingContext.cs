using System;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain;

namespace Ordering.Infrastructure
{
    public class OrderingContext : DbContext
    {
        internal const string DEFAULT_SCHEMA = "orders";
        public DbSet<Order> Orders { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public OrderingContext(DbContextOptions<OrderingContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new JobEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new JobStatusEntityTypeConfiguration());
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JobStatus>().HasData(
                JobStatus.Assigned,
                JobStatus.Completed,
                JobStatus.Draft,
                JobStatus.Unassigned
            );

            //modelBuilder.Entity<Order>().HasData(
            //    new Order
            //    {
            //        CustomerName = "Bob The Builder",
            //        OrderNumber = $"Order_{Guid.NewGuid()}",
            //        Id = 1
            //    }
            //);
        }
    }
}
