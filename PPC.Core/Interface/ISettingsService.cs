using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ISettingsService
    {

        /// <summary>
        /// Query Setting
        /// </summary>
        /// <param name="settingID"></param>
        /// <returns></returns>
        Settings GetSettingsById(int settingID);

        /// <summary>
        /// Get  Setting  based on id
        /// </summary>
        /// <param name="settingID"></param>
        /// <returns></returns>
        Task<Settings> GetSettingsByIdAsync(int settingID);

        /// <summary>
        /// Get all Setting
        /// </summary>
        /// <returns></returns>
        List<Settings> GetAll();

        /// <summary>
        /// Get all Setting Async
        /// </summary>
        /// <returns></returns>
        Task<List<Settings>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        bool Append(Settings settings);

        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        bool Append(SettingUpdateViewModel settingUpdateViewModel);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        bool Update(Settings settings);


        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        bool Update(SettingUpdateViewModel settingUpdateViewModel);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="settingID"></param>
        /// <returns></returns>
        long Delete(int settingID);

        Task<Settings> GetActiveVersionAsync();
        Task<Settings> GetActiveVersionByUserIdAsync(int userID);
        Task<Settings> GetActiveVersionByStationIdAsync(int stationID);

        /// <summary>
        /// Get all Setting Async
        /// </summary>
        /// <returns></returns>
        Task<List<SettingUpdateViewModel>> GetAllVersionInfo();

        /// <summary>
        /// Get all Setting Users 
        /// </summary>
        /// <returns></returns>
        List<SettingUserViewModel> GetSettingUsers(string version);

        /// <summary>
        /// Get all Setting Stations 
        /// </summary>
        /// <returns></returns>
        List<SettingStationViewModel> GetSettingStations(string version);


    }
}
