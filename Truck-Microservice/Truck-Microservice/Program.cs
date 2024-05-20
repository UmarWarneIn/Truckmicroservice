
//This file contains the entry point of the application.
//It creates and configures the web host for the application.

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
namespace Truck_Microservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
