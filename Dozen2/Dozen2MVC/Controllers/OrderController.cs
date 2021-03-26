using AutoMapper;
using Dozen2BL;
using Dozen2Models;
using Dozen2MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dozen2MVC.Controllers
{
    public class OrderController : Controller
    {
        private ICustomerBL _customerBL;
        private IMapper _mapper;
        private IOrderBL _orderBL;
        private ILocationBL _locationBL;
        private IDrinkBL _drinkBL;
        private IInventoryBL _inventoryBL;
        public OrderController(ICustomerBL customerBL, IMapper mapper, IOrderBL orderBL, ILocationBL locationBL, IDrinkBL drinkBL, IInventoryBL inventoryBL)
        {
            _customerBL = customerBL;
            _mapper = mapper;
            _orderBL = orderBL;
            _locationBL = locationBL;
            _drinkBL = drinkBL;
            _inventoryBL = inventoryBL;
        }

        [HttpPost]
        public IActionResult SearchCustomerOrders(CustomerOrdersVM customerOrdersVM) 
        {
            /*
             return RedirectToAction("ConfirmOrder", "Order",  orderIndexVM); we want to go to confirmorder , 
            “you need to tell me the controller. Confirmorder is gonna be in ordercontroller”, we want to pass orderindexvm in the ordercontroller.
            We want to pass this whole thing to that page  
             */
            return RedirectToAction("CustomerOrders", "Order", new { CustomerID = customerOrdersVM.CustomerID , SortBy = customerOrdersVM.SortBy});
        }


        [HttpPost]
        public IActionResult SearchLocationOrders(LocationOrdersVM locationOrdersVM)
        {
            return RedirectToAction("LocationOrders", "Order", new { LocationID = locationOrdersVM.LocationID, SortBy = locationOrdersVM.SortBy });
        }

        public IActionResult LocationOrders(int? LocationID = null, int? SortBy = null)
        { 
            ViewBag.SortOptions = GetSortOptions();
            var locations = _locationBL.GetLocations();
            ViewBag.Locations = locations
                .Select(i => new SelectListItem
                {
                    Value = i.LocationID.ToString(),
                    Text = $"{i.LocationName}, {i.State}"
                }).ToList();


            var locationOrdersVM = _orderBL.GetLocationOrdersVM(LocationID, SortBy);
            return View(locationOrdersVM);
        }

        private List<SelectListItem> GetSortOptions() 
        {
            var sortOptions = new List<SelectListItem>();
            sortOptions.Add(new SelectListItem
            {
                Value = "1",
                Text ="Sort by Date DESC"
            });

            sortOptions.Add(new SelectListItem
            {
                Value = "2",
                Text = "Sort by Date ASC"
            });

            sortOptions.Add(new SelectListItem
            {
                Value = "3",
                Text = "Sort by Cost DESC"
            });

            sortOptions.Add(new SelectListItem
            {
                Value = "4",
                Text = "Sort by Cost ASC"
            });
            return sortOptions;
        }

        public IActionResult CustomerOrders(int? CustomerID = null, int? SortBy = null) 
        {
            var customers = _customerBL.GetCustomers();
            ViewBag.Customers = customers
                .Select(i => new SelectListItem
                {
                    Value = i.CustomerId.ToString(),
                    Text = i.Name
                }).ToList(); 
              ViewBag.SortOptions = GetSortOptions();

            CustomerOrdersVM customerOrdersVM = _orderBL.GetCustomerOrdersVM(CustomerID, SortBy);
            return View(customerOrdersVM);

        }

        

        public IActionResult Index(OrderIndexVM orderIndexVM = null)
        {
            /*
             viewbag is temp placeholder for passing info to the page we dont care about in the VM itself 
            we dedicate the responsibility for repo to give the row data of the table
            we leave mapping to the controller 
             */
            if (orderIndexVM == null || orderIndexVM.CustomerID == 0)
            {
                orderIndexVM = new OrderIndexVM(); 
                var drinks = _drinkBL.GetDrinks();
                orderIndexVM.DrinkOrders = drinks
                .Select(i => new DrinkOrderVM
                {
                    DrinkId = i.DrinkId,
                    DrinkName = i.DrinkName,
                    ABV = i.ABV,
                    Price = i.Price
                }).ToList();

            }
            else 
            {
                string drinkOrderString = TempData["DrinkOrders"].ToString();
                orderIndexVM.DrinkOrders = JsonConvert.DeserializeObject<List<DrinkOrderVM>>(drinkOrderString);
            }
            
            var customers = _customerBL.GetCustomers();
            ViewBag.Customers = customers
                .Select(i => new SelectListItem
                {
                    Value = i.CustomerId.ToString(),
                    Text = i.Name
                }).ToList();

            var locations = _locationBL.GetLocations();
            ViewBag.Locations = locations
                .Select(i => new SelectListItem
                {
                    Value = i.LocationID.ToString(),
                    Text = $"{i.LocationName}, {i.State}"
                }).ToList();
           

            return View(orderIndexVM);


        }

        [HttpPost]
        public ActionResult PlaceOrder(OrderIndexVM orderIndexVM) 
        {
            string drinkOrderString = JsonConvert.SerializeObject(orderIndexVM.DrinkOrders);
            TempData["DrinkOrders"] = drinkOrderString;
            orderIndexVM.ErrorMessages = new List<string>();
            foreach (var drinkOrder in orderIndexVM.DrinkOrders)
            {
                if (drinkOrder.Quantity > 0) 
                {
                    var inventory = _inventoryBL.GetInventoryByLocationIDAndDrinkID(orderIndexVM.LocationID, drinkOrder.DrinkId);
                    if (inventory.Quantity < drinkOrder.Quantity) 
                    {
                        orderIndexVM.ErrorMessages.Add ($"Not enough {drinkOrder.DrinkName} \r\n ");
                        orderIndexVM.ErrorMessages.Add( $"We currently have {inventory.Quantity} in stock at this location \r\n");
                       
                    }
                }
            }
            if (orderIndexVM.ErrorMessages != null && orderIndexVM.ErrorMessages.Any()) 
            {
                return RedirectToAction("Index", "Order", orderIndexVM);
            }
            
           
            return RedirectToAction("ConfirmOrder", "Order",  orderIndexVM);

        }

        [HttpPost]
        public ActionResult SaveOrder(OrderIndexVM orderIndexVM) 
        {
            //saves to the table
            var order = new Order
            {
                CustomerID = orderIndexVM.CustomerID,
                LocationID = orderIndexVM.LocationID,
                Total = GetTotal(orderIndexVM.DrinkOrders)
            };
            order = _orderBL.AddOrder(order);
            foreach (var item in orderIndexVM.DrinkOrders)
            {
                if(item.Quantity > 0)
                {
                    var drinkOrder = new DrinkOrder
                    {
                        DrinkId = item.DrinkId,
                        OrderId = order.OrderID,
                        Quantity = item.Quantity

                    };
                    _orderBL.AddDrinkOrder(drinkOrder);
                }
                var inventory = _inventoryBL.GetInventoryByLocationIDAndDrinkID(order.LocationID, item.DrinkId);
                if (inventory != null)
                {
                    inventory.Quantity -= item.Quantity;
                    _inventoryBL.UpdateInventory(inventory);
                }
            }
            


            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult ConfirmOrder(OrderIndexVM orderIndexVM)
        {
            string drinkOrderString = TempData["DrinkOrders"].ToString();
            orderIndexVM.DrinkOrders = JsonConvert.DeserializeObject<List<DrinkOrderVM>>(drinkOrderString);
            var customer = _customerBL.GetCustomerByID(orderIndexVM.CustomerID);
            if (customer != null )
            {
                orderIndexVM.CustomerName = customer.Name;
            }

            var location = _locationBL.GetSpecifiedLocation(orderIndexVM.LocationID);
            if (location != null)
            {
                orderIndexVM.LocationName = location.LocationName;
                orderIndexVM.State = location.State;
            }
            orderIndexVM.Total = GetTotal(orderIndexVM.DrinkOrders);

            return View(orderIndexVM);
        }
        private decimal GetTotal(List<DrinkOrderVM> drinkOrderVMs) 
        {
            decimal total = 0m;
            foreach (var item in drinkOrderVMs)
            {
                total += item.Price * item.Quantity;
            }
            return total;
        }
    }
}
