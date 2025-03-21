using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface ICustomerDossierService
    {

        /// <summary>
        /// Query CustomerDossier
        /// </summary>
        /// <param name="customerDossierID"></param>
        /// <returns></returns>
        CustomerDossier GetCustomerDossierById(int customerDossierID);

        /// <summary>
        /// Get  CustomerDossier  based on id
        /// </summary>
        /// <param name="customerDossierID"></param>
        /// <returns></returns>
        Task<CustomerDossier> GetCustomerDossierByIdAsync(int customerDossierID);

        /// <summary>
        /// Get all CustomerDossier
        /// </summary>
        /// <returns></returns>
        List<CustomerDossier> GetAll();

        /// <summary>
        /// Get all CustomerDossier Async
        /// </summary>
        /// <returns></returns>
        Task<List<CustomerDossier>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="customerDossier"></param>
        /// <returns></returns>
        int Append(CustomerDossier customerDossier);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="customerDossier"></param>
        /// <returns></returns>
        bool Update(CustomerDossier customerDossier);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="customerDossierID"></param>
        /// <returns></returns>
        long Delete(int customerDossierID);

        /// <summary>
        /// Existing CustomerDossierAsync
        /// </summary>
        /// <param name="name">customerDossier name</param>
        /// <returns></returns>
        Task<CustomerDossier> GetByDossierNoAsync(int name);

        Task<List<CustomerDossier>> GetListByCustomerIdAsync(int customerId);

        Task<List<CustomerDossier>> GetListByProductIdAsync(int productId);

        Task<List<CustomerDossier>> GetListByCustomerIdProductIdAsync(int customerId, int productId);

        Task<CustomerDossier> GetInstanceByMaxDossierNoAsync();


    }
}
