using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface ICardTypesService
    {

        /// <summary>
        /// Query CardType
        /// </summary>
        /// <param name="cardTypeID"></param>
        /// <returns></returns>
        CardTypes GetCardTypesById(byte cardTypeID);

        /// <summary>
        /// Get  CardType  based on id
        /// </summary>
        /// <param name="cardTypeID"></param>
        /// <returns></returns>
        Task<CardTypes> GetCardTypesByIdAsync(byte cardTypeID);

        /// <summary>
        /// Get all CardType
        /// </summary>
        /// <returns></returns>
        List<CardTypes> GetAll();

        /// <summary>
        /// Get all CardType Async
        /// </summary>
        /// <returns></returns>
        Task<List<CardTypes>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="cardTypes"></param>
        /// <returns></returns>
        byte Append(CardTypes cardTypes);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="cardTypes"></param>
        /// <returns></returns>
        bool Update(CardTypes cardTypes);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="cardTypeID"></param>
        /// <returns></returns>
        long Delete(byte cardTypeID);



    }
}
