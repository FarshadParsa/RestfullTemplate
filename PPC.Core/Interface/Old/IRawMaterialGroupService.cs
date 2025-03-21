using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IRawMaterialGroupsService
    {

        /// <summary>
        /// Query RawMaterialGroup
        /// </summary>
        /// <param name="rawMaterialGroupID"></param>
        /// <returns></returns>
        RawMaterialGroups GetRawMaterialGroupsById(int rawMaterialGroupID);

        /// <summary>
        /// Get  RawMaterialGroup  based on id
        /// </summary>
        /// <param name="rawMaterialGroupID"></param>
        /// <returns></returns>
        Task<RawMaterialGroups> GetRawMaterialGroupsByIdAsync(int rawMaterialGroupID);

        /// <summary>
        /// Get all RawMaterialGroup
        /// </summary>
        /// <returns></returns>
        List<RawMaterialGroups> GetAll();

        /// <summary>
        /// Get all RawMaterialGroup Async
        /// </summary>
        /// <returns></returns>
        Task<List<RawMaterialGroups>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="rawMaterialGroups"></param>
        /// <returns></returns>
        bool Append(RawMaterialGroups rawMaterialGroups);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="rawMaterialGroups"></param>
        /// <returns></returns>
        bool Update(RawMaterialGroups rawMaterialGroups);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="rawMaterialGroupID"></param>
        /// <returns></returns>
        long Delete(int rawMaterialGroupID);

        /// <summary>
        /// Existing RawMaterialGroups
        /// </summary>
        /// <param name="name">rawMaterialGroup name</param>
        /// <returns></returns>
        Task<bool> ExistRawMaterialGroupsAsync(string name);



    }
}
