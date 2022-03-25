using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductMasterDetails.Data;
using ProductMasterDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMasterDetails
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddRazorPages();
            services.AddControllersWithViews();

            //services.AddDbContext<ProductDbContext>(options => options.UseInMemoryDatabase(Configuration.GetConnectionString("DbConn")));
            services.AddDbContext<ProductDbContext>(options => options.UseInMemoryDatabase("DbInventory"));
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
                app.UseExceptionHandler("/Error");
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
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });

            var scope = app.ApplicationServices.CreateScope();
            var apps = scope.ServiceProvider.GetService<ProductDbContext>();
            Seeddata(apps);
        }

        static void Seeddata(ProductDbContext dbcontext)
        {
            Product pd1 = new Product
            {
                Code = "PD0001",
                Name = "Gown",
                Description = "Pink Gown",
                Category = "Garments",
                Cost = 100,
                Price = 120
            };
            Product pd2 = new Product
            {
                Code = "PD0002",
                Name = "Dress",
                Description = "Pink Long Dress",
                Category = "Garments",
                Cost = 100,
                Price = 120
            };
            Product pd3 = new Product
            {
                Code = "PD0003",
                Name = "Shirt",
                Description = "Pink Shirt",
                Category = "Garments",
                Cost = 100,
                Price = 120
            };

            Product pd4 = new Product
            {
                Code = "PD0004",
                Name = "Jeans",
                Description = "Red Jeans",
                Category = "Garments",
                Cost = 110,
                Price = 120
            };

            Product pd5 = new Product
            {
                Code = "PD0005",
                Name = "Trousers",
                Description = "Pants",
                Category = "Garments",
                Cost = 90,
                Price = 120
            };


            Product pd6 = new Product
            {
                Code = "PD006",
                Name = "Sweaters",
                Description = "Woolen Cothes",
                Category = "Garments",
                Cost = 40,
                Price = 80
            };

            dbcontext.Products.Add(pd1);
            dbcontext.Products.Add(pd2);
            dbcontext.Products.Add(pd3);
            dbcontext.Products.Add(pd4);
            dbcontext.Products.Add(pd5);
            dbcontext.Products.Add(pd6);
            dbcontext.SaveChanges();
        }
    }
}
