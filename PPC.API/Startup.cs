using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Extension;
using Microsoft.Extensions.Hosting;
using PPC.Core;
using PPC.Core.Repository;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using PPC.API.Middleware;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PPC.Common.Auth;
using PPC.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Options;

namespace PPC.API
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
            #region configure Swagger
            services.ConfigSwagger();
            services.ConfigJWT(Configuration);
            #endregion configure Swagger

            #region configure DI Services
            services.ConfigBIGServices();
            
            services.AddScoped<ExtAutoMapper>();


            #region DBContex

            services.AddScoped<IUnitOfWork, UnitOfWork<PPCDbContext>>();

            //services.AddDbContext<PPCDbContext>((provider, options) =>
            //{
            //    options.UseSqlServer(DatabaseSetting.ConnectionString)
            //           .UseLazyLoadingProxies(); // فعال کردن Lazy Loading
            //});
            //services.AddScoped<IRepositoryFactory, RepositoryFactory>();

            #endregion


            services.TryAddSingleton<IUser, User>();
            services.ConfigBIGDb(Configuration);

            #endregion configure DI Services
           
            #region configure CorsPolicy JwtBearer
            services.ConfigJwtBearer(Configuration);
            services.ConfigCors();
            services.ConfigAntiforgery();
            #endregion configure CorsPolicy JwtBearer

            #region configure Controllers
            services.AddControllers(
                config =>
                {
                    config.Filters.Add(typeof(AuditFilterAttribute));
                });
            #endregion configure Controllers

            #region configure AutpMapper

            services.AddAutoMapper(typeof(Startup));

            #endregion

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            #region configure  ExceptionHandler
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Use(async (context, next) =>
                {
                    var error = context.Features[typeof(IExceptionHandlerFeature)] as IExceptionHandlerFeature;
                    if (error?.Error is SecurityTokenExpiredException)
                    {
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            State = 401,
                            Msg = "token expired"
                        }));
                    }
                    else if (error?.Error != null)
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            State = 500,
                            Msg = error.Error.Message
                        }));
                    }
                    else
                    {
                        await next();
                    }
                });
            });
            #endregion configure ExceptionHandler

            app.UseStatusCodePages();

            app.UseCustomSwagger();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseCors("CorsPolicy");

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