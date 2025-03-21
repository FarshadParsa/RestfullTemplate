using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public partial class CardInvDetailsService : BaseService, ICardInvDetailsService
    {

        private readonly PPCDbContext _contex;
        public CardInvDetailsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork,
            PPCDbContext contex = null)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
            _contex = contex;
            
        }

        public async Task<CardInvDetails> GetCardInvDetailsByIdAsync(char invTypeID, short year, int rawMaterialID, string entryDate, string entryTime)
        {
            try
            {
                var cardInvDetails = await _repositoryFactory.CardInvDetails
                    .FirstOrDefaultAsync(x => x.InvTypeID == invTypeID);

                return cardInvDetails;
            }
            catch
            {
                throw;
            }
        }

        public CardInvDetails Append(CardInvDetails cardInvDetails)
        {
            try
            {
                var _newObject = new CardInvDetails
                {
                    InvTypeID = cardInvDetails.InvTypeID,
                    Year = cardInvDetails.Year,
                    RawMaterialID = cardInvDetails.RawMaterialID,
                    EntryDate = cardInvDetails.EntryDate,
                    EntryTime = cardInvDetails.EntryTime,
                    Amount = cardInvDetails.Amount,
                    CardTypeVal = cardInvDetails.CardTypeVal,
                    IsEntry = cardInvDetails.IsEntry,
                    InsDate = cardInvDetails.InsDate,
                    InsTime = cardInvDetails.InsTime,
                    InsUserID = cardInvDetails.InsUserID,
                    InvRawMaterialID = cardInvDetails.InvRawMaterialID,
                    RawMaterialsDeliveredToProductionDetailID = cardInvDetails.RawMaterialsDeliveredToProductionDetailID,
                    InvProductionRawMaterialID = cardInvDetails.InvProductionRawMaterialID,
                    DataDosingDetailID = cardInvDetails.DataDosingDetailID,
                    GroupRawId = cardInvDetails.GroupRawId,
                };

                _repositoryFactory.CardInvDetails.AddAsynccc(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject;
                else
                    return null;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public bool Update(CardInvDetails cardInvDetails)
        {
            try
            {

                _repositoryFactory.CardInvDetails.UpdateBy(x => x.InvTypeID == cardInvDetails.InvTypeID && x.Year == cardInvDetails.Year &&
                        x.RawMaterialID == cardInvDetails.RawMaterialID && x.EntryDate == cardInvDetails.EntryDate && x.EntryTime == cardInvDetails.EntryTime
                ,
                    new CardInvDetails
                    {
                        InvTypeID = cardInvDetails.InvTypeID,
                        Year = cardInvDetails.Year,
                        RawMaterialID = cardInvDetails.RawMaterialID,
                        EntryDate = cardInvDetails.EntryDate,
                        EntryTime = cardInvDetails.EntryTime,
                        Amount = cardInvDetails.Amount,
                        CardTypeVal = cardInvDetails.CardTypeVal,
                        IsEntry = cardInvDetails.IsEntry,
                        InsDate = cardInvDetails.InsDate,
                        InsTime = cardInvDetails.InsTime,
                        InsUserID = cardInvDetails.InsUserID,
                        InvRawMaterialID = cardInvDetails.InvRawMaterialID,
                        RawMaterialsDeliveredToProductionDetailID = cardInvDetails.RawMaterialsDeliveredToProductionDetailID,
                        InvProductionRawMaterialID = cardInvDetails.InvProductionRawMaterialID,
                        DataDosingDetailID = cardInvDetails.DataDosingDetailID,
                        GroupRawId = cardInvDetails.GroupRawId,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long DeleteByInvRawMaterialID(int invRawMaterialID)
        {
            try
            {
                var cardInvDetails = _repositoryFactory.CardInvDetails
                    .FirstOrDefault(x => x.InvRawMaterialID == invRawMaterialID);

                //if (cardInvDetails == null)
                //    throw new System.Exception("CardInvDetails Notfound.");

                _repositoryFactory.CardInvDetails.Delete(cardInvDetails);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<long> DeleteByInvRawMaterials(List<InvRawMaterials> invRawMaterialList)
        {

            try
            {
                var cardInvDetailList = _repositoryFactory.CardInvDetails.Where(x => invRawMaterialList.Select(i => i.InvRawMaterialID).Contains((int)x.InvRawMaterialID)).ToList();

                foreach (CardInvDetails cardInvDetail in cardInvDetailList)
                    _repositoryFactory.CardInvDetails.Delete(cardInvDetail);

                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public long DeleteByRawMaterialsDeliveredToProductionDetailID(int rawMaterialsDeliveredToProductionDetailID)
        {
            try
            {
                var cardInvDetails = _repositoryFactory.CardInvDetails
                    .FirstOrDefault(x => x.RawMaterialsDeliveredToProductionDetailID == rawMaterialsDeliveredToProductionDetailID);

                if (cardInvDetails == null)
                    throw new System.Exception("CardInvDetails Notfound.");

                _repositoryFactory.CardInvDetails.Delete(cardInvDetails);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public long DeleteByInvProductionRawMaterialID(int invProductionRawMaterialID)
        {
            try
            {
                var cardInvDetails = _repositoryFactory.CardInvDetails
                    .FirstOrDefault(x => x.InvProductionRawMaterialID == invProductionRawMaterialID);

                if (cardInvDetails == null)
                    return 0;
                //    throw new System.Exception("CardInvDetails Notfound.");

                _repositoryFactory.CardInvDetails.Delete(cardInvDetails);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public long DeleteByDataDosingDetailID(int dataDosingDetailID)
        {
            try
            {

                var cardInvDetails = _repositoryFactory.CardInvDetails
                    .FirstOrDefault(x => x.DataDosingDetailID == dataDosingDetailID);

                if (cardInvDetails == null)
                    return 0;
                //    throw new System.Exception("CardInvDetails Notfound.");

                _repositoryFactory.CardInvDetails.Delete(cardInvDetails);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        //public long Delete(int )
        //{
        //    try
        //    {
        //        var cardInvDetails = _repositoryFactory.CardInvDetails
        //            .FirstOrDefault(x => x. == );

        //        if (cardInvDetails == null)
        //            throw new System.Exception("CardInvDetails Notfound.");

        //        _repositoryFactory.CardInvDetails.Delete(cardInvDetails);
        //        var statuse = _unitOfWork.Commit();

        //        return statuse;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}



    }
}
