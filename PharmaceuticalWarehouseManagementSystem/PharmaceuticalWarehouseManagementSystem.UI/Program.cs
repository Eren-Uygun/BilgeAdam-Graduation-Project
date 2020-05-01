using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PharmaceuticalWarehouseManagementSystem.DAL.Context;

namespace PharmaceuticalWarehouseManagementSystem.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
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
