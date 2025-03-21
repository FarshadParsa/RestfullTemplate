using System;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.Linq;
using PPC.Base.Extensions;
using PPC.Core.Models;
using System.Collections.Generic;

namespace AtlasCellData.ADO
{
    public class SettingUpdateViewModelDL : BaseDataAccessLayerClass
    {
        public static List<SettingUserViewModel> getVersionUsers(string version)
        {
            if (version.Length.Equals(0))
                return null;

            BaseDataAccessLayerClass b = new BaseDataAccessLayerClass();
            SqlCommand sqlCommand = b.sqlCommand;
            SqlTransaction sqlTransaction = b.sqlTransaction;
            SqlConnection sqlConnection = b.sqlConnection;
            SqlDataAdapter sqlDataAdapter = b.sqlDataAdapter;
            SqlDataReader sqlDataReader = b.sqlDataReader;
            string strSQL = "";
            //strSQL = string.Format(@"SELECT   cast( Setting.SettingID as int) SettingID,LastVersion, dbo.[User].UserID, dbo.[User].FullName, ISNULL(Setting.LastVersionWarninType, 0) AS LastVersionWarninType, ISNULL(Setting.IsActive, 0) AS IsActive
            //                        FROM         dbo.[User] LEFT OUTER JOIN
            //                        (SELECT     SettingID, LastVersion, LastVersionWarninType, UserID, StationID, IsActive
            //                        FROM          dbo.Setting AS Setting_1
            //                        WHERE      (LastVersion = '{0}')) AS Setting ON dbo.[User].UserID = Setting.UserID WHERE (dbo.[User].IsActive = 1) AND Setting.stationID is null",
            //        version);

            strSQL = string.Format(@"SELECT   cast( Setting.SettingID as int) SettingID,LastVersion, dbo.[User].UserID, dbo.[User].FullName, ISNULL(Setting.LastVersionWarninType, 0) AS LastVersionWarninType, ISNULL(Setting.IsActive, 0) AS IsActive
                                   FROM         dbo.[User] LEFT OUTER JOIN
                                    (SELECT     cast( SettingID as int) SettingID, LastVersion, LastVersionWarninType, UserID, StationID, IsActive
                                    FROM          dbo.Setting AS Setting_1
                                    WHERE      (LastVersion = '{0}')) AS Setting ON dbo.[User].UserID = Setting.UserID WHERE (dbo.[User].IsActive = 1) AND Setting.stationID is null",
        version);


            sqlCommand.CommandText = strSQL;
            if (sqlConnection.State == ConnectionState.Closed)
                try { sqlConnection.Open(); }
                catch (Exception ex) { throw; }
            sqlCommand.CommandType = CommandType.Text;
            try
            {
                DataSet DS = new DataSet();
                sqlDataAdapter.Fill(DS);

                //var lst = DS.Tables[0].ConvertDataTableToList<SettingUserViewModel>();
                var lst = DS.Tables[0].ConvertDataTableToList<SettingUserViewModel>();

                return lst;// DS.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static List<SettingStationViewModel> getVersionStations(string version)
        {
            if (version.Length.Equals(0))
                return null;

            BaseDataAccessLayerClass b = new BaseDataAccessLayerClass();
            SqlCommand sqlCommand = b.sqlCommand;
            SqlTransaction sqlTransaction = b.sqlTransaction;
            SqlConnection sqlConnection = b.sqlConnection;
            SqlDataAdapter sqlDataAdapter = b.sqlDataAdapter;
            SqlDataReader sqlDataReader = b.sqlDataReader;
            string strSQL = "";

            strSQL = string.Format(@"SELECT   cast( Setting.SettingID as int) SettingID, dbo.[Station].StationID, dbo.[Station].StationName, ISNULL(Setting.LastVersionWarninType, 0) AS LastVersionWarninType, ISNULL(Setting.IsActive, 0) AS IsActive
                                   FROM         dbo.[Station] LEFT OUTER JOIN
                                    (SELECT     cast( SettingID as int) SettingID, LastVersion, LastVersionWarninType, UserID, StationID, IsActive
                                    FROM          dbo.Setting AS Setting_1
                                    WHERE      (LastVersion = '{0}')) AS Setting ON dbo.[Station].StationID = Setting.StationID WHERE (dbo.[Station].IsActive = 1) AND Setting.UserID is null",
        version);


            sqlCommand.CommandText = strSQL;
            if (sqlConnection.State == ConnectionState.Closed)
                try { sqlConnection.Open(); }
                catch (Exception ex) { throw ex; }
            sqlCommand.CommandType = CommandType.Text;
            try
            {
                DataSet DS = new DataSet();
                sqlDataAdapter.Fill(DS);

                var lst = DS.Tables[0].ConvertDataTableToList<SettingStationViewModel>();

                return lst;// DS.Tables[0];

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //public static DataTable getVersionStations(string version)
        //{
        //    if (version.Length.Equals(0))
        //        return null;

        //    BaseDataAccessLayerClass b = new BaseDataAccessLayerClass();
        //    SqlCommand sqlCommand = b.sqlCommand;
        //    SqlTransaction sqlTransaction = b.sqlTransaction;
        //    SqlConnection sqlConnection = b.sqlConnection;
        //    SqlDataAdapter sqlDataAdapter = b.sqlDataAdapter;
        //    SqlDataReader sqlDataReader = b.sqlDataReader;
        //    string strSQL = "";
        //    strSQL = string.Format(@"SELECT     dbo.Station.StationID, ISNULL(Setting.IsActive, 0) AS IsActive, dbo.Station.StationName, ISNULL(Setting.LastVersionWarninType, 0) AS LastVersionWarninType
        //                            FROM         (SELECT     SettingID, LastVersion, LastVersionWarninType, UserID, StationID, IsActive
        //                                           FROM          dbo.Setting AS Setting_1
        //                                           WHERE      (LastVersion = '{0}')) AS Setting RIGHT OUTER JOIN
        //                                  dbo.Station ON Setting.StationID = dbo.Station.StationID
        //                            WHERE     (dbo.Station.IsActive = 1) ",
        //            version);
        //    sqlCommand.CommandText = strSQL;
        //    if (sqlConnection.State == ConnectionState.Closed)
        //        try { sqlConnection.Open(); }
        //        catch (Exception ex) { throw ex; }
        //    sqlCommand.CommandType = CommandType.Text;
        //    try
        //    {
        //        DataSet DS = new DataSet();
        //        sqlDataAdapter.Fill(DS);
        //        return DS.Tables[0];

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //    }
        //}
    }
}


