using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IDataGrindingDetailService
    {

        /// <summary>
        /// Query DataGrindingDetail
        /// </summary>
        /// <param name="dataGrindingDetailID"></param>
        /// <returns></returns>
        DataGrindingDetail GetDataGrindingDetailById(int dataGrindingDetailID);

        /// <summary>
        /// Get  DataGrindingDetail  based on id
        /// </summary>
        /// <param name="dataGrindingDetailID"></param>
        /// <returns></returns>
        Task<DataGrindingDetail> GetDataGrindingDetailByIdAsync(int dataGrindingDetailID);

        /// <summary>
        /// Get all DataGrindingDetail
        /// </summary>
        /// <returns></returns>
        List<DataGrindingDetail> GetAll();

        /// <summary>
        /// Get all DataGrindingDetail Async
        /// </summary>
        /// <returns></returns>
        Task<List<DataGrindingDetail>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="dataGrindingDetail"></param>
        /// <returns></returns>
        int Append(DataGrindingDetail dataGrindingDetail);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="dataGrindingDetail"></param>
        /// <returns></returns>
        bool Update(DataGrindingDetail dataGrindingDetail);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="dataGrindingDetailID"></param>
        /// <returns></returns>
        long Delete(int dataGrindingDetailID);

        Task<List<DataGrindingDetail>> GetListByDataProductionIdAsync(int dataProductionId);



    }
}
