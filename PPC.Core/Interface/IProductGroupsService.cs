using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IProductGroupsService
    {

        /// <summary>
        /// Query ProductGroup
        /// </summary>
        /// <param name="productGroupID"></param>
        /// <returns></returns>
        ProductGroups GetProductGroupsById(short productGroupID);

        /// <summary>
        /// Get  ProductGroup  based on id
        /// </summary>
        /// <param name="productGroupID"></param>
        /// <returns></returns>
        Task<ProductGroups> GetProductGroupsByIdAsync(short productGroupID);

        /// <summary>
        /// Get all ProductGroup
        /// </summary>
        /// <returns></returns>
        List<ProductGroups> GetAll();

        /// <summary>
        /// Get all ProductGroup Async
        /// </summary>
        /// <returns></returns>
        Task<List<ProductGroups>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="productGroups"></param>
        /// <returns></returns>
        bool Append(ProductGroups productGroups);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="productGroups"></param>
        /// <returns></returns>
        bool Update(ProductGroups productGroups);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="productGroupID"></param>
        /// <returns></returns>
        long Delete(short productGroupID);

        /// <summary>
        /// Existing ProductGroupsAsync
        /// </summary>
        /// <param name="name">productGroup name</param>
        /// <returns></returns>
        Task<bool> ExistProductGroupsAsync(string name);

    }
}
