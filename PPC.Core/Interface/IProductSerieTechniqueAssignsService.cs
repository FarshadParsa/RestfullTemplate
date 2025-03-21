using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IProductSerieTechniqueAssignsService
    {

        /// <summary>
        /// Query ProductSerieTechniqueAssign
        /// </summary>
        /// <param name="productSerieTechniqueAssignID"></param>
        /// <returns></returns>
        ProductSerieTechniqueAssigns GetProductSerieTechniqueAssignsById(int productSerieTechniqueAssignID);

        /// <summary>
        /// Get  ProductSerieTechniqueAssign  based on id
        /// </summary>
        /// <param name="productSerieTechniqueAssignID"></param>
        /// <returns></returns>
        Task<ProductSerieTechniqueAssigns> GetProductSerieTechniqueAssignsByIdAsync(int productSerieTechniqueAssignID);

        /// <summary>
        /// Get all ProductSerieTechniqueAssign
        /// </summary>
        /// <returns></returns>
        List<ProductSerieTechniqueAssigns> GetAll();

        /// <summary>
        /// Get all ProductSerieTechniqueAssign Async
        /// </summary>
        /// <returns></returns>
        Task<List<ProductSerieTechniqueAssigns>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="productSerieTechniqueAssigns"></param>
        /// <returns></returns>
        bool Append(ProductSerieTechniqueAssigns productSerieTechniqueAssigns);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="productSerieTechniqueAssigns"></param>
        /// <returns></returns>
        bool Update(ProductSerieTechniqueAssigns productSerieTechniqueAssigns);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="productSerieTechniqueAssignID"></param>
        /// <returns></returns>
        long Delete(int productSerieTechniqueAssignID);

        /// <summary>
        /// Get  ProductSerieTechniqueAssign  based on id
        /// </summary>
        /// <param name="productSerieTechniqueAssignID"></param>
        /// <returns></returns>
        Task<List<ProductSerieTechniqueAssigns>> GetProductSerieTechniqueAssignsBySerieIdAsync(int productSerieID);


    }
}
