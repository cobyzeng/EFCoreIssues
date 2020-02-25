using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ordering.Infrastructure;

namespace Ordering
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            MigrateDatabases(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void MigrateDatabases(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var orderingContext = scope.ServiceProvider.GetRequiredService<OrderingContext>();
                orderingContext.Database.Migrate();
            }
        }
    }
}
