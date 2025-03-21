using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IInvTypesService
    {

        /// <summary>
        /// Query InvType
        /// </summary>
        /// <param name="invTypeID"></param>
        /// <returns></returns>
        InvTypes GetInvTypesById(byte invTypeID);

        /// <summary>
        /// Get  InvType  based on id
        /// </summary>
        /// <param name="invTypeID"></param>
        /// <returns></returns>
        Task<InvTypes> GetInvTypesByIdAsync(byte invTypeID);

        /// <summary>
        /// Get all InvType
        /// </summary>
        /// <returns></returns>
        List<InvTypes> GetAll();

        /// <summary>
        /// Get all InvType Async
        /// </summary>
        /// <returns></returns>
        Task<List<InvTypes>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="invTypes"></param>
        /// <returns></returns>
        char Append(InvTypes invTypes);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="invTypes"></param>
        /// <returns></returns>
        bool Update(InvTypes invTypes);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="invTypeID"></param>
        /// <returns></returns>
        long Delete(byte invTypeID);



    }
}
