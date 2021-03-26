using System;
using Dozen2DL;
using Dozen2Models;
using System.Collections.Generic;
using Dozen2BL;


/// <summary>
/// CustomerBL applies the business logic for the customers
/// </summary>

namespace DozenBL
{
    public class CustomerBL : ICustomerBL
    {
        private ICustomerRepository _repo;
        public CustomerBL(ICustomerRepository repo)
        {
            _repo = repo;
        }
        public Customer AddCustomer(Customer newCustomer)
        {
            return _repo.AddCustomer(newCustomer);
        }

        public Customer DeleteCustomer(int customerId)
        {
            return _repo.DeleteCustomer(customerId);
        }

        public Customer EditCustomer(Customer customer)
        {
            return _repo.EditCustomer(customer);
        }

        public Customer GetCustomerByID(int id)
        {
            return _repo.GetCustomerByID(id);
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();
        }

        public List<Customer> GetCustomersByName(string name)
        {

            return _repo.GetCustomersByName(name);
        }
    }
}
