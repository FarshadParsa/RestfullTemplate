using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

public interface IUnitsService
{

    /// <summary>
    /// Query Unit
    /// </summary>
    /// <param name="unitID"></param>
    /// <returns></returns>
    Units GetUnitsById(int unitID);

    /// <summary>
    /// Get  Unit  based on id
    /// </summary>
    /// <param name="unitID"></param>
    /// <returns></returns>
    Task<Units> GetUnitsByIdAsync(int unitID);

    /// <summary>
    /// Get all Unit
    /// </summary>
    /// <returns></returns>
    List<Units> GetAll();

    /// <summary>
    /// Get all Unit Async
    /// </summary>
    /// <returns></returns>
    Task<List<Units>> GetAllAsync();


    /// <summary>
    /// Append a record
    /// </summary>
    /// <param name="units"></param>
    /// <returns></returns>
    bool Append(Units units);

    /// <summary>
    /// Update a record
    /// </summary>
    /// <param name="units"></param>
    /// <returns></returns>
    bool Update(Units units);

    /// <summary>
    /// Delete a record
    /// </summary>
    /// <param name="unitID"></param>
    /// <returns></returns>
    long Delete(int unitID);

    /// <summary>
    /// Existing Units
    /// </summary>
    /// <param name="name">unit name</param>
    /// <returns></returns>
    Task<bool> ExistUnitsAsync(string name);

    Task<Units> GetUnitByNameAsync(string unitName);
}
