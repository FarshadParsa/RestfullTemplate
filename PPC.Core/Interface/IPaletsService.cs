using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IPaletsService
    {

        /// <summary>
        /// Query Palets
        /// </summary>
        /// <param name="paletID"></param>
        /// <returns></returns>
        Palets GetPaletsById(int paletID);

        /// <summary>
        /// Get  Palets  based on id
        /// </summary>
        /// <param name="paletID"></param>
        /// <returns></returns>
        Task<Palets> GetPaletsByIdAsync(int paletID);

        /// <summary>
        /// Get all Palets
        /// </summary>
        /// <returns></returns>
        List<Palets> GetAll();

        /// <summary>
        /// Get all Palets Async
        /// </summary>
        /// <returns></returns>
        Task<List<Palets>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="palets"></param>
        /// <returns></returns>
        int Append(Palets palets);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="palets"></param>
        /// <returns></returns>
        bool Update(Palets palets);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="paletID"></param>
        /// <returns></returns>
        long Delete(int paletID);

        Task<Palets> GetInstanceByPaletNoAsync(string paletNo);

        /// <summary>
        /// validate of product before paletize
        /// </summary>
        /// <param name="invProductIdList"></param>
        /// <returns>
        /// string 1 : palet number
        /// string 2 : error message
        /// </returns>
        Task<List< string>> ValidateCanInsertProductsAsync(List<int> invProductIdList);
        string GetMaxPaletNo();

        Task<List<Palets>> GetArchiveList(string startDate, string endDate);


        /// <summary>
        /// Get  Palets  for label print by PaletId
        /// </summary>
        /// <param name="paletID"></param>
        /// <returns></returns>
        Task<Palets> GetPaletLabelInfoAsync(int paletID);


        /// <summary>
        /// return next palet number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        Task<string> GetNextPaletNoAsync(int number);

    }
}
