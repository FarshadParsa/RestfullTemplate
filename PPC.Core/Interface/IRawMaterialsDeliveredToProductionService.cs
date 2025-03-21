using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IRawMaterialsDeliveredToProductionService
    {

        /// <summary>
        /// Query RawMaterialsDeliveredToProduction
        /// </summary>
        /// <param name="rawMaterialsDeliveredToProductionID"></param>
        /// <returns></returns>
        RawMaterialsDeliveredToProduction GetRawMaterialsDeliveredToProductionById(int rawMaterialsDeliveredToProductionID);

        /// <summary>
        /// Get  RawMaterialsDeliveredToProduction  based on id
        /// </summary>
        /// <param name="rawMaterialsDeliveredToProductionID"></param>
        /// <returns></returns>
        Task<RawMaterialsDeliveredToProduction> GetRawMaterialsDeliveredToProductionByIdAsync(int rawMaterialsDeliveredToProductionID);

        /// <summary>
        /// Get all RawMaterialsDeliveredToProduction
        /// </summary>
        /// <returns></returns>
        List<RawMaterialsDeliveredToProduction> GetAll();

        /// <summary>
        /// Get all RawMaterialsDeliveredToProduction Async
        /// </summary>
        /// <returns></returns>
        Task<List<RawMaterialsDeliveredToProduction>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="rawMaterialsDeliveredToProduction"></param>
        /// <returns></returns>
        int Append(RawMaterialsDeliveredToProduction rawMaterialsDeliveredToProduction);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="rawMaterialsDeliveredToProduction"></param>
        /// <returns></returns>
        bool Update(RawMaterialsDeliveredToProduction rawMaterialsDeliveredToProduction);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="rawMaterialsDeliveredToProductionID"></param>
        /// <returns></returns>
        long Delete(int rawMaterialsDeliveredToProductionID);



    }
}
