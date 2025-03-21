using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IRevertProductsService
    {

        /// <summary>
        /// Query RevertProducts
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RevertProducts GetRevertProductsById(int id);

        /// <summary>
        /// Get  RevertProducts  based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RevertProducts> GetRevertProductsByIdAsync(int id);

        /// <summary>
        /// Get all RevertProducts
        /// </summary>
        /// <returns></returns>
        List<RevertProducts> GetAll();

        /// <summary>
        /// Get all RevertProducts Async
        /// </summary>
        /// <returns></returns>
        Task<List<RevertProducts>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="revertProducts"></param>
        /// <returns></returns>
        int Append(RevertProducts revertProducts);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="revertProducts"></param>
        /// <returns></returns>
        bool Update(RevertProducts revertProducts);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        long Delete(int id);



    }
}
