using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IRawMaterialsService
    {

        /// <summary>
        /// Query RawMaterial
        /// </summary>
        /// <param name="rawMaterialID"></param>
        /// <returns></returns>
        RawMaterials GetRawMaterialsById(int rawMaterialID);

        /// <summary>
        /// Get  RawMaterial  based on id
        /// </summary>
        /// <param name="rawMaterialID"></param>
        /// <returns></returns>
        Task<RawMaterials> GetRawMaterialsByIdAsync(int rawMaterialID);

        /// <summary>
        /// Get all RawMaterial
        /// </summary>
        /// <returns></returns>
        List<RawMaterials> GetAll();

        /// <summary>
        /// Get all RawMaterial Async
        /// </summary>
        /// <returns></returns>
        Task<List<RawMaterials>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="rawMaterials"></param>
        /// <returns></returns>
        bool Append(RawMaterials rawMaterials);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="rawMaterials"></param>
        /// <returns></returns>
        bool Update(RawMaterials rawMaterials);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="rawMaterialID"></param>
        /// <returns></returns>
        long Delete(int rawMaterialID);

        /// <summary>
        /// Existing RawMaterialsAsync
        /// </summary>
        /// <param name="name">rawMaterial name</param>
        /// <returns></returns>
        Task<bool> ExistRawMaterialsAsync(string name);
    }
}
