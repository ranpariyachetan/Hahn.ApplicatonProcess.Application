using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Hahn.ApplicatonProcess.May2020.Web.Extensions;

namespace Hahn.ApplicatonProcess.May2020.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().SeedData().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}