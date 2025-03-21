using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IWeightingProductsService
    {

        /// <summary>
        /// Query WeightingProducts
        /// </summary>
        /// <param name="weightingProductID"></param>
        /// <returns></returns>
        WeightingProducts GetWeightingProductsById(int weightingProductID);

        /// <summary>
        /// Get  WeightingProducts  based on id
        /// </summary>
        /// <param name="weightingProductID"></param>
        /// <returns></returns>
        Task<WeightingProducts> GetWeightingProductsByIdAsync(int weightingProductID);

        /// <summary>
        /// Get all WeightingProducts
        /// </summary>
        /// <returns></returns>
        List<WeightingProducts> GetAll();

        /// <summary>
        /// Get all WeightingProducts Async
        /// </summary>
        /// <returns></returns>
        Task<List<WeightingProducts>> GetAllAsync(string startDate, string endDate);


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="weightingProducts"></param>
        /// <returns></returns>
        int Append(WeightingProducts weightingProducts);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="weightingProducts"></param>
        /// <returns></returns>
        bool Update(WeightingProducts weightingProducts);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="weightingProductID"></param>
        /// <returns></returns>
        long Delete(int weightingProductID);

        Task<List<WeightingProducts>> GetListByProductionPlanPatilIdAsync(int productionPlanPatilId);

    }
}
