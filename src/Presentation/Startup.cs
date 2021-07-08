namespace Presentation
{
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using GraphQL.Base;

    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config) => _config = config;

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _config.GetSection("Database").GetValue<string>("ConnectionString");

            services.AddDbContext<Context>(options => options.UseMySQL(connectionString));
            services.AddControllers();

            services.AddScoped<Schema>();
        }

        public void Configure(IApplicationBuilder app, Context context)
        {
            ConfigureEnvironment(app);
            ConfigureDatabase(context);
            ConfigureEndpoints(app);
        }

        private void ConfigureEnvironment(IApplicationBuilder app)
        {
            string environmentVariable = _config.GetValue<string>("environment");
            if (environmentVariable == "Default")
            {
                app.UseDeveloperExceptionPage();
            }
        }

        private static void ConfigureEndpoints(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void ConfigureDatabase(Context context) => context.Database.Migrate();
    }
}
