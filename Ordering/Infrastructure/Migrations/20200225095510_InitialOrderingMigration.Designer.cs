﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ordering.Infrastructure;

namespace Ordering.Infrastructure.Migrations
{
    [DbContext(typeof(OrderingContext))]
    [Migration("20200225095510_InitialOrderingMigration")]
    partial class InitialOrderingMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ordering.Domain.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("JobNumber")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("_jobStatusId")
                        .HasColumnName("JobStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobNumber")
                        .IsUnique()
                        .HasFilter("[JobNumber] IS NOT NULL");

                    b.HasIndex("OrderId");

                    b.HasIndex("_jobStatusId");

                    b.ToTable("jobs","orders");
                });

            modelBuilder.Entity("Ordering.Domain.JobStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("jobstatus","orders");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            DisplayName = "Assigned",
                            Name = "assigned"
                        },
                        new
                        {
                            Id = 3,
                            DisplayName = "Completed",
                            Name = "completed"
                        },
                        new
                        {
                            Id = 4,
                            DisplayName = "Draft",
                            Name = "draft"
                        },
                        new
                        {
                            Id = 1,
                            DisplayName = "Unassigned",
                            Name = "unassigned"
                        });
                });

            modelBuilder.Entity("Ordering.Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OrderNumber")
                        .IsUnique()
                        .HasFilter("[OrderNumber] IS NOT NULL");

                    b.ToTable("orders","orders");
                });

            modelBuilder.Entity("Ordering.Domain.Job", b =>
                {
                    b.HasOne("Ordering.Domain.Order", null)
                        .WithMany("Jobs")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ordering.Domain.JobStatus", "JobStatus")
                        .WithMany()
                        .HasForeignKey("_jobStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
