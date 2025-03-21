using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IRMWhiteListsService
    {

        /// <summary>
        /// Query RMWhiteLists
        /// </summary>
        /// <param name="rMWhiteListID"></param>
        /// <returns></returns>
        RMWhiteLists GetRMWhiteListsById(int rMWhiteListID);

        /// <summary>
        /// Get  RMWhiteLists  based on id
        /// </summary>
        /// <param name="rMWhiteListID"></param>
        /// <returns></returns>
        Task<RMWhiteLists> GetRMWhiteListsByIdAsync(int rMWhiteListID);

        /// <summary>
        /// Get all RMWhiteLists
        /// </summary>
        /// <returns></returns>
        List<RMWhiteLists> GetAll();

        /// <summary>
        /// Get all RMWhiteLists Async
        /// </summary>
        /// <returns></returns>
        Task<List<RMWhiteLists>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="rMWhiteLists"></param>
        /// <returns></returns>
        int Append(RMWhiteLists rMWhiteLists);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="rMWhiteLists"></param>
        /// <returns></returns>
        bool Update(RMWhiteLists rMWhiteLists);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="rMWhiteListID"></param>
        /// <returns></returns>
        long Delete(int rMWhiteListID);

        /// <summary>
        /// Existing RMWhiteListsAsync
        /// </summary>
        /// <param name="name">rMWhiteLists name</param>
        /// <returns></returns>
        Task<RMWhiteLists> GetByCodeAsync(string code);
        Task<List<RMWhiteLists>> GetAllForDropDownAsync();
    }
}
