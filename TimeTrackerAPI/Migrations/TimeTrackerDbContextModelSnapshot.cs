﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Migrations
{
    [DbContext(typeof(TimeTrackerDbContext))]
    partial class TimeTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("StudentMessage", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("MessageId");

                    b.HasKey("StudentId", "MessageId");

                    b.HasIndex("MessageId");

                    b.ToTable("StudentMessage");
                });

            modelBuilder.Entity("TimeTrackerAPI.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("Show");

                    b.Property<int>("SortOrder");

                    b.HasKey("EventID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("TimeTrackerAPI.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MessageText")
                        .IsRequired();

                    b.Property<bool>("Show");

                    b.Property<int>("SortOrder");

                    b.HasKey("MessageID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TimeTrackerAPI.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Created");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("Grade");

                    b.Property<string>("LastName");

                    b.Property<int>("SchoolId");

                    b.Property<DateTime?>("SignInTime");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TimeTrackerAPI.Models.StudentTime", b =>
                {
                    b.Property<int>("StudentTimeID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CheckIn");

                    b.Property<DateTime>("CheckOut");

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<int>("StudentId");

                    b.Property<decimal>("TotalHrs")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("StudentTimeID");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentTimes");
                });

            modelBuilder.Entity("TimeTrackerAPI.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisplayName");

                    b.Property<string>("Email");

                    b.Property<DateTime>("LastLogin");

                    b.Property<string>("Name");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StudentMessage", b =>
                {
                    b.HasOne("TimeTrackerAPI.Models.Message", "Message")
                        .WithMany("StudentMessages")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TimeTrackerAPI.Models.Student", "Student")
                        .WithMany("StudentMessages")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TimeTrackerAPI.Models.StudentTime", b =>
                {
                    b.HasOne("TimeTrackerAPI.Models.Student")
                        .WithMany("StudentTimes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
