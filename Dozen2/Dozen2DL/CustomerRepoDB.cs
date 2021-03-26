using Dozen2Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Dozen2MVC.Mapping;

namespace Dozen2DL
{
    public class CustomerRepoDB : ICustomerRepository
    {
        private readonly DrinkDBContext _context;
        public CustomerRepoDB(DrinkDBContext context)
        {
            _context = context;
        }
        public Customer AddCustomer(Customer newCustomer)
        {
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
            return newCustomer;
        }

        public Customer DeleteCustomer(int customerId)
        {
            var customer2BDeleted = _context.Customers.Where(i => i.CustomerId == customerId).FirstOrDefault();
            if (customer2BDeleted != null) 
            {
                _context.Customers.Remove(customer2BDeleted);
                _context.SaveChanges();
            }
            return customer2BDeleted;
        }

        public Customer EditCustomer(Customer customer)
        {
           _context.Customers.Update(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer GetCustomerByID(int id)
        {
            return _context.Customers.Where(i => i.CustomerId == id).FirstOrDefault();
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers
             .AsNoTracking()
             .Select(customer => customer)
             .OrderBy(customer => customer.Name)
             .ToList();
        }

        public List<Customer> GetCustomersByName(string name)
        {
            var entityCustomers = _context.Customers.Where(i => i.Name.ToLower().Contains(name.ToLower())).ToList();
            
            //var customers = _mapper.ParseCustomers(entityCustomers);
            return entityCustomers;

        }
    }
}
