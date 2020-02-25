using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain;

namespace Ordering.Infrastructure
{
    public class JobEntityTypeConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("jobs", OrderingContext.DEFAULT_SCHEMA);
            builder.HasIndex(x => x.JobNumber).IsUnique();
            builder.Property(p => p.JobNumber).HasMaxLength(100);
            builder.Property(p => p.OrderId).IsRequired();
            builder.Property<int>("_jobStatusId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("JobStatusId")
                .IsRequired();
            builder.HasOne(o => o.JobStatus)
                .WithMany()
                .HasForeignKey("_jobStatusId");
        }
    }
}
