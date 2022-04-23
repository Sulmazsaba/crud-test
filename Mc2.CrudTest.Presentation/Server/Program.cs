using Mc2.CrudTest.Infrastructure.Persistence;
using Mc2.CrudTest.Presentation.Server.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Mc2.CrudTest.Presentation.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = CreateHostBuilder(args).Build();

            app.MigrateDatabase<Mc2DbContext>((context, services) =>
            {
                var logger = services.GetService<ILogger<DbContextSeed>>();
                DbContextSeed.SeedAsync(context, logger).Wait();
            });


            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
