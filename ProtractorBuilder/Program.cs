using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProtractorBuilder.Protractor.DbContext;

namespace ProtractorBuilder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args){
            var host = WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.Build();

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					var context = services.GetRequiredService<TestContext>();
					DbInitializer.Initialize(context);
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred while seeding the database.");
				}
			}

            return host;
        }
    }
}
