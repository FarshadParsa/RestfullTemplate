using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class CardInvService : BaseService, ICardInvService
    {
        //IUnitOfWork _unitOfWork;
        public CardInvService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CardInv>> GetListByKeysAsync(short year, char invTypeID, List<int> rawMaterialID)
        {
            try
            {
                var cardInvList = await _repositoryFactory.CardInv.Table
                    .Where(x => x.InvTypeID == invTypeID && x.Year == year)
                    .ToListAsync();

                return cardInvList;
            }
            catch
            {
                throw;
            }
        }

    }
}
