using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;

namespace ASP.Server
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
            services.AddDbContext<LibraryDbContext>(options => options.UseInMemoryDatabase("LibraryDatabase"));
            services.AddControllersWithViews().AddNewtonsoftJson().AddRazorRuntimeCompilation();;
            services.AddSwaggerDocument();
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
            ASP_Server.UseSwaggerUi3();
            ASP_Server.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            using (var scope = ASP_Server.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var libraryDbContext = services.GetRequiredService<LibraryDbContext>();
                DbInitializer.Initialize(libraryDbContext);
            }
        }
    }
}
