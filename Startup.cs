using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using laundry.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace laundry
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if ( Environment.IsDevelopment() )
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlite(
                Configuration.GetConnectionString("DefaultConnection")));
                services.AddDatabaseDeveloperPageExceptionFilter();
            } else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                Configuration.GetConnectionString("LaundryContext")));
            }

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

/*             app.MapWhen(
                context => 
                    context.Request.Method == "GET" &&

                    
                    context.Request.Path == "/Api/Cron",
                config =>
                    config.Use(async (context, next) => {
                        Cronie cronie = new Cronie(new ApplicationDbContext());
                        await context.Response.WriteAsync(cronie.CronJob());
                    } 
                )
            ); */

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
 /*        class Cronie {
        private readonly laundry.Data.ApplicationDbContext _context;

        public Cronie(laundry.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Laundry> Laundry { get;set; }
            public string CronJob() {
            IEnumerable<laundry.Data.Laundry> NeedsAttention = 
                from wash in _context.Laundry
                where wash.Attention == true
                select wash;
            
            foreach(var wash in NeedsAttention) {
                Console.WriteLine(wash.Status);
            }
            
            return $"200 OK\n\r\n\r";
        }
        } */
    }
}
