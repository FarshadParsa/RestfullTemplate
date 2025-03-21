using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IProductionPlanBOMDetailRevisedService
    {

        /// <summary>
        /// Query ProductionPlanBOMDetailRevised
        /// </summary>
        /// <param name="productionPlanBOMDetailRevisedID"></param>
        /// <returns></returns>
        ProductionPlanBOMDetailRevised GetProductionPlanBOMDetailRevisedById(int productionPlanBOMDetailRevisedID);

        /// <summary>
        /// Get  ProductionPlanBOMDetailRevised  based on id
        /// </summary>
        /// <param name="productionPlanBOMDetailRevisedID"></param>
        /// <returns></returns>
        Task<ProductionPlanBOMDetailRevised> GetProductionPlanBOMDetailRevisedByIdAsync(int productionPlanBOMDetailRevisedID);

        /// <summary>
        /// Get all ProductionPlanBOMDetailRevised
        /// </summary>
        /// <returns></returns>
        List<ProductionPlanBOMDetailRevised> GetAll();

        /// <summary>
        /// Get all ProductionPlanBOMDetailRevised Async
        /// </summary>
        /// <returns></returns>
        Task<List<ProductionPlanBOMDetailRevised>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="productionPlanBOMDetailRevised"></param>
        /// <returns></returns>
        int Append(ProductionPlanBOMDetailRevised productionPlanBOMDetailRevised);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="productionPlanBOMDetailRevised"></param>
        /// <returns></returns>
        bool Update(ProductionPlanBOMDetailRevised productionPlanBOMDetailRevised);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="productionPlanBOMDetailRevisedID"></param>
        /// <returns></returns>
        long Delete(int productionPlanBOMDetailRevisedID);


    }
}
