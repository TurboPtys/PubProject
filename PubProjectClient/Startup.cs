using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PubProjectClient.Data;
using PubProjectClient.Models;
using PubProjectClient.Services;
using PubProjectApi.Models;

namespace PubProjectClient
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
            services.AddDbContext<PubProjectApi.Models.ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<PubProjectApi.Models.ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

            services.AddAuthentication();
            services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Account2/Login");
            services.ConfigureApplicationCookie(opts => opts.AccessDeniedPath = "/Account2/Login");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //app.UseIdentity();
            app.UseStaticFiles();

            //var alreadyExists = roleManager.RoleExistsAsync("Admin");
            //if (!alreadyExists.Result)
            //    roleManager.CreateAsync(new IdentityRole("Admin"));
            //var alreadyExists2 = roleManager.RoleExistsAsync("User");
            //if (!alreadyExists2.Result)
            //    roleManager.CreateAsync(new IdentityRole("User"));
            //var alreadyExists3 = roleManager.RoleExistsAsync("GastronomicVenueOwner");
            //if (!alreadyExists3.Result)
            //    roleManager.CreateAsync(new IdentityRole("GastronomicVenueOwner"));

            app.UseAuthentication();
           // app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
