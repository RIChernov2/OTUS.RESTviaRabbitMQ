using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApi.Configuration;
using WebApi.Configuration.Models;

namespace WebApi
{
    public class Startup
    {
        // читай ==> Solution Items/README.txt

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration.Get<AppConfiguration>();
        }

        public AppConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddJson();
            services.AddControllers();
            services.AddSnakeCaseMapping();
            services.AddDatabaseFactory(Configuration);

            services.AddSingleton<ISchemaCongiguration>(Configuration);
            services.AddRepositories();

            services.AddStorageManagers();
            services.ConfigureRabbitMQ(Configuration);
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(string.Format(@"{0}/WebApi.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });
            services.ConfigureMigrator(Configuration);
        }
        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // для инициализации стартового значения таблиц
            // Configuration.FluentMigratorProfile = "FirstStart";

            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.RunMigrator();
        }
    }
}
