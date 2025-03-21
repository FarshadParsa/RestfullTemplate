using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IProductGroupTypesService
    {

        /// <summary>
        /// Query ProductGroupType
        /// </summary>
        /// <param name="productGroupTypeID"></param>
        /// <returns></returns>
        ProductGroupTypes GetProductGroupTypesById(short productGroupTypeID);

        /// <summary>
        /// Get  ProductGroupType  based on id
        /// </summary>
        /// <param name="productGroupTypeID"></param>
        /// <returns></returns>
        Task<ProductGroupTypes> GetProductGroupTypesByIdAsync(short productGroupTypeID);

        /// <summary>
        /// Get all ProductGroupType
        /// </summary>
        /// <returns></returns>
        List<ProductGroupTypes> GetAll();

        /// <summary>
        /// Get all ProductGroupType Async
        /// </summary>
        /// <returns></returns>
        Task<List<ProductGroupTypes>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="productGroupTypes"></param>
        /// <returns></returns>
        bool Append(ProductGroupTypes productGroupTypes);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="productGroupTypes"></param>
        /// <returns></returns>
        bool Update(ProductGroupTypes productGroupTypes);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="productGroupTypeID"></param>
        /// <returns></returns>
        long Delete(short productGroupTypeID);

        /// <summary>
        /// Existing ProductGroupTypesAsync
        /// </summary>
        /// <param name="name">productGroupType name</param>
        /// <returns></returns>
        Task<bool> ExistProductGroupTypesAsync(string name);
    }
}
