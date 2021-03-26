﻿// <auto-generated />
using System;
using Dozen2DL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Dozen2DL.Migrations
{
    [DbContext(typeof(DrinkDBContext))]
    [Migration("20210317041149_addInventory2")]
    partial class addInventory2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Dozen2Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Age")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Dozen2Models.Drink", b =>
                {
                    b.Property<int>("DrinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ABV")
                        .HasColumnType("integer");

                    b.Property<string>("DrinkName")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("DrinkId");

                    b.ToTable("Drinks");

                    b.HasData(
                        new
                        {
                            DrinkId = 1,
                            ABV = 6,
                            DrinkName = "Lager",
                            Price = 5.00m
                        },
                        new
                        {
                            DrinkId = 2,
                            ABV = 9,
                            DrinkName = "Ale",
                            Price = 8.00m
                        },
                        new
                        {
                            DrinkId = 3,
                            ABV = 12,
                            DrinkName = "Stout",
                            Price = 10.00m
                        });
                });

            modelBuilder.Entity("Dozen2Models.DrinkOrder", b =>
                {
                    b.Property<int>("DrinkOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("DrinkId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("DrinkOrderId");

                    b.HasIndex("DrinkId");

                    b.HasIndex("OrderId");

                    b.ToTable("DrinkOrders");
                });

            modelBuilder.Entity("Dozen2Models.Inventory", b =>
                {
                    b.Property<int>("InventoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("DrinkID")
                        .HasColumnType("integer");

                    b.Property<int>("LocationID")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("InventoryID");

                    b.HasIndex("DrinkID");

                    b.HasIndex("LocationID");

                    b.ToTable("Inventories");

                    b.HasData(
                        new
                        {
                            InventoryID = 1,
                            DrinkID = 1,
                            LocationID = 1,
                            Quantity = 50
                        },
                        new
                        {
                            InventoryID = 2,
                            DrinkID = 1,
                            LocationID = 2,
                            Quantity = 50
                        },
                        new
                        {
                            InventoryID = 3,
                            DrinkID = 1,
                            LocationID = 3,
                            Quantity = 50
                        },
                        new
                        {
                            InventoryID = 4,
                            DrinkID = 2,
                            LocationID = 1,
                            Quantity = 50
                        },
                        new
                        {
                            InventoryID = 5,
                            DrinkID = 2,
                            LocationID = 2,
                            Quantity = 50
                        },
                        new
                        {
                            InventoryID = 6,
                            DrinkID = 2,
                            LocationID = 3,
                            Quantity = 50
                        },
                        new
                        {
                            InventoryID = 7,
                            DrinkID = 3,
                            LocationID = 1,
                            Quantity = 50
                        },
                        new
                        {
                            InventoryID = 8,
                            DrinkID = 3,
                            LocationID = 2,
                            Quantity = 50
                        },
                        new
                        {
                            InventoryID = 9,
                            DrinkID = 3,
                            LocationID = 3,
                            Quantity = 50
                        });
                });

            modelBuilder.Entity("Dozen2Models.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("LocationName")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.HasKey("LocationID");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            LocationID = 1,
                            LocationName = "Location1",
                            State = "NY"
                        },
                        new
                        {
                            LocationID = 2,
                            LocationName = "Location2",
                            State = "FL"
                        },
                        new
                        {
                            LocationID = 3,
                            LocationName = "Location3",
                            State = "VA"
                        });
                });

            modelBuilder.Entity("Dozen2Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustomerID")
                        .HasColumnType("integer");

                    b.Property<int>("LocationID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OrderDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("LocationID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Dozen2Models.DrinkOrder", b =>
                {
                    b.HasOne("Dozen2Models.Drink", "Drink")
                        .WithMany()
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dozen2Models.Order", "Order")
                        .WithMany("DrinkOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drink");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Dozen2Models.Inventory", b =>
                {
                    b.HasOne("Dozen2Models.Drink", "Drink")
                        .WithMany()
                        .HasForeignKey("DrinkID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dozen2Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drink");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Dozen2Models.Order", b =>
                {
                    b.HasOne("Dozen2Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dozen2Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Dozen2Models.Order", b =>
                {
                    b.Navigation("DrinkOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
