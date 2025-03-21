using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IProductGroupService
    {

        /// <summary>
        /// Query productGroupType 
        /// </summary>
        /// <param name="productGroupId"></param>
        /// <returns></returns>
        ProductGroup GetProductGroupById(int productGroupId);

        ProductGroup[] GetProductGroup();

        /// <summary>
        /// Find ProductGroup Async
        /// </summary>
        /// <param name="productGroupName"></param>
        /// <returns></returns>
        Task<ProductGroup> FindProductGroupAsync(string productGroupname);

        /// <summary>
        /// Get ProductGroup  based on id
        /// </summary>
        /// <param name="productGroupId"></param>
        /// <returns></returns>
        Task<ProductGroup> GetProductGroupByIdAsync(int productGroupId);

        /// <summary>
        /// Get Current ProductGroup 
        /// </summary>
        /// <param name="productGroupId"></param>
        /// <returns></returns>
        Task<ProductGroup> GetCurrentProductGroupAsync();

        Task<ProductGroup[]> GetProductGroupAsync();

        bool Append(ProductGroup productGroup);
        bool Update(ProductGroup productGroup);
        long Delete(int productGroupId);




    }
}
