using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain;

namespace Ordering.Infrastructure
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders", OrderingContext.DEFAULT_SCHEMA);
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.OrderNumber).IsUnique();
            builder.Property(p => p.CustomerName).HasMaxLength(255).IsRequired(false);

            var jobsNavigation = builder.Metadata.FindNavigation(nameof(Order.Jobs));
            jobsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(c => c.Jobs)
                .WithOne()
                .HasForeignKey("OrderId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
