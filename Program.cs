using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace TodoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                // TODO: Do not hardcode locations
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseWebRoot(Path.Combine(Directory.GetCurrentDirectory(), "webroot"))
                .Build();

            host.Run();
        }
    }
}
