using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ISettingGeneralsService
    {

        /// <summary>
        /// Query SettingGeneral
        /// </summary>
        /// <param name="settingGeneralID"></param>
        /// <returns></returns>
        SettingGenerals GetSettingGeneralsById(int settingGeneralID);

        /// <summary>
        /// Get  SettingGeneral  based on id
        /// </summary>
        /// <param name="settingGeneralID"></param>
        /// <returns></returns>
        Task<SettingGenerals> GetSettingGeneralsByIdAsync(int settingGeneralID);

        /// <summary>
        /// Get all SettingGeneral
        /// </summary>
        /// <returns></returns>
        List<SettingGenerals> GetAll();

        /// <summary>
        /// Get all SettingGeneral Async
        /// </summary>
        /// <returns></returns>
        Task<List<SettingGenerals>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="settingGenerals"></param>
        /// <returns></returns>
        bool Append(SettingGenerals settingGenerals);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="settingGenerals"></param>
        /// <returns></returns>
        bool Update(SettingGenerals settingGenerals);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="settingGeneralID"></param>
        /// <returns></returns>
        long Delete(int settingGeneralID);

        /// <summary>
        /// Existing SettingGeneralsAsync
        /// </summary>
        /// <param name="name">settingGeneral name</param>
        /// <returns></returns>
        Task<bool> ExistSettingGeneralsAsync(string vrsion);

        Task<SettingGenerals> GetInstanceByVesionAsync(string vrsion);


    }
}
