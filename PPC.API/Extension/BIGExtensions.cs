using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PPC.Core.Repository;
using PPC.Core.Interface;
using PPC.Core.Services;
using Microsoft.Extensions.Configuration;
using PPC.Core.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Extensions.Logging;
using PPC.Base;
using Microsoft.AspNetCore.Builder;
using System.IO;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PPC.Core.Models;
using AC_PPC.Response.DTOs;
using PPC.Response.DTOs;

namespace WebApi.Extension
{

    public static class BIGExtensions
    {

        public static void ConfigAntiforgery(this IServiceCollection services)
        {
            services.AddAntiforgery(x => x.HeaderName = "X-XSRF-TOKEN");
            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
        }

        public static void ConfigBIGServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAntiForgeryCookieService, AntiForgeryCookieService>();

            // Unit of work Using Entity Framework Core
            services.AddTransient<IRepositoryFactory, RepositoryFactory>();

            //services.AddTransient<ITokenManager, TokenManager>();
            services.AddScoped<IUserAccountService, UserAccountService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddSingleton<ISecurityService, SecurityService>();
            services.AddScoped<ITokenStoreService, TokenStoreService>();
            services.AddScoped<ITokenValidatorService, TokenValidatorService>();
            services.AddScoped<ITokenFactoryService, TokenFactoryService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IStationsService, StationsService>();
            services.AddScoped<IUnitsService, UnitsService>();
            services.AddScoped<IRawMaterialGroupsService, RawMaterialGroupsService>();
            services.AddScoped<IRawMaterialsService, RawMaterialsService>();
            //services.AddScoped<ICustomerDraftService, CustomerDraftService>();
            //services.AddScoped<ICustomerDraftPaletsBobinsService, CustomerDraftPaletsBobinsService>();
            services.AddScoped<IProvincesService, ProvincesService>();
            services.AddScoped<ICustomersService, CustomersService>();
            //            services.AddScoped<IPaletsService, PaletsService>();
            //services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IDomainService, DomainService>();
            services.AddScoped<ICustomerGradesService, CustomerGradesService>();
            services.AddScoped<ISaleAgentsService, SaleAgentsService>();
            services.AddScoped<IPrintingTechniquesService, PrintingTechniquesService>();
            services.AddScoped<IProductGroupTypesService, ProductGroupTypesService>();
            services.AddScoped<IProductGroupsService, ProductGroupsService>();
            services.AddScoped<IProductTypesService, ProductTypesService>();
            services.AddScoped<IProductSeriesService, ProductSeriesService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IProductSerieTechniqueAssignsService, ProductSerieTechniqueAssignsService>();
            services.AddScoped<IRawMaterialGroupTypesService, RawMaterialGroupTypesService>();
            services.AddScoped<ISuppliersService, SuppliersService>();
            services.AddScoped<ITestPlanGroupsService, TestPlanGroupsService>();
            services.AddScoped<ITestPlanIndexesService, TestPlanIndexesService>();
            services.AddScoped<ICountriesService, CountriesService>();
            services.AddScoped<IInstructionsService, InstructionsService>();
            services.AddScoped<ITestPlansService, TestPlansService>();
            services.AddScoped<ITestPlanDetailsService, TestPlanDetailsService>();
            services.AddScoped<ITestPlanGroupTypeAssignsService, TestPlanGroupTypeAssignsService>();
            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<ISettingUpdatesService, SettingUpdatesService>();
            services.AddScoped<ISettingGeneralsService, SettingGeneralsService>();
            services.AddScoped<IMenuAccessStatesService, MenuAccessStatesService>();
            services.AddScoped<IDenyAccessesService, DenyAccessesService>();
            services.AddScoped<ILoginLogsService, LoginLogsService>();
            services.AddScoped<ILogsService, LogsService>();
            services.AddScoped<IUserGroupsService, UserGroupsService>();
            services.AddScoped<IUserGroupStationsService, UserGroupStationsService>();
            services.AddScoped<IUserGroupAssignsService, UserGroupAssignsService>();
            services.AddScoped<IStationTypesService, StationTypesService>();
            services.AddScoped<IPackagingPlansService, PackagingPlansService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IOrderDetailsService, OrderDetailsService>();
            services.AddScoped<IDensityOfProductsService, DensityOfProductsService>();
            services.AddScoped<IRawMaterialLotNumbersService, RawMaterialLotNumbersService>();
            services.AddScoped<ITestPlanAssignService, TestPlanAssignService>();
            services.AddScoped<ITestPlanAssignDetailService, TestPlanAssignDetailService>();
            services.AddScoped<IPackagingTypesService, PackagingTypesService>();
            services.AddScoped<IInvRawMaterialsService, InvRawMaterialsService>();
            services.AddScoped<IInvRawMaterialLotsService, InvRawMaterialLotsService>();
            services.AddScoped<ITestPlanCodeCharService, TestPlanCodeCharService>();
            services.AddScoped<IOrderDetailPackagingsService, OrderDetailPackagingsService>();
            services.AddScoped<IAutoCompleteFieldService, AutoCompleteFieldService>();
            services.AddScoped<ITestPlanBasicIndexService, TestPlanBasicIndexService>();
            services.AddScoped<IRMWhiteListsService, RMWhiteListsService>();
            services.AddScoped<IRawMaterialWhiteListAssignService, RawMaterialWhiteListAssignService>();
            services.AddScoped<IRawMaterialConfirmationService, RawMaterialConfirmationService>();
            services.AddScoped<IBOMService, BOMService>();
            services.AddScoped<IBOMDetailService, BOMDetailService>();
            services.AddScoped<IBOMComplementaryService, BOMComplementaryService>();
            services.AddScoped<ICustomerDossierService, CustomerDossierService>();
            services.AddScoped<ICustomerDossierBOMsService, CustomerDossierBOMsService>();
            services.AddScoped<IProductionPlanPatilsCapacityService, ProductionPlanPatilsCapacityService>();
            services.AddScoped<IProductionPlanPackagingService, ProductionPlanPackagingService>();
            services.AddScoped<IProductionPlansService, ProductionPlansService>();
            services.AddScoped<IProductionPlanBOMDetailRevisedService, ProductionPlanBOMDetailRevisedService>(); 
            services.AddScoped<IProductionPlanBOMDetailService, ProductionPlanBOMDetailService>();
            services.AddScoped<IProductionPlanPatilsService, ProductionPlanPatilsService>();
            services.AddScoped<IDeliveryRawMaterialToProductionService, DeliveryRawMaterialToProductionService>();
            services.AddScoped<IDeliveryRawMaterialToProductionDetailService, DeliveryRawMaterialToProductionDetailService>();
            services.AddScoped<IDeliveryRawMaterialToProductionPatilsService, DeliveryRawMaterialToProductionPatilsService>();
            services.AddScoped<IRawMaterialsDeliveredToProductionService, RawMaterialsDeliveredToProductionService>();
            services.AddScoped<IRawMaterialsDeliveredToProductionDetailService, RawMaterialsDeliveredToProductionDetailService>();
            services.AddScoped<IDataProductionService, DataProductionService>();
            services.AddScoped<IDataGrindingDetailService, DataGrindingDetailService>();
            services.AddScoped<IDataDosingDetailService, DataDosingDetailService>();
            services.AddScoped<IPatilsService, PatilsService>();
            services.AddScoped<IWeightingProductsService, WeightingProductsService>();
            services.AddScoped<IWeightingProductDetailService, WeightingProductDetailService>();
            services.AddScoped<IInvProductsService, InvProductsService>();
            services.AddScoped<ILabelService, LabelService>();
            services.AddScoped<IPaletsService, PaletsService>();
            services.AddScoped<IPaletDetailService, PaletDetailService>();
            services.AddScoped<ICustomerDraftsService, CustomerDraftsService>();
            services.AddScoped<ICustomerDraftPaletsService, CustomerDraftPaletsService>();
            services.AddScoped<IOrderBOMRevisionsService, OrderBOMRevisionsService>();
            services.AddScoped<IExcelExportSettingService, ExcelExportSettingService>();
            services.AddScoped<IExcelExportSettingDetailService, ExcelExportSettingDetailService>();
            services.AddScoped<IInvTypesService, InvTypesService>();
            services.AddScoped<ICardInvDetailsService, CardInvDetailsService>();
            services.AddScoped<ICardTypesService, CardTypesService>();
            services.AddScoped<IInvProductionRawMaterialsService, InvProductionRawMaterialsService>();
            services.AddScoped<ICardInvService, CardInvService>();
            services.AddScoped<IRawMaterialLotsInventoryService, RawMaterialLotsInventoryService>();
            services.AddScoped<IProductionPlanReworksService, ProductionPlanReworksService>();
            services.AddScoped<IProductionPlanReworkDetailsService, ProductionPlanReworkDetailsService>();
            services.AddScoped<IRevertsService, RevertsService>();
            services.AddScoped<IRevertPaletsService, RevertPaletsService>();
            //services.AddScoped<IService, Service>();
            //services.AddScoped<IService, Service>();
            //services.AddScoped<IService, Service>();
            //services.AddScoped<IService, Service>();
            //services.AddScoped<IService, Service>();
            //services.AddScoped<IService, Service>();
            //services.AddScoped<IService, Service>();
            //services.AddScoped<IService, Service>();
            services.AddScoped<ITestService, TestService>();

