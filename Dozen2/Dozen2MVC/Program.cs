using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dozen2MVC
{
    public class Program
    {
                                                                //dotnet ef migrations add Initial -c DrinkDBContext --startup-project ../Dozen2MVC
        //to apply changes of the latest migration to your database, run: dotnet ef database update --startup-project ../Dozen2MVC
                                                                    
                                                                  
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

/*
    What you actually interact with is an HTML page, that is sent from the server.  
        The View is server-side.  when you return the view via action, serverside things happen and they compile that view to become some 
        html css javascript and they send it to your browser .
    What you send back to the server is NEW data 
    The view gets compiled and get sent to the server.  



    /*
             return RedirectToAction("ConfirmOrder", "Order",  orderIndexVM); we want to go to confirmorder , 
            “you need to tell me the controller. Confirmorder is gonna be in ordercontroller”, we want to pass orderindexvm in the ordercontroller.
            We want to pass this whole thing to that page  

firstordefault only expects 1 match


razor doesnt support foreach if you need to change the values 
if u need to track what you change then use for loop 

tempdata is a temporary dictionary. To save anything in thereu  need to provide a key and then save the list.  At anytime u wanna retrieve it u provide the same key and that gives original value . U need the as keyword to convert to the original type it was 

@model passes info btwn controller and the index page 
the purpose of this page is to submit an order aka form element.(placeorder)

form asks where am I submitting this to? Im submitting this to placeorder which is an http post.
The submit button here takes me to placeorder

bootstrap for css

we dont need your temporary data anymore e in viewbag bc you made your choices. Theyre locked in


controller-specific functions like serving up a view need to be separated.  We take the c# computation 

locationorders depends on locationID , nullable int
make sure it returns no orders  when the id is null

             */
