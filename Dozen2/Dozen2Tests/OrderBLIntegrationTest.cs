using Dozen2BL;
using Dozen2DL;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Dozen2Tests
{
    [TestClass]
    public class OrderBLIntegrationTest
    {
        [TestMethod]
        public void GetLocationOrdersVM_ShouldReturnNoOrders_WhenLocationIDisNull()
        {
            //arrange - testing how method reacts to a specific condition
            var options = new DbContextOptionsBuilder<DrinkDBContext>()
                .UseNpgsql("Host = ziggy.db.elephantsql.com; Port = 5432; Database = diijqqsl; Username = diijqqsl; Password = 95ILlqxg9G1qwYYI4V8ZlFe7lh2z499K;")
                .Options;
            var drinkDBContext = new DrinkDBContext(options);
            var orderRepo = new OrderRepositoryDB(drinkDBContext);
            OrderBL orderBL = new OrderBL(orderRepo);
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
            var options = new DbContextOptionsBuilder<DrinkDBContext>()
                .UseNpgsql("Host = ziggy.db.elephantsql.com; Port = 5432; Database = diijqqsl; Username = diijqqsl; Password = 95ILlqxg9G1qwYYI4V8ZlFe7lh2z499K;")
                .Options;
            var drinkDBContext = new DrinkDBContext(options);
            var orderRepo = new OrderRepositoryDB(drinkDBContext);
            OrderBL orderBL = new OrderBL(orderRepo);
            int? locationID = 1;
            int? sortBy = null;


            //act 
            var result = orderBL.GetLocationOrdersVM(locationID, sortBy);
            //assert 
            Assert.IsTrue(result.Orders.Any());
        }

      
        [TestMethod]
        public void GetCustomerOrdersVM_ShouldReturnNoOrders_WhenCustIDisNull()
        { 
            // arrange - testing how a method reacts to a specific condition
            var options = new DbContextOptionsBuilder<DrinkDBContext>()
                .UseNpgsql("Host = ziggy.db.elephantsql.com; Port = 5432; Database = diijqqsl; Username = diijqqsl; Password = 95ILlqxg9G1qwYYI4V8ZlFe7lh2z499K;")
                .Options;
            var drinkDBContext = new DrinkDBContext(options);
            var orderRepo = new OrderRepositoryDB(drinkDBContext);
            OrderBL orderBL = new OrderBL(orderRepo);
            int? customerID = null;
            int? sortBy = null;

            
            //act
            var result = orderBL.GetCustomerOrdersVM(customerID, sortBy);


            //assert
            Assert.AreEqual(0, result.Orders.Count);

        }
    }
}
