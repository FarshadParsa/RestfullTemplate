using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ISettingGeneralService
    {

        /// <summary>
        /// Query SettingGeneral
        /// </summary>
        /// <param name="systemVersion"></param>
        /// <returns></returns>
        SettingGeneral GetSettingGeneralById(string systemVersion);

        /// <summary>
        /// Get  SettingGeneral  based on id
        /// </summary>
        /// <param name="systemVersion"></param>
        /// <returns></returns>
        Task<SettingGeneral> GetSettingGeneralByIdAsync(string systemVersion);

        /// <summary>
        /// Get all SettingGeneral
        /// </summary>
        /// <returns></returns>
        List<SettingGeneral> GetAll();

        /// <summary>
        /// Get all SettingGeneral Async
        /// </summary>
        /// <returns></returns>
        Task<List<SettingGeneral>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="settingGeneral"></param>
        /// <returns></returns>
        bool Append(SettingGeneral settingGeneral);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="settingGeneral"></param>
        /// <returns></returns>
        bool Update(SettingGeneral settingGeneral);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="systemVersion"></param>
        /// <returns></returns>
        long Delete(string systemVersion);




    }
}
