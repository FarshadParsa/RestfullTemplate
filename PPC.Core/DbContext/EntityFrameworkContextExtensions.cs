using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;


namespace WebApi.Core
{
    public static class EntityFrameworkContextExtensions
    {
        public static void ConfigBIGDb(this IServiceCollection services, IConfiguration configuration)
        {
            DatabaseSetting.ServerAddress = configuration["DbConnector:dbServerAddress"];
            DatabaseSetting.DatabaseName = configuration["DbConnector:databaseName"];

            ConfigurationCache.DbConnector = new DbConnector
            {
                Provider = DbProvider.SQLServer,
                //ConnectionString = configuration["DbConnector:ConnectionString"]
                ConnectionString = $"Data Source={DatabaseSetting.ServerAddress};Initial Catalog={DatabaseSetting.DatabaseName};" +
                $"User ID={DatabaseSetting.DatabaseUserName};Password={DatabaseSetting.DatabasePassword};TrustServerCertificate=True;"
            };

            services.AddDbContext<ApplicationDbContext>();
            using (var ctx = new ApplicationDbContext())
            {
                //ctx.Database.EnsureCreated();
            }
        }
    }
}
