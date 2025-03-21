using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class OrderDetailPackagingsService : BaseService, IOrderDetailPackagingsService
    {
        IUnitOfWork _unitOfWork;
        public OrderDetailPackagingsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<OrderDetailPackagings> GetAll()
        {
            try
            {
                var orderDetailPackagings = _repositoryFactory.OrderDetailPackagings.Table.ToList();

                return orderDetailPackagings;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<OrderDetailPackagings>> GetAllAsync()
        {
            try
            {

                var orderDetailPackagings = await _repositoryFactory.OrderDetailPackagings.Table.ToListAsync();
                return orderDetailPackagings;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public OrderDetailPackagings GetOrderDetailPackagingsById(int orderDetailPackagingID)
        {
            try
            {
                var orderDetailPackagings = _repositoryFactory.OrderDetailPackagings
                    .FirstOrDefault(x => x.OrderDetailPackagingID == orderDetailPackagingID);

                return orderDetailPackagings;
            }
            catch
            {
                throw;
            }
        }

        public async Task<OrderDetailPackagings> GetOrderDetailPackagingsByIdAsync(int orderDetailPackagingID)
        {
            try
            {
                var orderDetailPackagings = await _repositoryFactory.OrderDetailPackagings
                    .FirstOrDefaultAsync(x => x.OrderDetailPackagingID == orderDetailPackagingID);

                return orderDetailPackagings;
            }
            catch
            {
                throw;
            }
        }

        public int Append(OrderDetailPackagings orderDetailPackagings)
        {
            try
            {
                var _newObject = new OrderDetailPackagings
                {
                    OrderDetailPackagingID = orderDetailPackagings.OrderDetailPackagingID,
                    OrderDetailID = orderDetailPackagings.OrderDetailID,
                    PackagingPlanID = orderDetailPackagings.PackagingPlanID,
                    Priority = orderDetailPackagings.Priority,


                };

                _repositoryFactory.OrderDetailPackagings.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.OrderDetailPackagingID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(OrderDetailPackagings orderDetailPackagings)
        {
            try
            {

                _repositoryFactory.OrderDetailPackagings.UpdateBy(x => x.OrderDetailPackagingID == orderDetailPackagings.OrderDetailPackagingID,
                    new OrderDetailPackagings
                    {
                        OrderDetailPackagingID = orderDetailPackagings.OrderDetailPackagingID,
                        OrderDetailID = orderDetailPackagings.OrderDetailID,
                        PackagingPlanID = orderDetailPackagings.PackagingPlanID,
                        Priority = orderDetailPackagings.Priority,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int orderDetailPackagingID)
        {
            try
            {
                var orderDetailPackagings = _repositoryFactory.OrderDetailPackagings
                    .FirstOrDefault(x => x.OrderDetailPackagingID == orderDetailPackagingID);

                if (orderDetailPackagings == null)
                    throw new System.Exception("OrderDetailPackagings Notfound.");

                _repositoryFactory.OrderDetailPackagings.Delete(orderDetailPackagings);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


    }
}
