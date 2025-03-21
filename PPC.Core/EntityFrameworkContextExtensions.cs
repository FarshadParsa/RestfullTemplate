using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;


namespace PPC.Core
{
    public static class EntityFrameworkContextExtensions
    {
        public static void ConfigBIGDb(this IServiceCollection services, IConfiguration configuration)
        {
            PPC.DatabaseSetting.ServerAddress = configuration["DbConnector:dbServerAddress"];
            PPC.DatabaseSetting.DatabaseName = configuration["DbConnector:databaseName"];

            ConfigurationCache.DbConnector = new DbConnector
            {
                Provider = DbProvider.SQLServer,
                //ConnectionString = configuration["DbConnector:ConnectionString"]
                ConnectionString = $"Data Source={PPC.DatabaseSetting.ServerAddress};Initial Catalog={PPC.DatabaseSetting.DatabaseName};" +
                $"User ID={PPC.DatabaseSetting.DatabaseUserName};Password={PPC.DatabaseSetting.DatabasePassword};TrustServerCertificate=True;"
            };

            services.AddDbContext<PPCDbContext>();
            using (var ctx = new PPCDbContext())
            {
                //ctx.Database.EnsureCreated();
            }
        }
    }
}
