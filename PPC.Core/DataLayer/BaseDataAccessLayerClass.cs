using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.Win32;
using Microsoft.Data.SqlClient;
using PPC.Core;
using PPC.Base.Extensions;

namespace AtlasCellData.ADO
{

    public enum AggregateType { COUNT, SUM, AVG, MAX, MIN };

    public class BaseDataAccessLayerClass
    {
        //private static string _sqlServerName = @"192.168.20.88";
        //private static string _databaseName = "AtlasCellPPCDB";
        //private static string _databaseUserName = "AtlasCellPPCUsers";
        //private static string _databasePassword = "123321";
        //private static string _sqlServerInstanceName = "";

        public static string SqlServerName { get { return PPC.DatabaseSetting.ServerAddress; } }
        public static string DatabaseName { get { return PPC.DatabaseSetting.DatabaseName; } }
        public static string IPAddressCurrent { get; set; }
        public static string connString = "";
        public SqlCommand sqlCommand;
        public SqlTransaction sqlTransaction;
        public SqlConnection sqlConnection;
        public SqlDataAdapter sqlDataAdapter;
        public SqlDataReader sqlDataReader;
        protected bool shouldLoad = false;

        //public static string PPCDatabase
        //{

        //    get
        //    {
        //        try
        //        {

        //            string retValue;
        //            RegistryKey AMrKey;

        //            AMrKey = Registry.CurrentUser.OpenSubKey("AtlasCell", true);
        //            if (AMrKey == null)
        //            {
        //                AMrKey = Registry.CurrentUser.CreateSubKey("AtlasCell");
        //            }

        //            if (AMrKey.GetValue("DatabaseName") == null)
        //            {
        //                AMrKey.SetValue("DatabaseName", "AtlasCellPPCDB");

        //            }

        //            retValue = AMrKey.GetValue("DatabaseName").ToString();
        //            return retValue;

        //        }
        //        catch (Exception ex)
        //        {

        //            throw new Exception(Environment.UserDomainName+"#"+Environment.UserName+"#"+ex.Message);
        //        }

        //    }
        //}
        public static List<string> AtlasCellServers = new List<string>();


        internal BaseDataAccessLayerClass Parent;
        //===================================================================================================

        string strConnection;
        //===================================================================================================
        public BaseDataAccessLayerClass()
        {

            strConnection = ReadConnectionString();
            //sqlTransaction=new SqlTransaction();
            sqlConnection = new SqlConnection(strConnection);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);

        }
        //===================================================================================================

        public static string ReadConnectionString()
        {
            if (connString != "") return connString;
            try
            {
                string sqlConnectionStr = "workstation id={0};packet size=4096;user id=" + PPC.DatabaseSetting.DatabaseUserName +
                                             ";data source={1};persist security info=True;" +
                                             "initial catalog={2};password={3};Connection Timeout=30;TrustServerCertificate=True;";

                //string temp = @"workstation id=" + Environment.MachineName + @";packet size=1292;integrated security=SSPI;data source=";

                //string retValue;

                //retValue = BaseDataAccessLayerClass.IPAddressCurrent.ToEmptyString();

                //if (retValue.Length == 0)
                //{
                //    string key = "";
                //    string defualtIP = "";


                //    for (int i = 1; i <= 20; i++)
                //    {
                //        key = GetSettingValue("AtlasCellServer" + i.ToString());
                //        if (BaseDataAccessLayerClass.AtlasCellServers.IndexOf(key) == -1)
                //            BaseDataAccessLayerClass.AtlasCellServers.Add(key);
                //    }

                //    defualtIP = BaseDataAccessLayerClass.AtlasCellServers[0];
                //    try
                //    {
                //        defualtIP = GetSettingValue("AtlasCellServerDefault");
                //    }
                //    catch { }

                //    retValue = defualtIP;
                //    IPAddressCurrent = retValue;
                //}

                //temp += "\"" + retValue + "\";persist security info=False;initial catalog=" + PPC.DatabaseSetting.DatabaseName;// BaseDataAccessLayerClass.PPCDatabase;
                sqlConnectionStr = string.Format(sqlConnectionStr, Environment.MachineName, SqlServerName, PPC.DatabaseSetting.DatabaseName, PPC.DatabaseSetting.DatabasePassword);

                return sqlConnectionStr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return sqlConnectionStr
        }

        //===================================================================================================
        protected void OpenConnection()
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)

