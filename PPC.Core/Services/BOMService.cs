using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class BOMService : BaseService, IBOMService
    {
        IUnitOfWork _unitOfWork;
        public BOMService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<BOM> GetAll()
        {
            try
            {
                var bOM = _repositoryFactory.BOM.Table.ToList();

                return bOM;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<BOM>> GetAllAsync()
        {
            try
            {

                var bOM = await _repositoryFactory.BOM.Table
                    .Include(x => x.Product)
                    .Include(x => x.Parent)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    .ToListAsync();
                return bOM;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public BOM GetBOMById(int bOMID)
        {
            try
            {
                var bOM = _repositoryFactory.BOM.Table
                    .Include(x => x.Product)
                    .Include(x => x.Parent)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    .FirstOrDefault(x => x.BOMID == bOMID);

                return bOM;
            }
            catch
            {
                throw;
            }
        }

        public async Task<BOM> GetBOMByIdAsync(int bOMID)
        {
            try
            {
                var bOM = await _repositoryFactory.BOM.Table
                    .Include(x => x.Product)
                    .Include(x => x.Parent)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    .FirstOrDefaultAsync(x => x.BOMID == bOMID);

                return bOM;
            }
            catch
            {
                throw;
            }
        }

        public int Append(BOM bom)
        {
            //using (var t = _unitOfWork.StartTransaction())
            //{

                try
                {
                    var _newBOM = new BOM
                    {
                        //BOMID = bom.BOMID,
                        BOMCode = bom.BOMCode,
                        ProductID = bom.ProductID,
                        Status = bom.Status,
                        Version = bom.Version,
                        ParentID = bom.ParentID,
                        IsMainBOM = bom.IsMainBOM,
                        Describe = bom.Describe,
                        Ver = bom.Ver,
                        CustomerVer = bom.CustomerVer,
                        InsUserID = bom.InsUserID,
                        InsUserName = bom.InsUserName,
                        InsUserFullName = bom.InsUserFullName,
                        InsDate = bom.InsDate,
                        InsTime = bom.InsTime,
                        IsDraft = bom.IsDraft,
                        EditUserID = bom.EditUserID,
                        EditUserName = bom.EditUserName,
                        EditUserFullName = bom.EditUserFullName,
                        EditDate = bom.EditDate,
                        EditTime = bom.EditTime,
                        IsActive = bom.IsActive,
                        BOMDetailList = bom.BOMDetailList,

                    };

                    _repositoryFactory.BOM.Add(_newBOM);

                    var statuse = _unitOfWork.Commit() > 0;

                    //foreach (BOMDetail detail in bom.BOMDetailList)
                    //{
                    //    var _newDetail = new BOMDetail
                    //    {
                    //        BOMID = _newBOM.BOMID,
                    //        RawMaterialID = detail.RawMaterialID,
                    //        RMWhiteListID = detail.RMWhiteListID,
                    //        Priority = detail.Priority,
                    //        Percentage = detail.Percentage,
                    //        IsFinalRM = detail.IsFinalRM,
                    //        Describe = detail.Describe,
                    //    };
                    //    _repositoryFactory.BOMDetail.Add(_newDetail);
                    //    statuse &= _unitOfWork.Commit() > 0;

                    //    foreach (BOMComplementary complementaryin in detail.BOMComplementaryList)
                    //    {
                    //        _repositoryFactory.BOMComplementary.Add(
                    //            new BOMComplementary
                    //            {
                    //                BOMDetailID = _newDetail.BOMDetailID,
                    //                RawMaterialID = complementaryin.RawMaterialID,
                    //                Priority = complementaryin.Priority,
                    //                Percentage = complementaryin.Percentage,
                    //                Describe = complementaryin.Describe,
                    //            });
                    //        statuse &= _unitOfWork.Commit() > 0;
                    //    }
                    //}




                    //t.Commit();
                    if (statuse)
                        return _newBOM.BOMID;
                    else
                        return int.MinValue;
                }
                catch (System.Exception)
                {
                    //t.Rollback();
                    throw;
                }
            //}
        }


        public bool Update(BOM bom)
        {
            //using (var t = _unitOfWork.StartTransaction())
            //{
                try
                {
                    //bom.BOMDetailList.ForEach(d =>
                    //{
                    //    _repositoryFactory.BOMComplementary.DeleteBy(x => x.BOMDetailID == d.BOMDetailID);
                    //    _repositoryFactory.BOMDetail.Delete(d);

                    //});

                    var statuse = _unitOfWork.Commit() > 0;

                    _repositoryFactory.BOM.UpdateBy(x => x.BOMID == bom.BOMID,
                        new BOM
                        {
                            BOMID = bom.BOMID,
                            BOMCode = bom.BOMCode,
                            ProductID = bom.ProductID,
                            Status = bom.Status,
                            Version = bom.Version,
                            ParentID = bom.ParentID,
                            IsMainBOM = bom.IsMainBOM,
                            Describe = bom.Describe,
                            Ver = bom.Ver,
                            CustomerVer = bom.CustomerVer,
                            InsUserID = bom.InsUserID,
                            InsUserName = bom.InsUserName,
                            InsUserFullName = bom.InsUserFullName,
                            InsDate = bom.InsDate,
                            InsTime = bom.InsTime,
                            IsDraft = bom.IsDraft,
                            EditUserID = bom.EditUserID,
                            EditUserName = bom.EditUserName,
                            EditUserFullName = bom.EditUserFullName,
                            EditDate = bom.EditDate,
                            EditTime = bom.EditTime,
                            IsActive = bom.IsActive,
                            BOMDetailList= bom.BOMDetailList,
                        });
                    statuse &= _unitOfWork.Commit() > 0;


                    //t.Commit();

                    return statuse;
                }
                catch (System.Exception ex)
                {
                    //t.Rollback();
                    throw ex;
                }
            //}
        }


        //public bool Update(BOM bom)
        //{
        //    using (var t = _unitOfWork.StartTransaction())
        //    {
        //        try
        //        {
        //            bom.BOMDetailList.ForEach(d =>
        //            {
        //                _repositoryFactory.BOMComplementary.DeleteBy(x => x.BOMDetailID == d.BOMDetailID);
        //                _repositoryFactory.BOMDetail.Delete(d);

        //            });

        //            var statuse = _unitOfWork.Commit() > 0;

        //            _repositoryFactory.BOM.UpdateBy(x => x.BOMID == bom.BOMID,
        //                new BOM
        //                {
        //                    BOMID = bom.BOMID,
        //                    BOMCode = bom.BOMCode,
        //                    ProductID = bom.ProductID,
        //                    Status = bom.Status,
        //                    Version = bom.Version,
        //                    ParentID = bom.ParentID,
        //                    IsMainBOM = bom.IsMainBOM,
        //                    Describe = bom.Describe,
        //                    Ver = bom.Ver,
        //                    CustomerVer = bom.CustomerVer,
        //                    InsUserID = bom.InsUserID,
        //                    InsUserName = bom.InsUserName,
        //                    InsUserFullName = bom.InsUserFullName,
        //                    InsDate = bom.InsDate,
        //                    InsTime = bom.InsTime,
        //                    IsDraft = bom.IsDraft,
        //                    EditUserID = bom.EditUserID,
        //                    EditUserName = bom.EditUserName,
        //                    EditUserFullName = bom.EditUserFullName,
        //                    EditDate = bom.EditDate,
        //                    EditTime = bom.EditTime,
        //                    IsActive = bom.IsActive,
        //                });
        //            statuse &= _unitOfWork.Commit() > 0;

        //            foreach (BOMDetail detail in bom.BOMDetailList)
        //            {
        //                var _newDetail = new BOMDetail
        //                {
        //                    BOMID = bom.BOMID,
        //                    RawMaterialID = detail.RawMaterialID,
        //                    RMWhiteListID = detail.RMWhiteListID,
        //                    Priority = detail.Priority,
        //                    Percentage = detail.Percentage,
        //                    IsFinalRM = detail.IsFinalRM,
        //                    Describe = detail.Describe,
        //                };
        //                _repositoryFactory.BOMDetail.Add(_newDetail);
        //                statuse &= _unitOfWork.Commit() > 0;

        //                foreach (BOMComplementary complementaryin in detail.BOMComplementaryList)
        //                {
        //                    _repositoryFactory.BOMComplementary.Add(
        //                        new BOMComplementary
        //                        {
        //                            BOMDetailID = _newDetail.BOMDetailID,
        //                            RawMaterialID = complementaryin.RawMaterialID,
        //                            Priority = complementaryin.Priority,
        //                            Percentage = complementaryin.Percentage,
        //                            Describe = complementaryin.Describe,
        //                        });
        //                    statuse &= _unitOfWork.Commit() > 0;
        //                }
        //            }


        //            t.Commit();

        //            return statuse;
        //        }
        //        catch (System.Exception ex)
        //        {
        //            t.Rollback();
        //            throw ex;
        //        }
        //    }
        //}

        public long Delete(int bOMID)
        {
            try
            {
                var bOM = _repositoryFactory.BOM
                    .FirstOrDefault(x => x.BOMID == bOMID);

                if (bOM == null)
                    throw new System.Exception("BOM Notfound.");

                _repositoryFactory.BOM.Delete(bOM);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<BOM> GetByBOMCodeAsync(string bomCode)
        {
            try
            {
                var bom = await _repositoryFactory.BOM
                    .FirstOrDefaultAsync(x => x.BOMCode.ToUpper() == bomCode.ToUpper());

                return bom;
            }
            catch
            {
                throw;
            }
        }

        public bool ConfirmDraft(int bomId)
        {
            try
            {
                var bom = GetBOMById(bomId);

                bom.IsDraft = false;
                _repositoryFactory.BOM.Update(bom);
                var statuse = _unitOfWork.Commit() > 0;

                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<BOM>> GetListByProductIdAsync(int id)
        {
            try
            {

                var bOM = await _repositoryFactory.BOM
                    .Where(x=>x.ProductID==id)
                    .Include(x => x.Product)
                    .Include(x => x.Parent)
                    .Include(x => x.BOMDetailList).ThenInclude(x=>x.RawMaterial)
                    //.Include(x => x.BOMDetailList).ThenInclude(x=>x.RMWhiteList)
                    //.Include(x => x.User_InsUser)
                    //.Include(x => x.User_EditUser)
                    .ToListAsync();
                return bOM;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<BOM> GetLatestVersionByIdAsync(int bOMID)
        {
            try
            {
                var _b = GetBOMById(bOMID);

                var bOM = await _repositoryFactory.BOM.Table
                    .Where(x => x.BOMCode == _b.BOMCode)
                    .OrderByDescending(x=>x.Version)
                    .Include(x => x.Product)
                    .Include(x => x.Parent)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    .FirstOrDefaultAsync();

                return bOM;
            }
            catch
            {
                throw;
            }
        }

        public async Task<BOM> GetBOMWithComplementaryByIdAsync(int bOMID)
        {
            try
            {
                var bOM = await _repositoryFactory.BOM.Table
                    .Include(x=>x.BOMDetailList).ThenInclude(x=>x.BOMComplementaryList)
                    .Include(x=>x.BOMDetailList).ThenInclude(x=>x.RawMaterial)
                    .Include(x => x.Product)
                    .Include(x => x.Parent)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    .FirstOrDefaultAsync(x => x.BOMID == bOMID);

                return bOM;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<BOM>> GetListByRawMaterialIdAsync(int rawMaterialId)
        {
            try
            {
                var product = _repositoryFactory.Products
                    .FirstOrDefault(x => x.Final_RawMaterialID == rawMaterialId);

                if (product == null)
                    return null;


                var bOM = await _repositoryFactory.BOM
                    .Where(x => x.ProductID == product.ProductID)
                    .Include(x => x.BOMDetailList).ThenInclude(x => x.BOMComplementaryList)
                    .Include(x => x.BOMDetailList).ThenInclude(x => x.RawMaterial)
                    .Include(x => x.Product)
                    .Include(x => x.Parent)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    .ToListAsync();

                return bOM;
            }
            catch
            {
                throw;
            }
        }

        public BOM GetMaxBOMcodeByProductId(int productId)
        {
            try
            {
                var bOM = _repositoryFactory.BOM
                    .Where(x=>x.ProductID ==  productId)
                    .Include(x => x.Product)
                    .Include(x => x.Parent)
                    .OrderByDescending(x => x.BOMCode).Take(1);

                return bOM.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }



    }
}
