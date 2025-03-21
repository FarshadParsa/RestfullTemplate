using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface ICustomerDraftPaletsService
    {

        /// <summary>
        /// Query CustomerDraftPalets
        /// </summary>
        /// <param name="customerDraftPaletID"></param>
        /// <returns></returns>
        CustomerDraftPalets GetCustomerDraftPaletsById(int customerDraftPaletID);

        /// <summary>
        /// Get  CustomerDraftPalets  based on id
        /// </summary>
        /// <param name="customerDraftPaletID"></param>
        /// <returns></returns>
        Task<CustomerDraftPalets> GetCustomerDraftPaletsByIdAsync(int customerDraftPaletID);

        /// <summary>
        /// Get all CustomerDraftPalets
        /// </summary>
        /// <returns></returns>
        List<CustomerDraftPalets> GetAll();

        /// <summary>
        /// Get all CustomerDraftPalets Async
        /// </summary>
        /// <returns></returns>
        Task<List<CustomerDraftPalets>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="customerDraftPalets"></param>
        /// <returns></returns>
        int Append(CustomerDraftPalets customerDraftPalets);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="customerDraftPalets"></param>
        /// <returns></returns>
        bool Update(CustomerDraftPalets customerDraftPalets);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="customerDraftPaletID"></param>
        /// <returns></returns>
        long Delete(int customerDraftPaletID);



    }
}
