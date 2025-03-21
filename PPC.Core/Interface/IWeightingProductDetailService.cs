using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IWeightingProductDetailService
    {

        /// <summary>
        /// Query WeightingProductDetail
        /// </summary>
        /// <param name="weightingProductDetailID"></param>
        /// <returns></returns>
        WeightingProductDetail GetWeightingProductDetailById(int weightingProductDetailID);

        /// <summary>
        /// Get  WeightingProductDetail  based on id
        /// </summary>
        /// <param name="weightingProductDetailID"></param>
        /// <returns></returns>
        Task<WeightingProductDetail> GetWeightingProductDetailByIdAsync(int weightingProductDetailID);

        /// <summary>
        /// Get all WeightingProductDetail
        /// </summary>
        /// <returns></returns>
        List<WeightingProductDetail> GetAll();

        /// <summary>
        /// Get all WeightingProductDetail Async
        /// </summary>
        /// <returns></returns>
        Task<List<WeightingProductDetail>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="weightingProductDetail"></param>
        /// <returns></returns>
        int Append(WeightingProductDetail weightingProductDetail);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="weightingProductDetail"></param>
        /// <returns></returns>
        bool Update(WeightingProductDetail weightingProductDetail);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="weightingProductDetailID"></param>
        /// <returns></returns>
        long Delete(int weightingProductDetailID);


    }
}
