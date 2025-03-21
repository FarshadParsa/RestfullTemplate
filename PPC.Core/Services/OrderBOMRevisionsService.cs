using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Extensions;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class OrderBOMRevisionsService : BaseService, IOrderBOMRevisionsService
    {
        //IUnitOfWork _unitOfWork;
        public OrderBOMRevisionsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<OrderBOMRevisions> GetAll()
        {
            try
            {
                var orderBOMRevisions = _repositoryFactory.OrderBOMRevisions.Table.ToList();

                return orderBOMRevisions;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<OrderBOMRevisions>> GetAllAsync()
        {
            try
            {

                var orderBOMRevisions = await _repositoryFactory.OrderBOMRevisions.Table.ToListAsync();
                return orderBOMRevisions;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public OrderBOMRevisions GetOrderBOMRevisionsById(int orderBOMRevisionID)
        {
            try
            {
                var orderBOMRevisions = _repositoryFactory.OrderBOMRevisions
                    .FirstOrDefault(x => x.OrderBOMReviseID == orderBOMRevisionID);

                return orderBOMRevisions;
            }
            catch
            {
                throw;
            }
        }

        public async Task<OrderBOMRevisions> GetOrderBOMRevisionsByIdAsync(int orderBOMRevisionID)
        {
            try
            {
                var orderBOMRevisions = await _repositoryFactory.OrderBOMRevisions.Table
                    .Include(x=>x.OrderDetail).ThenInclude(x=>x.BOM).ThenInclude(x=>x.CustomerDossierList)
                    .Include(x=>x.OrderDetail).ThenInclude(x=>x.BOM).ThenInclude(x=>x.Product)
                    .Include(x=>x.OrderDetail).ThenInclude(x=>x.Order).ThenInclude(x=>x.Customer)
                    //.Include(x=>x.).ThenInclude(x=>x.)
                    //.Include(x=>x.).ThenInclude(x=>x.)
                    .FirstOrDefaultAsync(x => x.OrderBOMReviseID == orderBOMRevisionID);

                return orderBOMRevisions;
            }
            catch
            {
                throw;
            }
        }

        public int Append(OrderBOMRevisions orderBOMRevisions)
        {
            using (var t = _unitOfWork.StartTransaction())
            {


                try
                {
                    var orderDetail = _repositoryFactory.OrderDetails.Table.First(x => x.OrderDetailID == orderBOMRevisions.OrderDetailID);
                    orderDetail.BOMID = orderBOMRevisions.NewBOMID;

                    var _newObject = new OrderBOMRevisions
                    {
                        OrderBOMReviseID = orderBOMRevisions.OrderBOMReviseID,
                        OrderDetailID = orderBOMRevisions.OrderDetailID,
                        OldBOMID = orderBOMRevisions.OldBOMID,
                        NewBOMID = orderBOMRevisions.NewBOMID,
                        Describe = orderBOMRevisions.Describe,
                        InsUserID = orderBOMRevisions.InsUserID,
                        InsDate = orderBOMRevisions.InsDate,
                        InsTime = orderBOMRevisions.InsTime,
                        EditUserID = orderBOMRevisions.EditUserID,
                        EditDate = orderBOMRevisions.EditDate,
                        EditTime = orderBOMRevisions.EditTime,
                        RowVer = orderBOMRevisions.RowVer,
                    };

                    _repositoryFactory.OrderBOMRevisions.Add(_newObject);

                    var statuse = _unitOfWork.Commit() > 0;

                    t.Commit();

                    if (statuse)
                        return _newObject.OrderBOMReviseID;
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


        public bool Update(OrderBOMRevisions orderBOMRevisions)
        {
            try
            {

                _repositoryFactory.OrderBOMRevisions.UpdateBy(x => x.OrderBOMReviseID == orderBOMRevisions.OrderBOMReviseID,
                    new OrderBOMRevisions
                    {
                        OrderBOMReviseID = orderBOMRevisions.OrderBOMReviseID,
                        OrderDetailID = orderBOMRevisions.OrderDetailID,
                        OldBOMID = orderBOMRevisions.OldBOMID,
                        NewBOMID = orderBOMRevisions.NewBOMID,
                        Describe = orderBOMRevisions.Describe,
                        InsUserID = orderBOMRevisions.InsUserID,
                        InsDate = orderBOMRevisions.InsDate,
                        InsTime = orderBOMRevisions.InsTime,
                        EditUserID = orderBOMRevisions.EditUserID,
                        EditDate = orderBOMRevisions.EditDate,
                        EditTime = orderBOMRevisions.EditTime,
                        RowVer = orderBOMRevisions.RowVer,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int orderBOMRevisionID)
        {
            using (var t = _unitOfWork.StartTransaction())
            {


                try
                {
                    var orderBOMRevisions = _repositoryFactory.OrderBOMRevisions
                    .FirstOrDefault(x => x.OrderBOMReviseID == orderBOMRevisionID);

                    if (orderBOMRevisions == null)
                        throw new System.Exception("OrderBOMRevisions Notfound.");

                    var orderDetail = _repositoryFactory.OrderDetails.Table.First(x => x.OrderDetailID == orderBOMRevisions.OrderDetailID);
                    orderDetail.BOMID = orderBOMRevisions.OldBOMID;

                    _repositoryFactory.OrderBOMRevisions.Delete(orderBOMRevisions);

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

        public async Task<List<OrderBOMRevisions>> GetArchiveAsync(string startDate, string endDate)
        {
            try
            {

                var orderBOMRevisions = await _repositoryFactory.OrderBOMRevisions.Table
                    //.Where(x=> string.Compare(x.InsDate,startDate)>=0 && string.Compare(x.EditDate, endDate)<=0)
                    .Include(x=>x.OrderDetail).ThenInclude(x=>x.Order).ThenInclude(x=>x.Customer)
                    .Include(x => x.OrderDetail).ThenInclude(x => x.BOM).ThenInclude(x => x.CustomerDossierList)
                    .Include(x => x.OrderDetail).ThenInclude(x => x.Product)
                    .Include(x=>x.BOM_OldBOM)
                    .Include(x=>x.BOM_NewBOM)
                    .Include(x=>x.User_InsUser)
                    .Include(x=>x.User_EditUser)
                    .ToListAsync();
                return orderBOMRevisions;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


    }
}
