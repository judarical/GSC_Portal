using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Mvc;
using JSC_Portal.Logic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace JSC_Portal
{
    public class Startup
    {
        // todo: разобраться, как работает каждый метод этого конструктора и создать его с нуля, исключив лишний код.
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                // todo: добавить UserSecrets в приложение
                // builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                // builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc();
            /*
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CustomExceptionFilter());
            });*/

            //Register your filter as a service (Note this filter need not be an attribute as such)
            // services.AddTransient<CustomExceptionFilter>();

            // Add application services.
            // services.AddTransient<IEmailSender, AuthMessageSender>();
            // services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // app.UseApplicationInsightsRequestTelemetry();
            // app.UseIISPlatformHandler();

            /*app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });*/            

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
                    {
                        //serviceScope.ServiceProvider.GetService<ApplicationDbContext>()
                          //   .Database.Migrate();
                    }
                }
                catch { }
            }

            // app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());
            // app.UseApplicationInsightsExceptionTelemetry();
            
            app.UseStaticFiles();
            // app.UseIdentity();

            app.UseMvc(m => {
                m.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
