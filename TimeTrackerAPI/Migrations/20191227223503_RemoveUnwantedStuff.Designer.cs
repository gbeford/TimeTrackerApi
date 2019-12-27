﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Migrations
{
    [DbContext(typeof(TimeTrackerDbContext))]
    [Migration("20191227223503_RemoveUnwantedStuff")]
    partial class RemoveUnwantedStuff
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("StudentMessage", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("MessageId");

                    b.HasKey("StudentId", "MessageId");

                    b.HasIndex("MessageId");

                    b.ToTable("StudentMessage");
                });

            modelBuilder.Entity("TimeTrackerAPI.Models.AppUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("LastLogin");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("UserId");

                    b.ToTable("User","Security");
                });

            modelBuilder.Entity("TimeTrackerAPI.Models.AppUserClaim", b =>
                {
                    b.Property<Guid>("ClaimId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType")
                        .IsRequired();

                    b.Property<string>("ClaimValue")
                        .IsRequired();

                    b.Property<Guid>("UserId");

                    b.HasKey("ClaimId");

                    b.ToTable("UserClaim","Security");
                });

            modelBuilder.Entity("TimeTrackerAPI.Models.Apparel", b =>
                {
                    b.Property<int>("ApparelId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApparelImageId");

                    b.Property<bool>("CanHaveName");

                    b.Property<string>("ContentType");

                    b.Property<string>("Description");

                    b.Property<string>("Filename");

                    b.Property<string>("Gender");

                    b.Property<string>("Image");

                    b.Property<string>("Item");

                    b.Property<decimal?>("NameCharge");

                    b.Property<float>("Price");

                    b.Property<int?>("Quantity");

                    b.Property<bool>("ShowGenderSize");

                    b.Property<bool>("ShowItem");

                    b.Property<string>("Size");

                    b.Property<string>("Type");

                    b.Property<decimal?>("UpCharge");

                    b.HasKey("ApparelId");

                    b.ToTable("Apparels");
                });

            modelBuilder.Entity("TimeTrackerAPI.Models.ApparelImage", b =>
                {
                    b.Property<int>("ApparelImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentType");

                    b.Property<string>("FileName");

                    b.Property<byte[]>("Image");

                    b.Property<string>("ImageName");

                    b.HasKey("ApparelImageId");

                    b.ToTable("ApparelImages");
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

                    b.HasKey("MessageID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TimeTrackerAPI.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("GrossTotal");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("StudentId");

                    b.Property<string>("StudentName");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TimeTrackerAPI.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApparelId");

                    b.Property<string>("Gender");

                    b.Property<decimal?>("NameCharge");

                    b.Property<bool?>("NameOnSleeve");

                    b.Property<int?>("OrderId");

                    b.Property<float>("Price");

                    b.Property<int?>("Quantity");

                    b.Property<string>("Size");

                    b.Property<string>("SleeveName");

                    b.Property<decimal?>("UpCharge");

                    b.HasKey("Id");

                    b.HasIndex("ApparelId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("TimeTrackerAPI.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Created");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("Grade");

                    b.Property<string>("LastName");

                    b.Property<int?>("SignInEventId");

                    b.Property<DateTime?>("SignInTime");

                    b.Property<int>("StudentId");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TimeTrackerAPI.Models.StudentTime", b =>
                {
                    b.Property<int>("StudentTimeID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CheckIn");

                    b.Property<DateTime>("CheckOut");

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<int>("EventId");

                    b.Property<int>("StudentId");

                    b.Property<decimal>("TotalHrs")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("StudentTimeID");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentTimes");
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

            modelBuilder.Entity("TimeTrackerAPI.Models.OrderItem", b =>
                {
                    b.HasOne("TimeTrackerAPI.Models.Apparel", "Apparel")
                        .WithMany()
                        .HasForeignKey("ApparelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TimeTrackerAPI.Models.Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId");
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
