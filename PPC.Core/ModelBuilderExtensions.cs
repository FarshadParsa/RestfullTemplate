using Microsoft.EntityFrameworkCore;

namespace PPC.Core
{
    public static class ModelBuilderExtensions
    {
        public static DbContextOptionsBuilder UseDatabase(this DbContextOptionsBuilder builder)
        {
            var conn = ConfigurationCache.DbConnector.ConnectionString;
            switch (ConfigurationCache.DbConnector.Provider)
            {
                case DbProvider.SQLServer:
                    builder.UseSqlServer(conn);
                    break;
            }
            return builder;
        }
    }
}
