using Canteen_Management_System.Core.Common.Interfaces;
using Canteen_Management_System.Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Canteen_Management_System.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDBContext>(
                           options => options.UseSqlServer(config.GetConnectionString("Default")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IEmailSender>(SMTPEmailSender => new SMTPEmailSender(config.GetValue<string>("Email:UserName"), config.GetValue<string>("Email:Password")));

            return services;
        }
    }
}
