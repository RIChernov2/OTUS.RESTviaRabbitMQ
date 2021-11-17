using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Notifications.Manager.Configurations;
using Notifications.Manager.Configurations.Models;
using Notifications.Manager.Migrations;

namespace Noticifacion.Manager
{
    public class Startup
    {
        // читай ==> Solution Items/README.txt
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration.Get<AppConfiguration>();
            AddMessages.SchemeName = Configuration.SchemaName;
        }

        public AppConfiguration Configuration { get; }
        private static bool s_useSwagger = false;

        public void ConfigureServices(IServiceCollection services)
        {
            DapperConfiguration.Configure();
            RabbitMqConfiguration.Configure(Configuration);
            services.ConfigureMigrator(Configuration);
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // для инициализации стартового значения таблиц
            // Configuration.FluentMigratorProfile = "FirstStart";

            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }

            // swagger
            if ( s_useSwagger )
            {
                app.UseRouting();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }

            app.RunMigrator();
        }
    }
}
