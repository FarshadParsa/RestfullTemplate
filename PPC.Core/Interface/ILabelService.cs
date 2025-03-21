using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface ILabelService
    {

        /// <summary>
        /// Query Label
        /// </summary>
        /// <param name="labelID"></param>
        /// <returns></returns>
        Label GetLabelById(int labelID);

        /// <summary>
        /// Get  Label  based on id
        /// </summary>
        /// <param name="labelID"></param>
        /// <returns></returns>
        Task<Label> GetLabelByIdAsync(int labelID);

        /// <summary>
        /// Get all Label
        /// </summary>
        /// <returns></returns>
        List<Label> GetAll();

        /// <summary>
        /// Get all Label Async
        /// </summary>
        /// <returns></returns>
        Task<List<Label>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        int Append(Label label);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        bool Update(Label label);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="labelID"></param>
        /// <returns></returns>
        long Delete(int labelID);

        /// <summary>
        /// Existing LabelAsync
        /// </summary>
        /// <param name="name">label name</param>
        /// <returns></returns>
        Task<Label> GetInstanceByNameAsync(string name);


    }
}
