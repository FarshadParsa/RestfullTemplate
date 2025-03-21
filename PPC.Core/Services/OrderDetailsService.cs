using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class OrderDetailsService : BaseService, IOrderDetailsService
    {
        IUnitOfWork _unitOfWork;
        public OrderDetailsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<OrderDetails> GetAll()
        {
            try
            {
                var orderDetails = _repositoryFactory.OrderDetails.Table
                    .Include(x => x.Order)
                    .ToList();

                return orderDetails;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<OrderDetails>> GetAllAsync()
        {
            try
            {

                var orderDetails = await _repositoryFactory.OrderDetails.Table
                    .Include(x => x.Order)
                    .ToListAsync();
                return orderDetails;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public OrderDetails GetOrderDetailsById(int orderDetailID)
        {
            try
            {
                var orderDetails = _repositoryFactory.OrderDetails.Table
                    .Include(x => x.Order).ThenInclude(x => x.Customer)
                    .Include(x => x.Product).ThenInclude(x => x.ProductSerie).ThenInclude(x => x.ProductType).ThenInclude(x => x.ProductGroup)
                    .Include(x => x.BOM)
                    .FirstOrDefault(x => x.OrderDetailID == orderDetailID);

                return orderDetails;
            }
            catch
            {
                throw;
            }
        }

        public async Task<OrderDetails> GetOrderDetailsByIdAsync(int orderDetailID)
        {
            try
            {
                var orderDetails = await _repositoryFactory.OrderDetails.Table
                    .Include(x => x.Order).ThenInclude(x => x.Customer)
                    .Include(x => x.Product).ThenInclude(x => x.ProductSerie).ThenInclude(x => x.ProductType).ThenInclude(x => x.ProductGroup)
                    .Include(x => x.BOM).ThenInclude(x=>x.CustomerDossierBOMList).ThenInclude(x=>x.CustomerDossier)
                    .Include(x => x.BOM).ThenInclude(x=>x.Product)
                    .Include(x => x.PackagingPlan)
                    .FirstOrDefaultAsync(x => x.OrderDetailID == orderDetailID);

                return orderDetails;
            }
            catch
            {
                throw;
            }
        }

        public int Append(OrderDetails orderDetails)
        {
            try
            {
                var _newObject = new OrderDetails
                {
                    OrderDetailID = orderDetails.OrderDetailID,
                    OrderID = orderDetails.OrderID,
                    ProductID = orderDetails.ProductID,
                    Quantity = orderDetails.Quantity,
                    ProgrammedQuantity = orderDetails.ProgrammedQuantity,
                    Status = orderDetails.Status,
                    ProducedNo = orderDetails.ProducedNo,
                    DeliveredNo = orderDetails.DeliveredNo,
                    ProducedWeight = orderDetails.ProducedWeight,
                    DeliveredWeight = orderDetails.DeliveredWeight,
                    InPlan = orderDetails.InPlan,
                    PackagingPlanID = orderDetails.PackagingPlanID,
                    Priority = orderDetails.Priority,
                    Remark = orderDetails.Remark,
                    DeliverDate = orderDetails.DeliverDate,
                    OrderRequestDetailID = orderDetails.OrderRequestDetailID,
                    PlannedRemain = orderDetails.PlannedRemain,
                    WarehouseAmount = orderDetails.WarehouseAmount,
                    ConfirmUserID = orderDetails.ConfirmUserID,
                    Radif = orderDetails.Radif,


                };

                _repositoryFactory.OrderDetails.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.OrderDetailID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(OrderDetails orderDetails)
        {
            try
            {

                _repositoryFactory.OrderDetails.UpdateBy(x => x.OrderDetailID == orderDetails.OrderDetailID,
                    new OrderDetails
                    {
                        OrderDetailID = orderDetails.OrderDetailID,
                        OrderID = orderDetails.OrderID,
                        ProductID = orderDetails.ProductID,
                        Quantity = orderDetails.Quantity,
                        ProgrammedQuantity = orderDetails.ProgrammedQuantity,
                        Status = orderDetails.Status,
                        ProducedNo = orderDetails.ProducedNo,
                        DeliveredNo = orderDetails.DeliveredNo,
                        ProducedWeight = orderDetails.ProducedWeight,
                        DeliveredWeight = orderDetails.DeliveredWeight,
                        InPlan = orderDetails.InPlan,
                        PackagingPlanID = orderDetails.PackagingPlanID,
                        Priority = orderDetails.Priority,
                        Remark = orderDetails.Remark,
                        DeliverDate = orderDetails.DeliverDate,
                        OrderRequestDetailID = orderDetails.OrderRequestDetailID,
                        PlannedRemain = orderDetails.PlannedRemain,
                        WarehouseAmount = orderDetails.WarehouseAmount,
                        ConfirmUserID = orderDetails.ConfirmUserID,
                        Radif = orderDetails.Radif,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int orderDetailID)
        {
            try
            {
                var orderDetails = _repositoryFactory.OrderDetails
                    .FirstOrDefault(x => x.OrderDetailID == orderDetailID);

                if (orderDetails == null)
                    throw new System.Exception("OrderDetails Notfound.");

                _repositoryFactory.OrderDetails.Delete(orderDetails);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistOrderDetailsAsync(int id)
        {
            try
            {

                return await _repositoryFactory.OrderDetails.FirstOrDefaultAsync(x => x.OrderDetailID == id) != null;
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<OrderDetails>> GetAllByOrderIdAsync(int orderId)
        {
            try
            {
                var orderDetails = await _repositoryFactory.OrderDetails.Where(x => x.OrderID == orderId)
                    .Include(x => x.Product)
                    .Include(x => x.PackagingPlan)
                    .Include(x => x.OrderDetailPackagingList)
                    .ToListAsync();

                ////var db = _repositoryFactory;
                ////var packagingPlans = (from orderDetailPackagings in db.OrderDetailPackagings.Table
                ////                      //join orderDetails in db.OrderDetails.Table on orderDetailPackagings.OrderDetailID equals orderDetails.OrderDetailID
                ////                      where orderDetails.Select(x=>x.OrderDetailID).Contains(orderDetailPackagings.OrderDetailID)
                ////                     );


                //var orderDetailPackaging = _repositoryFactory.OrderDetailPackagings
                //    .Where(x => orderDetails.Select(x => x.OrderDetailID).Contains(x.OrderDetailID)).ToList();

                //orderDetails.ForEach(x =>
                //{
                //    x.PackagingPlanIdList = orderDetailPackaging
                //    .Where(o => o.OrderDetailID == x.OrderDetailID)
                //    .ToDictionary(x => x.PackagingPlanID, x => x.Priority);
                //});


                return orderDetails;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<OrderDetails>> GetDropdownList()
        {
            try
            {

                var orderDetails = await _repositoryFactory.OrderDetails.Table
                    .Include(x => x.Order).ThenInclude(x => x.Customer)
                    .Include(x => x.Product)
                    .ToListAsync();
                return orderDetails;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<OrderDetails>> GetPlannedListAsync(string dateFrom, string dateTo, List<byte> orderStatus = null)
        {
            try
            {

                var orders = await _repositoryFactory.ProductionPlans.Table
                    .Include(x => x.OrderDetail).ThenInclude(x => x.Order).ThenInclude(x => x.Customer)
                    .Include(x => x.OrderDetail).ThenInclude(x => x.Product)
                    .Where(x => string.Compare(x.StartDate, dateFrom) >= 0 &&
                    string.Compare(x.EndDate, dateTo) <= 0 && (orderStatus == null ? true : orderStatus.Contains(x.OrderDetail.Order.Status)))
                    .Select(x => x.OrderDetail).ToListAsync();
                return orders;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<OrderDetails>> GetListToAssignBOMAsync(string dateFrom, string dateTo)
        {
            try
            {

                var orders = await _repositoryFactory.OrderDetails.Table
                    .Include(x => x.Order).ThenInclude(x => x.Customer)
                    .Include(x => x.Order).ThenInclude(x => x.User_InsUser)
                    .Include(x => x.Order).ThenInclude(x => x.User_EditUser)
                    .Include(x => x.Product)
                    .Include(x => x.BOM)
                    //.Include(x => x.OrderBOMRevisions.OrderBy(x=>x.OrderBOMReviseID).LastOrDefault())
                    .Include(x => x.OrderBOMRevisions).ThenInclude(x=>x.BOM_OldBOM)
                    .Include(x => x.OrderBOMRevisions).ThenInclude(x=>x.BOM_NewBOM)
                    .Where(x => x.BOM == null || 
                    (string.Compare(x.Order.InsDate, dateFrom) >= 0 && string.Compare(x.Order.InsDate, dateTo) <= 0))
                    .ToListAsync();
                return orders;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


        public async Task<List<OrderDetails>> GetForSearchByProductId(int productId)
        {
            try
            {
                var orderDetails = await _repositoryFactory.OrderDetails
                    .Where(x=>x.ProductID== productId)
                    .Include(x => x.Order).ThenInclude(x=>x.Customer)
                    .Include(x=>x.Product)

                    .ToListAsync();
                return orderDetails;
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
    public class OrderDetailsService : BaseService, IOrderDetailsService
    {
        IUnitOfWork _unitOfWork;
        public OrderDetailsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<OrderDetails> GetAll()
        {
            try
            {
                var orderDetails = _repositoryFactory.OrderDetails.Table.ToList();

                return orderDetails;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<OrderDetails>> GetAllAsync()
        {
            try
            {

                var orderDetails = await _repositoryFactory.OrderDetails.Table.ToListAsync();
                return orderDetails;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public OrderDetails GetOrderDetailsById(int orderDetailID)
        {
            try
            {
                var orderDetails = _repositoryFactory.OrderDetails
                    .FirstOrDefault(x => x.OrderDetailID == orderDetailID);

                return orderDetails;
            }
            catch
            {
                throw;
            }
        }

        public async Task<OrderDetails> GetOrderDetailsByIdAsync(int orderDetailID)
        {
            try
            {
                var orderDetails = await _repositoryFactory.OrderDetails
                    .FirstOrDefaultAsync(x => x.OrderDetailID == orderDetailID);

                return orderDetails;
            }
            catch
            {
                throw;
            }
        }

        public int Append(OrderDetails orderDetails)
        {
            try
            {
                var _newObject = new OrderDetails
                {
                    OrderDetailID = orderDetails.OrderDetailID,
                    OrderID = orderDetails.OrderID,
                    ProductID = orderDetails.ProductID,
                    Thickness = orderDetails.Thickness,
                    InnerDiameter = orderDetails.InnerDiameter,
                    OuterDiameter = orderDetails.OuterDiameter,
                    Width = orderDetails.Width,
                    Quantity = orderDetails.Quantity,
                    ProgrammedQuantity = orderDetails.ProgrammedQuantity,
                    Length = orderDetails.Length,
                    WeightPerRoll = orderDetails.WeightPerRoll,
                    NoOfRolls = orderDetails.NoOfRolls,
                    PalletType = orderDetails.PalletType,
                    Status = orderDetails.Status,
                    ProducedNo = orderDetails.ProducedNo,
                    DeliveredNo = orderDetails.DeliveredNo,
                    ProducedWeight = orderDetails.ProducedWeight,
                    DeliveredWeight = orderDetails.DeliveredWeight,
                    InPlan = orderDetails.InPlan,
                    PackagingPlanID = orderDetails.PackagingPlanID,
                    Periority = orderDetails.Periority,
                    Remark = orderDetails.Remark,
                    UnitPrice = orderDetails.UnitPrice,
                    DeliverDate = orderDetails.DeliverDate,
                    OrderRequestDetailID = orderDetails.OrderRequestDetailID,
                    PlannedRemain = orderDetails.PlannedRemain,
                    WarehouseAmount = orderDetails.WarehouseAmount,
                    ConfirmUserID = orderDetails.ConfirmUserID,


                };

                _repositoryFactory.OrderDetails.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.OrderDetailID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(OrderDetails orderDetails)
        {
            try
            {

                _repositoryFactory.OrderDetails.UpdateBy(x => x.OrderDetailID == orderDetails.OrderDetailID,
                    new OrderDetails
                    {
                        OrderDetailID = orderDetails.OrderDetailID,
                        OrderID = orderDetails.OrderID,
                        ProductID = orderDetails.ProductID,
                        Thickness = orderDetails.Thickness,
                        InnerDiameter = orderDetails.InnerDiameter,
                        OuterDiameter = orderDetails.OuterDiameter,
                        Width = orderDetails.Width,
                        Quantity = orderDetails.Quantity,
                        ProgrammedQuantity = orderDetails.ProgrammedQuantity,
                        Length = orderDetails.Length,
                        WeightPerRoll = orderDetails.WeightPerRoll,
                        NoOfRolls = orderDetails.NoOfRolls,
                        PalletType = orderDetails.PalletType,
                        Status = orderDetails.Status,
                        ProducedNo = orderDetails.ProducedNo,
                        DeliveredNo = orderDetails.DeliveredNo,
                        ProducedWeight = orderDetails.ProducedWeight,
                        DeliveredWeight = orderDetails.DeliveredWeight,
                        InPlan = orderDetails.InPlan,
                        PackagingPlanID = orderDetails.PackagingPlanID,
                        Periority = orderDetails.Periority,
                        Remark = orderDetails.Remark,
                        UnitPrice = orderDetails.UnitPrice,
                        DeliverDate = orderDetails.DeliverDate,
                        OrderRequestDetailID = orderDetails.OrderRequestDetailID,
                        PlannedRemain = orderDetails.PlannedRemain,
                        WarehouseAmount = orderDetails.WarehouseAmount,
                        ConfirmUserID = orderDetails.ConfirmUserID,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int orderDetailID)
        {
            try
            {
                var orderDetails = _repositoryFactory.OrderDetails
                    .FirstOrDefault(x => x.OrderDetailID == orderDetailID);

                if (orderDetails == null)
                    throw new System.Exception("OrderDetails Notfound.");

                _repositoryFactory.OrderDetails.Delete(orderDetails);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistOrderDetailsAsync(int id)
        {
            try
            {

                return await _repositoryFactory.OrderDetails.FirstOrDefaultAsync(x => x.OrderDetailID== id) != null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<OrderDetails>> GetAllByOrderIdAsync(int orderId)
        {
            try
            {
                var orderDetails = await _repositoryFactory.OrderDetails.Where(x=>x.OrderID == orderId)//.Include(x=> x.Product).Include(x=>x.PackagingPlan)
                    .ToListAsync();
                return orderDetails;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }



    }
}
*/