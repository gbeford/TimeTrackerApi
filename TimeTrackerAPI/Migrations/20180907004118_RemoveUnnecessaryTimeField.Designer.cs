﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Migrations
{
    [DbContext(typeof(TimeTrackerDbContext))]
    [Migration("20180907004118_RemoveUnnecessaryTimeField")]
    partial class RemoveUnnecessaryTimeField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TimeTrackerAPI.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("Show");

                    b.Property<int>("SortOrder");

                    b.HasKey("EventID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("TimeTrackerAPI.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MessageText");

                    b.Property<bool>("Show");

                    b.Property<int>("SortOrder");

                    b.HasKey("MessageID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TimeTrackerAPI.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("Grade");

                    b.Property<string>("LastName");

                    b.Property<DateTime?>("SignInTime");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TimeTrackerAPI.Models.StudentTime", b =>
                {
                    b.Property<int>("StudentTimeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CheckIn");

                    b.Property<DateTime>("CheckOut");

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<int>("StudentId");

                    b.Property<decimal>("TotalHrs")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("StudentTimeID");

                    b.ToTable("StudentTimes");
                });

            modelBuilder.Entity("TimeTrackerAPI.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayName");

                    b.Property<string>("Email");

                    b.Property<DateTime>("LastLogin");

                    b.Property<string>("Name");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
