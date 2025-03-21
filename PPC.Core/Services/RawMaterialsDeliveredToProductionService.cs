using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PPC.Common;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class RawMaterialsDeliveredToProductionService : BaseService, IRawMaterialsDeliveredToProductionService
    {
        IUnitOfWork _unitOfWork;
        public RawMaterialsDeliveredToProductionService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<RawMaterialsDeliveredToProduction> GetAll()
        {
            try
            {
                var rawMaterialsDeliveredToProduction = _repositoryFactory.RawMaterialsDeliveredToProduction.Table
                    .Include(x => x.DeliveryRawMaterialToProduction)
                    .Include(x => x.RawMaterialsDeliveredToProductionDetailList).ThenInclude(x => x.RawMaterial)
                    .ToList();

                return rawMaterialsDeliveredToProduction;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RawMaterialsDeliveredToProduction>> GetAllAsync()
        {
            try
            {
                var rawMaterialsDeliveredToProduction = await _repositoryFactory.RawMaterialsDeliveredToProduction.Table
                    .Include(x => x.DeliveryRawMaterialToProduction).ThenInclude(x => x.Requester)
                    .Include(x => x.DeliveryUser)
                    .Include(x => x.RawMaterialsDeliveredToProductionDetailList).ThenInclude(x => x.RawMaterial)

                    .ToListAsync();
                return rawMaterialsDeliveredToProduction;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public RawMaterialsDeliveredToProduction GetRawMaterialsDeliveredToProductionById(int rawMaterialsDeliveredToProductionID)
        {
            try
            {
                var rawMaterialsDeliveredToProduction = _repositoryFactory.RawMaterialsDeliveredToProduction
                    .FirstOrDefault(x => x.RawMaterialsDeliveredToProductionID == rawMaterialsDeliveredToProductionID);

                return rawMaterialsDeliveredToProduction;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RawMaterialsDeliveredToProduction> GetRawMaterialsDeliveredToProductionByIdAsync(int rawMaterialsDeliveredToProductionID)
        {
            try
            {
                var rawMaterialsDeliveredToProduction = await _repositoryFactory.RawMaterialsDeliveredToProduction.Table
                    .Include(x => x.DeliveryRawMaterialToProduction)
                    .Include(x => x.RawMaterialsDeliveredToProductionDetailList).ThenInclude(x => x.RawMaterial)

                    .FirstOrDefaultAsync(x => x.RawMaterialsDeliveredToProductionID == rawMaterialsDeliveredToProductionID);

                return rawMaterialsDeliveredToProduction;
            }
            catch
            {
                throw;
            }
        }

        //public int Append(RawMaterialsDeliveredToProduction rawMaterialsDeliveredToProduction)
        //{
        //    using (var t = _unitOfWork.StartTransaction())
        //    {
        //        var i = 0;
        //        try
        //        {

        //            #region Update requst status to Deleiverd

        //            //// deliverd update
        //            var deliveryRawMaterialToProduction = _repositoryFactory.DeliveryRawMaterialToProduction.FirstOrDefault(x => x.DeliveryRawMaterialToProductionID == rawMaterialsDeliveredToProduction.DeliveryRawMaterialToProductionID);
        //            deliveryRawMaterialToProduction.Status = (byte)DeliveryRawMaterialToProductionStatus.Deleiverd;

        //            #endregion


        //            #region Append RawMaterialsDeliveredToProduction --> تحویل مواد درخواست شده

        //            var _newObject = new RawMaterialsDeliveredToProduction
        //            {
        //                RawMaterialsDeliveredToProductionID = rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionID,
        //                DeliveryRawMaterialToProductionID = rawMaterialsDeliveredToProduction.DeliveryRawMaterialToProductionID,
        //                DeliverDate = rawMaterialsDeliveredToProduction.DeliverDate,
        //                DeliverTime = rawMaterialsDeliveredToProduction.DeliverTime,
        //                DeliveryUserID = rawMaterialsDeliveredToProduction.DeliveryUserID,
        //                ReceivingUserID = rawMaterialsDeliveredToProduction.ReceivingUserID,
        //                Describe = rawMaterialsDeliveredToProduction.Describe,
        //                Status = rawMaterialsDeliveredToProduction.Status,
        //                InsUserID = rawMaterialsDeliveredToProduction.InsUserID,
        //                InsDate = rawMaterialsDeliveredToProduction.InsDate,
        //                InsTime = rawMaterialsDeliveredToProduction.InsTime,
        //                IsDraft = rawMaterialsDeliveredToProduction.IsDraft,
        //                EditUserID = rawMaterialsDeliveredToProduction.EditUserID,
        //                EditDate = rawMaterialsDeliveredToProduction.EditDate,
        //                EditTime = rawMaterialsDeliveredToProduction.EditTime,
        //                RawMaterialsDeliveredToProductionDetailList = rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionDetailList,
        //                //RowVer = rawMaterialsDeliveredToProduction.RowVer,

        //            };

        //            _repositoryFactory.RawMaterialsDeliveredToProduction.Add(_newObject);
        //            var statuse = _unitOfWork.Commit() > 0;

        //            #endregion

        //            #region Append InvProductionRawMaterials --> ورود به پای کار تولید

        //            var newInvProductionRawMaterialList = new List<InvProductionRawMaterials>();
        //            _newObject.RawMaterialsDeliveredToProductionDetailList.ForEach(detail =>
        //            {
        //                var newInvProduction = new InvProductionRawMaterials
        //                {
        //                    RawMaterialID = detail.RawMaterialID,
        //                    RawMaterialsDeliveredToProductionID = _newObject.RawMaterialsDeliveredToProductionID,
        //                    Weight = detail.DeliveredAmount,
        //                    EntryDate = rawMaterialsDeliveredToProduction.DeliverDate,
        //                    EntryTime = rawMaterialsDeliveredToProduction.DeliverTime,
        //                    ReceivingUserID = rawMaterialsDeliveredToProduction.ReceivingUserID,
        //                    InsUserID = rawMaterialsDeliveredToProduction.InsUserID,
        //                    InsDate = rawMaterialsDeliveredToProduction.InsDate,
        //                    InsTime = rawMaterialsDeliveredToProduction.InsTime,
        //                    EditUserID = rawMaterialsDeliveredToProduction.EditUserID,
        //                    EditDate = rawMaterialsDeliveredToProduction.EditDate,
        //                    EditTime = rawMaterialsDeliveredToProduction.EditTime,
        //                    InsSysTime = null,
        //                };

        //                InvProductionRawMaterialsService invProductionRawMaterialsService = new InvProductionRawMaterialsService(_repositoryFactory, _unitOfWork);
        //                newInvProduction.InvProductionRawMaterialID = invProductionRawMaterialsService.Append(newInvProduction);
        //                if (newInvProduction.InvProductionRawMaterialID > 0)
        //                {
        //                    //statuse &= _unitOfWork.Commit() > 0;
        //                    //_repositoryFactory.InvProductionRawMaterials.Add(newInvProduction);
        //                    //statuse &= _unitOfWork.Commit() > 0;
        //                    newInvProductionRawMaterialList.Add(newInvProduction);
        //                }
        //                else
        //                {
        //                    statuse = false;
        //                }

        //            });

        //            //_newObject.RawMaterialsDeliveredToProductionDetailList.ForEach(detail =>
        //            //{
        //            //    _repositoryFactory.InvProductionRawMaterials.Add(new InvProductionRawMaterials
        //            //    {
        //            //        RawMaterialID = detail.RawMaterialID,
        //            //        Weight= detail.DeliveredAmount,
        //            //        EntryDate = rawMaterialsDeliveredToProduction.DeliverDate,
        //            //        EntryTime = rawMaterialsDeliveredToProduction.DeliverTime,
        //            //        ReceivingUserID = rawMaterialsDeliveredToProduction.ReceivingUserID,
        //            //        InsUserID = rawMaterialsDeliveredToProduction.InsUserID,
        //            //        InsDate = rawMaterialsDeliveredToProduction.InsDate,
        //            //        InsTime = rawMaterialsDeliveredToProduction.InsTime,
        //            //        EditUserID = rawMaterialsDeliveredToProduction.EditUserID,
        //            //        EditDate = rawMaterialsDeliveredToProduction.EditDate,
        //            //        EditTime = rawMaterialsDeliveredToProduction.EditTime,
        //            //    });
        //            //});

        //            #endregion

        //            #region Append to Kardex --> کاردکس

        //            if (statuse)
        //            {

        //                #region (Kardex) ==> Append CardInvDetail - خروج از انبار مواد

        //                //جمع مواد تحویل شده به ازای هر ماده
        //                var sumOfDetails = rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionDetailList.GroupBy(x => new
        //                {
        //                    x.RawMaterialID,
        //                }).Select(g => new
        //                {
        //                    g.Key.RawMaterialID,
        //                    DeliveredAmount = g.Sum(x => x.DeliveredAmount)
        //                }).ToList();

        //                sumOfDetails.ForEach(detail =>
        //                {
        //                    CardInvDetails cardInvDetails = new CardInvDetails();

        //                    cardInvDetails.InvTypeID = 'R';
        //                    cardInvDetails.Year = General.Year;
        //                    cardInvDetails.RawMaterialID = detail.RawMaterialID;
        //                    cardInvDetails.EntryDate = rawMaterialsDeliveredToProduction.DeliverDate;
        //                    cardInvDetails.EntryTime = rawMaterialsDeliveredToProduction.DeliverTime;
        //                    cardInvDetails.Amount = detail.DeliveredAmount;
        //                    cardInvDetails.CardTypeVal = '#';
        //                    cardInvDetails.IsEntry = false;
        //                    cardInvDetails.InsDate = rawMaterialsDeliveredToProduction.InsDate;
        //                    cardInvDetails.InsTime = rawMaterialsDeliveredToProduction.InsTime;
        //                    cardInvDetails.InsUserID = rawMaterialsDeliveredToProduction.InsUserID;
        //                    cardInvDetails.InvRawMaterialID = null;
        //                    cardInvDetails.RawMaterialsDeliveredToProductionDetailID = rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionDetailList.FirstOrDefault(x => x.RawMaterialID == detail.RawMaterialID).RawMaterialsDeliveredToProductionDetailID;

        //                    CardInvDetailsService card = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
        //                    cardInvDetails = card.Append(cardInvDetails);

        //                    if (cardInvDetails == null)
        //                        statuse &= false;
        //                });


        //                #endregion

        //                #region (Kardex) ==> Append InvProductionRawMaterials - ورود به انبار پای کار تولید


        //                //جمع مواد تحویل شده به ازای هر ماده
        //                var sumOfProduction = newInvProductionRawMaterialList.GroupBy(x => new
        //                {
        //                    x.RawMaterialID,
        //                }).Select(g => new
        //                {
        //                    g.Key.RawMaterialID,
        //                    Weight = g.Sum(x => x.Weight)
        //                }).ToList();

        //                sumOfProduction.ForEach(detail =>
        //                {
        //                    var firstInvPRM = newInvProductionRawMaterialList.First(x => x.RawMaterialID == detail.RawMaterialID);
        //                    CardInvDetails cardInvDetails = new CardInvDetails();

        //                    cardInvDetails.InvTypeID = 'P';
        //                    cardInvDetails.Year = General.Year;
        //                    cardInvDetails.RawMaterialID = detail.RawMaterialID;
        //                    cardInvDetails.EntryDate = firstInvPRM.EntryDate;
        //                    cardInvDetails.EntryTime = firstInvPRM.EntryTime;
        //                    cardInvDetails.Amount = detail.Weight;
        //                    cardInvDetails.CardTypeVal = '$';
        //                    cardInvDetails.IsEntry = true;
        //                    cardInvDetails.InsDate = newInvProductionRawMaterialList.First(x => x.RawMaterialID == detail.RawMaterialID).InsDate;
        //                    cardInvDetails.InsTime = newInvProductionRawMaterialList.First(x => x.RawMaterialID == detail.RawMaterialID).InsTime;
        //                    cardInvDetails.InsUserID = firstInvPRM.InsUserID;
        //                    cardInvDetails.InvRawMaterialID = null;
        //                    cardInvDetails.RawMaterialsDeliveredToProductionDetailID = null;
        //                    cardInvDetails.InvProductionRawMaterialID = firstInvPRM.InvProductionRawMaterialID;
        //                    cardInvDetails.DataDosingDetailID = null;

        //                    CardInvDetailsService cardInvDetailsService = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
        //                    cardInvDetails = cardInvDetailsService.Append(cardInvDetails);

        //                    if (cardInvDetails == null)
        //                        statuse &= false;

        //                });




        //                ////جمع مواد تحویل شده به ازای هر ماده
        //                //var sumOfProduction = newInvProductionRawMaterialList.GroupBy(x => new
        //                //{
        //                //    x.RawMaterialID,
        //                //}).Select(g => new
        //                //{
        //                //    g.Key.RawMaterialID,
        //                //    Weight = g.Sum(x => x.Weight)
        //                //}).ToList();

        //                //sumOfProduction.ForEach(detail =>
        //                //{
        //                //    var firstInvPRM = newInvProductionRawMaterialList.First(x => x.RawMaterialID == detail.RawMaterialID);
        //                //    CardInvDetails cardInvDetails = new CardInvDetails();

        //                //    cardInvDetails.InvTypeID = 'P';
        //                //    cardInvDetails.Year = General.Year;
        //                //    cardInvDetails.RawMaterialID = detail.RawMaterialID;
        //                //    cardInvDetails.EntryDate = firstInvPRM.EntryDate;
        //                //    cardInvDetails.EntryTime = firstInvPRM.EntryTime;
        //                //    cardInvDetails.Amount = detail.Weight;
        //                //    cardInvDetails.CardTypeVal = '$';
        //                //    cardInvDetails.IsEntry = true;
        //                //    cardInvDetails.InsDate = newInvProductionRawMaterialList.First(x => x.RawMaterialID == detail.RawMaterialID).InsDate;
        //                //    cardInvDetails.InsTime = newInvProductionRawMaterialList.First(x => x.RawMaterialID == detail.RawMaterialID).InsTime;
        //                //    cardInvDetails.InsUserID = firstInvPRM.InsUserID;
        //                //    cardInvDetails.InvRawMaterialID = null;
        //                //    cardInvDetails.RawMaterialsDeliveredToProductionDetailID = null;
        //                //    cardInvDetails.InvProductionRawMaterialID = firstInvPRM.InvProductionRawMaterialID;
        //                //    cardInvDetails.DataDosingDetailID = null;

        //                //    CardInvDetailsService cardInvDetailsService = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
        //                //    cardInvDetails = cardInvDetailsService.Append(cardInvDetails);

        //                //    if (cardInvDetails == null)
        //                //        statuse &= false;

        //                //});

        //                #endregion
        //            }

        //            #endregion

        //            t.Commit();


        //            if (statuse)
        //                return _newObject.RawMaterialsDeliveredToProductionID;
        //            else
        //                throw new System.Exception(Resources.Resources.pub_RegistrationHasError);
        //        }
        //        catch (System.Exception)
        //        {
        //            t.Rollback();

        //            throw;
        //        }
        //    }
        //}

        public int Append(RawMaterialsDeliveredToProduction rawMaterialsDeliveredToProduction)
        {
            using (var t = _unitOfWork.StartTransaction())
            {
                var i = 0;
                try
                {

                    #region Update requst status to Deleiverd

                    //// deliverd update
                    var deliveryRawMaterialToProduction = _repositoryFactory.DeliveryRawMaterialToProduction.FirstOrDefault(x => x.DeliveryRawMaterialToProductionID == rawMaterialsDeliveredToProduction.DeliveryRawMaterialToProductionID);
                    deliveryRawMaterialToProduction.Status = (byte)DeliveryRawMaterialToProductionStatus.Deleiverd;

                    #endregion


                    #region Append RawMaterialsDeliveredToProduction --> تحویل مواد درخواست شده

                    var _newObject = new RawMaterialsDeliveredToProduction
                    {
                        RawMaterialsDeliveredToProductionID = rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionID,
                        DeliveryRawMaterialToProductionID = rawMaterialsDeliveredToProduction.DeliveryRawMaterialToProductionID,
                        DeliverDate = rawMaterialsDeliveredToProduction.DeliverDate,
                        DeliverTime = rawMaterialsDeliveredToProduction.DeliverTime,
                        DeliveryUserID = rawMaterialsDeliveredToProduction.DeliveryUserID,
                        ReceivingUserID = rawMaterialsDeliveredToProduction.ReceivingUserID,
                        Describe = rawMaterialsDeliveredToProduction.Describe,
                        Status = rawMaterialsDeliveredToProduction.Status,
                        InsUserID = rawMaterialsDeliveredToProduction.InsUserID,
                        InsDate = rawMaterialsDeliveredToProduction.InsDate,
                        InsTime = rawMaterialsDeliveredToProduction.InsTime,
                        IsDraft = rawMaterialsDeliveredToProduction.IsDraft,
                        EditUserID = rawMaterialsDeliveredToProduction.EditUserID,
                        EditDate = rawMaterialsDeliveredToProduction.EditDate,
                        EditTime = rawMaterialsDeliveredToProduction.EditTime,
                        RawMaterialsDeliveredToProductionDetailList = rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionDetailList,
                        //RowVer = rawMaterialsDeliveredToProduction.RowVer,

                    };

                    _repositoryFactory.RawMaterialsDeliveredToProduction.Add(_newObject);
                    var statuse = _unitOfWork.Commit() > 0;

                    #endregion

                    #region Append InvProductionRawMaterials --> ورود به پای کار تولید

                    var newInvProductionRawMaterialList = new List<InvProductionRawMaterials>();
                    _newObject.RawMaterialsDeliveredToProductionDetailList.ForEach(detail =>
                    {
                        var newInvProduction = new InvProductionRawMaterials
                        {
                            RawMaterialID = detail.RawMaterialID,
                            RawMaterialsDeliveredToProductionID = _newObject.RawMaterialsDeliveredToProductionID,
                            Weight = detail.DeliveredAmount,
                            EntryDate = rawMaterialsDeliveredToProduction.DeliverDate,
                            EntryTime = rawMaterialsDeliveredToProduction.DeliverTime,
                            ReceivingUserID = rawMaterialsDeliveredToProduction.ReceivingUserID,
                            InsUserID = rawMaterialsDeliveredToProduction.InsUserID,
                            InsDate = rawMaterialsDeliveredToProduction.InsDate,
                            InsTime = rawMaterialsDeliveredToProduction.InsTime,
                            EditUserID = rawMaterialsDeliveredToProduction.EditUserID,
                            EditDate = rawMaterialsDeliveredToProduction.EditDate,
                            EditTime = rawMaterialsDeliveredToProduction.EditTime,
                            InsSysTime = null,
                        };

                        InvProductionRawMaterialsService invProductionRawMaterialsService = new InvProductionRawMaterialsService(_repositoryFactory, _unitOfWork);
                        newInvProduction.InvProductionRawMaterialID = invProductionRawMaterialsService.Append(newInvProduction);
                        if (newInvProduction.InvProductionRawMaterialID > 0)
                        {
                            newInvProductionRawMaterialList.Add(newInvProduction);
                        }
                        else
                        {
                            statuse = false;
                        }

                    });

                    #endregion

                    #region Append to Kardex --> کاردکس

                    if (!statuse)
                        throw new System.Exception("بعلت بروز خطای فنی امکان ثبت اطلاعات در کاردکس میسر نمی باشد!");


                    #region (Kardex) ==> Append CardInvDetail - خروج از انبار مواد

                    //جمع مواد تحویل شده به ازای هر ماده
                    //var sumOfDetails = rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionDetailList.GroupBy(x => new
                    //{
                    //    x.RawMaterialID,
                    //}).Select(g => new
                    //{
                    //    g.Key.RawMaterialID,
                    //    DeliveredAmount = g.Sum(x => x.DeliveredAmount)
                    //}).ToList();

                    foreach (RawMaterialsDeliveredToProductionDetail detail in rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionDetailList)
                    {
                        //rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionDetailList.ForEach(detail =>
                        //    {
                        CardInvDetails cardInvDetails = new CardInvDetails();
                        if (detail.DeliveredAmount == 0)
                            continue;

                        cardInvDetails.InvTypeID = 'R';
                        cardInvDetails.Year = General.Year;
                        cardInvDetails.RawMaterialID = detail.RawMaterialID;
                        cardInvDetails.EntryDate = rawMaterialsDeliveredToProduction.DeliverDate;
                        cardInvDetails.EntryTime = rawMaterialsDeliveredToProduction.DeliverTime;
                        cardInvDetails.Amount = detail.DeliveredAmount;
                        cardInvDetails.CardTypeVal = '#';
                        cardInvDetails.IsEntry = false;
                        cardInvDetails.InsDate = rawMaterialsDeliveredToProduction.InsDate;
                        cardInvDetails.InsTime = rawMaterialsDeliveredToProduction.InsTime;
                        cardInvDetails.InsUserID = rawMaterialsDeliveredToProduction.InsUserID;
                        cardInvDetails.InvRawMaterialID = null;
                        cardInvDetails.RawMaterialsDeliveredToProductionDetailID = rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionDetailList.FirstOrDefault(x => x.RawMaterialID == detail.RawMaterialID).RawMaterialsDeliveredToProductionDetailID;

                        CardInvDetailsService card = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
                        cardInvDetails = card.Append(cardInvDetails);

                        if (cardInvDetails == null)
                            statuse &= false;
                        //});
                    }

                    #endregion

                    #region (Kardex) ==> Append InvProductionRawMaterials - ورود به انبار پای کار تولید


                    //جمع مواد تحویل شده به ازای هر ماده
                    //var sumOfProduction = newInvProductionRawMaterialList.GroupBy(x => new
                    //{
                    //    x.RawMaterialID,
                    //}).Select(g => new
                    //{
                    //    g.Key.RawMaterialID,
                    //    Weight = g.Sum(x => x.Weight)
                    //}).ToList();

                    foreach (InvProductionRawMaterials detail in newInvProductionRawMaterialList)
                    {

                        if (detail.Weight == 0)
                            continue;

                        //newInvProductionRawMaterialList.ForEach(detail =>
                        //{
                        var firstInvPRM = newInvProductionRawMaterialList.First(x => x.RawMaterialID == detail.RawMaterialID);
                        CardInvDetails cardInvDetails = new CardInvDetails();

                        cardInvDetails.InvTypeID = 'P';
                        cardInvDetails.Year = General.Year;
                        cardInvDetails.RawMaterialID = detail.RawMaterialID;
                        cardInvDetails.EntryDate = firstInvPRM.EntryDate;
                        cardInvDetails.EntryTime = firstInvPRM.EntryTime;
                        cardInvDetails.Amount = detail.Weight;
                        cardInvDetails.CardTypeVal = '$';
                        cardInvDetails.IsEntry = true;
                        cardInvDetails.InsDate = newInvProductionRawMaterialList.First(x => x.RawMaterialID == detail.RawMaterialID).InsDate;
                        cardInvDetails.InsTime = newInvProductionRawMaterialList.First(x => x.RawMaterialID == detail.RawMaterialID).InsTime;
                        cardInvDetails.InsUserID = firstInvPRM.InsUserID;
                        cardInvDetails.InvRawMaterialID = null;
                        cardInvDetails.RawMaterialsDeliveredToProductionDetailID = null;
                        cardInvDetails.InvProductionRawMaterialID = firstInvPRM.InvProductionRawMaterialID;
                        cardInvDetails.DataDosingDetailID = null;

                        CardInvDetailsService cardInvDetailsService = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
                        cardInvDetails = cardInvDetailsService.Append(cardInvDetails);

                        if (cardInvDetails == null)
                            statuse &= false;

                        //});

                    }


                    ////جمع مواد تحویل شده به ازای هر ماده
                    //var sumOfProduction = newInvProductionRawMaterialList.GroupBy(x => new
                    //{
                    //    x.RawMaterialID,
                    //}).Select(g => new
                    //{
                    //    g.Key.RawMaterialID,
                    //    Weight = g.Sum(x => x.Weight)
                    //}).ToList();

                    //sumOfProduction.ForEach(detail =>
                    //{
                    //    var firstInvPRM = newInvProductionRawMaterialList.First(x => x.RawMaterialID == detail.RawMaterialID);
                    //    CardInvDetails cardInvDetails = new CardInvDetails();

                    //    cardInvDetails.InvTypeID = 'P';
                    //    cardInvDetails.Year = General.Year;
                    //    cardInvDetails.RawMaterialID = detail.RawMaterialID;
                    //    cardInvDetails.EntryDate = firstInvPRM.EntryDate;
                    //    cardInvDetails.EntryTime = firstInvPRM.EntryTime;
                    //    cardInvDetails.Amount = detail.Weight;
                    //    cardInvDetails.CardTypeVal = '$';
                    //    cardInvDetails.IsEntry = true;
                    //    cardInvDetails.InsDate = newInvProductionRawMaterialList.First(x => x.RawMaterialID == detail.RawMaterialID).InsDate;
                    //    cardInvDetails.InsTime = newInvProductionRawMaterialList.First(x => x.RawMaterialID == detail.RawMaterialID).InsTime;
                    //    cardInvDetails.InsUserID = firstInvPRM.InsUserID;
                    //    cardInvDetails.InvRawMaterialID = null;
                    //    cardInvDetails.RawMaterialsDeliveredToProductionDetailID = null;
                    //    cardInvDetails.InvProductionRawMaterialID = firstInvPRM.InvProductionRawMaterialID;
                    //    cardInvDetails.DataDosingDetailID = null;

                    //    CardInvDetailsService cardInvDetailsService = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
                    //    cardInvDetails = cardInvDetailsService.Append(cardInvDetails);

                    //    if (cardInvDetails == null)
                    //        statuse &= false;

                    //});

                    #endregion


                    #endregion

                    t.Commit();


                    if (statuse)
                        return _newObject.RawMaterialsDeliveredToProductionID;
                    else
                        throw new System.Exception(Resources.Resources.pub_RegistrationHasError);
                }
                catch (System.Exception)
                {
                    t.Rollback();

                    throw;
                }
            }
        }


        public bool Update(RawMaterialsDeliveredToProduction rawMaterialsDeliveredToProduction)
        {



            using (var t = _unitOfWork.StartTransaction())
            {
                try
                {

                    #region update RawMaterialsDeliveredToProduction

                    _repositoryFactory.RawMaterialsDeliveredToProduction.UpdateBy(x => x.RawMaterialsDeliveredToProductionID == rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionID,
                        new RawMaterialsDeliveredToProduction
                        {
                            RawMaterialsDeliveredToProductionID = rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionID,
                            DeliveryRawMaterialToProductionID = rawMaterialsDeliveredToProduction.DeliveryRawMaterialToProductionID,
                            DeliverDate = rawMaterialsDeliveredToProduction.DeliverDate,
                            DeliverTime = rawMaterialsDeliveredToProduction.DeliverTime,
                            DeliveryUserID = rawMaterialsDeliveredToProduction.DeliveryUserID,
                            ReceivingUserID = rawMaterialsDeliveredToProduction.ReceivingUserID,
                            Describe = rawMaterialsDeliveredToProduction.Describe,
                            Status = rawMaterialsDeliveredToProduction.Status,
                            InsUserID = rawMaterialsDeliveredToProduction.InsUserID,
                            InsDate = rawMaterialsDeliveredToProduction.InsDate,
                            InsTime = rawMaterialsDeliveredToProduction.InsTime,
                            IsDraft = rawMaterialsDeliveredToProduction.IsDraft,
                            EditUserID = rawMaterialsDeliveredToProduction.EditUserID,
                            EditDate = rawMaterialsDeliveredToProduction.EditDate,
                            EditTime = rawMaterialsDeliveredToProduction.EditTime,
                            RawMaterialsDeliveredToProductionDetailList = rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionDetailList,
                            //RowVer = rawMaterialsDeliveredToProduction.RowVer,
                        });

                    #endregion

                    #region update InvProductionRawMaterials

                    rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionDetailList.ForEach(x =>
                    {
                        var invProduct = _repositoryFactory.InvProductionRawMaterials.FirstOrDefault(i => i.RawMaterialsDeliveredToProductionID == rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionID && i.RawMaterialID == x.RawMaterialID);

                        _repositoryFactory.InvProductionRawMaterials.UpdateBy(i => i.RawMaterialsDeliveredToProductionID == rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionID && i.RawMaterialID == x.RawMaterialID,
                            new InvProductionRawMaterials
                            {
                                InvProductionRawMaterialID = invProduct.InvProductionRawMaterialID,
                                RawMaterialID = x.RawMaterialID,
                                RawMaterialsDeliveredToProductionID = x.RawMaterialsDeliveredToProductionID,
                                Weight = x.DeliveredAmount,
                                EntryDate = rawMaterialsDeliveredToProduction.DeliverDate,
                                EntryTime = rawMaterialsDeliveredToProduction.DeliverTime,
                                ReceivingUserID = rawMaterialsDeliveredToProduction.ReceivingUserID,
                                InsUserID = rawMaterialsDeliveredToProduction.InsUserID,
                                InsDate = rawMaterialsDeliveredToProduction.InsDate,
                                InsTime = rawMaterialsDeliveredToProduction.InsTime,
                                EditUserID = rawMaterialsDeliveredToProduction.EditUserID,
                                EditDate = rawMaterialsDeliveredToProduction.EditDate,
                                EditTime = rawMaterialsDeliveredToProduction.EditTime,

                            });

                    });

                    #endregion


                    var statuse = _unitOfWork.Commit() > 0;

                    #region Append to Kardex --> کاردکس

                    if (statuse)
                    {

                        #region  بروز رسانی رکورد های کاردکس منطبق با شناسه ورود به انبار پای کار

                        ///  شناسه های انبار پای کار
                        var invProductionIdList = _repositoryFactory.InvProductionRawMaterials.Where(x => x.RawMaterialsDeliveredToProductionID == rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionID);

                        /// رکورد های مرتبط به شناسه انبار پای کار
                        var cardInvProductionList = _repositoryFactory.CardInvDetails
                            .Where(x => x.InvProductionRawMaterialID != null && invProductionIdList.Select(x => x.InvProductionRawMaterialID).Contains((int)x.InvProductionRawMaterialID)).ToList();

                        if (cardInvProductionList != null)
                        {
                            cardInvProductionList.ForEach(x =>
                            {
                                var cardInvDetail = _repositoryFactory.CardInvDetails.FirstOrDefault(c => c.InvProductionRawMaterialID == x.InvProductionRawMaterialID);
                                cardInvDetail.Amount = invProductionIdList.First(i => i.InvProductionRawMaterialID == x.InvProductionRawMaterialID).Weight;
                            });
                        }

                        #endregion

                        statuse &= _unitOfWork.Commit() > 0;

                        #region  بروز رسانی رکورد های کاردکس منطبق با شناسه خروج از انبار به تولید


                        rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionDetailList.ForEach(x =>
                        {
                            var cardInvProductionList = _repositoryFactory.CardInvDetails.FirstOrDefault(c => c.RawMaterialsDeliveredToProductionDetailID == x.RawMaterialsDeliveredToProductionDetailID);

                            cardInvProductionList.Amount = x.DeliveredAmount;
                        });

                        statuse &= _unitOfWork.Commit() > 0;

                        #endregion

                        statuse &= _unitOfWork.Commit() > 0;

                    }

                    #endregion

                    t.Commit();
                    return statuse;
                }
                catch (System.Exception)
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        public long Delete(int rawMaterialsDeliveredToProductionID)
        {
            using (var t = _unitOfWork.StartTransaction())
            {
                try
                {
                    #region delete  RawMaterialsDeliveredToProduction && InvProductionRawMaterials

                    var rawMaterialsDeliveredToProduction = _repositoryFactory.RawMaterialsDeliveredToProduction.Table.Include(x => x.RawMaterialsDeliveredToProductionDetailList)
                        .FirstOrDefault(x => x.RawMaterialsDeliveredToProductionID == rawMaterialsDeliveredToProductionID);

                    if (rawMaterialsDeliveredToProduction == null)
                        throw new System.Exception("RawMaterialsDeliveredToProduction Notfound.");

                    ///use in Kardex
                    var DeliverdDetailIDList = rawMaterialsDeliveredToProduction.RawMaterialsDeliveredToProductionDetailList.Select(x => x.RawMaterialsDeliveredToProductionDetailID).ToList();
                    var InvProductionRawMaterialIDList = _repositoryFactory.InvProductionRawMaterials.Where(x => x.RawMaterialsDeliveredToProductionID == rawMaterialsDeliveredToProductionID).ToList();

                    ///Delete  InvProductionRawMaterials recordes
                    _repositoryFactory.InvProductionRawMaterials.DeleteBy(x => x.RawMaterialsDeliveredToProductionID == rawMaterialsDeliveredToProductionID);

                    ///Delete  RawMaterialsDeliveredToProduction recordes
                    _repositoryFactory.RawMaterialsDeliveredToProduction.Delete(rawMaterialsDeliveredToProduction);


                    //long statuse = _unitOfWork.Commit();

                    #endregion

                    #region Update requst status to Deleiverd

                    //// deliverd update
                    var deliveryRawMaterialToProduction = _repositoryFactory.DeliveryRawMaterialToProduction.FirstOrDefault(x => x.DeliveryRawMaterialToProductionID == rawMaterialsDeliveredToProduction.DeliveryRawMaterialToProductionID);
                    deliveryRawMaterialToProduction.Status = (byte)DeliveryRawMaterialToProductionStatus.Saved;

                    #endregion

                    long statuse = _unitOfWork.Commit();

                    #region Kardex

                    #region  حذف رکورد های کاردکس منطبق با شناسه ورود به انبار پای کار

                    var cardInvProductionList = _repositoryFactory.CardInvDetails
                        .Where(x => x.InvProductionRawMaterialID != null && InvProductionRawMaterialIDList.Select(i => i.InvProductionRawMaterialID).Contains((int)x.InvProductionRawMaterialID)).ToList();

                    if (cardInvProductionList != null)
                    {
                        CardInvDetailsService detail = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
                        cardInvProductionList.ForEach(x =>
                        {
                            //حذف رکورد های کاردکس منطبق با پای کار تولید
                            statuse &= detail.DeleteByInvProductionRawMaterialID(Convert.ToInt32(x.InvProductionRawMaterialID));
                        });
                    }

                    #endregion


                    #region حذف رکورد های کاردکس منطبق با شناسه خروج از انبار مواد اولیه

                    var cardInvDetailDeliverdList = _repositoryFactory.CardInvDetails
                        .Where(x => x.RawMaterialsDeliveredToProductionDetailID != null && DeliverdDetailIDList.Contains((int)x.RawMaterialsDeliveredToProductionDetailID)).ToList();

                    if (cardInvDetailDeliverdList != null)
                    {
                        CardInvDetailsService detail = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
                        cardInvDetailDeliverdList.ForEach(x =>
                        {
                            //حذف تحویل به تولید
                            statuse &= detail.DeleteByRawMaterialsDeliveredToProductionDetailID(Convert.ToInt32(x.RawMaterialsDeliveredToProductionDetailID));
                        });
                    }

                    #endregion

                    #endregion

                    t.Commit();
                    return statuse;
                }
                catch
                {
                    t.Rollback();
                    throw;
                }
            }
        }




    }
}
