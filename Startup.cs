using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RctWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.Run(async (context) =>
            {

                // Procitaj parametar: rds=13000
                var parametar = context.Request.Query["rsd"];

                // Konvertuj parametar u double (parametar je uvek tekst)
                var rsd = Convert.ToDouble(parametar);
                // Pretvori vrednost dinara u valutu euro po kursu 120:1
                var euro = rsd/120.0;
                // Pretvori odgovor u JSON format
                var json = "{\"euro\":" + euro + "}";
                // Vrati rezultat formatiran kao JSON
                await context.Response.WriteAsync(json);
            
            });
        }
    }
}
