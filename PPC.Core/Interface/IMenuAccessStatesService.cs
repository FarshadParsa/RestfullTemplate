using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IMenuAccessStatesService
    {

        /// <summary>
        /// Query MenuAccessState
        /// </summary>
        /// <param name="menuAccessStateID"></param>
        /// <returns></returns>
        MenuAccessStates GetMenuAccessStatesById(int menuAccessStateID);

        /// <summary>
        /// Get  MenuAccessState  based on id
        /// </summary>
        /// <param name="menuAccessStateID"></param>
        /// <returns></returns>
        Task<MenuAccessStates> GetMenuAccessStatesByIdAsync(int menuAccessStateID);

        /// <summary>
        /// Get all MenuAccessState
        /// </summary>
        /// <returns></returns>
        List<MenuAccessStates> GetAll();

        /// <summary>
        /// Get all MenuAccessState Async
        /// </summary>
        /// <returns></returns>
        Task<List<MenuAccessStates>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="menuAccessStates"></param>
        /// <returns></returns>
        bool Append(MenuAccessStates menuAccessStates);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="menuAccessStates"></param>
        /// <returns></returns>
        bool Update(MenuAccessStates menuAccessStates);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="menuAccessStateID"></param>
        /// <returns></returns>
        long Delete(int menuAccessStateID);

        /// <summary>
        /// Existing MenuAccessStatesAsync
        /// </summary>
        /// <param name="name">menuAccessState name</param>
        /// <returns></returns>
        Task<bool> ExistMenuAccessStatesAsync(string name);

        /// <summary>
        /// Get  MenuAccessState  based on id
        /// </summary>
        /// <param name="menuAccessStateID"></param>
        /// <returns></returns>
        Task<List<MenuAccessStates>> GetMenuAccessStatesByGroupIdAsync(byte groupID);


    }
}
