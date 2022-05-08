using Canteen_Management_System.Core.Common.Interfaces;
using Canteen_Management_System.Infrastructure.Models;
using Canteen_Management_System.Infrastructure.Services;
using Canteen_Management_System.Infrastructure.Settings;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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


            //Configuration from AppSettings
            services.Configure<JWT>(config.GetSection("JWT"));
            //User Manager Service
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDBContext>();
            services.AddScoped<IUserService, UserService>();
            //Adding DB Context with MSSQL
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(
                    config.GetConnectionString("Default"),
                    b => b.MigrationsAssembly(typeof(AppDBContext).Assembly.FullName)));
            //Adding Athentication - JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,

                        ValidIssuer = config["JWT:Issuer"],
                        ValidAudience = config["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]))
                    };
                });

            return services;
        }
    }
}
