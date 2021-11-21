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

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/euro", async context =>
                {
                    var parametar = context.Request.Query["rsd"];
                    var json = ConvertTo(context.Request.Query["rsd"], 120 );
                    await context.Response.WriteAsync(json);
                });
                endpoints.MapGet("/usd", async context =>
                {
                    var parametar = context.Request.Query["rsd"];
                    var json = ConvertTo(context.Request.Query["rsd"], 105 );
                    await context.Response.WriteAsync(json);
                });
                endpoints.MapGet("/chf", async context =>
                {
                    var parametar = context.Request.Query["rsd"];
                    var json = ConvertTo(context.Request.Query["rsd"], 95 );
                    await context.Response.WriteAsync(json);
                });
            });
        }

        string ConvertTo(string parametar, double kurs) {

            // Konvertuj parametar u double (parametar je uvek tekst)
            var rsd = Convert.ToDouble(parametar);
            // Pretvori vrednost dinara u valutu euro po zadatom kursu
            var value = rsd/kurs;
            // Pretvori odgovor u JSON format
            var json = "{\"value\":" + value + "}";
            // Vrati rezultat formatiran kao JSON
            return json;

        }
    }
}
