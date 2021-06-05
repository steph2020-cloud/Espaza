using eSpazaShop.Services.Implementations;
using eSpazaShop.Services.Interfaces;
using eSpazaShop.WebUI.Helpers;
using eSpazaShop.WebUI.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eSpazaShop.WebUI.Configuration
{
    public class ConfigureDependencies
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddTransient<IUserAccessor, UserAccessor>();
            //services.AddTransient<IPaymentService, PaymentService>();
            //services.AddTransient<ICatalogService, CatalogService>();
            //services.AddTransient<ICartService, CartService>();
            //services.AddTransient<IOrderService, OrderService>();
            //services.AddTransient<IFileHelper, FileHelper>();
        }
    }
}
