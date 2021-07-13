using GtecClinica.Abstrato.Servico.Interfaces;
using GtecClinica.Dados.Contexto;
using GtecClinica.Servico;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GtecClinica.Web
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddMvc(options =>
            {
            })
            .AddViewOptions(options => {
                options.HtmlHelperOptions.ClientValidationEnabled = true;
            }).AddSessionStateTempDataProvider();

            services.AddSession();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Login/Index");
                options.LogoutPath = new PathString("/Login/Logout");
                options.AccessDeniedPath = new PathString("/Erro/403");
                options.ExpireTimeSpan = new TimeSpan(0, 120, 0);
                options.Cookie = new CookieBuilder()
                {
                    Name = "Gtec",
                };
            });

            services.AddMemoryCache();

            services.AddDbContext<GtecContexto>(options => options.UseSqlServer(Configuration.GetConnectionString("GtecCon")));

            services.AddHttpContextAccessor();
            services.AddScoped<ITesteServico, TesteServico>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            
            app.UseStaticFiles();
           
            app.UseSession();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
