using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ISettingUpdatesService
    {

        /// <summary>
        /// Query SettingUpdate
        /// </summary>
        /// <param name="updateID"></param>
        /// <returns></returns>
        SettingUpdates GetSettingUpdatesById(int updateID);

        /// <summary>
        /// Get  SettingUpdate  based on id
        /// </summary>
        /// <param name="updateID"></param>
        /// <returns></returns>
        Task<SettingUpdates> GetSettingUpdatesByIdAsync(int updateID);

        /// <summary>
        /// Get all SettingUpdate
        /// </summary>
        /// <returns></returns>
        List<SettingUpdates> GetAll();

        /// <summary>
        /// Get all SettingUpdate Async
        /// </summary>
        /// <returns></returns>
        Task<List<SettingUpdates>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="settingUpdates"></param>
        /// <returns></returns>
        bool Append(SettingUpdates settingUpdates);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="settingUpdates"></param>
        /// <returns></returns>
        bool Update(SettingUpdates settingUpdates);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="updateID"></param>
        /// <returns></returns>
        long Delete(int updateID);

        Task<SettingUpdates> GetSettingUpdatesByVersionAsync(string version);

    }
}
