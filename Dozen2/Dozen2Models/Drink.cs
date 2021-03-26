using System;

namespace Dozen2Models
{
    public class Drink
    {   public int DrinkId { get; set; }

        private string drinkName; //private backing field for DrinkName
        private int abv; //private backing field for ABV
        private decimal price; //private backing field for Price

        public string DrinkName
        {
            get;set;
        }

        public int ABV
        {
            get{return abv;}
            set{abv = value;}
        }

        public decimal Price
        {
            get{return price;}
            set{price = value;}
        }



    }
}


/*
    things needed to build a db context:
constructors
list of entities i want to build in db
 */