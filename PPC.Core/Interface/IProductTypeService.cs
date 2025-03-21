using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IProductTypeService
    {

        /// <summary>
        /// Query productTypeType 
        /// </summary>
        /// <param name="productTypeId"></param>
        /// <returns></returns>
        ProductType GetProductTypeById(int productTypeId);

        ProductType[] GetProductType();

        /// <summary>
        /// Find ProductType Async
        /// </summary>
        /// <param name="productTypeName"></param>
        /// <returns></returns>
        Task<ProductType> FindProductTypeAsync(string productTypename);

        /// <summary>
        /// Get ProductType  based on id
        /// </summary>
        /// <param name="productTypeId"></param>
        /// <returns></returns>
        Task<ProductType> GetProductTypeByIdAsync(int productTypeId);

        /// <summary>
        /// Get Current ProductType 
        /// </summary>
        /// <param name="productTypeId"></param>
        /// <returns></returns>
        Task<ProductType> GetCurrentProductTypeAsync();

        Task<ProductType[]> GetProductTypeAsync();

        bool Append(ProductType productType);
        bool Update(ProductType productType);
        long Delete(int productTypeId);




    }
}
