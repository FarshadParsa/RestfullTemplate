using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Common;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
using PPC.Exception;
using PPC.Response.DTOs;

namespace PPC.Core.Services
{
    public partial class PaletsService : BaseService, IPaletsService
    {
        //IUnitOfWork _unitOfWork;
        public PaletsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<Palets> GetAll()
        {
            try
            {
                var palets = _repositoryFactory.Palets.Table.ToList();

                return palets;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Palets>> GetAllAsync()
        {
            try
            {

                var palets = await _repositoryFactory.Palets.Table.ToListAsync();
                return palets;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public Palets GetPaletsById(int paletID)
        {
            try
            {
                var palets = _repositoryFactory.Palets.Table.AsNoTracking()
                    .FirstOrDefault(x => x.PaletID == paletID);

                return palets;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Palets> GetPaletsByIdAsync(int paletID)
        {
            try
            {
                var palets = await _repositoryFactory.Palets.Table
                    .Include(x => x.Product)
                    .Include(x => x.PaletDetailList).ThenInclude(x => x.InvProduct).ThenInclude(x => x.DataProduction).ThenInclude(x => x.ProductionPlanPatil)
                    .Include(x => x.PaletDetailList).ThenInclude(x => x.InvProduct).ThenInclude(x => x.Product)
                    .Include(x => x.OrderDetail).ThenInclude(x => x.Order)
                    .Include(x => x.Customer)
                    .FirstOrDefaultAsync(x => x.PaletID == paletID);

                return palets;
            }
            catch
            {
                throw;
            }
        }

        public int Append(Palets palets)
        {
            using (var t = _unitOfWork.StartTransaction())
            {
                try
                {
                    var invProducts = _repositoryFactory.InvProducts.Where(x => palets.PaletDetailList.Select(p => p.InvProductID).Contains(x.ProductID));
                    invProducts.ToList().ForEach(x => x.Status = (byte)InvProductStatus.Warehouse);
                    var _newObject = new Palets
                    {
                        PaletID = palets.PaletID,
                        PaletNo = palets.PaletNo,
                        CustomerID = palets.CustomerID,
                        OrderDetailID = palets.OrderDetailID,
                        ProductID = palets.ProductID,
                        NetWeight = palets.NetWeight,
                        Weight = palets.Weight,
                        QTY = palets.QTY,
                        PaletDate = palets.PaletDate,
                        PaletTime = palets.PaletTime,
                        UserID = palets.UserID,
                        StationID = palets.StationID,
                        QualityClass = palets.QualityClass,
                        Status = palets.Status,
                        ProductsQuality = palets.ProductsQuality,
                        Remarks = palets.Remarks,
                        QcStatus = palets.QcStatus,
                        PaletDetailList = palets.PaletDetailList,
                    };
                    _repositoryFactory.Palets.Add(_newObject);

                    var statuse = _unitOfWork.Commit() > 0;

                    //// set palet id into productId
                    _newObject.PaletDetailList.ForEach(x =>
                    {
                        var invP = _repositoryFactory.InvProducts.FirstOrDefault(p => p.InvProductID == x.InvProductID);
                        invP.PaletID = _newObject.PaletID;
                        invP.Status = (byte)InvProductStatus.Warehouse;
                        statuse = _unitOfWork.Commit() > 0;
                    });


                    t.Commit();

                    if (statuse)
                        return _newObject.PaletID;
                    else
                        return int.MinValue;
                }
                catch (System.Exception)
                {
                    t.Rollback();
                    throw;
                }
            }
        }


        public bool Update(Palets palets)
        {
            try
            {

                _repositoryFactory.Palets.UpdateBy(x => x.PaletID == palets.PaletID,
                    new Palets
                    {
                        PaletID = palets.PaletID,
                        PaletNo = palets.PaletNo,
                        CustomerID = palets.CustomerID,
                        OrderDetailID = palets.OrderDetailID,
                        ProductID = palets.ProductID,
                        NetWeight = palets.NetWeight,
                        Weight = palets.Weight,
                        QTY = palets.QTY,
                        PaletDate = palets.PaletDate,
                        PaletTime = palets.PaletTime,
                        UserID = palets.UserID,
                        StationID = palets.StationID,
                        QualityClass = palets.QualityClass,
                        Status = palets.Status,
                        ProductsQuality = palets.ProductsQuality,
                        Remarks = palets.Remarks,
                        QcStatus = palets.QcStatus,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int paletID)
        {
            using (var t = _unitOfWork.StartTransaction())
            {
                try
                {
                    var palets = _repositoryFactory.Palets.Table
                        .Include(x => x.PaletDetailList).ThenInclude(x => x.InvProduct)
                        .FirstOrDefault(x => x.PaletID == paletID);

                    if (palets == null)
                        throw new System.Exception("Palets Notfound.");

                    #region set paletid to null

                    palets.PaletDetailList.ForEach(x =>
                    {
                        x.InvProduct.PaletID = null;
                        x.InvProduct.Status = (byte)InvProductStatus.Weighted;

                    });

                    #endregion

                    _repositoryFactory.Palets.Delete(palets);
                    var statuse = _unitOfWork.Commit();

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

        public async Task<Palets> GetInstanceByPaletNoAsync(string paletNo)
        {
            try
            {
                var palets = await _repositoryFactory.Palets.Table.AsNoTracking()
                    .Include(x => x.Customer)
                    .Include(x => x.Product)
                    .Include(x => x.OrderDetail).ThenInclude(x => x.Order).ThenInclude(x => x.Customer)
                    .Include(x => x.PaletDetailList)
                    .Include(x => x.User)
                    .FirstOrDefaultAsync(x => x.PaletNo == paletNo);

                return palets;
            }
            catch
            {
                throw;
            }
        }


        public async Task<List<string>> ValidateCanInsertProductsAsync(List<int> invProductIdList)
        {
            try
            {
                var invList = _repositoryFactory.InvProducts.Table
                    .Include(x => x.Product)
                    .Include(x => x.DataProduction).ThenInclude(x => x.ProductionPlanPatil).ThenInclude(x => x.ProductionPlan)

                    .Where(x => invProductIdList.Contains(x.InvProductID))
                    //.Include(x=>x.Palet)
                    .ToList();
                List<string> invProducts = invList == null ? null : new List<string>();

                invList.ForEach(invProduct =>
                {
                    if (invProduct.PaletID != null)
                    {
                        if (!(invProduct.Status == (byte)InvProductStatus.Weighted || invProduct.Status == (byte)InvProductStatus.ReturnedToProduction ||
                        invProduct.Status == (byte)InvProductStatus.Reverted || invProduct.Status == (byte)InvProductStatus.Arrived))
                        {
                            var statusDesc = (InvProductStatus)Enum.Parse(typeof(InvProductStatus), invProduct.Status.ToString());
                            invProducts.Add($"بارکد محصول : {invProduct.InvProductCode}, وضعیت محصول : «{statusDesc}» .");
                        }
                    }

                    if (invProducts.IndexOf(invProduct.InvProductCode) == -1 &&
                    invProduct.Product.IsSemiProduct && !invProduct.DataProduction.ProductionPlanPatil.ProductionPlan.TransferToWarehouse)
                    {

                        var statusDesc = "عدم مجوز انتقال به انبار محصول";
                        invProducts.Add($"بارکد : {invProduct.InvProductCode}, «{statusDesc}» .");
                    }

                });


                return invProducts;
            }
            catch
            {
                throw;
            }
        }

        public string GetMaxPaletNo()
        {
            try
            {
                var paletNo = _repositoryFactory.Palets.Table.Max(x => x.PaletNo);
                return paletNo;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Palets>> GetArchiveList(string startDate, string endDate)
        {
            try
            {

                var palets = await _repositoryFactory.Palets
                    .Where(x => (string.Compare(x.PaletDate, startDate) >= 0 && string.Compare(x.PaletDate, endDate) <= 0))
                    .Include(x => x.Customer)
                    .Include(x => x.OrderDetail).ThenInclude(x => x.Order)
                    .Include(x => x.Product)
                    .Include(x => x.Station)
                    .Include(x => x.User)
                    .Include(x => x.PaletDetailList).ThenInclude(x => x.InvProduct).ThenInclude(x => x.DataProduction).ThenInclude(x => x.ProductionPlanPatil).ThenInclude(x => x.ProductionPlan)
                    .ToListAsync();
                return palets;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<Palets> GetPaletLabelInfoAsync(int paletID)
        {
            try
            {
                var palets = await _repositoryFactory.Palets.Table
                    .Include(x => x.PaletDetailList).ThenInclude(x => x.InvProduct).ThenInclude(x => x.DataProduction).ThenInclude(x => x.ProductionPlanPatil)
                    .Include(x => x.PaletDetailList).ThenInclude(x => x.InvProduct).ThenInclude(x => x.Product)
                    .Include(x => x.OrderDetail)
                    .Include(x => x.Product)
                    .FirstOrDefaultAsync(x => x.PaletID == paletID);

                return palets;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> GetNextPaletNoAsync(int number = 1)
        {
            try
            {


                string maxPaletNo = GetMaxPaletNo();
                SettingGeneralsService settingGeneralsService = new SettingGeneralsService(_repositoryFactory, _unitOfWork);
                SettingsService settingsService = new SettingsService(_repositoryFactory, _unitOfWork);
                string paletNoFirstPart = "";

                string paletNoSecondPart = "";
                string lastVer = settingsService.GetActiveVersion().LastVersion;
                var settingGeneral = await settingGeneralsService.GetInstanceByVesionAsync(lastVer);

                string nextPaletNo = null;
                string paletNoDateString = $"{General.CurrentYear}{General.CurrentMonth.ToString("00")}{General.CurrentDay.ToString("00")}";
                paletNoFirstPart = paletNoDateString.Substring(2, 6);

                if (maxPaletNo.Length == 0 ||
                    (maxPaletNo.Substring(2, 2) != (General.CurrentYear.ToString().Substring(2, 2)).ToString())// New Year
                    )
                {
                    paletNoSecondPart = number.ToString("00000");
                    nextPaletNo = $"{paletNoFirstPart}{paletNoSecondPart}";

                }
                else
                {
                    if (maxPaletNo.Substring(8) != "99999")
                    {

                        int MaxNo = int.Parse(maxPaletNo.Substring(8));
                        MaxNo += number;

                        paletNoSecondPart = MaxNo.ToString("00000");
                        nextPaletNo = $"{paletNoFirstPart}{paletNoSecondPart}";


                    }
                    else
                    {
                        paletNoSecondPart = number.ToString("00000");
                        nextPaletNo = $"{paletNoFirstPart}{paletNoSecondPart}";
                    }
                    //}
                }

                nextPaletNo = settingGeneral.FactoryCode.ToString("00") + nextPaletNo;

                return nextPaletNo;


            }
            catch
            {
                throw;
            }
        }



    }
}
