using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IProductionPlanReworkDetailsService
    {

        /// <summary>
        /// Query ProductionPlanReworkDetail
        /// </summary>
        /// <param name="productionPlanReworkDetailID"></param>
        /// <returns></returns>
        ProductionPlanReworkDetails GetProductionPlanReworkDetailsById(int productionPlanReworkDetailID);

        /// <summary>
        /// Get  ProductionPlanReworkDetail  based on id
        /// </summary>
        /// <param name="productionPlanReworkDetailID"></param>
        /// <returns></returns>
        Task<ProductionPlanReworkDetails> GetProductionPlanReworkDetailsByIdAsync(int productionPlanReworkDetailID);

        /// <summary>
        /// Get all ProductionPlanReworkDetail
        /// </summary>
        /// <returns></returns>
        List<ProductionPlanReworkDetails> GetAll();

        /// <summary>
        /// Get all ProductionPlanReworkDetail Async
        /// </summary>
        /// <returns></returns>
        Task<List<ProductionPlanReworkDetails>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="productionPlanReworkDetails"></param>
        /// <returns></returns>
        int Append(ProductionPlanReworkDetails productionPlanReworkDetails);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="productionPlanReworkDetails"></param>
        /// <returns></returns>
        bool Update(ProductionPlanReworkDetails productionPlanReworkDetails);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="productionPlanReworkDetailID"></param>
        /// <returns></returns>
        long Delete(int productionPlanReworkDetailID);

        /// <summary>
        /// دریافت لیست 
        /// </summary>
        /// <param name="productionPlanReworkId"></param>
        /// <returns></returns>
        Task<List<ProductionPlanReworkDetails>> GetDetailsListByProductionPlanReworkIdAsync(int productionPlanReworkId);



    }
}
