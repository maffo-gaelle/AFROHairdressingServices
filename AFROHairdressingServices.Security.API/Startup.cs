using GS = HairdressingServices.Api.Models.Global.Services;
using GR = HairdressingServices.Api.Models.Global.Repositories;
using HairDressingServices.Api.Models.Client.Services;
using HairDressingServices.Api.Models.Client.Repositories;
using HairdressingServices.Tools;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFROHairdressingServices.Security.API.Infrastructures.Security;

namespace AFROHairdressingServices.Security.API
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
            services.AddSingleton(sp => new Connection(SqlClientFactory.Instance, Configuration.GetConnectionString("HairdressingProject")));
            services.AddSingleton<GR.IAuthRepository, GS.UserService>();
            services.AddSingleton<GR.IProfessionnalCategoryRepository, GS.ProfessionnalCategoryService>();
            services.AddSingleton<GR.ICommentRepository, GS.CommentService>();
            services.AddSingleton<GR.IAvisRepository, GS.AvisService>();
            services.AddSingleton<GR.IUserCategoryProfessionnalRepository, GS.UserCategoryProfessionnalService>();
            services.AddSingleton<GR.ILocalityRepository, GS.LocalityService>();
            services.AddSingleton<GR.IUserLocalityRepository, GS.UserLocalityService>();
            services.AddSingleton<IAuthRepository, UserService>();
            services.AddSingleton<IProfessionnalCategoryRepository, ProfessionnalCategoryService>();
            services.AddSingleton<ICommentRepository, CommentService>();
            services.AddSingleton<IAvisRepository, AvisService>();
            services.AddSingleton<IUserCategoryProfessionnalRepository, UserCategoryProfessionnalService>();
            services.AddSingleton<ILocalityRepository, LocalityService>();
            services.AddSingleton<IUserLocalityRepository, UserLocalityService>();
            services.AddSingleton<ITokenRepository, TokenService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AFROHairdressingServices.Security.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AFROHairdressingServices.Security.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
