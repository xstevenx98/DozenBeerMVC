using Dozen2BL;
using Dozen2DL;
using Dozen2Models;
using Dozen2MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dozen2Tests
{

    /*
     Mock tests dont depend on anything . 
    We need an orderbl and that needs an iorderrepo so we make a fake iorder 
    repo  so we pass the mockiorderrepo.object
     */

    [TestClass]
    public class OrderBLMoqTest
    {
        [TestMethod]
        public void GetLocationOrdersVM_ShouldReturnNoOrders_WhenLocationIDisNull()
        {
            //arrange - testing how method reacts to a specific condition
           
            var orderRepoMoq = new Mock<IOrderRepo>();
            OrderBL orderBL = new OrderBL(orderRepoMoq.Object);
            int? locationID = null;
            int? sortBy = null;
           
            //act 
            var result = orderBL.GetLocationOrdersVM(locationID, sortBy);
            //assert 
            Assert.IsTrue(result.Orders == null || !result.Orders.Any());
        }

        [TestMethod]
        public void GetLocationOrdersVM_ShouldReturnOrders_WhenLocationIDisOne()
        {
            //arrange - testing how method reacts to a specific condition
             int? locationID = 1;
            int? sortBy = null;
            var mockOrdersforLocation1 = new List<Order>() { new Order { OrderID = 1, CustomerID = 2, Customer= new Customer(), Location = new Location()  } };
            var orderRepoMoq = new Mock<IOrderRepo>();
            orderRepoMoq.Setup(i => i.GetLocationOrders(locationID.Value)).Returns(mockOrdersforLocation1);
            OrderBL orderBL = new OrderBL(orderRepoMoq.Object);
            
            //act 
            var result = orderBL.GetLocationOrdersVM(locationID, sortBy);
            //assert 
            Assert.IsTrue(result.Orders.Any());
        }

        [TestMethod]
        public void GetCustomerOrdersVM_ShouldReturnNoOrders_WhenCustIDisNull()
        {
            //we are interested in testing what happens when custid is null

            //arrange
            var mockIOrderRepo = new Mock<IOrderRepo>();
            OrderBL orderBL = new OrderBL(mockIOrderRepo.Object);
            int? customerID = null;
            int sortBy = 1;

            //act
            var result = orderBL.GetCustomerOrdersVM(customerID, sortBy);
            //sortby can be a legitimate value 


            //assert
            Assert.AreEqual(0, result.Orders.Count);

        }

        [TestMethod]
        public void GetCustomerOrdersVM_ShouldReturnOrdersByDateDESC_WhenSortByIsOne()
        {
            //arrange 
            int customerID = 1;            
            int sortBy = 1;
            List<Order> orders = new List<Order>();
            var order1 = new Order()
            {
                OrderID = 1,
                CustomerID = 1,
                Customer = new Customer(),
                LocationID = 1,
                OrderDateTime = DateTime.Today.AddDays(-10),
                Location = new Location(),
                DrinkOrders = new List<DrinkOrder>()
            };
            var order2 = new Order()
            {
                OrderID = 2,
                CustomerID = 1,
                Customer = new Customer(),
                LocationID = 1,
                OrderDateTime = DateTime.Today.AddDays(-5),
                Location = new Location(),
                DrinkOrders = new List<DrinkOrder>()
            };
            orders.Add(order1);
            orders.Add(order2);
            var mockIOrderRepo = new Mock<IOrderRepo>();
            mockIOrderRepo.Setup(i => i.GetCustomerOrders(customerID)).Returns(orders);
            OrderBL orderBL = new OrderBL(mockIOrderRepo.Object);

           

            //act
            var result = orderBL.GetCustomerOrdersVM(customerID, sortBy);

            //assert
            Assert.IsTrue(result.Orders[0].OrderDateTime >= result.Orders[1].OrderDateTime);

        }

    }
}
