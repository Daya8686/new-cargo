﻿// <auto-generated />
using System;
using CargoManagerSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CargoManagerSystem.Migrations
{
    [DbContext(typeof(MyCargoDBContext))]
    [Migration("20230603144033_Fourth")]
    partial class Fourth
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CargoManagerSystem.Models.CargoCategory", b =>
                {
                    b.Property<int>("CargoCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoCategoryId"));

                    b.Property<string>("CargoCategoryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CargoCategoryId");

                    b.ToTable("CargoCategories");
                });

            modelBuilder.Entity("CargoManagerSystem.Models.CargoOrder", b =>
                {
                    b.Property<int>("CargoorderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoorderId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("CargoorderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CargoOrders");
                });

            modelBuilder.Entity("CargoManagerSystem.Modules.CargoOrderDetails", b =>
                {
                    b.Property<int>("CargoorderDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoorderDetailsId"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CargoorderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CargoorderId")
                        .HasColumnType("int");

                    b.Property<string>("FromCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("ToCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CargoorderDetailsId");

                    b.HasIndex("CargoorderId")
                        .IsUnique();

                    b.ToTable("CargoOderDetails");
                });

            modelBuilder.Entity("CargoManagerSystem.Modules.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<int?>("CargoorderDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("CargoorderDetailsId");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("CargoManagerSystem.Modules.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<int>("CargooderId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerZip")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.HasIndex("CityId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CargoManagerSystem.Modules.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfResign")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeFName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeLName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("CityId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CargoManagerSystem.Modules.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateId"));

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("CargoManagerSystem.Models.CargoOrder", b =>
                {
                    b.HasOne("CargoManagerSystem.Modules.Customer", "Customer")
                        .WithMany("CargoOrders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CargoManagerSystem.Modules.CargoOrderDetails", b =>
                {
                    b.HasOne("CargoManagerSystem.Models.CargoOrder", "CargoOrder")
                        .WithOne("CargoOrderDetails")
                        .HasForeignKey("CargoManagerSystem.Modules.CargoOrderDetails", "CargoorderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CargoOrder");
                });

            modelBuilder.Entity("CargoManagerSystem.Modules.City", b =>
                {
                    b.HasOne("CargoManagerSystem.Modules.CargoOrderDetails", null)
                        .WithMany("Cities")
                        .HasForeignKey("CargoorderDetailsId");

                    b.HasOne("CargoManagerSystem.Modules.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("CargoManagerSystem.Modules.Customer", b =>
                {
                    b.HasOne("CargoManagerSystem.Modules.City", "City")
                        .WithMany("Customers")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CargoManagerSystem.Modules.Employee", b =>
                {
                    b.HasOne("CargoManagerSystem.Modules.City", "City")
                        .WithMany("Employees")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CargoManagerSystem.Models.CargoOrder", b =>
                {
                    b.Navigation("CargoOrderDetails")
                        .IsRequired();
                });

            modelBuilder.Entity("CargoManagerSystem.Modules.CargoOrderDetails", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("CargoManagerSystem.Modules.City", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("CargoManagerSystem.Modules.Customer", b =>
                {
                    b.Navigation("CargoOrders");
                });

            modelBuilder.Entity("CargoManagerSystem.Modules.State", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
