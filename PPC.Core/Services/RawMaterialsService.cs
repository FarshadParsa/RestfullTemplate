using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;
using static PPC.Common.General;

namespace PPC.Core.Services
{
    public class RawMaterialsService : BaseService, IRawMaterialsService
    {
        IUnitOfWork _unitOfWork;
        public RawMaterialsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<RawMaterials> GetAll()
        {
            try
            {

                var rawMaterials = _repositoryFactory.RawMaterials.Table
                    .Include(x => x.RawMaterialGroups)
                    .Include(x => x.Units)
                    //.Include(x=>x.TestPlanAssign)
                    .ToList();

                return rawMaterials;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RawMaterials>> GetAllAsync()
        {
            try
            {

                var rawMaterials = await _repositoryFactory.RawMaterials.Table
                    .Include(x => x.RawMaterialGroups)
                    .Include(x => x.Units)
                    //.Include(x => x.TestPlanAssign)
                    .ToListAsync();
                return rawMaterials;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public RawMaterials GetRawMaterialsById(int rawMaterialID)
        {
            try
            {
                var rawMaterials = _repositoryFactory.RawMaterials.Table
                    .Include(x => x.RMWhiteListAssign)
                    .Include(x => x.RawMaterialGroups)
                    .Include(x => x.Units)
                    .Include(x => x.TestPlanAssign)
                    .FirstOrDefault(x => x.RawMaterialID == rawMaterialID);

                return rawMaterials;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RawMaterials> GetRawMaterialsByIdAsync(int rawMaterialID)
        {
            try
            {
                var rawMaterials = await _repositoryFactory.RawMaterials.Table
                    .Include(x => x.RawMaterialGroups).ThenInclude(x => x.RawMaterialGroupType)
                    .Include(x => x.Units)
                    .Include(x => x.LotNosList)
                    .Include(x => x.RMWhiteListAssign)
                    .FirstOrDefaultAsync(x => x.RawMaterialID == rawMaterialID);
                //rawMaterials.LotNosList = _repositoryFactory.RawMaterialLotNumbers.Where(x => x.RawMaterialID == rawMaterialID).ToList();
                //rawMaterials.RMWhiteList = _repositoryFactory.RawMaterialWhiteListAssign.Where(x => x.RawMaterialID == rawMaterialID).Select(x => x.RMWhiteList).ToList();

                return rawMaterials;
            }
            catch
            {
                throw;
            }
        }

        public int Append(RawMaterials rawMaterials)
        {
            using (var tr = _unitOfWork.StartTransaction())
            {

                try
                {
                    var _newObject = new RawMaterials
                    {
                        RawMaterialID = rawMaterials.RawMaterialID,
                        RawMaterialSampleID = rawMaterials.RawMaterialSampleID,
                        RawMaterialOriginCode = rawMaterials.RawMaterialOriginCode,
                        RawMaterialOriginName = rawMaterials.RawMaterialOriginName,
                        RawMaterialCode = rawMaterials.RawMaterialCode,
                        RawMaterialName = rawMaterials.RawMaterialName,
                        RawMaterialLatinName = rawMaterials.RawMaterialLatinName,
                        UnitID = rawMaterials.UnitID,
                        SupplierID = rawMaterials.SupplierID,
                        RawMaterialGroupID = rawMaterials.RawMaterialGroupID,
                        IsRecycled = rawMaterials.IsRecycled,
                        StorageConditions = rawMaterials.StorageConditions,
                        IsSample = rawMaterials.IsSample,
                        IsSemiProduct = rawMaterials.IsSemiProduct,
                        HasBOMFormula = rawMaterials.HasBOMFormula,
                        SolidPercentage = rawMaterials.SolidPercentage,
                        IsConfirmed = rawMaterials.IsConfirmed,
                        InsUserID = rawMaterials.InsUserID,
                        InsDate = rawMaterials.InsDate,
                        InsTime = rawMaterials.InsTime,
                        IsActive = rawMaterials.IsActive,
                        TestPlanAssignID = rawMaterials.TestPlanAssignID,
                        LotNosList = rawMaterials.LotNosList,
                        RMWhiteListAssign = rawMaterials.RMWhiteListAssign,
                        //ParentID = rawMaterials.ParentID,


                    };

                    _repositoryFactory.RawMaterials.Add(_newObject);
                    var statuse = _unitOfWork.Commit() > 0;


                    //#region append RawMaterialConfirmation
                    //_repositoryFactory.RawMaterialConfirmation.Add(
                    //    new RawMaterialConfirmation
                    //    {
                    //        RawMaterialID = _newObject.RawMaterialID,
                    //        Status = (byte)RawMaterialConfirmationStatus.Saved,
                    //        IsConfirmed = false,
                    //        InsUserID = _newObject.InsUserID,
                    //        InsDate = _newObject.InsDate,
                    //        InsTime = _newObject.InsTime,

                    //    });

                    //#endregion

                    //#region  append lot No's 

                    //if (rawMaterials.LotNosList != null)
                    //{
                    //    rawMaterials.LotNosList?.ForEach(x =>
                    //    {
                    //        _repositoryFactory.RawMaterialLotNumbers.Add(
                    //            new RawMaterialLotNumbers
                    //            {
                    //                RawMaterialID = _newObject.RawMaterialID,
                    //                RepeatNo = x.RepeatNo,
                    //                LotNumber = x.LotNumber,
                    //                Describe = x.Describe,
                    //                InsUserID = x.InsUserID,
                    //                InsDate = x.InsDate,
                    //                InsTime = x.InsTime,
                    //                EditUserID = x.EditUserID,
                    //                EditDate = x.EditDate,
                    //                EditTime = x.EditTime,
                    //            });
                    //    });
                    //}

                    //#endregion

                    //statuse &= _unitOfWork.Commit() > 0;


                    #region append RMWhiteList assign

                    //if (rawMaterials.RMWhiteList != null)
                    //{
                    //    rawMaterials.RMWhiteList?.ForEach(x =>
                    //    {
                    //        _repositoryFactory.RawMaterialWhiteListAssign.Add(
                    //            new RawMaterialWhiteListAssign
                    //            {
                    //                RawMaterialID = _newObject.RawMaterialID,
                    //                RMWhiteListID = x.RMWhiteListID,
                    //            });
                    //    });

                    //    statuse &= _unitOfWork.Commit() > 0;
                    //}
                    #endregion


                    tr.Commit();

                    if (statuse)
                        return _newObject.RawMaterialID;
                    else
                        return int.MinValue;
                }
                catch (System.Exception)
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

        public bool Update(RawMaterials rawMaterials)
        {

            using (var t = _unitOfWork.StartTransaction())
            {


                try
                {
                    _repositoryFactory.RawMaterialWhiteListAssign.Where(x => x.RawMaterialID == rawMaterials.RawMaterialID).ToList()
                        .RemoveAll(x => !rawMaterials.RMWhiteListAssign.Select(x => x.RMWhiteListID).Contains(x.RMWhiteListID));

                    _repositoryFactory.RawMaterials.UpdateBy(x => x.RawMaterialID == rawMaterials.RawMaterialID,
                        new RawMaterials
                        {
                            RawMaterialID = rawMaterials.RawMaterialID,
                            RawMaterialSampleID = rawMaterials.RawMaterialSampleID,
                            RawMaterialOriginCode = rawMaterials.RawMaterialOriginCode,
                            RawMaterialOriginName = rawMaterials.RawMaterialOriginName,
                            RawMaterialCode = rawMaterials.RawMaterialCode,
                            RawMaterialName = rawMaterials.RawMaterialName,
                            RawMaterialLatinName = rawMaterials.RawMaterialLatinName,
                            UnitID = rawMaterials.UnitID,
                            SupplierID = rawMaterials.SupplierID,
                            RawMaterialGroupID = rawMaterials.RawMaterialGroupID,
                            IsRecycled = rawMaterials.IsRecycled,
                            StorageConditions = rawMaterials.StorageConditions,
                            IsSample = rawMaterials.IsSample,
                            IsSemiProduct = rawMaterials.IsSemiProduct,
                            HasBOMFormula = rawMaterials.HasBOMFormula,
                            SolidPercentage = rawMaterials.SolidPercentage,
                            IsConfirmed = rawMaterials.IsConfirmed,
                            InsUserID = rawMaterials.InsUserID,
                            InsDate = rawMaterials.InsDate,
                            InsTime = rawMaterials.InsTime,
                            IsActive = rawMaterials.IsActive,
                            TestPlanAssignID = rawMaterials.TestPlanAssignID,
                            LotNosList = rawMaterials.LotNosList,
                            RMWhiteListAssign = rawMaterials.RMWhiteListAssign,
                            //ParentID = rawMaterials.ParentID,
                        });

                    var statuse = _unitOfWork.Commit() > 0;


                    t.Commit();
                    return statuse;
                }
                catch (System.Exception ex)
                {
                    t.Rollback();
                    throw ex;
                }
            }
        }

        //public bool Update(RawMaterials rawMaterials)
        //{
        //    using (var tr = _unitOfWork.StartTransaction())
        //    {
        //        try
        //        {
        //            //throw new NotImplementedException();

        //            _repositoryFactory.RawMaterials.UpdateBy(x => x.RawMaterialID == rawMaterials.RawMaterialID,
        //                new RawMaterials
        //                {
        //                    RawMaterialID = rawMaterials.RawMaterialID,
        //                    RawMaterialSampleID = rawMaterials.RawMaterialSampleID,
        //                    RawMaterialOriginCode = rawMaterials.RawMaterialOriginCode,
        //                    RawMaterialOriginName = rawMaterials.RawMaterialOriginName,
        //                    RawMaterialCode = rawMaterials.RawMaterialCode,
        //                    RawMaterialName = rawMaterials.RawMaterialName,
        //                    RawMaterialLatinName = rawMaterials.RawMaterialLatinName,
        //                    UnitID = rawMaterials.UnitID,
        //                    SupplierID = rawMaterials.SupplierID,
        //                    RawMaterialGroupID = rawMaterials.RawMaterialGroupID,
        //                    IsRecycled = rawMaterials.IsRecycled,
        //                    StorageConditions = rawMaterials.StorageConditions,
        //                    IsSample = rawMaterials.IsSample,
        //                    IsSemiProduct = rawMaterials.IsSemiProduct,
        //                    SolidPercentage = rawMaterials.SolidPercentage,
        //                    IsConfirmed = rawMaterials.IsConfirmed,
        //                    InsUserID = rawMaterials.InsUserID,
        //                    InsDate = rawMaterials.InsDate,
        //                    InsTime = rawMaterials.InsTime,
        //                    IsActive = rawMaterials.IsActive,
        //                    TestPlanAssignID = rawMaterials.TestPlanAssignID,
        //                    //ParentID = rawMaterials.ParentID,


        //                });

        //            #region delete lot No's & RMWhiteListAssign

        //            _repositoryFactory.RawMaterialLotNumbers.DeleteBy(x => x.RawMaterialID == rawMaterials.RawMaterialID);
        //            _repositoryFactory.RawMaterialWhiteListAssign.DeleteBy(x => x.RawMaterialID == rawMaterials.RawMaterialID);

        //            #endregion

        //            #region  update lot No's 

        //            rawMaterials.LotNosList?.ForEach(x =>
        //            {
        //                _repositoryFactory.RawMaterialLotNumbers.Add(
        //                    new RawMaterialLotNumbers
        //                    {
        //                        RawMaterialID = rawMaterials.RawMaterialID,
        //                        RepeatNo = x.RepeatNo,
        //                        LotNumber = x.LotNumber,
        //                        Describe = x.Describe,
        //                        InsUserID = x.InsUserID,
        //                        InsDate = x.InsDate,
        //                        InsTime = x.InsTime,
        //                        EditUserID = x.EditUserID,
        //                        EditDate = x.EditDate,
        //                        EditTime = x.EditTime,
        //                    });
        //            });

        //            #endregion

        //            #region update RMWhiteList assign


        //            rawMaterials.RMWhiteList?.ForEach(x =>
        //            {
        //                _repositoryFactory.RawMaterialWhiteListAssign.Add(
        //                    new  RawMaterialWhiteListAssign
        //                    {
        //                        RawMaterialID = rawMaterials.RawMaterialID,
        //                        RMWhiteListID = x.RMWhiteListID,
        //                    });
        //            });

        //            #endregion


        //            var statuse = _unitOfWork.Commit() > 0;



        //            tr.Commit();
        //            return statuse;
        //        }
        //        catch (System.Exception ex)
        //        {
        //            tr.Rollback();
        //            throw ex;
        //        }
        //    }
        //}

        public long Delete(int rawMaterialID)
        {
            using (var t = _unitOfWork.StartTransaction())
            {


                try
                {
                    //var rawMaterials = _repositoryFactory.RawMaterials
                    //    .FirstOrDefault(x => x.RawMaterialID == rawMaterialID);

                    //if (rawMaterials == null)
                    //    throw new System.Exception("RawMaterials Notfound.");

                    //var rawMaterialConfirmation = _repositoryFactory.RawMaterialConfirmation
                    //    .FirstOrDefault(x => x.RawMaterialID == rawMaterialID);

                    //if (rawMaterialConfirmation != null)
                    //{
                    //    if (rawMaterialConfirmation.Status != (byte)RawMaterialConfirmationStatus.Saved)
                    //        throw new System.Exception("RawMaterials Notfound.");

                    //}


                    //    //Lot nos 
                    //    //کنترل شود

                    //_repositoryFactory.RawMaterials.Delete(rawMaterials);
                    //var statuse = _unitOfWork.Commit();

                    //return statuse;



                    var rawMaterials = _repositoryFactory.RawMaterials.Table
                        .Include(x => x.RMWhiteListAssign)
                        .Include(x => x.LotNosList)
                        .FirstOrDefault(x => x.RawMaterialID == rawMaterialID);

                    if (rawMaterials == null)
                        throw new System.Exception("RawMaterials Notfound.");

                    //var statuse = 0;

                    //if (_repositoryFactory.RawMaterialLotNumbers.Any(x => x.RawMaterialID == rawMaterialID))
                    //{
                    //    _repositoryFactory.RawMaterialLotNumbers.DeleteBy(x => x.RawMaterialID == rawMaterialID);

                    //    statuse += _unitOfWork.Commit();
                    //}

                    var rawMaterialConfirmation = _repositoryFactory.RawMaterialConfirmation
                        .FirstOrDefault(x => x.RawMaterialID == rawMaterialID);

                    if (rawMaterialConfirmation != null)
                    {
                        if (rawMaterialConfirmation.Status != (byte)PPC.Common.RawMaterialConfirmationStatus.Saved)
                            throw new System.Exception("RawMaterials Notfound.");

                        _repositoryFactory.RawMaterialConfirmation.Delete(rawMaterialConfirmation);

                        //statuse += _unitOfWork.Commit();

                    }

                    _repositoryFactory.RawMaterials.Delete(rawMaterials);
                    var statuse = _unitOfWork.Commit();

                    t.Commit();
                    return statuse;

                }
                catch
                {
                    throw;
                }
            }
        }


        public async Task<bool> ExistRawMaterialsAsync(string name)
        {
            try
            {

                return await _repositoryFactory.RawMaterials.FirstOrDefaultAsync(x => x.RawMaterialName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }


        public async Task<List<RawMaterials>> GetAllForDropDownAsync()
        {
            try
            {
                var rawMaterials = await _repositoryFactory.RawMaterials.Table
                    .Include(x => x.RawMaterialGroups)
                    .Include(x => x.Units)
                    //.Include(x => x.TestPlanAssign)
                    .ToListAsync();
                return rawMaterials;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<RawMaterials> GetInstanceByRawMaterialSampleId(int rawMaterialSampleId)
        {
            try
            {
                var rawMaterials = await _repositoryFactory.RawMaterials.Table
                    .Include(x => x.RawMaterialGroups)
                    .Include(x => x.Units)
                    //.Include(x => x.TestPlanAssign)
                    .FirstOrDefaultAsync(x => x.RawMaterialSampleID == rawMaterialSampleId);

                return rawMaterials;
            }
            catch
            {
                throw;
            }
        }

        //public async Task<bool> CheckRawMateriaIsParent(int rawMaterialId)
        //{
        //    try
        //    {
        //        var exist = await _repositoryFactory.RawMaterials.CountAsync(x => x.ParentID == rawMaterialId) > 0;

        //        return exist;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        public async Task<List<RawMaterials>> GetListForBOMAsync()
        {
            try
            {
                var rawMaterials = await _repositoryFactory.RawMaterials.Table
                    .Include(x => x.RawMaterialGroups)
                    .Include(x => x.Units)
                    //.Include(x => x.TestPlanAssign)
                    .ToListAsync();
                return rawMaterials;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<RawMaterials>> GetListByRawMatrtialIdAsync(int id)
        {
            try
            {
                var rawMaterials = await _repositoryFactory.RawMaterials.Table
                    .Include(x => x.RawMaterialGroups)
                    .Include(x => x.Units)
                    //.Include(x => x.TestPlanAssign)
                    .ToListAsync();
                return rawMaterials;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public bool ChangeSampleConfirmation(int rawMaterialId, bool state)
        {
            try
            {
                var rm = _repositoryFactory.RawMaterials.FirstOrDefault(x => x.RawMaterialID == rawMaterialId);
                rm.IsConfirmed = state;

                _repositoryFactory.RawMaterials.Update(rm);

                var statuse = _unitOfWork.Commit() > 0;

                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RawMaterials>> GetListByIdListAsync(List<int> rawMaterialIdList)
        {
            try
            {

                var rawMaterials = await _repositoryFactory.RawMaterials
                    .Where(x => rawMaterialIdList.Contains(x.RawMaterialID))
                    //.Include(x=>x.)
                    .ToListAsync();

                return rawMaterials;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


    }
}



/*
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class RawMaterialsService : BaseService, IRawMaterialsService
    {
        IUnitOfWork _unitOfWork;
        public RawMaterialsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<RawMaterials> GetAll()
        {
            try
            {
                var rawMaterials = _repositoryFactory.RawMaterials.Table.Include(x => x.RawMaterialGroups).Include(x => x.Units).ToList();

                return rawMaterials;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RawMaterials>> GetAllAsync()
        {
            try
            {

                var rawMaterials = await _repositoryFactory.RawMaterials.Table.Include(x => x.RawMaterialGroups).Include(x => x.Units).ToListAsync();
                return rawMaterials;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public RawMaterials GetRawMaterialsById(int rawMaterialID)
        {
            try
            {
                var rawMaterials = _repositoryFactory.RawMaterials.Table.Include(x => x.RawMaterialGroups).Include(x => x.Units)
                    .FirstOrDefault(x => x.RawMaterialID == rawMaterialID);

                return rawMaterials;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RawMaterials> GetRawMaterialsByIdAsync(int rawMaterialID)
        {
            try
            {
                var rawMaterials = await _repositoryFactory.RawMaterials.Table.Include(x => x.RawMaterialGroups).Include(x => x.Units)
                    .FirstOrDefaultAsync(x => x.RawMaterialID == rawMaterialID);

                return rawMaterials;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(RawMaterials rawMaterials)
        {
            try
            {
                _repositoryFactory.RawMaterials.Add(
                    new RawMaterials
                    {
                        RawMaterialID = rawMaterials.RawMaterialID,
                        RawMaterialOriginCode = rawMaterials.RawMaterialOriginCode,
                        RawMaterialOriginName = rawMaterials.RawMaterialOriginName,
                        RawMaterialCode = rawMaterials.RawMaterialCode,
                        RawMaterialName = rawMaterials.RawMaterialName,
                        RawMaterialLatinName = rawMaterials.RawMaterialLatinName,
                        UnitID = rawMaterials.UnitID,
                        RawMaterialGroupID = rawMaterials.RawMaterialGroupID,
                        SupplierID = rawMaterials.SupplierID,
                        IsRecycled = rawMaterials.IsRecycled,
                        StorageConditions = rawMaterials.StorageConditions,
                        IsSample = rawMaterials.IsSample,
                        SampleID = rawMaterials.SampleID,
                        IsActive = rawMaterials.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(RawMaterials rawMaterials)
        {
            try
            {

                _repositoryFactory.RawMaterials.UpdateBy(x => x.RawMaterialID == rawMaterials.RawMaterialID,
                    new RawMaterials
                    {
                        RawMaterialID = rawMaterials.RawMaterialID,
                        RawMaterialOriginCode = rawMaterials.RawMaterialOriginCode,
                        RawMaterialOriginName = rawMaterials.RawMaterialOriginName,
                        RawMaterialCode = rawMaterials.RawMaterialCode,
                        RawMaterialName = rawMaterials.RawMaterialName,
                        RawMaterialLatinName = rawMaterials.RawMaterialLatinName,
                        UnitID = rawMaterials.UnitID,
                        RawMaterialGroupID = rawMaterials.RawMaterialGroupID,
                        SupplierID = rawMaterials.SupplierID,
                        IsRecycled = rawMaterials.IsRecycled,
                        StorageConditions = rawMaterials.StorageConditions,
                        IsSample = rawMaterials.IsSample,
                        SampleID = rawMaterials.SampleID,
                        IsActive = rawMaterials.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int rawMaterialID)
        {
            try
            {
                var rawMaterials = _repositoryFactory.RawMaterials
                    .FirstOrDefault(x => x.RawMaterialID == rawMaterialID);

                if (rawMaterials == null)
                    throw new System.Exception("RawMaterials Notfound.");

                _repositoryFactory.RawMaterials.Delete(rawMaterials);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistRawMaterialsAsync(string name)
        {
            try
            {

                return await _repositoryFactory.RawMaterials.FirstOrDefaultAsync(x => x.RawMaterialName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }

        int IRawMaterialsService.Append(RawMaterials rawMaterials)
        {
            throw new System.NotImplementedException();
        }
    }
}
*/