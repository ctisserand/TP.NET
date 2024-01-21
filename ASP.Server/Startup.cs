using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;
using System.Globalization;

namespace ASP.Server
{

    public class Startup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; } = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LibraryDbContext>(options => options.UseInMemoryDatabase("LibraryDatabase"));
            services.AddControllersWithViews().AddNewtonsoftJson().AddRazorRuntimeCompilation();;
            services.AddSwaggerDocument();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddMvc();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder ASP_Server, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                ASP_Server.UseDeveloperExceptionPage();
            }
            else
            {
                ASP_Server.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                ASP_Server.UseHsts();
            }
            ASP_Server.UseHttpsRedirection();
            ASP_Server.UseStaticFiles();
            ASP_Server.UseRouting();
            ASP_Server.UseAuthorization();
            ASP_Server.UseOpenApi();
            ASP_Server.UseSwaggerUi();
            ASP_Server.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            using (var scope = ASP_Server.ApplicationServices.CreateScope())
            {
                DbInitializer.Initialize(scope.ServiceProvider.GetRequiredService<LibraryDbContext>());
            }
        }
    }
}
