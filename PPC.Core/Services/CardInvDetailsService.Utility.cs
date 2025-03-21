using PPC.Common;
using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Services
{
    public partial class CardInvDetailsService : BaseService
    {

        public bool AppendCardInvDetails(InvRawMaterials invRawMaterials, int invRawMaterialID, short? groupRawId = null)
        {
            CardInvDetails cardInvDetails = new CardInvDetails();

            cardInvDetails.InvTypeID = 'R';
            cardInvDetails.Year = General.Year;
            cardInvDetails.RawMaterialID = invRawMaterials.RawMaterialID;
            cardInvDetails.EntryDate = invRawMaterials.EntryDate;
            cardInvDetails.EntryTime = invRawMaterials.EditTime;
            //cardInvDetails.Amount = invRawMaterials.NetWeight;
            cardInvDetails.Amount = invRawMaterials.InvRawMaterialLotsList.Sum(x=>x.NetWeight);
            cardInvDetails.CardTypeVal = '$';
            cardInvDetails.IsEntry = true;
            cardInvDetails.InsDate = invRawMaterials.InsDate;
            cardInvDetails.InsTime = invRawMaterials.InsTime;
            cardInvDetails.InsUserID = invRawMaterials.InsUserID;
            cardInvDetails.InvRawMaterialID = invRawMaterialID;
            cardInvDetails.RawMaterialsDeliveredToProductionDetailID = null;
            cardInvDetails.InvProductionRawMaterialID = null;
            cardInvDetails.DataDosingDetailID = null;
            cardInvDetails.GroupRawId = groupRawId;

            var _newInstance = Append(cardInvDetails);

            return _newInstance != null;
        }

        public bool UpdateCardInvDetails(InvRawMaterials invRawMaterials)
        {
            var statuse = false;

            var cardInvDetails = _repositoryFactory.CardInvDetails.Table
                .FirstOrDefault(x => x.InvRawMaterialID == invRawMaterials.InvRawMaterialID);

            if (cardInvDetails != null)
            {
                //cardInvDetails.Amount = invRawMaterials.NetWeight;
                cardInvDetails.Amount = invRawMaterials.InvRawMaterialLotsList.Sum(x => x.NetWeight);

                CardInvDetailsService detail = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
                statuse = detail.Update(cardInvDetails);
            }

            return statuse;
        }

        public bool DeleteCardInvDetailsByInvRawMaterials(List<InvRawMaterials> invRawMaterialList)
        {

            //using (var t = _unitOfWork.StartTransaction())
            {
                try
                {
                    var statuse = true;

                    ////در زمان بروز رسانی اینجا خطا داریم

                    //invRawMaterialList.ForEach(invRawMaterials =>
                    //{
                    //    CardInvDetailsService detail = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
                    //    statuse &= detail.DeleteByInvRawMaterialID(invRawMaterials.InvRawMaterialID) > 0;
                    //});

                    //در زمان بروز رسانی اینجا خطا داریم


                    //CardInvDetailsService detail = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
                    //statuse &= detail.DeleteByInvRawMaterials(invRawMaterialList) > 0;

                    //CardInvDetailsService detail = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
                    // var q = detail.DeleteByInvRawMaterials(invRawMaterialList).Result;

                    DeleteByInvRawMaterials(invRawMaterialList);



                    //t.Commit();
                    return statuse;
                }
                catch
                {
                    //t.Rollback();
                    throw;
                }

            }
        }


    }
}
