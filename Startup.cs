using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.Diagnostics;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Data.Entity;
//using Microsoft.Data.SQLite;
using MvcApp.Models;

namespace MvcApp
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        public Startup()
        {
            Configuration = new Configuration()
            .AddJsonFile("config.json")
            .AddEnvironmentVariables(); //All environment variables in the process's context flow in as configuration values.
        }

        public void Configure(IApplicationBuilder app)
        {
            Console.WriteLine("Starting '{0}'", MvcApp.Global.SiteName);
            app.UseStaticFiles();

            app.UseServices(services =>
            {
                services.AddMvc();
                services.AddEntityFramework()
                .AddInMemoryStore() // currently EntityFramework only supports InMemory on *nix platforms
                .AddDbContext<AppContext>(options =>
                {
                    // until SQLite support works
                    // options.UseSQLite(connectionStringBuilder.ConnectionString);
                    options.UseInMemoryStore();
                });
            });
            app.UseErrorPage(ErrorPageOptions.ShowAll);

            app.UseRuntimeInfoPage();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index"}
                );

                routes.MapRoute(
                    name: "api",
                    template: "{controller}/{id?}"
                );
            });
        }
    }
}
