using Dozen2Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2DL
{
    // By inheriting the dbcontext class im establishing an is-a relationship between
    // drinkdb context and the dbcontext. which implies that the drinkdbcontext is a dbcontext
    public class DrinkDBContext : DbContext
    {
        public DrinkDBContext(DbContextOptions options) : base(options)
        {
            //building the connection by feeding it the connection string
        }

        protected DrinkDBContext()
        {
        }

        //these are the models/entities I want to be persisted to my database
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet <DrinkOrder> DrinkOrders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>()
                .HasData
                (
                    new Drink
                    {
                        DrinkId = 1,
                        DrinkName = "Lager",
                        ABV = 6,
                        Price = 5.00m
                    },

                            new Drink
                            {
                                DrinkId = 2,
                                DrinkName = "Ale",
                                ABV = 9,
                                Price = 8.00m
                            },

                                    new Drink
                                    {
                                        DrinkId = 3,
                                        DrinkName = "Stout",
                                        ABV = 12,
                                        Price = 10.00m
                                    }
                );

            modelBuilder.Entity<Location>()
             .HasData
             (
                 new Location
                 {
                     LocationID = 1,
                    LocationName = "Location1",
                    State = "NY"
                 },

                         new Location
                         {
                             LocationID = 2,
                             LocationName = "Location2",
                             State = "FL"
                         },

                                 new Location
                                 {
                                     LocationID = 3,
                                     LocationName = "Location3",
                                     State = "VA"
                                 }
             );

            modelBuilder.Entity<Inventory>()
                .HasData
                (
                new Inventory 
                { 
                    InventoryID=1,
                    DrinkID = 1,
                    LocationID = 1,
                    Quantity = 50
                },
                 new Inventory
                 {
                     InventoryID = 2,
                     DrinkID = 1,
                     LocationID = 2,
                     Quantity = 50
                 },
                  new Inventory
                  {
                      InventoryID = 3,
                      DrinkID = 1,
                      LocationID = 3,
                      Quantity = 50
                  },
                   new Inventory
                   {
                       InventoryID = 4,
                       DrinkID = 2,
                       LocationID = 1,
                       Quantity = 50
                   },
                    new Inventory
                    {
                        InventoryID = 5,
                        DrinkID = 2,
                        LocationID = 2,
                        Quantity = 50
                    },
                     new Inventory
                     {
                         InventoryID = 6,
                         DrinkID = 2,
                         LocationID = 3,
                         Quantity = 50
                     },

                      new Inventory
                      {
                          InventoryID = 7,
                          DrinkID = 3,
                          LocationID = 1,
                          Quantity = 50
                      },
                       new Inventory
                       {
                           InventoryID = 8,
                           DrinkID = 3,
                           LocationID = 2,
                           Quantity = 50
                       },
                        new Inventory
                        {
                            InventoryID = 9,
                            DrinkID = 3,
                            LocationID = 3,
                            Quantity = 50
                        }

                );

            base.OnModelCreating(modelBuilder);




      

        }







    }
}

/*
 //onmodelcreating() - what youd use to manually define to your entity framework core; how you want your database to be built out 
            //in the recording, if a superhero gets deleted, its superpower automatically gets deleted with it
            //my hero has one superpower and i want to establish that the superpower refers to the hero, and not the other way around.
      //modelBuilder.Entity<Drink>()
            //    .Property(drink => drink.DrinkId)
            //    .ValueGeneratedOnAdd();
            //modelBuilder.Entity<Drink>()
            //    .HasOne(drink => drink.OrderID)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.Cascade);

            //dotnet ef migrations add RelationshipFix -c HeroDBContext --startup-project ../ToHMVC
*/