using Biblioteka.Hubs;
using Domen;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Podaci;
using Podaci.Implementacija;
using Podaci.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka
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
            services.AddScoped<IUnitOfWork, BibliotekaUnitOfWork>();
            services.AddScoped<IRepositoryKorisnik,RepositoryKorisnik>();
            services.AddScoped<IRepositoryKnjiga, RepositoryKnjiga>();
            services.AddScoped<IRepositoryKorisnik, RepositoryKorisnik>();
            services.AddScoped<IRepositoryRezervacija, RepositoryRezervacija>();
            services.AddScoped<IRepositoryZahtev, RepositoryZahtev>();
            services.AddScoped< BibliotekaHub > ();
            services.AddDbContext<BibliotekaContext>(options =>
         options.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = Biblioteka; "));
            services.AddControllersWithViews();

            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            services.AddControllersWithViews()
              .AddNewtonsoftJson(options =>
                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );
            services.AddMvc();
  
            services.AddSignalR(o =>
            {
              
                
                o.EnableDetailedErrors = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Korisnik}/{action=SignIn}/{id?}");
                endpoints.MapHub<BibliotekaHub>("/bibliotekaHub");
     
            });
            
        }
    }
}
