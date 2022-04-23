using Canteen_Management_System.Application.BrandServices;
using Canteen_Management_System.Application.DomainEventHandlers;
using Canteen_Management_System.Application.Interfaces;
using Canteen_Management_System.Application.ProductServices;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Canteen_Management_System.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IBrandAppService, BrandAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            return services;
        }
    }
}
