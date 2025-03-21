using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IPaletDetailService
    {

        /// <summary>
        /// Query PaletDetail
        /// </summary>
        /// <param name="paletDetailID"></param>
        /// <returns></returns>
        PaletDetail GetPaletDetailById(int paletDetailID);

        /// <summary>
        /// Get  PaletDetail  based on id
        /// </summary>
        /// <param name="paletDetailID"></param>
        /// <returns></returns>
        Task<PaletDetail> GetPaletDetailByIdAsync(int paletDetailID);

        /// <summary>
        /// Get all PaletDetail
        /// </summary>
        /// <returns></returns>
        List<PaletDetail> GetAll();

        /// <summary>
        /// Get all PaletDetail Async
        /// </summary>
        /// <returns></returns>
        Task<List<PaletDetail>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="paletDetail"></param>
        /// <returns></returns>
        int Append(PaletDetail paletDetail);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="paletDetail"></param>
        /// <returns></returns>
        bool Update(PaletDetail paletDetail);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="paletDetailID"></param>
        /// <returns></returns>
        long Delete(int paletDetailID);

    }
}
