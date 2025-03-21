using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface ICardInvService
    {



        /// <summary>
        /// Get  CardInv  based on id
        /// </summary>
        /// <param name="invTypeID"></param>
        /// <returns></returns>
        Task<List<CardInv>> GetListByKeysAsync(short year, char invTypeID, List<int> rawMaterialID);



    }
}
