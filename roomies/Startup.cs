using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using roomies.Models;
using roomies.Models.Repository;

namespace roomies
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<RoomiesDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("RoomiesDb"));
            });
            services.AddControllers();
            services.AddMvc(option=> option.EnableEndpointRouting=false)
                .AddNewtonsoftJson(opt=>opt.SerializerSettings.ReferenceLoopHandling=ReferenceLoopHandling.Ignore);

            services.AddScoped<IUserRepository,SqlUserRepository>();
            services.AddScoped<IRoomRepository,SqlRoomRepository>();
            services.AddControllers();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=UserController}/{action=User}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