            services.AddScoped<IAuditService, AuditService>();


            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.FullName.Contains("PPC.Core"));
            if (assembly == null) return;
            foreach (var type in assembly.GetTypes())
            {
                var serviceAttribute = type.GetCustomAttribute<ServiceMapToAttribute>();

                if (serviceAttribute != null)
                {
                    switch (serviceAttribute.Lifetime)
                    {
                        case ServiceLifetime.Singleton:
                            services.AddSingleton(serviceAttribute.ServiceType, type);
                            break;
                        case ServiceLifetime.Scoped:
                            services.AddScoped(serviceAttribute.ServiceType, type);
                            break;
                        case ServiceLifetime.Transient:
                            services.AddTransient(serviceAttribute.ServiceType, type);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public static void ConfigJwtBearer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(RolesHandler.Admin, policy => policy.RequireRole(RolesHandler.Admin));
                options.AddPolicy(RolesHandler.User, policy => policy.RequireRole(RolesHandler.User));
                options.AddPolicy(RolesHandler.Editor, policy => policy.RequireRole(RolesHandler.Editor));
                options.AddPolicy(RolesHandler.AdminOrUser,
                        policy => policy.RequireAssertion(
                             (context) =>
                             {
                                 return context.User.IsInRole("Admin") ||
                                        (
                                             context.User.IsInRole("User")
                                        //&&
                                        //context.User.HasClaim(p => p.Type == "CanGetDefinition")
                                        );
                             }));
            });



            // Needed for jwt auth.
            services
                .AddAuthentication(options =>
                {
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = configuration["JwtConfig:Issuer"], // site that makes the token
                        ValidateIssuer = false, // TODO: change this to avoid forwarding attacks
                        ValidAudience = configuration["JwtConfig:Audience"], // site that consumes the token
                        ValidateAudience = false, // TODO: change this to avoid forwarding attacks
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:Key"])),
                        ValidateIssuerSigningKey = true, // verify signature to avoid tampering
                        ValidateLifetime = true, // validate the expiration
                        ClockSkew = TimeSpan.Zero // tolerance for the expiration date
                    };
                    cfg.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                            logger.LogError("Authentication failed.", context.Exception);
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            var tokenValidatorService = context.HttpContext.RequestServices.GetRequiredService<ITokenValidatorService>();
                            return tokenValidatorService.ValidateAsync(context);
                        },
                        OnMessageReceived = context =>
                        {
                            return Task.CompletedTask;
                        },
                        OnChallenge = context =>
                        {
                            var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                            logger.LogError("OnChallenge error", context.Error, context.ErrorDescription);
                            return Task.CompletedTask;
                        }
                    };
                });
        }

        public static void ConfigJWT(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<JwtConfigOptions>()
                                .Bind(configuration.GetSection("JwtConfig"))
                                .Validate(JwtConfig =>
                                {
                                    return JwtConfig.ATExpires < JwtConfig.RTExpires;
                                }, "Refresh Token Expiration Minutes is less than Access Token Expiration Minutes. please change refresh token.");
            services.AddOptions<ApiSettings>()
                    .Bind(configuration.GetSection("ApiSettings"));
        }


        public static void ConfigCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .WithOrigins("http://192.168.8.28:44377") //Note:  The URL must be specified without a trailing slash (/).
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetIsOriginAllowed((host) => true)
                        .AllowCredentials());
            });
        }

        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(
                    url: "/swagger/PPCAPI/swagger.json",
                    name: "Library API");
                //setupAction.RoutePrefix = ""; //--> To be able to access it from this URL: https://192.168.8.28:5001/swagger/index.html

                setupAction.DefaultModelExpandDepth(2);
                setupAction.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
                setupAction.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                setupAction.EnableDeepLinking();
                //setupAction.DisplayOperationId();
            });
        }

        public static void ConfigSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(setupAction =>
            {

                setupAction.SwaggerDoc(
                   name: "PPCAPI",
                  info: new Microsoft.OpenApi.Models.OpenApiInfo()
                  {
                      Title = "BIG API",
                      Version = "v1",
                      Description = "Backend Bayazian Indistrial Group",
                      Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                      {
                          Name = "Farshad Parsa",
                          Email = "Parsa.Polfilm@gmail.com",
                      }
                  });

                var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => setupAction.IncludeXmlComments(xmlFile));

                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Value: Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                       },
                        new List<string>()
                    }
                }
                );
            });
        }

    }
}


