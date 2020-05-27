using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Basic
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.Use(async (context, next) =>
            //{
            //    var cultureQuery = context.Request.Query["culture"];
            //    if (!string.IsNullOrWhiteSpace(cultureQuery))
            //    {
            //        var culture = new CultureInfo(cultureQuery);
            //        CultureInfo.CurrentCulture = culture;
            //        CultureInfo.CurrentUICulture = culture;
            //    }

            //    await next();
            //});
            // equ
            //app.UseMiddleware<RequestCultureMiddleware>();
            // equ
            app.UseRequestCulture();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync($"Hello \"{CultureInfo.CurrentCulture.DisplayName}\"");
                });
            });
        }
    }
}
