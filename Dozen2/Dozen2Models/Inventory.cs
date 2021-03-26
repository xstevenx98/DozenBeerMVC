namespace Dozen2Models
{
    /// <summary>
    /// this data structure models a drink and its quantity.
    /// the quantity was separated from the drink as it could vary from orders and locations
    /// this is a wrapper class
    /// </summary>
    public class Inventory
    {   public int InventoryID { get; set; }
        public int DrinkID { get; set; }
       
        public virtual Drink Drink {get;set;}

        public int Quantity {get;set;} 
        
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }
     
    }
}