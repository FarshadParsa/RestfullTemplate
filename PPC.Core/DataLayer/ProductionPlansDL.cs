using System;
using System.Data;
//using System.Data;
using System.Collections;
using Microsoft.Data.SqlClient;

namespace AtlasCellData.ADO
{
    public class ProductionPlansDL : BaseDataAccessLayerClass
    {

        #region private variables
        Hashtable FieldValues;
        private Transaction mTransaction;
        #endregion private variables

        #region properties
        public Transaction transaction
        {
            get
            {
                return mTransaction;
            }
            set
            {
                if (value != null)
                {
                    sqlConnection = value.sqlTransaction.Connection;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Transaction = value.sqlTransaction;
                }
                mTransaction = value;
            }
        }
        #endregion properties

        public static (DataTable productionDT, DataTable bomDT, DataTable packagingDT, DataTable patilesDT) GetProductionReport(int productionPlanId)
        {
            BaseDataAccessLayerClass b = new BaseDataAccessLayerClass();
            SqlCommand sqlCommand = b.sqlCommand;
            SqlTransaction sqlTransaction = b.sqlTransaction;
            SqlConnection sqlConnection = b.sqlConnection;
            SqlDataAdapter sqlDataAdapter = b.sqlDataAdapter;
            SqlDataReader sqlDataReader = b.sqlDataReader;
            string strSQL1 = "";
            string strSQL2 = "";
            strSQL1 = $@"	Select  BOM.BOMID, BOMDetail.BOMDetailID, RawMaterial.RawMaterialCode, 
			BOMCode,ProductionPlanBOMDetail.[Priority] ,
			ProductionPlanBOMDetail.[Percentage]*ProductionPlan.ProducibleQuantity/100 as ProgramWeight,
				Case RawMaterial.IsSemiProduct When 1 then 'S' else 'R' End RawMaterial
	    From ProductionPlanBOMDetail LEFT OUTER JOIN
			    BOMDetail ON ProductionPlanBOMDetail.BomDetailID = BOMDetail.BomDetailID INNER JOIN
			    BOM On BOMDetail.BOMID = BOM.BOMID INNER JOIN
			    RawMaterial ON ProductionPlanBOMDetail.RawMaterialID = RawMaterial.RawMaterialID INNER JOIN
			    ProductionPlan ON ProductionPlanBOMDetail.ProductionPlanID = ProductionPlan.ProductionPlanID
	    Where ProductionPlan.ProductionPlanID = {productionPlanId}";

            strSQL2 = $@"SELECT ProductionPlan.[ProductionPlanID]
                  ,ProductionPlanPatils.ProductionPlanPatilID
                  ,[BatchNo]
	              ,LotNo
	              ,Product.ProductName
	              ,Product.ProductCode
	              ,[PlannedCapacity]
	              ,'{{0}}' As BOMCode
	              ,[ProductionPlan].StartDate
	              ,[ProductionPlan].EndDate
                  ,[ProducibleQuantity]
                  ,[ProductionProcessCirculation]
                  ,[ProductionProcessType]
                  ,[Describe]
        FROM [ProductionPlan] INNER JOIN
		        ProductionPlanPatils ON ProductionPlan.ProductionPlanID = ProductionPlanPatils.ProductionPlanID INNER JOIN
		        OrderDetail ON ProductionPlan.OrderDetailID = OrderDetail.OrderDetailID INNER JOIN 
		        Product ON OrderDetail.ProductID= Product.ProductID
        Where [ProductionPlan].ProductionPlanID = {productionPlanId}";

            var strSQLPackaging = $@"SELECT  
                              [Priority]
	                          ,PackagingPlan.PackagingPlanName
                              ,[QTY]
	                          ,PackagingPlan.Capacity
	                          ,PackagingPlan.Capacity*QTY As [Weight]
                          FROM [ProductionPlanPackaging] INNER JOIN 
		                        PackagingPlan ON [ProductionPlanPackaging] .PackagingPlanID = PackagingPlan.PackagingPlanID
                        WHERE [ProductionPlanID] = {productionPlanId}";

            var strSQLProductionPlanPatil = $@"SELECT  
                                              [LotNo],
                                              [PlannedCapacity]
                                          FROM [ProductionPlanPatils]
                                          WHERE [ProductionPlanID] = {productionPlanId}";

            if (sqlConnection.State == ConnectionState.Closed)
                try { sqlConnection.Open(); } catch (Exception ex) { throw ex; }
            sqlCommand.CommandType = CommandType.Text;
            try
            {
                DataSet DSbom = new DataSet();
                DataSet DSproduction = new DataSet();
                DataSet DSpackaging = new DataSet();
                DataSet DSpatil = new DataSet();

                #region Packaging

                sqlCommand.CommandText = strSQLPackaging;
                sqlDataAdapter.Fill(DSpackaging);
                DataTable dtpackaging = DSpackaging.Tables[0];

                #endregion

                #region ProductionPlanPatil

                sqlCommand.CommandText = strSQLProductionPlanPatil;
                sqlDataAdapter.Fill(DSpatil);
                DataTable dtpatil = DSpatil.Tables[0];

                #endregion

                sqlCommand.CommandText = strSQL1;
                sqlDataAdapter.Fill(DSbom);
                DataTable dtBOM = DSbom.Tables[0];

                if (dtBOM != null && dtBOM.Rows.Count > -0)
                {
                    dtBOM.Select("Len(IsNull(BOMCode,''))>0");
                    strSQL2 = string.Format(strSQL2, dtBOM.DefaultView[0]["BOMCode"].ToString());
                }

                sqlCommand.CommandText = strSQL2;
                sqlDataAdapter.Fill(DSproduction);

                return (DSproduction.Tables[0], dtBOM, dtpackaging, dtpackaging);

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

    }
}
