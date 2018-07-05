using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                //Acciones
                //var file = Path.Combine(env.WebRootPath, "\\" + context.Request.Path.Value);
                if (File.Exists(env.WebRootPath + "\\" + context.Request.Path.Value.Split("/")[1]))
                {
                    //Delegar
                    await next.Invoke();
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync("File not found");
                }
            });

            app.UseStaticFiles();
            
            app.Use(async (context, next) =>
            {
                //Acciones
                await context.Response.WriteAsync("Metodo1" + Environment.NewLine);
                //Delegar

                await next.Invoke();

                await context.Response.WriteAsync(Environment.NewLine + "Metodo1 FIN");
            });

            app.Use(async (context, next) =>
            {
                //Acciones
                await context.Response.WriteAsync("Metodo2" + Environment.NewLine);
                //Delegar

                await next.Invoke();

                await context.Response.WriteAsync(Environment.NewLine + "Metodo2 FIN");
            });

            app.Map("/Mundial-Rusia-2018", MundialRusia2018Handler.Handler);

            app.Run(async (context) =>
            {
                if (context.Request.Path.Value.Equals("/Eduardo.html"))
                {
                    await context.Response.WriteAsync("Hello Eduardo!");
                }
                else
                {
                    await context.Response.WriteAsync("Hello World!");
                }
            });
        }
    }
}
