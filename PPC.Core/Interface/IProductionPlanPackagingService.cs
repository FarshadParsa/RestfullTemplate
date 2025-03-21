using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IProductionPlanPackagingService
    {

        /// <summary>
        /// Query ProductionPlanPackaging
        /// </summary>
        /// <param name="productionPlanPackagingID"></param>
        /// <returns></returns>
        ProductionPlanPackaging GetProductionPlanPackagingById(int productionPlanPackagingID);

        /// <summary>
        /// Get  ProductionPlanPackaging  based on id
        /// </summary>
        /// <param name="productionPlanPackagingID"></param>
        /// <returns></returns>
        Task<ProductionPlanPackaging> GetProductionPlanPackagingByIdAsync(int productionPlanPackagingID);

        /// <summary>
        /// Get all ProductionPlanPackaging
        /// </summary>
        /// <returns></returns>
        List<ProductionPlanPackaging> GetAll();

        /// <summary>
        /// Get all ProductionPlanPackaging Async
        /// </summary>
        /// <returns></returns>
        Task<List<ProductionPlanPackaging>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="productionPlanPackaging"></param>
        /// <returns></returns>
        int Append(ProductionPlanPackaging productionPlanPackaging);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="productionPlanPackaging"></param>
        /// <returns></returns>
        bool Update(ProductionPlanPackaging productionPlanPackaging);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="productionPlanPackagingID"></param>
        /// <returns></returns>
        long Delete(int productionPlanPackagingID);


    }
}
