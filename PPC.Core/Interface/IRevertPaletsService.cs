using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IRevertPaletsService
    {

        /// <summary>
        /// Query RevertPalets
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RevertPalets GetRevertPaletsById(int id);

        /// <summary>
        /// Get  RevertPalets  based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RevertPalets> GetRevertPaletsByIdAsync(int id);

        /// <summary>
        /// Get all RevertPalets
        /// </summary>
        /// <returns></returns>
        List<RevertPalets> GetAll();

        /// <summary>
        /// Get all RevertPalets Async
        /// </summary>
        /// <returns></returns>
        Task<List<RevertPalets>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="revertPalets"></param>
        /// <returns></returns>
        int Append(RevertPalets revertPalets);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="revertPalets"></param>
        /// <returns></returns>
        bool Update(RevertPalets revertPalets);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        long Delete(int id);



    }
}
