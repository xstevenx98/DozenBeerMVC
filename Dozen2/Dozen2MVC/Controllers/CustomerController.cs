using AutoMapper;
using Dozen2BL;
using Dozen2MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dozen2MVC.Controllers
{

    /*
     irst steP: we decide to go into customerorders in the controller itself, and separate out the lines of 
    code thats preparing the view model FROM the lines of code thats loading the view (which is asp frameworks job)
    
    the lines im selecting im preparing the VM for this page , so we cut it. And make a new function in the OrderBL.  

     */
    public class CustomerController : Controller
    {
        private ICustomerBL _customerBL;
        private IMapper _mapper;
        public CustomerController(ICustomerBL customerBL, IMapper mapper)
        {
            _customerBL = customerBL;
            _mapper = mapper;
        }
        // GET: CustomerController
        public ActionResult Index(string searchName = null)
        {// loads the index page for customer
            var customers = string.IsNullOrWhiteSpace(searchName)?_customerBL.GetCustomers(): _customerBL.GetCustomersByName(searchName); //else after colon
            // if you have a searchname, call getcustomersbyname...if you dont then get all the customers
            var customerVMs = new List<CustomerVM>();
            foreach (var item in customers)
            {
                var customerVM = _mapper.Map<CustomerVM>(item);
                customerVMs.Add(customerVM);
            }
            var customerIndexVM = new CustomerIndexVM();
            customerIndexVM.Customers = customerVMs;
            return View(customerIndexVM);
        }



        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            var newCustomer = new CustomerCreateVM();
            return View(newCustomer);
        }

        //public ActionResult Create(CustomerCRVM newCustomer)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        try 
        //        {
        //            _drinkBL.AddCustomer(_mapper.cast2Customer(newCustomer));
        //              return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //          {
        //              return View();
        //          }
        //    }
        //    return View();
        //}

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreateVM customerCreateVM)
        {

            try
            {
                var customer = _mapper.Map<Dozen2Models.Customer>(customerCreateVM);
                _customerBL.AddCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            Dozen2Models.Customer customer = _customerBL.GetCustomerByID(id);
            CustomerEditVM customerEditVM = _mapper.Map<CustomerEditVM>(customer);
            return View(customerEditVM);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerEditVM customerEditVM )
        {
            try
            {
                var customer = _mapper.Map<Dozen2Models.Customer>(customerEditVM);
                _customerBL.EditCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            Dozen2Models.Customer customer = _customerBL.GetCustomerByID(id);
            CustomerDeleteVM customerDeleteVM = _mapper.Map<CustomerDeleteVM>(customer);
            return View(customerDeleteVM);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CustomerDeleteVM customerDeleteVM)
        {
            try
            {
                _customerBL.DeleteCustomer(customerDeleteVM.CustomerId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(CustomerIndexVM customerIndexVM)
        {
            return RedirectToAction("Index", "Customer", new {SearchName = customerIndexVM.SearchName});
          
                
            
            //CustomerSearchVM customerSearchVM = _mapper.Map<CustomerSearchVM>(customer);
            //return View(customerSearchVM);
        }

        public ActionResult Search (CustomerSearchVM customerSearchVM)
        {
            try
            {
                //get a loop of customers?
                _customerBL.GetCustomersByName(customerSearchVM.Name);
                return RedirectToAction();
            }
            catch
            {
                return View();
            }
        }
    }
}
