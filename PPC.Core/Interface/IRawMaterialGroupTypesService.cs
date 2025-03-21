using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IRawMaterialGroupTypesService
    {

        /// <summary>
        /// Query RawMaterialGroupType
        /// </summary>
        /// <param name="rawMaterialGroupTypeID"></param>
        /// <returns></returns>
        RawMaterialGroupTypes GetRawMaterialGroupTypesById(short rawMaterialGroupTypeID);

        /// <summary>
        /// Get  RawMaterialGroupType  based on id
        /// </summary>
        /// <param name="rawMaterialGroupTypeID"></param>
        /// <returns></returns>
        Task<RawMaterialGroupTypes> GetRawMaterialGroupTypesByIdAsync(short rawMaterialGroupTypeID);

        /// <summary>
        /// Get all RawMaterialGroupType
        /// </summary>
        /// <returns></returns>
        List<RawMaterialGroupTypes> GetAll();

        /// <summary>
        /// Get all RawMaterialGroupType Async
        /// </summary>
        /// <returns></returns>
        Task<List<RawMaterialGroupTypes>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="rawMaterialGroupTypes"></param>
        /// <returns></returns>
        bool Append(RawMaterialGroupTypes rawMaterialGroupTypes);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="rawMaterialGroupTypes"></param>
        /// <returns></returns>
        bool Update(RawMaterialGroupTypes rawMaterialGroupTypes);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="rawMaterialGroupTypeID"></param>
        /// <returns></returns>
        long Delete(short rawMaterialGroupTypeID);

        /// <summary>
        /// Existing RawMaterialGroupTypesAsync
        /// </summary>
        /// <param name="name">rawMaterialGroupType name</param>
        /// <returns></returns>
        Task<bool> ExistRawMaterialGroupTypesAsync(string name);
    }
}
