using PPC.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ISuppliersService
    {

        /// <summary>
        /// Query Supplier
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        Suppliers GetSuppliersById(short supplierID);

        /// <summary>
        /// Get  Supplier  based on id
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        Task<Suppliers> GetSuppliersByIdAsync(short supplierID);

        /// <summary>
        /// Get all Supplier
        /// </summary>
        /// <returns></returns>
        List<Suppliers> GetAll();

        /// <summary>
        /// Get all Supplier Async
        /// </summary>
        /// <returns></returns>
        Task<List<Suppliers>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="suppliers"></param>
        /// <returns></returns>
        bool Append(Suppliers suppliers);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="suppliers"></param>
        /// <returns></returns>
        bool Update(Suppliers suppliers);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        long Delete(short supplierID);

        /// <summary>
        /// Existing SuppliersAsync
        /// </summary>
        /// <param name="name">supplier name</param>
        /// <returns></returns>
        Task<bool> ExistSuppliersAsync(string name);


    }
}
