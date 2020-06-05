using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PharmaceuticalWarehouseManagementSystem.DAL.Context;
using PharmaceuticalWarehouseManagementSystem.DAL.DataSeed;

namespace PharmaceuticalWarehouseManagementSystem.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    DataSeed.Seed(services);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            CreateHostBuilder(args).Build().Run();

            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                .ConfigureLogging((ProjectContext, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddConfiguration(ProjectContext.Configuration.GetSection("Logging"));

                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddEventSourceLogger();



                })
              
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                });
    }
}
