using System;
using Microsoft.AspNetCore.Builder;
using TodoApp.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Framework.Configuration;

namespace TodoApp
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            Console.WriteLine("Adding logger...");
            loggerFactory.AddConsole();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
        
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            services.AddSingleton<ITodoRepository, TodoRepository>();
        }
        
        public Startup(IHostingEnvironment hostingEnvironment) {
            var builder = new ConfigurationBuilder()
            .SetBasePath(hostingEnvironment.ContentRootPath);
        }
    }
}