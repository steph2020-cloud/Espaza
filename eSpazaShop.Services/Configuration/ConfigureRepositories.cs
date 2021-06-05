using eSpazaShop.Entities;
using eSpazaShop.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSpazaShop.Services.Configuration
{
    public class ConfigureRepositories
    {
        //add IConfiguration Configuration to the 
        public static void AddServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<AppDbContext>((options) =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DbConnection"));
            });
            //used to store the user in the database 
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            //used for maintaing the system 
            services.AddScoped<DbContext, AppDbContext>();

            //services.AddTransient<IOrderRepository, OrderRepository>();
            //services.AddTransient<ICartRepository, CartRepository>();

            //services.AddTransient<IRepository<Item>, Repository<Item>>();
            //services.AddTransient<IRepository<Category>, Repository<Category>>();
            //services.AddTransient<IRepository<ItemType>, Repository<ItemType>>();
            //services.AddTransient<IRepository<CartItem>, Repository<CartItem>>();
            //services.AddTransient<IRepository<OrderItem>, Repository<OrderItem>>();
            //services.AddTransient<IRepository<PaymentDetails>, Repository<PaymentDetails>>();
        }
    }
}
