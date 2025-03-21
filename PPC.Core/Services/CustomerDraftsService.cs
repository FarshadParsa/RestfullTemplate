using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AtlasCellData.ADO;
using Microsoft.EntityFrameworkCore;
using PPC.Common;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
using PPC.Response.DTOs;

namespace PPC.Core.Services
{
    public class CustomerDraftsService : BaseService, ICustomerDraftsService
    {
        //IUnitOfWork _unitOfWork;
        public CustomerDraftsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<CustomerDrafts> GetAll()
        {
            try
            {

                var customerDrafts = _repositoryFactory.CustomerDrafts.Table.ToList();

                return customerDrafts;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CustomerDrafts>> GetAllAsync()
        {
            try
            {

                var customerDrafts = await _repositoryFactory.CustomerDrafts.Table.ToListAsync();
                return customerDrafts;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


        public CustomerDrafts GetCustomerDraftsById(int customerDraftID)
        {
            try
            {
                var customerDrafts = _repositoryFactory.CustomerDrafts
                    .FirstOrDefault(x => x.CustomerDraftID == customerDraftID);

                return customerDrafts;

            }
            catch
            {
                throw;
            }
        }

        public async Task<CustomerDrafts> GetCustomerDraftsByIdAsync(int customerDraftID)
        {
            try
            {
                var customerDrafts = await _repositoryFactory.CustomerDrafts.Table
                    .Include(x => x.Customer)
                    .Include(x => x.User)
                    .Include(x => x.Station)
                    .Include(x => x.CustomerDraftPaletList).ThenInclude(x => x.Palet)
                    .FirstOrDefaultAsync(x => x.CustomerDraftID == customerDraftID);

                return customerDrafts;
            }
            catch
            {
                throw;
            }
        }

        public int Append(CustomerDrafts customerDrafts)
        {
            using (var t = _unitOfWork.StartTransaction())
            {


                try
                {

                    #region palet and product status change

                    customerDrafts.CustomerDraftPaletList.ForEach(x =>
                    {

                        var product = _repositoryFactory.InvProducts.Where(i => i.PaletID == x.PaletID).Include(i => i.Palet).ToList();
                        if (product != null)
                        {
                            product.ForEach(p =>
                            {
                                p.Status = (byte)InvProductStatus.Deleiverd;
                                p.Palet.Status = (byte)PaletStatus.Delivered;
                            });

                        }
                        else
                        {
                            throw new System.Exception($"برای پالت با شماره «{x.Palet.PaletNo}» محصولی پیدا نشد");
                        }

                        //x.Palet.Status = (byte)PaletStatus.Delivered;
                    });

                    #endregion

                    var _newObject = new CustomerDrafts
                    {
                        CustomerDraftID = customerDrafts.CustomerDraftID,
                        DraftNo = customerDrafts.DraftNo,
                        FinancialDraftNo = customerDrafts.FinancialDraftNo,
                        CustomerID = customerDrafts.CustomerID,
                        BarnameNo = customerDrafts.BarnameNo,
                        DriverName = customerDrafts.DriverName,
                        VehicleType = customerDrafts.VehicleType,
                        TransportOrg = customerDrafts.TransportOrg,
                        VehicleNo = customerDrafts.VehicleNo,
                        UserID = customerDrafts.UserID,
                        StationID = customerDrafts.StationID,
                        Describe = customerDrafts.Describe,
                        DraftDate = customerDrafts.DraftDate,
                        DraftTime = customerDrafts.DraftTime,
                        DriverTelNo = customerDrafts.DriverTelNo,
                        IsConfirmed = customerDrafts.IsConfirmed,

                        InsUserID = customerDrafts.InsUserID,
                        InsDate = customerDrafts.InsDate,
                        InsTime = customerDrafts.InsTime,

                        EditUserID = customerDrafts.EditUserID,
                        EditDate = customerDrafts.EditDate,
                        EditTime = customerDrafts.EditTime,

                        CustomerDraftPaletList = customerDrafts.CustomerDraftPaletList,
                    };


                    _repositoryFactory.CustomerDrafts.Add(_newObject);

                    var statuse = _unitOfWork.Commit() > 0;
                    t.Commit();
                    if (statuse)
                        return _newObject.CustomerDraftID;
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


        public bool Update(CustomerDrafts customerDrafts)
        {
            try
            {
                #region rollback product status


                var removed = _repositoryFactory.CustomerDraftPalets.Where(x => x.CustomerDraftID == customerDrafts.CustomerDraftID &&
                    !customerDrafts.CustomerDraftPaletList.Select(d => d.CustomerDraftPaletID).Contains(x.CustomerDraftPaletID)).ToList();

                removed.ForEach(p =>
                {
                    var invList = _repositoryFactory.InvProducts.Where(x => x.PaletID == p.PaletID).Include(x => x.Palet).ToList();

                    invList.ForEach(x =>
                    {
                        x.Status = (byte)InvProductStatus.Warehouse;
                        x.Palet.Status = (byte)PaletStatus.InWareHouse;

                    });

                });

                #endregion

                #region palet and product status change to deliver

                customerDrafts.CustomerDraftPaletList.ForEach(x =>
                {

                    var product = _repositoryFactory.InvProducts.Where(i => i.PaletID == x.PaletID).Include(i => i.Palet).ToList();
                    if (product != null)
                    {
                        product.ForEach(p =>
                        {
                            p.Status = (byte)InvProductStatus.Deleiverd;
                            p.Palet.Status = (byte)PaletStatus.Delivered;
                        });

                    }
                    else
                    {
                        throw new System.Exception($"برای پالت با شماره «{x.Palet.PaletNo}» محصولی پیدا نشد");
                    }

                    //x.Palet.Status = (byte)PaletStatus.Delivered;
                });

                #endregion

                _repositoryFactory.CustomerDrafts.UpdateBy(x => x.CustomerDraftID == customerDrafts.CustomerDraftID,
                    new CustomerDrafts
                    {
                        CustomerDraftID = customerDrafts.CustomerDraftID,
                        DraftNo = customerDrafts.DraftNo,
                        FinancialDraftNo = customerDrafts.FinancialDraftNo,
                        CustomerID = customerDrafts.CustomerID,
                        BarnameNo = customerDrafts.BarnameNo,
                        DriverName = customerDrafts.DriverName,
                        VehicleType = customerDrafts.VehicleType,
                        TransportOrg = customerDrafts.TransportOrg,
                        VehicleNo = customerDrafts.VehicleNo,
                        UserID = customerDrafts.UserID,
                        StationID = customerDrafts.StationID,
                        Describe = customerDrafts.Describe,
                        DraftDate = customerDrafts.DraftDate,
                        DraftTime = customerDrafts.DraftTime,
                        DriverTelNo = customerDrafts.DriverTelNo,
                        IsConfirmed = customerDrafts.IsConfirmed,

                        InsUserID = customerDrafts.InsUserID,
                        InsDate = customerDrafts.InsDate,
                        InsTime = customerDrafts.InsTime,

                        EditUserID = customerDrafts.EditUserID,
                        EditDate = customerDrafts.EditDate,
                        EditTime = customerDrafts.EditTime,

                        CustomerDraftPaletList = customerDrafts.CustomerDraftPaletList,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int customerDraftID)
        {
            try
            {
                var customerDrafts = _repositoryFactory.CustomerDrafts.Table.Include(x => x.CustomerDraftPaletList)
                    .FirstOrDefault(x => x.CustomerDraftID == customerDraftID);

                if (customerDrafts == null)
                    throw new System.Exception("CustomerDrafts Notfound.");


                #region rollback status

                customerDrafts.CustomerDraftPaletList.ForEach(p =>
                {
                    var invList = _repositoryFactory.InvProducts.Where(x => x.PaletID == p.PaletID).Include(x => x.Palet).ToList();

                    invList.ForEach(x =>
                    {
                        x.Status = (byte)InvProductStatus.Warehouse;
                        x.Palet.Status = (byte)PaletStatus.InWareHouse;

                    });

                });

                #endregion

                _repositoryFactory.CustomerDrafts.Delete(customerDrafts);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CustomerDrafts>> GetListForGridAsync(string dateFrom, string dateTo)
        {
            try
            {

                var customerDrafts = await _repositoryFactory.CustomerDrafts.Table
                    .Where(x => (string.Compare(x.InsDate, dateFrom) >= 0 && string.Compare(x.InsDate, dateTo) <= 0))
                    .Include(x => x.Customer)
                    .Include(x => x.Station)
                    .Include(x => x.User)
                    .Include(x => x.CustomerDraftPaletList).ThenInclude(x => x.Palet).ThenInclude(x => x.Customer)
                    .Include(x => x.CustomerDraftPaletList).ThenInclude(x => x.Palet).ThenInclude(x => x.Product)
                    .Include(x => x.User_InsUser)
                    .ToListAsync();
                return customerDrafts;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<string> GetNextDraftNoAsync()
        {
            try
            {
                //var d1 = DateTime.Now;
                //var draftNo = _repositoryFactory.CustomerDrafts.Table
                //    .Max(x => x.DraftNo);
                //var customerDrafts = _repositoryFactory.CustomerDrafts.FirstOrDefault(x=>x.DraftNo== draftNo);

                var draftNo = _repositoryFactory.CustomerDrafts.Table.OrderByDescending(x => Convert.ToInt32(x.DraftNo)).FirstOrDefault()?.DraftNo;

                //var d2 = DateTime.Now;
                //var diff = (d2 - d1).Ticks;

                draftNo = draftNo == null ? "1" : (Convert.ToInt32(draftNo) + 1).ToString();
                return draftNo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Dictionary<string, string>> ValidateCanInsertPaletAsync(List<int> paletIdList)
        {
            try
            {
                var invList = _repositoryFactory.Palets
                    .Where(x => paletIdList.Contains(x.PaletID))
                    .ToList();
                //List<string> palets = invList == null ? null : new List<string>();
                Dictionary<string, string> palets = invList == null ? null : new Dictionary<string, string>();

                invList.ForEach(palet =>
                {
                    if (!(palet.Status == (byte)PaletStatus.Saved || palet.Status == (byte)PaletStatus.InWareHouse ||
                    palet.Status == (byte)PaletStatus.Reverted))
                    {
                        var statusDesc = (PaletStatus)Enum.Parse(typeof(PaletStatus), palet.Status.ToString());
                        palets.Add(palet.PaletNo, $" وضعیت محصول : «{statusDesc}».");
                    }
                });

                return palets;
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetCustomerDraftReport(int customerDraftID)
        {
            try
            {
                return CustomerDraftDL.GetCustomerDraftReport(customerDraftID);
            }
            catch
            {
                throw;
            }
        }



    }
}
