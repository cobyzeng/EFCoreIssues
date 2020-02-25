using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain;

namespace Ordering.Infrastructure
{
    public class JobStatusEntityTypeConfiguration : IEntityTypeConfiguration<JobStatus>
    {
        public void Configure(EntityTypeBuilder<JobStatus> builder)
        {
            builder.ToTable("jobstatus", OrderingContext.DEFAULT_SCHEMA);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.DisplayName).HasMaxLength(100).IsRequired();

            builder.Property(o => o.Id)
                .ValueGeneratedNever()
                .IsRequired();
        }
    }
}
