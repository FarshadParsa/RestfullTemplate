using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IDensityOfProductsService
    {

        /// <summary>
        /// Query DensityOfProduct
        /// </summary>
        /// <param name="densityID"></param>
        /// <returns></returns>
        DensityOfProducts GetDensityOfProductsById(int densityID);

        /// <summary>
        /// Get  DensityOfProduct  based on id
        /// </summary>
        /// <param name="densityID"></param>
        /// <returns></returns>
        Task<DensityOfProducts> GetDensityOfProductsByIdAsync(int densityID);

        /// <summary>
        /// Get all DensityOfProduct
        /// </summary>
        /// <returns></returns>
        List<DensityOfProducts> GetAll();

        /// <summary>
        /// Get all DensityOfProduct Async
        /// </summary>
        /// <returns></returns>
        Task<List<DensityOfProducts>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="densityOfProducts"></param>
        /// <returns></returns>
        List<DensityOfProducts> Append(List<DensityOfProducts> densityOfProducts);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="densityOfProducts"></param>
        /// <returns></returns>
        bool Update(DensityOfProducts densityOfProducts);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="densityID"></param>
        /// <returns></returns>
        long Delete(int densityID);

        Task<List<DensityOfProducts>> GetAllByProductAsync(int productId);

    }
}
