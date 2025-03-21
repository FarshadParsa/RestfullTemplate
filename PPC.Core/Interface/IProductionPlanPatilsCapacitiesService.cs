using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IProductionPlanPatilsCapacityService
    {

        /// <summary>
        /// Query ProductionPlanPatilsCapacity
        /// </summary>
        /// <param name="productionPlanPatilCapacityID"></param>
        /// <returns></returns>
        ProductionPlanPatilsCapacity GetProductionPlanPatilsCapacityById(int productionPlanPatilCapacityID);

        /// <summary>
        /// Get  ProductionPlanPatilsCapacity  based on id
        /// </summary>
        /// <param name="productionPlanPatilCapacityID"></param>
        /// <returns></returns>
        Task<ProductionPlanPatilsCapacity> GetProductionPlanPatilsCapacityByIdAsync(int productionPlanPatilCapacityID);

        /// <summary>
        /// Get all ProductionPlanPatilsCapacity
        /// </summary>
        /// <returns></returns>
        List<ProductionPlanPatilsCapacity> GetAll();

        /// <summary>
        /// Get all ProductionPlanPatilsCapacity Async
        /// </summary>
        /// <returns></returns>
        Task<List<ProductionPlanPatilsCapacity>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="productionPlanPatilsCapacity"></param>
        /// <returns></returns>
        int Append(ProductionPlanPatilsCapacity productionPlanPatilsCapacity);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="productionPlanPatilsCapacity"></param>
        /// <returns></returns>
        bool Update(ProductionPlanPatilsCapacity productionPlanPatilsCapacity);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="productionPlanPatilCapacityID"></param>
        /// <returns></returns>
        long Delete(int productionPlanPatilCapacityID);

    }
}
