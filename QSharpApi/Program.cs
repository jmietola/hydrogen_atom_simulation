using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace QSharpApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices(services =>
                    {
                        services.AddControllers();
                        services.AddCors(options =>
                        {
                            options.AddDefaultPolicy(builder =>
                            {
                                builder.WithOrigins("*") // You can replace the "*" with the specific origin you want to allow
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                            });
                        });
                    });

                    webBuilder.Configure(app =>
                    {
                        app.UseHttpsRedirection();
                        app.UseStaticFiles(); // Add this line to serve static files
                        app.UseRouting();
                        app.UseCors(); // Add this line to enable CORS
                        app.UseAuthorization();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
                });
    }
}
