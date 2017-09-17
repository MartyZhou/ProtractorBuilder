using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProtractorBuilder.Protractor.Common;

namespace ProtractorBuilder
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
    //        services.AddCors(options =>
    //        {
    //            options.AddPolicy("AllowAllOrigins", builder =>
    //            {
    //                builder.AllowAnyOrigin();
    //            });

				//options.AddPolicy("AllowAllMethods", builder =>
				//{
				//	builder.AllowAnyMethod();
				//});

				//options.AddPolicy("AllowAllHeaders", builder =>
				//{
				//	builder.AllowAnyHeader();
				//});
            //});

            services.AddOptions();
            services.Configure<ProtractorConfiguration>(Configuration);
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info() { Title = "Protractor Builder API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Protractor Builder API V1");
            });
        }
    }
}
