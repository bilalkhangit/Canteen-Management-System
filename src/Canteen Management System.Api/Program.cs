using Canteen_Management_System.Infrastructure.Identity;
using Canteen_Management_System.Infrastructure.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canteen_Management_System.Api
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    var logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
        //    try
        //    {
        //        logger.Debug("Application Starting Up");
        //        CreateHostBuilder(args).Build().Run();
        //    }
        //    catch (Exception exception)
        //    {
        //        logger.Error(exception, "Stopped program because of exception");
        //        throw;
        //    }
        //    finally
        //    {
        //        NLog.LogManager.Shutdown();
        //    }
        //}

        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args)
                         .Build();
            var logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    //Seed Default Users
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await ApplicationDbContextSeed.SeedEssentialsAsync(userManager, roleManager);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Stopped program because of exception");
                    throw;
                }
                finally
                {
                    NLog.LogManager.Shutdown();
                }
            }

            logger.Debug("Application Starting Up");
            host.Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
               .UseNLog();
    }
}
