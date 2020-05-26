using Hahn.ApplicatonProcess.May2020.Data.DataAccess;
using Hahn.ApplicatonProcess.May2020.Web.Intializers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hahn.ApplicatonProcess.May2020.Web.Extensions
{
    public static class HostExtensions
    {
        public static IHost SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService(typeof(HahnDbContext)) as HahnDbContext;

                new DatabaseInitializer(context).PopulateInitialData();
            }

            return host;
        }
    }
}
