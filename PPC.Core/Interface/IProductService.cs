using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IProductsService
    {

        /// <summary>
        /// Query Product
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        Products GetProductsById(int productID);

        /// <summary>
        /// Get  Product  based on id
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        Task<Products> GetProductsByIdAsync(int productID);

        /// <summary>
        /// Get all Product
        /// </summary>
        /// <returns></returns>
        List<Products> GetAll();

        /// <summary>
        /// Get all Product Async
        /// </summary>
        /// <returns></returns>
        Task<List<Products>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        int Append(Products products);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        bool Update(Products products);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        long Delete(int productID);

        /// <summary>
        /// Existing ProductsAsync
        /// </summary>
        /// <param name="name">product name</param>
        /// <returns></returns>
        Task<bool> ExistProductsAsync(string name);

        Task<List<Products>> GetAllWithProductTypeAsync();

        Task<string> GetMaxSerialCodeAsync();

        Task<string> GetMaxBOMcodeAsync();

        Task<Products> GetListByFinalRawMaterialID(int finalRawMaterialID);

        Task<List<Products>> GetProductsByPaletIdAsync(int paletId);


    }
}
