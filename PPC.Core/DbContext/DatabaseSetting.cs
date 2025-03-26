using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core
{
    public class DatabaseSetting
    {

        private static string _serverAdress = @"127.0.0.1";
        private static string _databaseName = "DB";
        private static string _databaseUserName = "DBCUsers";
        private static string _databasePassword = "123456";
        private static string _sqlServerInstanceName = "";

        public static string ConnectionString
        {
            get
            {

                string cString = $"Data Source={ServerAddress};Initial Catalog={DatabaseName};" +
                    $"User ID={DatabaseUserName};Password={DatabasePassword};TrustServerCertificate=True;";

                return cString;

            }
        }

        internal static string ServerAddress
        {
            get => _serverAdress;
            set { if (value != _serverAdress) _serverAdress = value; }
        }

        internal static string DatabaseName
        {
            get => _databaseName;
            set { if (value != _databaseName) _databaseName = value; }
        }

        internal static string DatabaseUserName
        {
            get => _databaseUserName;
            set { if (value != _databaseUserName) _databaseUserName = value; }
        }


        internal static string DatabasePassword
        {
            get => _databasePassword;
            set{if (value != _databasePassword) _databasePassword = value;}
        }


        internal static string SqlServerInstanceName
        {
            get => _sqlServerInstanceName;
            set { if (value != _sqlServerInstanceName) _sqlServerInstanceName = value; }
        }





    }
}
