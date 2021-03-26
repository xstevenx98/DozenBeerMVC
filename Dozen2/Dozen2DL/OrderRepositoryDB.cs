using AutoMapper;
using Dozen2Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2DL
{
    public class OrderRepositoryDB : IOrderRepo
    {

        // private IMapper _mapper;
        public OrderRepositoryDB()
        {

        }
        private readonly DrinkDBContext _context;

        public OrderRepositoryDB (DrinkDBContext context)
        {
            //this._mapper = mapper;
            _context = context;
        }

        public void AddDrinkOrder(DrinkOrder drinkOrder)
        {
            _context.DrinkOrders.Add(drinkOrder);
            _context.SaveChanges();
        }

        public Order FindOrder(int orderID)
        {
            throw new NotImplementedException();
        }

        //public List<Order> GetLocationOrder(int locationID)
        //{
        //    var entityOrders = _context.Orders
        //        .Include("Customer")
        //        .Include("Drink")
        //        .Include("Location")
        //        .Where(i => i.LocationId == locationID)
        //        .ToList();

        //    var orders = _mapper.ParseOrders(entityOrders);

        //    return orders;
        //}

        public Order FindOrder(double totalCost)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrders(int customerID)
        {
            return _context.Orders
                .Include("Customer")
                .Include("Location")
                .Include(i => i.DrinkOrders).ThenInclude(j => j.Drink)
                .Where(i => i.CustomerID == customerID)
                .ToList();
        }

        //public List<Order> GetCustomerOrders(int customerId)
        //{
        //    var entityOrders = _context.Orders
        //        .Include("Customer")
        //        .Include("Drink")
        //        .Include("Location")
        //        .Where(i => i.CustomerId == customerId)
        //        .ToList();

        //    var orders = _mapper.ParseOrders(entityOrders);

        //    return orders;
        //}

        public List<Order> GetCustomerOrdersASC(int custID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrdersASCTotal(int custID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrdersDESC(int custID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrdersDESCTotal(int custID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetLocationOrderASC(int locationID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetLocationOrderASCTotal(int locationID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetLocationOrderDESC(int locationID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetLocationOrderDESCTotal(int locationID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetLocationOrders(int locationID)
        {
            return _context.Orders
              .Include("Customer")
              .Include("Location")
              .Include(i => i.DrinkOrders).ThenInclude(j => j.Drink)
              .Where(i => i.LocationID == locationID)
              .ToList();
        }

        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        Order IOrderRepo.AddOrder(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return newOrder;
        }
    }
}
