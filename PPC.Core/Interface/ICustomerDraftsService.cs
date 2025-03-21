using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;

namespace PPC.Core.Interface
{
    public interface ICustomerDraftsService
    {

        /// <summary>
        /// Query CustomerDraft
        /// </summary>
        /// <param name="customerDraftID"></param>
        /// <returns></returns>
        CustomerDrafts GetCustomerDraftsById(int customerDraftID);

        /// <summary>
        /// Get  CustomerDraft  based on id
        /// </summary>
        /// <param name="customerDraftID"></param>
        /// <returns></returns>
        Task<CustomerDrafts> GetCustomerDraftsByIdAsync(int customerDraftID);

        /// <summary>
        /// Get all CustomerDraft
        /// </summary>
        /// <returns></returns>
        List<CustomerDrafts> GetAll();

        /// <summary>
        /// Get all CustomerDraft Async
        /// </summary>
        /// <returns></returns>
        Task<List<CustomerDrafts>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="customerDrafts"></param>
        /// <returns></returns>
        int Append(CustomerDrafts customerDrafts);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="customerDrafts"></param>
        /// <returns></returns>
        bool Update(CustomerDrafts customerDrafts);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="customerDraftID"></param>
        /// <returns></returns>
        long Delete(int customerDraftID);

        Task<List<CustomerDrafts>> GetListForGridAsync(string dateFrom, string dateTo);

        Task<string> GetNextDraftNoAsync();

        /// <summary>
        /// validate before insert palet into draft
        /// </summary>
        /// <param name="paletIdList"></param>
        /// <returns> string1: PaletNumber,  string2: Error message</returns>
        Task<Dictionary<string, string>> ValidateCanInsertPaletAsync(List<int> paletIdList);

        /// <summary>
        /// گزاش حواله خروج
        /// </summary>
        /// <returns></returns>
        DataTable GetCustomerDraftReport(int customerDraftID);

    }
}
