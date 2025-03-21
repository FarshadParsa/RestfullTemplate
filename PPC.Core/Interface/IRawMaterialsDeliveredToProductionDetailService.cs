using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IRawMaterialsDeliveredToProductionDetailService
    {

        /// <summary>
        /// Query RawMaterialsDeliveredToProductionDetail
        /// </summary>
        /// <param name="rawMaterialsDeliveredToProductionDetailID"></param>
        /// <returns></returns>
        RawMaterialsDeliveredToProductionDetail GetRawMaterialsDeliveredToProductionDetailById(int rawMaterialsDeliveredToProductionDetailID);

        /// <summary>
        /// Get  RawMaterialsDeliveredToProductionDetail  based on id
        /// </summary>
        /// <param name="rawMaterialsDeliveredToProductionDetailID"></param>
        /// <returns></returns>
        Task<RawMaterialsDeliveredToProductionDetail> GetRawMaterialsDeliveredToProductionDetailByIdAsync(int rawMaterialsDeliveredToProductionDetailID);

        /// <summary>
        /// Get all RawMaterialsDeliveredToProductionDetail
        /// </summary>
        /// <returns></returns>
        List<RawMaterialsDeliveredToProductionDetail> GetAll();

        /// <summary>
        /// Get all RawMaterialsDeliveredToProductionDetail Async
        /// </summary>
        /// <returns></returns>
        Task<List<RawMaterialsDeliveredToProductionDetail>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="rawMaterialsDeliveredToProductionDetail"></param>
        /// <returns></returns>
        int Append(RawMaterialsDeliveredToProductionDetail rawMaterialsDeliveredToProductionDetail);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="rawMaterialsDeliveredToProductionDetail"></param>
        /// <returns></returns>
        bool Update(RawMaterialsDeliveredToProductionDetail rawMaterialsDeliveredToProductionDetail);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="rawMaterialsDeliveredToProductionDetailID"></param>
        /// <returns></returns>
        long Delete(int rawMaterialsDeliveredToProductionDetailID);


    }
}
