using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
namespace PPC.Core.Interface
{
    public interface ICardInvDetailsService//:IDisposable
    {
       

        /// <summary>
        /// Get  CardInvDetail  based on id
        /// </summary>
        /// <param name="invTypeID"></param>
        /// <returns></returns>
        Task<CardInvDetails> GetCardInvDetailsByIdAsync(char invTypeID, short year, int rawMaterialID, string entryDate , string entryTime);

        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="cardInvDetails"></param>
        /// <returns></returns>
        CardInvDetails Append(CardInvDetails cardInvDetails);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="cardInvDetails"></param>
        /// <returns></returns>
        bool Update(CardInvDetails cardInvDetails);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="invRawMaterialID"></param>
        /// <returns></returns>
        //long DeleteByInvRawMaterialID(char invTypeId, short year, int rawMaterialID, string entryDate, string entryTime, int invRawMaterialID);
        long DeleteByInvRawMaterialID(int invRawMaterialID);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="RawMaterialsDeliveredToProductionDetailID"></param>
        /// <returns></returns>
        long DeleteByRawMaterialsDeliveredToProductionDetailID(int rawMaterialsDeliveredToProductionDetailID);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="InvProductionRawMaterialID"></param>
        /// <returns></returns>
        long DeleteByInvProductionRawMaterialID(int invProductionRawMaterialID);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="DataDosingDetailID"></param>
        /// <returns></returns>
        long DeleteByDataDosingDetailID(int DataDosingDetailID);

        ///// <summary>
        ///// Delete a record
        ///// </summary>
        ///// <param name=""></param>
        ///// <returns></returns>
        //long DeleteBy(int );


    }
}
