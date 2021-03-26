using Dozen2Models;
using Dozen2MVC.Models;
using System.Collections.Generic;

namespace Dozen2BL
{
    public interface IOrderBL
    {
         List<Order> GetOrders();
         Order AddOrder (Order newOrder);
         Order FindOrder(int orderID);
         Order FindOrder(double totalAmount);
         List<Order> GetCustomerOrders(int customerID);
         List<Order> GetLocationOrders(int locationID);
         List <Order> GetLocationOrderTotal(int locationID);
         List<Order> GetCustomerOrderTotal(int customerID);
        void AddDrinkOrder(DrinkOrder drinkOrder);

        List<OrderVM> SortOrders(int sortBy, List<OrderVM> orders);

        LocationOrdersVM GetLocationOrdersVM(int? LocationID, int? SortBy);
        CustomerOrdersVM GetCustomerOrdersVM(int? customerID, int? sortBy);
    }
}