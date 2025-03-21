using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IInstructionsService
    {

        /// <summary>
        /// Query Instruction
        /// </summary>
        /// <param name="instructionID"></param>
        /// <returns></returns>
        Instructions GetInstructionsById(short instructionID);

        /// <summary>
        /// Get  Instruction  based on id
        /// </summary>
        /// <param name="instructionID"></param>
        /// <returns></returns>
        Task<Instructions> GetInstructionsByIdAsync(short instructionID);

        /// <summary>
        /// Get all Instruction
        /// </summary>
        /// <returns></returns>
        List<Instructions> GetAll();

        /// <summary>
        /// Get all Instruction Async
        /// </summary>
        /// <returns></returns>
        Task<List<Instructions>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="instructions"></param>
        /// <returns></returns>
        bool Append(Instructions instructions);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="instructions"></param>
        /// <returns></returns>
        bool Update(Instructions instructions);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="instructionID"></param>
        /// <returns></returns>
        long Delete(short instructionID);

        /// <summary>
        /// Existing InstructionsAsync
        /// </summary>
        /// <param name="name">instruction name</param>
        /// <returns></returns>
        Task<bool> ExistInstructionsAsync(string name);


    }
}
