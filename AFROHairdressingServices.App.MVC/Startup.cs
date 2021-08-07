using HairdressingServices.MVC.Client.Repositories;
using HairdressingServices.MVC.Client.Services;
using GR = HairdressingServices.MVC.Global.Repositories;
using GS = HairdressingServices.MVC.Global.Services;
using HairdressingServices.Tools;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using AFROHairdressingServices.App.MVC.Infrastructures.Session;
using System.Data.SqlClient;

namespace AFROHairdressingServices.App.MVC
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
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();

            services.AddTransient(sp =>
            {
                HttpClient client = new HttpClient() { BaseAddress = new Uri("https://localhost:6001/") };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                ISessionManager sessionManager = sp.GetService<ISessionManager>();

                if (sessionManager.User is not null)
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionManager.User.Token);
                return client;

            });
            services.AddSingleton(sp => new Connection(SqlClientFactory.Instance, Configuration.GetConnectionString("HairdressingProject")));
            services.AddScoped<GR.IAuthRepository, GS.UserService>();
            services.AddScoped<GR.IProfessionnalCategoryRepository, GS.ProfessionnalCategoryService>();
            services.AddScoped<GR.ICommentRepository, GS.CommentService>();
            services.AddScoped<GR.IAvisRepository, GS.AvisService>();
            services.AddScoped<GR.IUserCategoryProfessionnalRepository, GS.UserCategoryProfessionnalService>();
            services.AddScoped<IAuthRepository, UserService>();
            services.AddScoped<IProfessionnalCategoryRepository, ProfessionnalCategoryService>();
            services.AddScoped<ICommentRepository, CommentService>();
            services.AddScoped<IAvisRepository, AvisService>();
            services.AddScoped<IUserCategoryProfessionnalRepository, UserCategoryProfessionnalService>();
            //services.AddScoped<ILocalityRepository, UserCategoryProfessionnalService>();
            services.AddScoped<ISessionManager, SessionManager>();

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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
