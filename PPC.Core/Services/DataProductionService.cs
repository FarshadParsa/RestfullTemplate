using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Common;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class DataProductionService : BaseService, IDataProductionService
    {
        IUnitOfWork _unitOfWork;
        public DataProductionService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<DataProduction> GetAll()
        {
            try
            {
                var dataProduction = _repositoryFactory.DataProduction.Table.ToList();

                return dataProduction;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DataProduction>> GetAllAsync()
        {
            try
            {

                var dataProduction = await _repositoryFactory.DataProduction.Table
                    .Include(x => x.ProductionPlanPatil).ThenInclude(x => x.ProductionPlan).ThenInclude(x => x.OrderDetail).ThenInclude(x => x.Product)
                    .Include(x => x.DataDosingDetailList).ThenInclude(x => x.RawMaterial)
                    .Include(x => x.DataGrindingDetailList)
                    .Include(x => x.Patil)
                    .Include(x => x.Premix_Station)
                    .Include(x => x.Grinding_Station)
                    .ToListAsync();
                return dataProduction;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public DataProduction GetDataProductionById(int dataProductionID)
        {
            try
            {
                var dataProduction = _repositoryFactory.DataProduction
                    .FirstOrDefault(x => x.DataProductionID == dataProductionID);

                return dataProduction;
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataProduction> GetDataProductionByIdAsync(int dataProductionID)
        {
            try
            {
                var dataProduction = await _repositoryFactory.DataProduction.Table
                    .Include(x => x.ProductionPlanPatil).ThenInclude(x => x.ProductionPlan)
                    .FirstOrDefaultAsync(x => x.DataProductionID == dataProductionID);

                return dataProduction;
            }
            catch
            {
                throw;
            }
        }

        //public int Append(DataProduction dataProduction)
        //{
        //    using (var t = _unitOfWork.StartTransaction())
        //    {


        //        try
        //        {
        //            #region append DataProduction

        //            var _newObject = new DataProduction
        //            {
        //                DataProductionID = dataProduction.DataProductionID,
        //                ProductionPlanPatilID = dataProduction.ProductionPlanPatilID,
        //                StartDate = dataProduction.StartDate,
        //                StartTime = dataProduction.StartTime,
        //                EndDate = dataProduction.EndDate,
        //                EndTime = dataProduction.EndTime,
        //                Duration = dataProduction.Duration,
        //                Describe = dataProduction.Describe,
        //                PatilID = dataProduction.PatilID,
        //                Patil_Capacity = dataProduction.Patil_Capacity,
        //                Patil_EmptyWeight = dataProduction.Patil_EmptyWeight,
        //                Patil_AfterChargeWeight = dataProduction.Patil_AfterChargeWeight,
        //                Patil_AfterFirstMixWeight = dataProduction.Patil_AfterFirstMixWeight,
        //                Patil_DuringGrindingWeight = dataProduction.Patil_DuringGrindingWeight,
        //                Patil_FinalWeight = dataProduction.Patil_FinalWeight,
        //                Patil_NetWeight = dataProduction.Patil_NetWeight,
        //                Patil_MaterialEvaporation = dataProduction.Patil_MaterialEvaporation,
        //                Patil_Wastes = dataProduction.Patil_Wastes,
        //                Patil_Describe = dataProduction.Patil_Describe,
        //                Dosing_StartDate = dataProduction.Dosing_StartDate,
        //                Dosing_StartTime = dataProduction.Dosing_StartTime,
        //                Dosing_EndDate = dataProduction.Dosing_EndDate,
        //                Dosing_EndTime = dataProduction.Dosing_EndTime,
        //                Dosing_Duration = dataProduction.Dosing_Duration,
        //                Dosing_WeighbridgeNo = dataProduction.Dosing_WeighbridgeNo,
        //                Dosing_ShiftNo = dataProduction.Dosing_ShiftNo,
        //                Dosing_Operators = dataProduction.Dosing_Operators,
        //                Dosing_Wastes = dataProduction.Dosing_Wastes,
        //                Dosing_Stopes = dataProduction.Dosing_Stopes,
        //                Dosing_StopesDesc = dataProduction.Dosing_StopesDesc,
        //                Dosing_Describe = dataProduction.Dosing_Describe,
        //                Mixer_StationID = dataProduction.Mixer_StationID,
        //                Mixer_StartDate = dataProduction.Mixer_StartDate,
        //                Mixer_StartTime = dataProduction.Mixer_StartTime,
        //                Mixer_EndDate = dataProduction.Mixer_EndDate,
        //                Mixer_EndTime = dataProduction.Mixer_EndTime,
        //                Mixer_Duration = dataProduction.Mixer_Duration,
        //                Mixer_ShiftNo = dataProduction.Mixer_ShiftNo,
        //                Mixer_Operators = dataProduction.Mixer_Operators,
        //                Mixer_Wastes = dataProduction.Mixer_Wastes,
        //                Mixer_Stopes = dataProduction.Mixer_Stopes,
        //                Mixer_StopesDesc = dataProduction.Mixer_StopesDesc,
        //                Mixer_StationSpeed = dataProduction.Mixer_StationSpeed,
        //                Mixer_Describe = dataProduction.Mixer_Describe,
        //                Reactor_StationID = dataProduction.Reactor_StationID,
        //                Reactor_StartDate = dataProduction.Reactor_StartDate,
        //                Reactor_StartTime = dataProduction.Reactor_StartTime,
        //                Reactor_EndDate = dataProduction.Reactor_EndDate,
        //                Reactor_EndTime = dataProduction.Reactor_EndTime,
        //                Reactor_Duration = dataProduction.Reactor_Duration,
        //                Reactor_ShiftNo = dataProduction.Reactor_ShiftNo,
        //                Reactor_Operators = dataProduction.Reactor_Operators,
        //                Reactor_Wastes = dataProduction.Reactor_Wastes,
        //                Reactor_Stopes = dataProduction.Reactor_Stopes,
        //                Reactor_StopesDesc = dataProduction.Reactor_StopesDesc,
        //                Reactor_MixerSpeed = dataProduction.Reactor_MixerSpeed,
        //                Reactor_Temperature = dataProduction.Reactor_Temperature,
        //                Reactor_MaterialTemperature = dataProduction.Reactor_MaterialTemperature,
        //                Reactor_Describe = dataProduction.Reactor_Describe,
        //                Premix_StationID = dataProduction.Premix_StationID,
        //                Premix_StartDate = dataProduction.Premix_StartDate,
        //                Premix_StartTime = dataProduction.Premix_StartTime,
        //                Premix_EndDate = dataProduction.Premix_EndDate,
        //                Premix_EndTime = dataProduction.Premix_EndTime,
        //                Premix_Duration = dataProduction.Premix_Duration,
        //                Premix_ShiftNo = dataProduction.Premix_ShiftNo,
        //                Premix_Operators = dataProduction.Premix_Operators,
        //                Premix_Wastes = dataProduction.Premix_Wastes,
        //                Premix_Stopes = dataProduction.Premix_Stopes,
        //                Premix_StopesDesc = dataProduction.Premix_StopesDesc,
        //                Premix_StationSpeed = dataProduction.Premix_StationSpeed,
        //                Premix_Describe = dataProduction.Premix_Describe,
        //                Grinding_StationID = dataProduction.Grinding_StationID,
        //                Grinding_StartDate = dataProduction.Grinding_StartDate,
        //                Grinding_StartTime = dataProduction.Grinding_StartTime,
        //                Grinding_EndDate = dataProduction.Grinding_EndDate,
        //                Grinding_EndTime = dataProduction.Grinding_EndTime,
        //                Grinding_Duration = dataProduction.Grinding_Duration,
        //                Grinding_ShiftNo = dataProduction.Grinding_ShiftNo,
        //                Grinding_Operators = dataProduction.Grinding_Operators,
        //                Grinding_Stopes = dataProduction.Grinding_Stopes,
        //                Grinding_StopesDesc = dataProduction.Grinding_StopesDesc,
        //                Grinding_StationSpeed = dataProduction.Grinding_StationSpeed,
        //                Grinding_Describe = dataProduction.Grinding_Describe,
        //                InsUserID = dataProduction.InsUserID,
        //                InsDate = dataProduction.InsDate,
        //                InsTime = dataProduction.InsTime,
        //                EditUserID = dataProduction.EditUserID,
        //                EditDate = dataProduction.EditDate,
        //                EditTime = dataProduction.EditTime,
        //                DataDosingDetailList = dataProduction.DataDosingDetailList,
        //                DataGrindingDetailList = dataProduction.DataGrindingDetailList,


        //            };

        //            _repositoryFactory.DataProduction.Add(_newObject);
        //            var statuse = _unitOfWork.Commit() > 0;

        //            #endregion


        //            #region (Kardex) ==> Append InvProductionRawMaterials - خروج از پای کار تولید

        //            //جمع مواد تحویل شده به ازای هر ماده
        //            var sumOfProduction = _newObject.DataDosingDetailList.GroupBy(x => new
        //            {
        //                x.RawMaterialID,
        //            }).Select(g => new
        //            {
        //                g.Key.RawMaterialID,
        //                Weight = g.Sum(x => x.ChargedWeight ?? 0)
        //            }).ToList();

        //            sumOfProduction.ForEach(detail =>
        //            {
        //                var firstInvPRM = _newObject.DataDosingDetailList.First(x => x.RawMaterialID == detail.RawMaterialID);
        //                CardInvDetails cardInvDetails = new CardInvDetails();

        //                cardInvDetails.InvTypeID = 'P';
        //                cardInvDetails.Year = General.Year;
        //                cardInvDetails.RawMaterialID = detail.RawMaterialID;
        //                cardInvDetails.EntryDate = _newObject.EndDate;
        //                cardInvDetails.EntryTime = _newObject.EndTime;
        //                cardInvDetails.Amount = detail.Weight;
        //                cardInvDetails.CardTypeVal = '#';
        //                cardInvDetails.IsEntry = false;
        //                cardInvDetails.InsDate = _newObject.InsDate;
        //                cardInvDetails.InsTime = _newObject.InsTime;
        //                cardInvDetails.InsUserID = _newObject.InsUserID;
        //                cardInvDetails.InvRawMaterialID = null;
        //                cardInvDetails.RawMaterialsDeliveredToProductionDetailID = null;
        //                cardInvDetails.InvProductionRawMaterialID = null;
        //                cardInvDetails.DataDosingDetailID = _newObject.DataDosingDetailList.First(x => x.RawMaterialID == detail.RawMaterialID).DataDosingDetailID;

        //                CardInvDetailsService cardInvDetailsService = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
        //                cardInvDetails = cardInvDetailsService.Append(cardInvDetails);

        //                if (cardInvDetails == null)
        //                    statuse = false;

        //            });

        //            //throw new System.Exception("QQ");


        //            #endregion

        //            t.Commit();

        //            if (statuse)
        //                return _newObject.DataProductionID;
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

        public int Append(DataProduction dataProduction)
        {
            using (var t = _unitOfWork.StartTransaction())
            {


                try
                {
                    #region append DataProduction

                    var _newObject = new DataProduction
                    {
                        DataProductionID = dataProduction.DataProductionID,
                        ProductionPlanPatilID = dataProduction.ProductionPlanPatilID,
                        StartDate = dataProduction.StartDate,
                        StartTime = dataProduction.StartTime,
                        EndDate = dataProduction.EndDate,
                        EndTime = dataProduction.EndTime,
                        Duration = dataProduction.Duration,
                        Describe = dataProduction.Describe,
                        PatilID = dataProduction.PatilID,
                        Patil_Capacity = dataProduction.Patil_Capacity,
                        Patil_EmptyWeight = dataProduction.Patil_EmptyWeight,
                        Patil_AfterChargeWeight = dataProduction.Patil_AfterChargeWeight,
                        Patil_AfterFirstMixWeight = dataProduction.Patil_AfterFirstMixWeight,
                        Patil_DuringGrindingWeight = dataProduction.Patil_DuringGrindingWeight,
                        Patil_FinalWeight = dataProduction.Patil_FinalWeight,
                        Patil_NetWeight = dataProduction.Patil_NetWeight,
                        Patil_MaterialEvaporation = dataProduction.Patil_MaterialEvaporation,
                        Patil_Wastes = dataProduction.Patil_Wastes,
                        Patil_Describe = dataProduction.Patil_Describe,

                        Dosing1_StartDate = dataProduction.Dosing1_StartDate,
                        Dosing1_StartTime = dataProduction.Dosing1_StartTime,
                        Dosing1_EndDate = dataProduction.Dosing1_EndDate,
                        Dosing1_EndTime = dataProduction.Dosing1_EndTime,
                        Dosing1_Duration = dataProduction.Dosing1_Duration,
                        Dosing1_WeighbridgeNo = dataProduction.Dosing1_WeighbridgeNo,
                        Dosing1_ShiftNo = dataProduction.Dosing1_ShiftNo,
                        Dosing1_Operators = dataProduction.Dosing1_Operators,
                        Dosing1_Wastes = dataProduction.Dosing1_Wastes,
                        Dosing1_Stopes = dataProduction.Dosing1_Stopes,
                        Dosing1_StopesDesc = dataProduction.Dosing1_StopesDesc,
                        Dosing1_Describe = dataProduction.Dosing1_Describe,

                        Dosing2_StartDate = dataProduction.Dosing2_StartDate,
                        Dosing2_StartTime = dataProduction.Dosing2_StartTime,
                        Dosing2_EndDate = dataProduction.Dosing2_EndDate,
                        Dosing2_EndTime = dataProduction.Dosing2_EndTime,
                        Dosing2_Duration = dataProduction.Dosing2_Duration,
                        Dosing2_WeighbridgeNo = dataProduction.Dosing2_WeighbridgeNo,
                        Dosing2_ShiftNo = dataProduction.Dosing2_ShiftNo,
                        Dosing2_Operators = dataProduction.Dosing2_Operators,
                        Dosing2_Wastes = dataProduction.Dosing2_Wastes,
                        Dosing2_Stopes = dataProduction.Dosing2_Stopes,
                        Dosing2_StopesDesc = dataProduction.Dosing2_StopesDesc,
                        Dosing2_Describe = dataProduction.Dosing2_Describe,

                        Dosing3_StartDate = dataProduction.Dosing3_StartDate,
                        Dosing3_StartTime = dataProduction.Dosing3_StartTime,
                        Dosing3_EndDate = dataProduction.Dosing3_EndDate,
                        Dosing3_EndTime = dataProduction.Dosing3_EndTime,
                        Dosing3_Duration = dataProduction.Dosing3_Duration,
                        Dosing3_WeighbridgeNo = dataProduction.Dosing3_WeighbridgeNo,
                        Dosing3_ShiftNo = dataProduction.Dosing3_ShiftNo,
                        Dosing3_Operators = dataProduction.Dosing3_Operators,
                        Dosing3_Wastes = dataProduction.Dosing3_Wastes,
                        Dosing3_Stopes = dataProduction.Dosing3_Stopes,
                        Dosing3_StopesDesc = dataProduction.Dosing3_StopesDesc,
                        Dosing3_Describe = dataProduction.Dosing3_Describe,

                        Dosing4_StartDate = dataProduction.Dosing4_StartDate,
                        Dosing4_StartTime = dataProduction.Dosing4_StartTime,
                        Dosing4_EndDate = dataProduction.Dosing4_EndDate,
                        Dosing4_EndTime = dataProduction.Dosing4_EndTime,
                        Dosing4_Duration = dataProduction.Dosing4_Duration,
                        Dosing4_WeighbridgeNo = dataProduction.Dosing4_WeighbridgeNo,
                        Dosing4_ShiftNo = dataProduction.Dosing4_ShiftNo,
                        Dosing4_Operators = dataProduction.Dosing4_Operators,
                        Dosing4_Wastes = dataProduction.Dosing4_Wastes,
                        Dosing4_Stopes = dataProduction.Dosing4_Stopes,
                        Dosing4_StopesDesc = dataProduction.Dosing4_StopesDesc,
                        Dosing4_Describe = dataProduction.Dosing4_Describe,

                        Mixer_StationID = dataProduction.Mixer_StationID,
                        Mixer_StartDate = dataProduction.Mixer_StartDate,
                        Mixer_StartTime = dataProduction.Mixer_StartTime,
                        Mixer_EndDate = dataProduction.Mixer_EndDate,
                        Mixer_EndTime = dataProduction.Mixer_EndTime,
                        Mixer_Duration = dataProduction.Mixer_Duration,
                        Mixer_ShiftNo = dataProduction.Mixer_ShiftNo,
                        Mixer_Operators = dataProduction.Mixer_Operators,
                        Mixer_Wastes = dataProduction.Mixer_Wastes,
                        Mixer_Stopes = dataProduction.Mixer_Stopes,
                        Mixer_StopesDesc = dataProduction.Mixer_StopesDesc,
                        Mixer_StationSpeed = dataProduction.Mixer_StationSpeed,
                        Mixer_Describe = dataProduction.Mixer_Describe,
                        Reactor_StationID = dataProduction.Reactor_StationID,
                        Reactor_StartDate = dataProduction.Reactor_StartDate,
                        Reactor_StartTime = dataProduction.Reactor_StartTime,
                        Reactor_EndDate = dataProduction.Reactor_EndDate,
                        Reactor_EndTime = dataProduction.Reactor_EndTime,
                        Reactor_Duration = dataProduction.Reactor_Duration,
                        Reactor_ShiftNo = dataProduction.Reactor_ShiftNo,
                        Reactor_Operators = dataProduction.Reactor_Operators,
                        Reactor_Wastes = dataProduction.Reactor_Wastes,
                        Reactor_Stopes = dataProduction.Reactor_Stopes,
                        Reactor_StopesDesc = dataProduction.Reactor_StopesDesc,
                        Reactor_MixerSpeed = dataProduction.Reactor_MixerSpeed,
                        Reactor_Temperature = dataProduction.Reactor_Temperature,
                        Reactor_MaterialTemperature = dataProduction.Reactor_MaterialTemperature,
                        Reactor_Describe = dataProduction.Reactor_Describe,
                        Premix_StationID = dataProduction.Premix_StationID,
                        Premix_StartDate = dataProduction.Premix_StartDate,
                        Premix_StartTime = dataProduction.Premix_StartTime,
                        Premix_EndDate = dataProduction.Premix_EndDate,
                        Premix_EndTime = dataProduction.Premix_EndTime,
                        Premix_Duration = dataProduction.Premix_Duration,
                        Premix_ShiftNo = dataProduction.Premix_ShiftNo,
                        Premix_Operators = dataProduction.Premix_Operators,
                        Premix_Wastes = dataProduction.Premix_Wastes,
                        Premix_Stopes = dataProduction.Premix_Stopes,
                        Premix_StopesDesc = dataProduction.Premix_StopesDesc,
                        Premix_StationSpeed = dataProduction.Premix_StationSpeed,
                        Premix_Describe = dataProduction.Premix_Describe,
                        Grinding_StationID = dataProduction.Grinding_StationID,
                        Grinding_StartDate = dataProduction.Grinding_StartDate,
                        Grinding_StartTime = dataProduction.Grinding_StartTime,
                        Grinding_EndDate = dataProduction.Grinding_EndDate,
                        Grinding_EndTime = dataProduction.Grinding_EndTime,
                        Grinding_Duration = dataProduction.Grinding_Duration,
                        Grinding_ShiftNo = dataProduction.Grinding_ShiftNo,
                        Grinding_Operators = dataProduction.Grinding_Operators,
                        Grinding_Stopes = dataProduction.Grinding_Stopes,
                        Grinding_StopesDesc = dataProduction.Grinding_StopesDesc,
                        Grinding_StationSpeed = dataProduction.Grinding_StationSpeed,
                        Grinding_Describe = dataProduction.Grinding_Describe,
                        InsUserID = dataProduction.InsUserID,
                        InsDate = dataProduction.InsDate,
                        InsTime = dataProduction.InsTime,
                        EditUserID = dataProduction.EditUserID,
                        EditDate = dataProduction.EditDate,
                        EditTime = dataProduction.EditTime,
                        DataDosingDetailList = dataProduction.DataDosingDetailList,
                        DataGrindingDetailList = dataProduction.DataGrindingDetailList,


                    };

                    _repositoryFactory.DataProduction.Add(_newObject);
                    var statuse = _unitOfWork.Commit() > 0;

                    #endregion


                    #region (Kardex) ==> Append InvProductionRawMaterials - خروج از پای کار تولید

                    List<CardInvDetails> cardInvDetailsInserted = new List<CardInvDetails>();
                    _newObject.DataDosingDetailList.ForEach(detail =>
                    {
                        var firstInvPRM = _newObject.DataDosingDetailList.First(x => x.RawMaterialID == detail.RawMaterialID);
                        CardInvDetails cardInvDetails = new CardInvDetails();

                        cardInvDetails.InvTypeID = 'P';
                        cardInvDetails.Year = General.Year;
                        cardInvDetails.RawMaterialID = detail.RawMaterialID;
                        cardInvDetails.EntryDate = _newObject.InsDate;
                        cardInvDetails.EntryTime = _newObject.InsTime;
                        cardInvDetails.Amount = Convert.ToDecimal(detail.ChargedWeight);
                        cardInvDetails.CardTypeVal = '#';
                        cardInvDetails.IsEntry = false;
                        cardInvDetails.InsDate = _newObject.InsDate;
                        cardInvDetails.InsTime = _newObject.InsTime;
                        cardInvDetails.InsUserID = _newObject.InsUserID;
                        cardInvDetails.InvRawMaterialID = null;
                        cardInvDetails.RawMaterialsDeliveredToProductionDetailID = null;
                        cardInvDetails.InvProductionRawMaterialID = null;
                        cardInvDetails.DataDosingDetailID = _newObject.DataDosingDetailList.First(x => x.RawMaterialID == detail.RawMaterialID && 
                        !cardInvDetailsInserted.Select(i=>i.DataDosingDetailID).Contains( x.DataDosingDetailID)).DataDosingDetailID;

                        cardInvDetailsInserted.Add(cardInvDetails);

                        CardInvDetailsService cardInvDetailsService = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
                        cardInvDetails = cardInvDetailsService.Append(cardInvDetails);

                        if (cardInvDetails == null)
                            statuse = false;

                    });

                    //_unitOfWork.Commit();

                    #endregion

                    t.Commit();

                    if (statuse)
                        return _newObject.DataProductionID;
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

        public bool Update(DataProduction dataProduction)
        {
            using (var t = _unitOfWork.StartTransaction())
            {


                try
                {

                    #region DELETE removed record

                    //_repositoryFactory.DataGrindingDetail.DeleteBy(x => !dataProduction.DataGrindingDetailList.Select(g => g.DataGrindingDetailID).Contains(x.DataGrindingDetailID));

                    #endregion

                    _repositoryFactory.DataProduction.UpdateBy(x => x.DataProductionID == dataProduction.DataProductionID,
                        new DataProduction
                        {
                            DataProductionID = dataProduction.DataProductionID,
                            ProductionPlanPatilID = dataProduction.ProductionPlanPatilID,
                            StartDate = dataProduction.StartDate,
                            StartTime = dataProduction.StartTime,
                            EndDate = dataProduction.EndDate,
                            EndTime = dataProduction.EndTime,
                            Duration = dataProduction.Duration,
                            Describe = dataProduction.Describe,
                            PatilID = dataProduction.PatilID,
                            Patil_Capacity = dataProduction.Patil_Capacity,
                            Patil_EmptyWeight = dataProduction.Patil_EmptyWeight,
                            Patil_AfterChargeWeight = dataProduction.Patil_AfterChargeWeight,
                            Patil_AfterFirstMixWeight = dataProduction.Patil_AfterFirstMixWeight,
                            Patil_DuringGrindingWeight = dataProduction.Patil_DuringGrindingWeight,
                            Patil_FinalWeight = dataProduction.Patil_FinalWeight,
                            Patil_NetWeight = dataProduction.Patil_NetWeight,
                            Patil_MaterialEvaporation = dataProduction.Patil_MaterialEvaporation,
                            Patil_Wastes = dataProduction.Patil_Wastes,
                            Patil_Describe = dataProduction.Patil_Describe,

                            Dosing1_StartDate = dataProduction.Dosing1_StartDate,
                            Dosing1_StartTime = dataProduction.Dosing1_StartTime,
                            Dosing1_EndDate = dataProduction.Dosing1_EndDate,
                            Dosing1_EndTime = dataProduction.Dosing1_EndTime,
                            Dosing1_Duration = dataProduction.Dosing1_Duration,
                            Dosing1_WeighbridgeNo = dataProduction.Dosing1_WeighbridgeNo,
                            Dosing1_ShiftNo = dataProduction.Dosing1_ShiftNo,
                            Dosing1_Operators = dataProduction.Dosing1_Operators,
                            Dosing1_Wastes = dataProduction.Dosing1_Wastes,
                            Dosing1_Stopes = dataProduction.Dosing1_Stopes,
                            Dosing1_StopesDesc = dataProduction.Dosing1_StopesDesc,
                            Dosing1_Describe = dataProduction.Dosing1_Describe,

                            Dosing2_StartDate = dataProduction.Dosing2_StartDate,
                            Dosing2_StartTime = dataProduction.Dosing2_StartTime,
                            Dosing2_EndDate = dataProduction.Dosing2_EndDate,
                            Dosing2_EndTime = dataProduction.Dosing2_EndTime,
                            Dosing2_Duration = dataProduction.Dosing2_Duration,
                            Dosing2_WeighbridgeNo = dataProduction.Dosing2_WeighbridgeNo,
                            Dosing2_ShiftNo = dataProduction.Dosing2_ShiftNo,
                            Dosing2_Operators = dataProduction.Dosing2_Operators,
                            Dosing2_Wastes = dataProduction.Dosing2_Wastes,
                            Dosing2_Stopes = dataProduction.Dosing2_Stopes,
                            Dosing2_StopesDesc = dataProduction.Dosing2_StopesDesc,
                            Dosing2_Describe = dataProduction.Dosing2_Describe,

                            Dosing3_StartDate = dataProduction.Dosing3_StartDate,
                            Dosing3_StartTime = dataProduction.Dosing3_StartTime,
                            Dosing3_EndDate = dataProduction.Dosing3_EndDate,
                            Dosing3_EndTime = dataProduction.Dosing3_EndTime,
                            Dosing3_Duration = dataProduction.Dosing3_Duration,
                            Dosing3_WeighbridgeNo = dataProduction.Dosing3_WeighbridgeNo,
                            Dosing3_ShiftNo = dataProduction.Dosing3_ShiftNo,
                            Dosing3_Operators = dataProduction.Dosing3_Operators,
                            Dosing3_Wastes = dataProduction.Dosing3_Wastes,
                            Dosing3_Stopes = dataProduction.Dosing3_Stopes,
                            Dosing3_StopesDesc = dataProduction.Dosing3_StopesDesc,
                            Dosing3_Describe = dataProduction.Dosing3_Describe,

                            Dosing4_StartDate = dataProduction.Dosing4_StartDate,
                            Dosing4_StartTime = dataProduction.Dosing4_StartTime,
                            Dosing4_EndDate = dataProduction.Dosing4_EndDate,
                            Dosing4_EndTime = dataProduction.Dosing4_EndTime,
                            Dosing4_Duration = dataProduction.Dosing4_Duration,
                            Dosing4_WeighbridgeNo = dataProduction.Dosing4_WeighbridgeNo,
                            Dosing4_ShiftNo = dataProduction.Dosing4_ShiftNo,
                            Dosing4_Operators = dataProduction.Dosing4_Operators,
                            Dosing4_Wastes = dataProduction.Dosing4_Wastes,
                            Dosing4_Stopes = dataProduction.Dosing4_Stopes,
                            Dosing4_StopesDesc = dataProduction.Dosing4_StopesDesc,
                            Dosing4_Describe = dataProduction.Dosing4_Describe,

                            Mixer_StationID = dataProduction.Mixer_StationID,
                            Mixer_StartDate = dataProduction.Mixer_StartDate,
                            Mixer_StartTime = dataProduction.Mixer_StartTime,
                            Mixer_EndDate = dataProduction.Mixer_EndDate,
                            Mixer_EndTime = dataProduction.Mixer_EndTime,
                            Mixer_Duration = dataProduction.Mixer_Duration,
                            Mixer_ShiftNo = dataProduction.Mixer_ShiftNo,
                            Mixer_Operators = dataProduction.Mixer_Operators,
                            Mixer_Wastes = dataProduction.Mixer_Wastes,
                            Mixer_Stopes = dataProduction.Mixer_Stopes,
                            Mixer_StopesDesc = dataProduction.Mixer_StopesDesc,
                            Mixer_StationSpeed = dataProduction.Mixer_StationSpeed,
                            Mixer_Describe = dataProduction.Mixer_Describe,
                            Reactor_StationID = dataProduction.Reactor_StationID,
                            Reactor_StartDate = dataProduction.Reactor_StartDate,
                            Reactor_StartTime = dataProduction.Reactor_StartTime,
                            Reactor_EndDate = dataProduction.Reactor_EndDate,
                            Reactor_EndTime = dataProduction.Reactor_EndTime,
                            Reactor_Duration = dataProduction.Reactor_Duration,
                            Reactor_ShiftNo = dataProduction.Reactor_ShiftNo,
                            Reactor_Operators = dataProduction.Reactor_Operators,
                            Reactor_Wastes = dataProduction.Reactor_Wastes,
                            Reactor_Stopes = dataProduction.Reactor_Stopes,
                            Reactor_StopesDesc = dataProduction.Reactor_StopesDesc,
                            Reactor_MixerSpeed = dataProduction.Reactor_MixerSpeed,
                            Reactor_Temperature = dataProduction.Reactor_Temperature,
                            Reactor_MaterialTemperature = dataProduction.Reactor_MaterialTemperature,
                            Reactor_Describe = dataProduction.Reactor_Describe,
                            Premix_StationID = dataProduction.Premix_StationID,
                            Premix_StartDate = dataProduction.Premix_StartDate,
                            Premix_StartTime = dataProduction.Premix_StartTime,
                            Premix_EndDate = dataProduction.Premix_EndDate,
                            Premix_EndTime = dataProduction.Premix_EndTime,
                            Premix_Duration = dataProduction.Premix_Duration,
                            Premix_ShiftNo = dataProduction.Premix_ShiftNo,
                            Premix_Operators = dataProduction.Premix_Operators,
                            Premix_Wastes = dataProduction.Premix_Wastes,
                            Premix_Stopes = dataProduction.Premix_Stopes,
                            Premix_StopesDesc = dataProduction.Premix_StopesDesc,
                            Premix_StationSpeed = dataProduction.Premix_StationSpeed,
                            Premix_Describe = dataProduction.Premix_Describe,
                            Grinding_StationID = dataProduction.Grinding_StationID,
                            Grinding_StartDate = dataProduction.Grinding_StartDate,
                            Grinding_StartTime = dataProduction.Grinding_StartTime,
                            Grinding_EndDate = dataProduction.Grinding_EndDate,
                            Grinding_EndTime = dataProduction.Grinding_EndTime,
                            Grinding_Duration = dataProduction.Grinding_Duration,
                            Grinding_ShiftNo = dataProduction.Grinding_ShiftNo,
                            Grinding_Operators = dataProduction.Grinding_Operators,
                            Grinding_Stopes = dataProduction.Grinding_Stopes,
                            Grinding_StopesDesc = dataProduction.Grinding_StopesDesc,
                            Grinding_StationSpeed = dataProduction.Grinding_StationSpeed,
                            Grinding_Describe = dataProduction.Grinding_Describe,
                            InsUserID = dataProduction.InsUserID,
                            InsDate = dataProduction.InsDate,
                            InsTime = dataProduction.InsTime,
                            EditUserID = dataProduction.EditUserID,
                            EditDate = dataProduction.EditDate,
                            EditTime = dataProduction.EditTime,
                            DataDosingDetailList = dataProduction.DataDosingDetailList,
                            DataGrindingDetailList = dataProduction.DataGrindingDetailList,


                        });

                    var statuse = _unitOfWork.Commit() > 0;

                    #region Kardex 

                    #region --> ویرایش رکورد های دوزینگ 

                    dataProduction.DataDosingDetailList.ForEach(x =>
                    {
                        var cardInvDetails = _repositoryFactory.CardInvDetails.FirstOrDefault(d => d.DataDosingDetailID == x.DataDosingDetailID);

                        if (cardInvDetails != null)
                        {
                            cardInvDetails.Amount = Convert.ToDecimal(x.ChargedWeight);

                            _unitOfWork.Commit() ;
                        }

                    });

                    #endregion

                    #endregion

                    t.Commit();
                    return statuse;
                }
                catch (System.Exception ex)
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        public long Delete(int dataProductionID)
        {
            using (var t = _unitOfWork.StartTransaction())
            {
                try
                {

                    #region Delete DataProduction

                    var dataProduction = _repositoryFactory.DataProduction.Table
                        .Include(x => x.DataDosingDetailList)
                        .Include(x => x.DataGrindingDetailList)
                        .FirstOrDefault(x => x.DataProductionID == dataProductionID);

                    if (dataProduction == null)
                        throw new System.Exception("DataProduction Notfound.");


                    #region Kardex 

                    #region --> حذف رکورد های دوزینگ جهت بازگشت به پای کار تولید

                    dataProduction.DataDosingDetailList.ForEach(x =>
                    {
                        var cardInvDetails = _repositoryFactory.CardInvDetails.FirstOrDefault(d => d.DataDosingDetailID == x.DataDosingDetailID);
                        
                        if (cardInvDetails != null)
                            _repositoryFactory.CardInvDetails.Delete(cardInvDetails);
                    });

                    #endregion

                    #endregion


                    _repositoryFactory.DataProduction.Delete(dataProduction);
                    var statuse = _unitOfWork.Commit();

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

        public async Task<DataProduction> GetByProductionPlanPatilIdAsync(int productionPlanPatilId)
        {
            try
            {
                var dataProduction = await _repositoryFactory.DataProduction.Table
                    .Include(x => x.ProductionPlanPatil).ThenInclude(x => x.ProductionPlan)
                    .FirstOrDefaultAsync(x => x.ProductionPlanPatilID == productionPlanPatilId);

                return dataProduction;
            }
            catch
            {
                throw;
            }
        }



    }
}







//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using PPC.Core.Interface;
//using PPC.Core.Models;
//using PPC.Core.Repository;
//namespace PPC.Core.Services
//{
//    public class DataProductionService : BaseService, IDataProductionService
//    {
//        IUnitOfWork _unitOfWork;
//        public DataProductionService(RepositoryFactory repositoryFactory,
//            IUnitOfWork unitOfWork)
//        {
//            _repositoryFactory = repositoryFactory;
//            _unitOfWork = unitOfWork;
//        }


//        public List<DataProduction> GetAll()
//        {
//            try
//            {
//                var dataProduction = _repositoryFactory.DataProduction.Table.ToList();

//                return dataProduction;
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public async Task<List<DataProduction>> GetAllAsync()
//        {
//            try
//            {

//                var dataProduction = await _repositoryFactory.DataProduction.Table
//                    .Include(x=>x.ProductionPlanPatil).ThenInclude(x=>x.ProductionPlan).ThenInclude(x=>x.OrderDetail).ThenInclude(x=>x.Product)
//                    .Include(x => x.DataDosingDetailList).ThenInclude(x => x.RawMaterial)
//                    .Include(x => x.DataGrindingDetailList)
//                    .Include(x=>x.Patil)
//                    .Include(x=>x.Premix_Station)
//                    .Include(x=>x.Grinding_Station)
//                    .ToListAsync();
//                return dataProduction;
//            }
//            catch (System.Exception ex)
//            {
//                throw;
//            }
//        }

//        public DataProduction GetDataProductionById(int dataProductionID)
//        {
//            try
//            {
//                var dataProduction = _repositoryFactory.DataProduction
//                    .FirstOrDefault(x => x.DataProductionID == dataProductionID);

//                return dataProduction;
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public async Task<DataProduction> GetDataProductionByIdAsync(int dataProductionID)
//        {
//            try
//            {
//                var dataProduction = await _repositoryFactory.DataProduction.Table
//                    .Include(x=>x.ProductionPlanPatil).ThenInclude(x=>x.ProductionPlan)
//                    .FirstOrDefaultAsync(x => x.DataProductionID == dataProductionID);

//                return dataProduction;
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public int Append(DataProduction dataProduction)
//        {
//            try
//            {
//                var _newObject = new DataProduction
//                {
//                    DataProductionID = dataProduction.DataProductionID,
//                    ProductionPlanPatilID = dataProduction.ProductionPlanPatilID,
//                    StartDate = dataProduction.StartDate,
//                    StartTime = dataProduction.StartTime,
//                    EndDate = dataProduction.EndDate,
//                    EndTime = dataProduction.EndTime,
//                    Duration = dataProduction.Duration,
//                    Describe = dataProduction.Describe,
//                    PatilID = dataProduction.PatilID,
//                    Patil_Capacity = dataProduction.Patil_Capacity,
//                    Patil_EmptyWeight = dataProduction.Patil_EmptyWeight,
//                    Patil_AfterChargeWeight = dataProduction.Patil_AfterChargeWeight,
//                    Patil_AfterFirstMixWeight = dataProduction.Patil_AfterFirstMixWeight,
//                    Patil_DuringGrindingWeight = dataProduction.Patil_DuringGrindingWeight,
//                    Patil_FinalWeight = dataProduction.Patil_FinalWeight,
//                    Patil_NetWeight = dataProduction.Patil_NetWeight,
//                    Dosing_StartDate = dataProduction.Dosing_StartDate,
//                    Dosing_StartTime = dataProduction.Dosing_StartTime,
//                    Dosing_EndDate = dataProduction.Dosing_EndDate,
//                    Dosing_EndTime = dataProduction.Dosing_EndTime,
//                    Dosing_Duration = dataProduction.Dosing_Duration,
//                    Dosing_WeighbridgeNo = dataProduction.Dosing_WeighbridgeNo,
//                    Dosing_ShiftNo = dataProduction.Dosing_ShiftNo,
//                    Dosing_Operators = dataProduction.Dosing_Operators,
//                    Dosing_Wastes = dataProduction.Dosing_Wastes,
//                    Dosing_Stopes = dataProduction.Dosing_Stopes,
//                    Dosing_StopesDesc = dataProduction.Dosing_StopesDesc,
//                    Dosing_Describe = dataProduction.Dosing_Describe,
//                    Premix_StationID = dataProduction.Premix_StationID,
//                    Premix_StartDate = dataProduction.Premix_StartDate,
//                    Premix_StartTime = dataProduction.Premix_StartTime,
//                    Premix_EndDate = dataProduction.Premix_EndDate,
//                    Premix_EndTime = dataProduction.Premix_EndTime,
//                    Premix_Duration = dataProduction.Premix_Duration,
//                    Premix_ShiftNo = dataProduction.Premix_ShiftNo,
//                    Premix_Operators = dataProduction.Premix_Operators,
//                    Premix_Wastes = dataProduction.Premix_Wastes,
//                    Premix_Stopes = dataProduction.Premix_Stopes,
//                    Premix_StopesDesc = dataProduction.Premix_StopesDesc,
//                    Premix_StationSpeed = dataProduction.Premix_StationSpeed,
//                    Premix_Describe = dataProduction.Premix_Describe,
//                    Grinding_StationID = dataProduction.Grinding_StationID,
//                    Grinding_StartDate = dataProduction.Grinding_StartDate,
//                    Grinding_StartTime = dataProduction.Grinding_StartTime,
//                    Grinding_EndDate = dataProduction.Grinding_EndDate,
//                    Grinding_EndTime = dataProduction.Grinding_EndTime,
//                    Grinding_Duration = dataProduction.Grinding_Duration,
//                    Grinding_ShiftNo = dataProduction.Grinding_ShiftNo,
//                    Grinding_Operators = dataProduction.Grinding_Operators,
//                    Grinding_Stopes = dataProduction.Grinding_Stopes,
//                    Grinding_StopesDesc = dataProduction.Grinding_StopesDesc,
//                    Grinding_StationSpeed = dataProduction.Grinding_StationSpeed,
//                    Grinding_Describe = dataProduction.Grinding_Describe,
//                    InsUserID = dataProduction.InsUserID,
//                    InsDate = dataProduction.InsDate,
//                    InsTime = dataProduction.InsTime,
//                    EditUserID = dataProduction.EditUserID,
//                    EditDate = dataProduction.EditDate,
//                    EditTime = dataProduction.EditTime,
//                    DataDosingDetailList= dataProduction.DataDosingDetailList,
//                    DataGrindingDetailList = dataProduction.DataGrindingDetailList,


//                };

//                _repositoryFactory.DataProduction.Add(_newObject);

//                var statuse = _unitOfWork.Commit() > 0;

//                if (statuse)
//                    return _newObject.DataProductionID;
//                else
//                    return int.MinValue;
//            }
//            catch (System.Exception)
//            {
//                throw;
//            }
//        }


//        public bool Update(DataProduction dataProduction)
//        {
//            try
//            {

//                _repositoryFactory.DataProduction.UpdateBy(x => x.DataProductionID == dataProduction.DataProductionID,
//                    new DataProduction
//                    {
//                        DataProductionID = dataProduction.DataProductionID,
//                        ProductionPlanPatilID = dataProduction.ProductionPlanPatilID,
//                        StartDate = dataProduction.StartDate,
//                        StartTime = dataProduction.StartTime,
//                        EndDate = dataProduction.EndDate,
//                        EndTime = dataProduction.EndTime,
//                        Duration = dataProduction.Duration,
//                        Describe = dataProduction.Describe,
//                        PatilID = dataProduction.PatilID,
//                        Patil_Capacity = dataProduction.Patil_Capacity,
//                        Patil_EmptyWeight = dataProduction.Patil_EmptyWeight,
//                        Patil_AfterChargeWeight = dataProduction.Patil_AfterChargeWeight,
//                        Patil_AfterFirstMixWeight = dataProduction.Patil_AfterFirstMixWeight,
//                        Patil_DuringGrindingWeight = dataProduction.Patil_DuringGrindingWeight,
//                        Patil_FinalWeight = dataProduction.Patil_FinalWeight,
//                        Patil_NetWeight = dataProduction.Patil_NetWeight,
//                        Dosing_StartDate = dataProduction.Dosing_StartDate,
//                        Dosing_StartTime = dataProduction.Dosing_StartTime,
//                        Dosing_EndDate = dataProduction.Dosing_EndDate,
//                        Dosing_EndTime = dataProduction.Dosing_EndTime,
//                        Dosing_Duration = dataProduction.Dosing_Duration,
//                        Dosing_WeighbridgeNo = dataProduction.Dosing_WeighbridgeNo,
//                        Dosing_ShiftNo = dataProduction.Dosing_ShiftNo,
//                        Dosing_Operators = dataProduction.Dosing_Operators,
//                        Dosing_Wastes = dataProduction.Dosing_Wastes,
//                        Dosing_Stopes = dataProduction.Dosing_Stopes,
//                        Dosing_StopesDesc = dataProduction.Dosing_StopesDesc,
//                        Dosing_Describe = dataProduction.Dosing_Describe,
//                        Premix_StationID = dataProduction.Premix_StationID,
//                        Premix_StartDate = dataProduction.Premix_StartDate,
//                        Premix_StartTime = dataProduction.Premix_StartTime,
//                        Premix_EndDate = dataProduction.Premix_EndDate,
//                        Premix_EndTime = dataProduction.Premix_EndTime,
//                        Premix_Duration = dataProduction.Premix_Duration,
//                        Premix_ShiftNo = dataProduction.Premix_ShiftNo,
//                        Premix_Operators = dataProduction.Premix_Operators,
//                        Premix_Wastes = dataProduction.Premix_Wastes,
//                        Premix_Stopes = dataProduction.Premix_Stopes,
//                        Premix_StopesDesc = dataProduction.Premix_StopesDesc,
//                        Premix_StationSpeed = dataProduction.Premix_StationSpeed,
//                        Premix_Describe = dataProduction.Premix_Describe,
//                        Grinding_StationID = dataProduction.Grinding_StationID,
//                        Grinding_StartDate = dataProduction.Grinding_StartDate,
//                        Grinding_StartTime = dataProduction.Grinding_StartTime,
//                        Grinding_EndDate = dataProduction.Grinding_EndDate,
//                        Grinding_EndTime = dataProduction.Grinding_EndTime,
//                        Grinding_Duration = dataProduction.Grinding_Duration,
//                        Grinding_ShiftNo = dataProduction.Grinding_ShiftNo,
//                        Grinding_Operators = dataProduction.Grinding_Operators,
//                        Grinding_Stopes = dataProduction.Grinding_Stopes,
//                        Grinding_StopesDesc = dataProduction.Grinding_StopesDesc,
//                        Grinding_StationSpeed = dataProduction.Grinding_StationSpeed,
//                        Grinding_Describe = dataProduction.Grinding_Describe,
//                        InsUserID = dataProduction.InsUserID,
//                        InsDate = dataProduction.InsDate,
//                        InsTime = dataProduction.InsTime,
//                        EditUserID = dataProduction.EditUserID,
//                        EditDate = dataProduction.EditDate,
//                        EditTime = dataProduction.EditTime,
//                        DataDosingDetailList = dataProduction.DataDosingDetailList,
//                        DataGrindingDetailList= dataProduction.DataGrindingDetailList,

//                    });
//                var statuse = _unitOfWork.Commit() > 0;
//                return statuse;
//            }
//            catch (System.Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public long Delete(int dataProductionID)
//        {
//            try
//            {
//                var dataProduction = _repositoryFactory.DataProduction
//                    .FirstOrDefault(x => x.DataProductionID == dataProductionID);

//                if (dataProduction == null)
//                    throw new System.Exception("DataProduction Notfound.");

//                _repositoryFactory.DataProduction.Delete(dataProduction);
//                var statuse = _unitOfWork.Commit();

//                return statuse;
//            }
//            catch
//            {
//                throw;
//            }
//        }




//    }
//}