                    sqlConnection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public static bool CanConnectToSQLServer(string SQLServerName, out Exception ex)
        //{
        //    RegistryKey AMrKey;
        //    AMrKey = Registry.CurrentUser.OpenSubKey(_databaseName, true);
        //    string sqlConnectionStr = "workstation id={0};packet size=8192;user id=" + _databaseUserName +
        //                     ";data source={1};persist security info=True;" +
        //                     "initial catalog={2};password={3}";
        //    sqlConnectionStr = string.Format(sqlConnectionStr, Environment.MachineName, SQLServerName, _databaseName, _databasePassword);

        //    ex = new Exception();
        //    string temp = @"workstation id=" + Environment.MachineName + ";packet size=4096;integrated security=SSPI;data source=\"" + SQLServerName +
        //       "\";persist security info=False;initial catalog=" + _databaseName;

        //    SqlConnection connection = new SqlConnection(sqlConnectionStr);
        //    try
        //    {
        //        connection.Open();
        //    }
        //    catch (Exception ex1)
        //    {
        //        ex = ex1;
        //        return false;
        //    }

        //    BaseDataAccessLayerClass.IPAddressCurrent = SQLServerName;

        //    return true;
        //}
        //===================================================================================================
        protected void CloseConnection()
        {
            if (sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();

        }
        internal virtual void upwardShouldLoad() { }
        internal virtual void upwardShouldLoad(BaseDataAccessLayerClass child) { }

        #region Xml setting

        static string DatabaseSettingsPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "DatabaseSettings.xml");

        public static string GetSettingValue(string key)
        {
            try
            {
                if (!File.Exists(DatabaseSettingsPath))
                    return string.Empty;

                XmlDocument doc = new XmlDocument();
                doc.Load(DatabaseSettingsPath);

                XmlNodeList elemList;
                elemList = doc.GetElementsByTagName(key);//"PPCServer"

                return elemList.Count > 0 ? elemList[0].InnerText : "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static bool CreateSettingFiles()
        {
            try
            {

                bool result = true;

                XmlDocument doc = new XmlDocument();

                //(1) the xml declaration is recommended, but not mandatory
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);

                //(2) string.Empty makes cleaner code
                XmlElement element1 = doc.CreateElement(string.Empty, "configuration", string.Empty);
                doc.AppendChild(element1);

                XmlElement element2 = doc.CreateElement(string.Empty, "ServerSettings", string.Empty);
                element1.AppendChild(element2);

                XmlElement element2_1 = doc.CreateElement(string.Empty, "AtlasCellServer1", string.Empty);
                XmlText text2_1 = doc.CreateTextNode("192.168.0.1");
                element2_1.AppendChild(text2_1);
                element2.AppendChild(element2_1);

                XmlElement element2_1_1 = doc.CreateElement(string.Empty, "AtlasCellServer2", string.Empty);
                XmlText text2_1_1 = doc.CreateTextNode("192.168.0.2");
                element2_1.AppendChild(text2_1);
                element2.AppendChild(element2_1);

                XmlElement element2_2 = doc.CreateElement(string.Empty, "DatabaseName", string.Empty);
                XmlText text2_2 = doc.CreateTextNode("PPC");
                element2_2.AppendChild(text2_2);
                element2.AppendChild(element2_2);

                XmlElement element2_3 = doc.CreateElement(string.Empty, "SQL_INSTANCE_NAME", string.Empty);
                XmlText text2_3 = doc.CreateTextNode("");
                element2_3.AppendChild(text2_3);
                element2.AppendChild(element2_3);

                XmlElement element2_4 = doc.CreateElement(string.Empty, "UserName", string.Empty);
                XmlText text2_4 = doc.CreateTextNode("");
                element2_4.AppendChild(text2_4);
                element2.AppendChild(element2_4);

                XmlElement element3 = doc.CreateElement(string.Empty, "FactorySettings", string.Empty);
                element1.AppendChild(element3);

                XmlElement element3_1 = doc.CreateElement(string.Empty, "Factory", string.Empty);
                XmlText text2 = doc.CreateTextNode("Plate");
                element3_1.AppendChild(text2);
                element3.AppendChild(element3_1);

                doc.Save(DatabaseSettingsPath);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion
    }

    public class Transaction
    {

        internal SqlTransaction sqlTransaction;
        public Transaction()
        {

        }
        public void StartTransaction()
        {
            BaseDataAccessLayerClass b = new BaseDataAccessLayerClass();
            if (b.sqlConnection.State == ConnectionState.Closed)
                b.sqlConnection.Open();
            sqlTransaction = b.sqlConnection.BeginTransaction();
        }
        public void Rollback()
        {
            sqlTransaction.Rollback();
            //this=null;
        }
        public void Commit()
        {

            sqlTransaction.Commit();
            //this=null;
        }
    }

}

