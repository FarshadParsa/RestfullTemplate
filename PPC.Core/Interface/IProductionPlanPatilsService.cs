using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IProductionPlanPatilsService
    {

        /// <summary>
        /// Query ProductionPlanPatils
        /// </summary>
        /// <param name="productionPlanPatilID"></param>
        /// <returns></returns>
        ProductionPlanPatils GetProductionPlanPatilsById(int productionPlanPatilID);

        /// <summary>
        /// Get  ProductionPlanPatils  based on id
        /// </summary>
        /// <param name="productionPlanPatilID"></param>
        /// <returns></returns>
        Task<ProductionPlanPatils> GetProductionPlanPatilsByIdAsync(int productionPlanPatilID);

        Task<ProductionPlanPatils> GetPatilsLatestUsgedBOMAsync(int productionPlanPatilID);

        /// <summary>
        /// Get all ProductionPlanPatils
        /// </summary>
        /// <returns></returns>
        List<ProductionPlanPatils> GetAll();

        /// <summary>
        /// Get all ProductionPlanPatils Async
        /// </summary>
        /// <returns></returns>
        Task<List<ProductionPlanPatils>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="productionPlanPatils"></param>
        /// <returns></returns>
        int Append(ProductionPlanPatils productionPlanPatils);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="productionPlanPatils"></param>
        /// <returns></returns>
        bool Update(ProductionPlanPatils productionPlanPatils);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="productionPlanPatilID"></param>
        /// <returns></returns>
        long Delete(int productionPlanPatilID);

        Task<List<ProductionPlanPatils>> GetListByProductionPlanIdAsync(int productionPlanId);
        Task<List<ProductionPlanPatils>> GetDropdownListByProductionPlanIdAsync(int productionPlanId);

    }
}
