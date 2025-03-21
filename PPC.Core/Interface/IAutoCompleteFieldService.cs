using PPC.Core.Models;
using PPC.Core.Interface;
using PPC.Response.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PPC.Core.Interface
{
    public interface IAutoCompleteFieldService
    {

        /// <summary>
        /// Query AutoCompleteField
        /// </summary>
        /// <param name="autoCompleteFieldID"></param>
        /// <returns></returns>
        AutoCompleteField GetAutoCompleteFieldById(int autoCompleteFieldID);

        /// <summary>
        /// Get  AutoCompleteField  based on id
        /// </summary>
        /// <param name="autoCompleteFieldID"></param>
        /// <returns></returns>
        Task<AutoCompleteField> GetAutoCompleteFieldByIdAsync(int autoCompleteFieldID);

        /// <summary>
        /// Get all AutoCompleteField
        /// </summary>
        /// <returns></returns>
        List<AutoCompleteField> GetAll();

        /// <summary>
        /// Get all AutoCompleteField Async
        /// </summary>
        /// <returns></returns>
        Task<List<AutoCompleteField>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="autoCompleteField"></param>
        /// <returns></returns>
        int Append(AutoCompleteField autoCompleteField);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="autoCompleteField"></param>
        /// <returns></returns>
        bool Update(AutoCompleteField autoCompleteField);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="autoCompleteFieldID"></param>
        /// <returns></returns>
        long Delete(int autoCompleteFieldID);

        /// <summary>
        /// Existing AutoCompleteFieldAsync
        /// </summary>
        /// <param name="name">autoCompleteField name</param>
        /// <returns></returns>
        Task<List<AutoCompleteField>> GetAutoCompleteFieldByFieldNameAsync(string name);


    }
}
