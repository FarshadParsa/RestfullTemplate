using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IInvProductsService
    {

        /// <summary>
        /// Query InvProduct
        /// </summary>
        /// <param name="invProductID"></param>
        /// <returns></returns>
        InvProducts GetInvProductsById(int invProductID);

        /// <summary>
        /// Get  InvProduct  based on id
        /// </summary>
        /// <param name="invProductID"></param>
        /// <returns></returns>
        Task<InvProducts> GetInvProductsByIdAsync(int invProductID);

        /// <summary>
        /// Get all InvProduct
        /// </summary>
        /// <returns></returns>
        List<InvProducts> GetAll();

        /// <summary>
        /// Get all InvProduct Async
        /// </summary>
        /// <returns></returns>
        Task<List<InvProducts>> GetAllInvProductsAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="invProducts"></param>
        /// <returns></returns>
        int Append(InvProducts invProducts);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="invProducts"></param>
        /// <returns></returns>
        bool Update(InvProducts invProducts);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="invProductID"></param>
        /// <returns></returns>
        long Delete(int invProductID);

        Task<InvProducts> GetInstanceByBarcodeAsync(string barcode);

        Task<List<InvProducts>> GetListByWeightingProductIdAsync(int weightingProductId);

        Task<List<InvProducts>> GetByPaletIdAsync(int paletId);


    }
}
