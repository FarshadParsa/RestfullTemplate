using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface ICustomerDossierBOMsService
    {

        /// <summary>
        /// Query CustomerDossierBOMs
        /// </summary>
        /// <param name="customerDossierBOMID"></param>
        /// <returns></returns>
        CustomerDossierBOMs GetCustomerDossierBOMsById(int customerDossierBOMID);

        /// <summary>
        /// Get  CustomerDossierBOMs  based on id
        /// </summary>
        /// <param name="customerDossierBOMID"></param>
        /// <returns></returns>
        Task<CustomerDossierBOMs> GetCustomerDossierBOMsByIdAsync(int customerDossierBOMID);

        /// <summary>
        /// Get all CustomerDossierBOMs
        /// </summary>
        /// <returns></returns>
        List<CustomerDossierBOMs> GetAll();

        /// <summary>
        /// Get all CustomerDossierBOMs Async
        /// </summary>
        /// <returns></returns>
        Task<List<CustomerDossierBOMs>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="customerDossierBOMs"></param>
        /// <returns></returns>
        int Append(CustomerDossierBOMs customerDossierBOMs);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="customerDossierBOMs"></param>
        /// <returns></returns>
        bool Update(CustomerDossierBOMs customerDossierBOMs);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="customerDossierBOMID"></param>
        /// <returns></returns>
        long Delete(int customerDossierBOMID);

        Task<List<CustomerDossierBOMs>> GetListByCustomerIdAsync(int customerId);
        Task<List<CustomerDossierBOMs>> GetListByCustomerDossierIdAsync(int customerDossierId);

        Task<List<CustomerDossierBOMs>> GetAllByBOMIdAsync(int bomId);

        bool SetActive(int customerDossierBOMId, bool isActive);

    }
}
