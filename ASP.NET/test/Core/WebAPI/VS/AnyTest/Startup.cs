using AnyTest.Clients;
using AnyTest.Filters;

namespace AnyTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISmthService, SmthService>();
            services.AddScoped<ActionFilterExample>();
            services.AddScoped<AsyncActionFilterExample>();
            services.AddScoped<ActionFilterDIExample>();
            services.AddScoped<AsyncActionFilterDIExample>();
            services.AddControllers();

            #if USE_HTTP_CLIENT_FACTORY
                services.AddHttpClient("weatherapi", client =>
                {
                    client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
                });
            #else
                services.AddHttpClient<IWeatherClient, OpenWeatherClient>(client =>
                {
                    client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
                });
            #endif
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
