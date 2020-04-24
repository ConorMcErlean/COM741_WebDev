using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SMS.Data.Services;
using SMS.Rest.Helpers;
using Microsoft.Extensions.Hosting;
using SMS.Rest.Controllers;

namespace SMS.Rest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {  
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
         
            // configure jwt authentication using extension method                      
            services.AddJwtSimple(appSettingsSection.Get<AppSettings>().Secret);

            services.AddCors(); 
            services.AddControllers();
      
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                StudentServiceSeeder.Seed(new StudentService());
            }

            app.UseHttpsRedirection();
            
            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();      
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();           
            });
        }
    }
}
