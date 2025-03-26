using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace WebApi.Core
{
    public static class ConfigurationCache
    {

        public static DbConnector DbConnector { get; set; }

        public static IServiceProvider RootServiceProvider { get; set; }

        static ConfigurationCache()
        {
        }
    }

    public class DbConnector
    {
        public DbProvider Provider { get; set; }
        public string ConnectionString { get; set; }
    }

    public enum DbProvider
    {
        SQLServer
    }
}
