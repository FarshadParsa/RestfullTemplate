using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Common;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class OrdersService : BaseService, IOrdersService
    {
        IUnitOfWork _unitOfWork;
        public OrdersService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<Orders> GetAll()
        {
            try
            {
                //var orders = _repositoryFactory.Orders.Table
                var orders = _repositoryFactory.Orders.Where(x => !x.IsPlanningOrder)
                    .Include(x => x.Customer)
                    .Include(x => x.SubCustomer)
                    .Include(x => x.User)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    .ToList();

                return orders;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Orders>> GetAllAsync()
        {
            try
            {

                //var orders = await _repositoryFactory.Orders.Table
                var orders = await _repositoryFactory.Orders.Where(x => !x.IsPlanningOrder)
                    .Include(x => x.Customer)
                    .Include(x => x.SubCustomer)
                    .Include(x => x.User)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    //.Table.Include(x => x.Customer).Include(x => x.SubCustomer).Include(x => x.User)
                    .ToListAsync();
                return orders;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public Orders GetOrdersById(int orderID)
        {
            try
            {
                //var orders = _repositoryFactory.Orders.Table
                var orders = _repositoryFactory.Orders.Where(x => !x.IsPlanningOrder)
                    .Include(x => x.Customer)
                    .Include(x => x.SubCustomer)
                    .Include(x => x.User)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    .FirstOrDefault(x => x.OrderID == orderID);

                return orders;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Orders> GetOrdersByIdAsync(int orderID)
        {
            try
            {
                //var orders = await _repositoryFactory.Orders.Table
                var orders = await _repositoryFactory.Orders.Where(x => !x.IsPlanningOrder)
                    .Include(x => x.Customer)
                    .Include(x => x.SubCustomer)
                    .Include(x => x.User)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    //.Include(x => x.OrderDetails)
                    .FirstOrDefaultAsync(x => x.OrderID == orderID);

                return orders;
            }
            catch
            {
                throw;
            }
        }

        public int Append(Orders orders)
        {
            using (var t = _unitOfWork.StartTransaction())
            {

                try
                {

                    var customerDossierList = _repositoryFactory.CustomerDossier.Where(x => x.CustomerID == orders.CustomerID).ToList();

                    orders.OrderDetailList.ForEach(x =>
                    {
                        var bomId = x.BOMID != null
                        ? x.BOMID
                        : customerDossierList.FirstOrDefault(c => c.ProductID == x.ProductID)?.DefaultBOMID ?? null;
                        x.BOMID = bomId;
                    });

                    var _newObject = new Orders
                    {
                        OrderID = orders.OrderID,
                        OrderNo = orders.OrderNo,
                        CustomerID = orders.CustomerID,
                        SubCustomerID = orders.SubCustomerID,
                        ConfirmDate = orders.ConfirmDate,
                        CustomerByeNomber = orders.CustomerByeNomber,
                        Remark = orders.Remark,
                        Tolerance = orders.Tolerance,
                        DeliverFromDate = orders.DeliverFromDate,
                        DeliverToDate = orders.DeliverToDate,
                        DeliveredDate = orders.DeliveredDate,
                        RegisterDate = orders.RegisterDate,
                        Status = orders.Status,
                        IsSample = orders.IsSample,
                        DeliverySample = orders.DeliverySample,
                        DeliveryTestReport = orders.DeliveryTestReport,
                        PestControlCertificate = orders.PestControlCertificate,
                        IsPlanningOrder = orders.IsPlanningOrder,
                        PaymentMethod = orders.PaymentMethod,
                        SendingReason = orders.SendingReason,
                        CustomerIndustry = orders.CustomerIndustry,
                        UserID = orders.UserID,
                        OrderType = orders.OrderType,
                        InsUserID = orders.InsUserID,
                        InsUserName = orders.InsUserName,
                        InsUserFullName = orders.InsUserFullName,
                        InsDate = orders.InsDate,
                        InsTime = orders.InsTime,
                        EditUserID = orders.EditUserID,
                        EditUserName = orders.EditUserName,
                        EditUserFullName = orders.EditUserFullName,
                        EditDate = orders.EditDate,
                        EditTime = orders.EditTime,
                        OrderDetailList = orders.OrderDetailList,

                    };

                    _repositoryFactory.Orders.Add(_newObject);

                    var statuse = _unitOfWork.Commit() > 0;

                    //orders.OrderDetailList.ForEach(x =>
                    //{
                    //    var bomId = x.BOMID != null
                    //    ? x.BOMID
                    //    : customerDossierList.FirstOrDefault(c => c.ProductID == x.ProductID)?.DefaultBOMID ?? null;

                    //    var newOrderDetail = new OrderDetails
                    //    {
                    //        OrderID = _newObject.OrderID,
                    //        ProductID = x.ProductID,
                    //        Quantity = x.Quantity,
                    //        ProgrammedQuantity = x.ProgrammedQuantity,
                    //        Status = x.Status,
                    //        ProducedNo = x.ProducedNo,
                    //        DeliveredNo = x.DeliveredNo,
                    //        ProducedWeight = x.ProducedWeight,
                    //        DeliveredWeight = x.DeliveredWeight,
                    //        PackagingPlanID = x.PackagingPlanID,
                    //        InPlan = x.InPlan,
                    //        Priority = x.Priority,
                    //        Remark = x.Remark,
                    //        DeliverDate = x.DeliverDate,
                    //        OrderRequestDetailID = x.OrderRequestDetailID,
                    //        PlannedRemain = x.PlannedRemain,
                    //        WarehouseAmount = x.WarehouseAmount,
                    //        ConfirmUserID = x.ConfirmUserID,
                    //        Radif = x.Radif,
                    //        BOMID = bomId,

                    //    };

                    //    _repositoryFactory.OrderDetails.Add(newOrderDetail);
                    //    statuse &= _unitOfWork.Commit() > 0;


                    //    if (x.PackagingPlanList != null)
                    //    {
                    //        foreach (var p in x.PackagingPlanList)
                    //        {
                    //            _repositoryFactory.OrderDetailPackagings.Add(
                    //                new OrderDetailPackagings
                    //                {
                    //                    OrderDetailID = newOrderDetail.OrderDetailID,
                    //                    PackagingPlanID = p.Key,
                    //                    Priority = p.Value,
                    //                });

                    //        }
                    //        statuse &= _unitOfWork.Commit() > 0;
                    //    }
                    //});


                    //statuse &= _unitOfWork.Commit() > 0;



                    t.Commit();

                    if (statuse)
                        return _newObject.OrderID;
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


        public bool Update(Orders orders)
        {
            //var orderDetails = _repositoryFactory.OrderDetails
            //    .Where(x => x.OrderID == orders.OrderID);

            //var orderDetailPackagings = _repositoryFactory.OrderDetailPackagings.Where(x => orderDetails.Select(o => o.OrderDetailID).Contains(x.OrderDetailID)).FirstOrDefault();
            //_repositoryFactory.OrderDetailPackagings.Delete(orderDetailPackagings);

            ////foreach (var item in orderDetailPackagings)
            ////{
            ////    _repositoryFactory.OrderDetailPackagings.Delete(item);
            ////}

            using (var t = _unitOfWork.StartTransaction())
            {
                try
                {
                    var statuse = true;

                    var orderDetails = _repositoryFactory.OrderDetails
                        .Where(x => x.OrderID == orders.OrderID && !orders.OrderDetailList.Select(d => d.OrderDetailID).Contains(x.OrderDetailID));

                    //var orderDetails = _repositoryFactory.OrderDetails
                    //    .Where(x => x.OrderID == orders.OrderID);

                    //orderDetails.ToList().ForEach(x => _repositoryFactory.OrderDetailPackagings.DeleteBy(d => d.OrderDetailID == x.OrderDetailID));
                    //orderDetails.ToList().ForEach(x => _repositoryFactory.OrderDetailPackagings.DeleteBy(d => d.OrderDetailID == x.OrderDetailID));



                    var orderDetailPackagings = _repositoryFactory.OrderDetailPackagings.Where(x => orderDetails.Select(o => o.OrderDetailID).Contains(x.OrderDetailID));
                    _repositoryFactory.OrderDetailPackagings.DeleteBy(orderDetailPackagings);

                    statuse &= _unitOfWork.Commit() > 0;

                    //var orderDetailPackagings = _repositoryFactory.OrderDetailPackagings.Where(x => orderDetails.Select(o => o.OrderDetailID).Contains(x.OrderDetailID)).ToList();

                    //_repositoryFactory.OrderDetailPackagings.DeleteBy(x=> orderDetailPackagings.Contains(x.OrderDetailID));
                    //foreach (var item in orderDetailPackagings)
                    //{
                    //    _repositoryFactory.OrderDetailPackagings.Delete(item);
                    //}




                    _repositoryFactory.OrderDetails.DeleteBy(orderDetails);

                    _repositoryFactory.Orders.UpdateBy(x => x.OrderID == orders.OrderID,
                        new Orders
                        {
                            OrderID = orders.OrderID,
                            OrderNo = orders.OrderNo,
                            CustomerID = orders.CustomerID,
                            SubCustomerID = orders.SubCustomerID,
                            ConfirmDate = orders.ConfirmDate,
                            CustomerByeNomber = orders.CustomerByeNomber,
                            Remark = orders.Remark,
                            Tolerance = orders.Tolerance,
                            DeliverFromDate = orders.DeliverFromDate,
                            DeliverToDate = orders.DeliverToDate,
                            DeliveredDate = orders.DeliveredDate,
                            RegisterDate = orders.RegisterDate,
                            Status = orders.Status,
                            IsSample = orders.IsSample,
                            DeliverySample = orders.DeliverySample,
                            DeliveryTestReport = orders.DeliveryTestReport,
                            PestControlCertificate = orders.PestControlCertificate,
                            IsPlanningOrder = orders.IsPlanningOrder,
                            PaymentMethod = orders.PaymentMethod,
                            SendingReason = orders.SendingReason,
                            CustomerIndustry = orders.CustomerIndustry,
                            UserID = orders.UserID,
                            OrderType = orders.OrderType,
                            InsUserID = orders.InsUserID,
                            InsUserName = orders.InsUserName,
                            InsUserFullName = orders.InsUserFullName,
                            InsDate = orders.InsDate,
                            InsTime = orders.InsTime,
                            EditUserID = orders.EditUserID,
                            EditUserName = orders.EditUserName,
                            EditUserFullName = orders.EditUserFullName,
                            EditDate = orders.EditDate,
                            EditTime = orders.EditTime,
                            OrderDetailList = orders.OrderDetailList,
                        });
                    statuse &= _unitOfWork.Commit() > 0;


                    ////orders.OrderDetails.ForEach(x =>
                    ////_repositoryFactory.OrderDetails.Add(
                    ////    new OrderDetails
                    ////    {
                    ////        OrderID = orders.OrderID,
                    ////        ProductID = x.ProductID,
                    ////        Quantity = x.Quantity,
                    ////        ProgrammedQuantity = x.ProgrammedQuantity,
                    ////        Status = x.Status,
                    ////        ProducedNo = x.ProducedNo,
                    ////        DeliveredNo = x.DeliveredNo,
                    ////        ProducedWeight = x.ProducedWeight,
                    ////        DeliveredWeight = x.DeliveredWeight,
                    ////        InPlan = x.InPlan,
                    ////        Priority = x.Priority,
                    ////        Remark = x.Remark,
                    ////        DeliverDate = x.DeliverDate,
                    ////        OrderRequestDetailID = x.OrderRequestDetailID,
                    ////        PlannedRemain = x.PlannedRemain,
                    ////        WarehouseAmount = x.WarehouseAmount,
                    ////        ConfirmUserID = x.ConfirmUserID,

                    ////    }));

                    ////var statuse = _unitOfWork.Commit() > 0;


                    //orders.OrderDetails.ForEach(x =>
                    //{
                    //    var newOrderDetail = new OrderDetails
                    //    {
                    //        OrderID = orders.OrderID,
                    //        ProductID = x.ProductID,
                    //        Quantity = x.Quantity,
                    //        ProgrammedQuantity = x.ProgrammedQuantity,
                    //        Status = x.Status,
                    //        ProducedNo = x.ProducedNo,
                    //        DeliveredNo = x.DeliveredNo,
                    //        ProducedWeight = x.ProducedWeight,
                    //        DeliveredWeight = x.DeliveredWeight,
                    //        InPlan = x.InPlan,
                    //        PackagingPlanID = x.PackagingPlanID,
                    //        Priority = x.Priority,
                    //        Remark = x.Remark,
                    //        DeliverDate = x.DeliverDate,
                    //        OrderRequestDetailID = x.OrderRequestDetailID,
                    //        PlannedRemain = x.PlannedRemain,
                    //        WarehouseAmount = x.WarehouseAmount,
                    //        ConfirmUserID = x.ConfirmUserID,
                    //        BOMID = x.BOMID,

                    //    };

                    //    _repositoryFactory.OrderDetails.Add(newOrderDetail);
                    //    statuse &= _unitOfWork.Commit() > 0;

                    //    if (x.PackagingPlanList != null)
                    //    {
                    //        foreach (var p in x.PackagingPlanList)
                    //        {
                    //            _repositoryFactory.OrderDetailPackagings.Add(
                    //                new OrderDetailPackagings
                    //                {
                    //                    OrderDetailID = newOrderDetail.OrderDetailID,
                    //                    PackagingPlanID = p.Key,
                    //                    Priority = p.Value,
                    //                });

                    //        }
                    //        statuse &= _unitOfWork.Commit() > 0;
                    //    }


                    //    //x.OrderDetailPackagings.ForEach(p =>
                    //    //_repositoryFactory.OrderDetailPackagings.Add(
                    //    //    new OrderDetailPackagings
                    //    //    {
                    //    //        OrderDetailID = newOrderDetail.OrderDetailID,
                    //    //        PackagingPlanID = p.PackagingPlanID,
                    //    //        Priority = p.Priority,
                    //    //    }));

                    //    statuse &= _unitOfWork.Commit() > 0;
                    //});


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

        public long Delete(int orderID)
        {
            using (var t = _unitOfWork.StartTransaction())
            {

                try
                {
                    var orders = _repositoryFactory.Orders
                        .FirstOrDefault(x => x.OrderID == orderID);

                    if (orders == null)
                        throw new System.Exception("Orders Notfound.");

                    var orderDetails = _repositoryFactory.OrderDetails
                        .Where(x => x.OrderID == orderID);

                    _repositoryFactory.OrderDetails.DeleteBy(orderDetails);
                    _repositoryFactory.Orders.Delete(orders);

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


        public async Task<bool> OrderDeliveryHasStarted(int orderId)
        {
            try
            {

                //            strSQL = string.Format("SELECT COUNT(dbo.CustomerDraft.CustomerDraftID)" +
                //"FROM dbo.CustomerDraft INNER JOIN " +
                //"dbo.CustomerDraftPalets ON dbo.CustomerDraft.CustomerDraftID = dbo.CustomerDraftPalets.CustomerDraftID RIGHT OUTER JOIN " +
                //"dbo.Palets ON dbo.CustomerDraftPalets.PaletID = dbo.Palets.PaletID LEFT OUTER JOIN " +
                //"dbo.[Order] INNER JOIN " +
                //"dbo.OrderDetail ON dbo.[Order].OrderID = dbo.OrderDetail.OrderID ON dbo.Palets.OrderDetailID = dbo.OrderDetail.OrderDetailID " +
                //"WHERE (dbo.[Order].OrderID = {0}) AND (dbo.Palets.Status IN (3)) ",
                //orderID.ToString());

                List<byte> notAloowdStatus = new List<byte>()
                {
                    (byte)PaletStatus.Delivered,
                };
                var palets = _repositoryFactory.Palets.Table
                            .Include(x => x.OrderDetail)
                            .Where(x => notAloowdStatus.Contains(x.Status) && x.OrderDetail.OrderID == orderId).ToList();

                return palets.Count > 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> OrderPlanningHasStarted(int orderId)
        {
            try
            {

                var productionPlanQTY = _repositoryFactory.ProductionPlans.Table
                            .Include(x => x.OrderDetail)
                            .Count(x => x.OrderDetail.OrderID == orderId);

                return productionPlanQTY > 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Orders>> GetAllByRegisterDateAsync(string dateFrom, string dateTo, bool? isForiegn)
        {
            try
            {

                var orders = await _repositoryFactory.Orders
                    .Where(x => !x.IsPlanningOrder && string.Compare(x.RegisterDate, dateFrom) >= 0 &&
                    string.Compare(x.RegisterDate, dateTo) <= 0 && (isForiegn == null || x.Customer.IsForeign == Convert.ToBoolean(isForiegn)))
                    .Include(x => x.Customer).Include(x => x.SubCustomer).Include(x => x.User).ToListAsync();
                return orders;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<Orders> GetOrdersByNoAsync(string orderNo)
        {
            try
            {
                var orders = await _repositoryFactory.Orders.Table.AsSplitQuery()
                    .Include(x=>x.Customer)
                    .FirstOrDefaultAsync(x => x.OrderNo.Replace("/","") == orderNo);

                return orders;
            }
            catch
            {
                throw;
            }
        }

        #region Planning

        public async Task<List<Orders>> GetAllPlanningByRegisterDateAsync(string dateFrom, string dateTo, bool? isForiegn)
        {
            try
            {

                var orders = await _repositoryFactory.Orders
                    .Where(x => x.IsPlanningOrder && string.Compare(x.RegisterDate, dateFrom) >= 0 &&
                    string.Compare(x.RegisterDate, dateTo) <= 0 && (isForiegn == null || x.Customer.IsForeign == Convert.ToBoolean(isForiegn)))
                    .Include(x => x.Customer).Include(x => x.SubCustomer).Include(x => x.User).ToListAsync();
                return orders;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


        #endregion

    }
}
