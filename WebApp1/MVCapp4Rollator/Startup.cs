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
using MVCapp4Rollator.Data;
using MVCapp4Rollator.Models;
using MVCapp4Rollator.Services;

namespace MVCapp4Rollator
{
    // Kørt når app starter.
    public class Startup 
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Tilføj services til IserviceCollection..
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();                                       // tilføj Model View Controller
        }

        // Configurer HTTP request pipeline.
        // IApplicationBuilder = En klasse der giver mulighed for at ændre i "Request pipelinen"
        // IHostingEnvironment = Information om web hosting miljøet applicationen køre i.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())            // kun inkluder følgende i dev-mode
            {
                app.UseBrowserLink();                   //refreash app i flere web browsers på en gang. Bruger SignalR til at kommunikere imellem browser og VS. VS=SignalR server
                app.UseDeveloperExceptionPage();        //Giver dev detailed error pages
                app.UseDatabaseErrorPage();             //HTML response fra Sync + Async database relaterede exceptions fra pibelinen som EntityFrameWork mirgration kan løse. 
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); // Hvis fejl hvis det ikke er i dev-enviorment 
            }

            app.UseStaticFiles();               // Gør fil servering mulig. std path wwwroot. program.cs 

            app.UseAuthentication();            // init default auth.

            app.UseMvc(routes =>                //default route, home controller. Index action og optinal id?.
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
