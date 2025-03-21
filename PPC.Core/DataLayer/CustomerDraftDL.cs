using System;
using System.Data;
//using System.Data;
using System.Collections;
using Microsoft.Data.SqlClient;

namespace AtlasCellData.ADO
{
    public class CustomerDraftDL : BaseDataAccessLayerClass
    {

        public static DataTable GetCustomerDraftReport(int customerDraftID)
        {
            BaseDataAccessLayerClass b = new BaseDataAccessLayerClass();
            SqlCommand sqlCommand = b.sqlCommand;
            SqlTransaction sqlTransaction = b.sqlTransaction;
            SqlConnection sqlConnection = b.sqlConnection;
            SqlDataAdapter sqlDataAdapter = b.sqlDataAdapter;
            SqlDataReader sqlDataReader = b.sqlDataReader;
            string strSQL = "";
            strSQL = $@"Select 
			CustomerDraft.DraftNo,
			CustomerDraft.DraftDate,
			CustomerDraft.VehicleNo,
			CustomerDraft.VehicleType,
			CustomerDraft.DriverName,
			CustomerDraft.DriverTelNo,
			Customer.CustomerName,
			Product.ProductCode,
			Product.ProductName,
			Product.ProductLatinName,
			PackagingPlan.PackagingPlanName,
			Palets.PaletNo,
			Palets.[Weight] GrossWeight,
			InvProduct.NetWeight,
			ProductionPlanPatils.LotNo
from CustomerDraft Inner join
		Customer ON CustomerDraft.CustomerID = Customer.CustomerID INNER JOIN
		CustomerDraftPalets ON CustomerDraft.CustomerDraftID = CustomerDraftPalets.CustomerDraftID INNER JOIN
		Palets ON CustomerDraftPalets.PaletID =  Palets.PaletID INNER JOIN
		PaletDetail ON Palets.PaletID = PaletDetail.PaletID INNER JOIN
		InvProduct ON PaletDetail.InvProductID = InvProduct.InvProductID INNER JOIN 
		Product ON  InvProduct.ProductID = Product.ProductID LEFT OUTER JOIN 
		[DataProduction] ON InvProduct.DataProductionID = [DataProduction].[DataProductionID] INNER JOIN
		ProductionPlanPatils ON DataProduction.ProductionPlanPatilID = ProductionPlanPatils.ProductionPlanPatilID LEFT OUTER JOIN
		WeightingProductDetail ON InvProduct.WeightingProductDetailID = WeightingProductDetail.WeightingProductDetailID INNER JOIN
		PackagingPlan ON WeightingProductDetail.PackagingPlanID = PackagingPlan.PackagingPlanID
WHERE CustomerDraft.CustomerDraftID ={customerDraftID}";

            if (sqlConnection.State == ConnectionState.Closed)
                try { sqlConnection.Open(); } catch (Exception ex) { throw ex; }
            sqlCommand.CommandType = CommandType.Text;
            try
            {
                DataSet DS = new DataSet();

                sqlCommand.CommandText = strSQL;
                sqlDataAdapter.Fill(DS);

                return DS.Tables[0];

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
