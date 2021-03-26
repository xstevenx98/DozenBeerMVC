using Dozen2BL;
using Dozen2DL;
using Dozen2MVC.Models;
using DozenBL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Dozen2MVC
{
    public class Startup
    {

        /*
            Layout + index compiled to the home Page for my Dozen2MVC website 

            The Views that you have in ASP.NET MVC and your MVC App gets compiled by 
            a razor view engine to become some sort of html css javascript web page that you sent to your client. 
                And what you're actually interacting with isn't the view in your web app,
                but an HTML page that was compiled from the view.
            
            When you request data from the server, youre going to have to send data from your HTML page
            to your controller

            again, views get compiled to HTML that you send to your end user to your client . client renders that html
                and client sends another request to that server that would return another HTML
         */
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services are the objects or things that your application would be dependent on
            services.AddControllersWithViews();
               services.AddDbContext<DrinkDBContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DrinkDB")));
            //   services.AddDbContext<DrinkDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DrinkDBSQL")));

            /*
            In ConfigureServices, this is where you declare  all the interfaces and implementations that you want those interfaces to use.
              whatever your different classes are dependent on, this is where you declare all of them 

             In P0 main, i had this long line where i'd inject all my dependencies. This method here  is where I would do that . 
             3 different lifetimes: singleton, transient, scoped
            singleton - for every request and response, youre going to use that ONE instance of that object 
            scope - for every request and response you create an instance of that object or of that service 
            transient means every time you use that service, you create a new object for that service 
            Here, we'd want to use scoped because every request and response should be independnt of each other.
            they should have different services
            we dont want to use transient bc were going to be recreating a bunch of objects

            with scoped we create objects per request from the client (as we need them)
            */
            services.AddScoped<IDrinkRepository, DrinkRepoDB>();
            services.AddScoped<IDrinkBL, DrinkBL>();
            services.AddScoped<ICustomerRepository, CustomerRepoDB>();
            services.AddScoped<ICustomerBL, CustomerBL>();
            services.AddScoped<IOrderRepo, OrderRepositoryDB>();
            services.AddScoped<IOrderBL, OrderBL>();
            services.AddScoped<ILocationRepository, LocationRepositoryDB>();
            services.AddScoped<ILocationBL, LocationBL>();
            services.AddScoped<IInventoryRepo, InventoryRepoDB>();
            services.AddScoped<IInventoryBL, InventoryBL>();
            //anytime someone is in need of icustomerbl, we will provide customerbl in its place.  customerbl is the real class 
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
