using Dozen2DL;
using Dozen2Models;
using Dozen2MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2BL
{
    public class OrderBL : IOrderBL
    {
        private IOrderRepo _orderRepoDB;

        public List<OrderVM> SortOrders(int sortBy, List<OrderVM> orders)
        {
            switch (sortBy)
            {
                case 1:
                    orders = orders.OrderByDescending(i => i.OrderDateTime).ToList();
                    break;
                case 2:
                    orders = orders.OrderBy(i => i.OrderDateTime).ToList();
                    break;
                case 3:
                    orders = orders.OrderByDescending(i => i.Total).ToList();
                    break;
                case 4:
                    orders = orders.OrderBy(i => i.Total).ToList();
                    break;

                default:
                    break;
            }
            return orders;
        }

        public LocationOrdersVM GetLocationOrdersVM(int? LocationID, int? SortBy)
        {
            var locationOrdersVM = new LocationOrdersVM();
            if (LocationID != null)
            {
                locationOrdersVM.LocationID = LocationID.Value;
                var orders = GetLocationOrders(locationOrdersVM.LocationID);
                foreach (var order in orders)
                {
                    var orderVM = new OrderVM()
                    {
                        CustomerID = order.CustomerID,
                        CustomerName = order.Customer.Name,
                        LocationID = order.LocationID,
                        LocationName = order.Location.LocationName,
                        State = order.Location.State,
                        OrderDateTime = order.OrderDateTime,
                        Total = order.Total
                    };
                    if (order.DrinkOrders != null)
                    {
                        foreach (var drinkOrder in order.DrinkOrders)
                        {
                            var drinkOrderVM = new DrinkOrderVM
                            {
                                DrinkId = drinkOrder.DrinkId,
                                DrinkName = drinkOrder.Drink.DrinkName,
                                ABV = drinkOrder.Drink.ABV,
                                Quantity = drinkOrder.Quantity,
                                Price = drinkOrder.Drink.Price
                            };
                            orderVM.DrinkOrders.Add(drinkOrderVM);
                        }
                    }


                    locationOrdersVM.Orders.Add(orderVM);
                }
            }
            if (SortBy != null)
            {
                locationOrdersVM.SortBy = SortBy.Value;
            }
            locationOrdersVM.Orders = SortOrders(locationOrdersVM.SortBy, locationOrdersVM.Orders);
            return locationOrdersVM;
        }

        public OrderBL(IOrderRepo orderRepoDB)
        {
            _orderRepoDB = orderRepoDB;
        }

        public void AddDrinkOrder(DrinkOrder drinkOrder)
        {
            _orderRepoDB.AddDrinkOrder(drinkOrder);
        }

        public Order AddOrder(Order newOrder)
        {
            return _orderRepoDB.AddOrder(newOrder);
        }


        public Order FindOrder(int orderID)
        {
            throw new NotImplementedException();
        }

        public Order FindOrder(double totalAmount)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrders(int customerID)
        {
            return _orderRepoDB.GetCustomerOrders(customerID);
        }

        public List<Order> GetCustomerOrderTotal(int customerID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetLocationOrders(int locationID)
        {
            return _orderRepoDB.GetLocationOrders(locationID);
        }

        //public List<Order> GetLocationOrder(int locationID)
        //{
        //    return orderRepoDB.GetLocationOrder(locationID);
        //}

        public List<Order> GetLocationOrderTotal(int locationID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public CustomerOrdersVM GetCustomerOrdersVM(int? CustomerID, int? SortBy)
        {
            var customerOrdersVM = new CustomerOrdersVM();
            if (CustomerID != null)
            {
                customerOrdersVM.CustomerID = CustomerID.Value;
                var orders = GetCustomerOrders(customerOrdersVM.CustomerID);
                foreach (var order in orders)
                {
                    var orderVM = new OrderVM()
                    {
                        CustomerID = customerOrdersVM.CustomerID,
                        LocationID = order.LocationID,
                        LocationName = order.Location.LocationName,
                        State = order.Location.State,
                        OrderDateTime = order.OrderDateTime,
                        Total = order.Total
                    };
                    if (order.DrinkOrders != null)
                    {
                        foreach (var drinkOrder in order.DrinkOrders)
                        {
                            var drinkOrderVM = new DrinkOrderVM
                            {
                                DrinkId = drinkOrder.DrinkId,
                                DrinkName = drinkOrder.Drink.DrinkName,
                                ABV = drinkOrder.Drink.ABV,
                                Quantity = drinkOrder.Quantity,
                                Price = drinkOrder.Drink.Price
                            };
                            orderVM.DrinkOrders.Add(drinkOrderVM);
                        }
                    }


                    customerOrdersVM.Orders.Add(orderVM);
                }
                if (SortBy != null)
                {
                    customerOrdersVM.SortBy = SortBy.Value;
                }
                customerOrdersVM.Orders = SortOrders(customerOrdersVM.SortBy, customerOrdersVM.Orders);
            }


            return customerOrdersVM;

        }

        //public List<Order> GetCustomerOrders(int customerId)
        //{
        //    return orderRepoDB.GetCustomerOrders(customerId);
        //}
    }
}
