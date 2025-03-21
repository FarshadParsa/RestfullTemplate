using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IProductTypesService
    {

        /// <summary>
        /// Query ProductType
        /// </summary>
        /// <param name="productTypeID"></param>
        /// <returns></returns>
        ProductTypes GetProductTypesById(short productTypeID);

        /// <summary>
        /// Get  ProductType  based on id
        /// </summary>
        /// <param name="productTypeID"></param>
        /// <returns></returns>
        Task<ProductTypes> GetProductTypesByIdAsync(short productTypeID);

        /// <summary>
        /// Get all ProductType
        /// </summary>
        /// <returns></returns>
        List<ProductTypes> GetAll();

        /// <summary>
        /// Get all ProductType Async
        /// </summary>
        /// <returns></returns>
        Task<List<ProductTypes>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="productTypes"></param>
        /// <returns></returns>
        bool Append(ProductTypes productTypes);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="productTypes"></param>
        /// <returns></returns>
        bool Update(ProductTypes productTypes);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="productTypeID"></param>
        /// <returns></returns>
        long Delete(short productTypeID);

        /// <summary>
        /// Existing ProductTypesAsync
        /// </summary>
        /// <param name="name">productType name</param>
        /// <returns></returns>
        Task<bool> ExistProductTypesAsync(string name);
    }
}
