using Microsoft.AspNetCore.Builder;
using TodoApp.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Framework.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Diagnostics;

namespace TodoApp
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, ILoggerFactory logger, IHostingEnvironment env)
        {
            //if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            //}
            
            logger.AddConsole();
            
            app.UseStaticFiles();
            app.UseDirectoryBrowser(new DirectoryBrowserOptions() {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "webroot", "js")),
                RequestPath = new PathString("/js")
            });
            app.UseDirectoryBrowser(new DirectoryBrowserOptions() {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "webroot", "images")),
                RequestPath = new PathString("/images")
            });
            app.UseDirectoryBrowser(new DirectoryBrowserOptions() {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "webroot", "css")),
                RequestPath = new PathString("/css")
            });
            app.UseMvcWithDefaultRoute();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<ITodoRepository, TodoRepository>();
        }

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath);
        }
    }
}