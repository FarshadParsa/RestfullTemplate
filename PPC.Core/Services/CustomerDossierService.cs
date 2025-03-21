using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class CustomerDossierService : BaseService, ICustomerDossierService
    {
        IUnitOfWork _unitOfWork;
        public CustomerDossierService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<CustomerDossier> GetAll()
        {
            try
            {
                var customerDossier = _repositoryFactory.CustomerDossier.Table.ToList();

                return customerDossier;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CustomerDossier>> GetAllAsync()
        {
            try
            {

                var customerDossier = await _repositoryFactory.CustomerDossier.Table
                    .Include(x => x.Product)
                    .Include(x => x.Customer)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    .Include(x => x.DefaultBOM)
                    .Include(x => x.RefDossier)
                    .ToListAsync();
                return customerDossier;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public CustomerDossier GetCustomerDossierById(int customerDossierID)
        {
            try
            {
                var customerDossier = _repositoryFactory.CustomerDossier
                    .FirstOrDefault(x => x.CustomerDossierID == customerDossierID);

                return customerDossier;
            }
            catch
            {
                throw;
            }
        }

        public async Task<CustomerDossier> GetCustomerDossierByIdAsync(int customerDossierID)
        {
            try
            {
                var customerDossier = await _repositoryFactory.CustomerDossier.Table
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)

                    .FirstOrDefaultAsync(x => x.CustomerDossierID == customerDossierID);

                return customerDossier;
            }
            catch
            {
                throw;
            }
        }

        public int Append(CustomerDossier customerDossier)
        {
            using (var t = _unitOfWork.StartTransaction())
            {

                try
                {
                    var _newObject = new CustomerDossier
                    {
                        CustomerDossierID = customerDossier.CustomerDossierID,
                        DossierNo = customerDossier.DossierNo,
                        RefDossierID = customerDossier.RefDossierID,
                        CustomerID = customerDossier.CustomerID,
                        ProductID = customerDossier.ProductID,
                        DefaultBOMID = customerDossier.DefaultBOMID,
                        IsActive = customerDossier.IsActive,
                        IsDraft = customerDossier.IsDraft,
                        TestPlanAssignID = customerDossier.TestPlanAssignID,
                        InsUserID = customerDossier.InsUserID,
                        InsDate = customerDossier.InsDate,
                        InsTime = customerDossier.InsTime,
                        EditUserID = customerDossier.EditUserID,
                        EditDate = customerDossier.EditDate,
                        EditTime = customerDossier.EditTime,
                        Describe = customerDossier.Describe,
                        Status = customerDossier.Status,
                    };

                    _repositoryFactory.CustomerDossier.Add(_newObject);
                    var statuse = _unitOfWork.Commit() > 0;

                    #region Append CustomerDossierBOMs

                    customerDossier.CustomerDossierBOMList.ForEach(x =>
                    _repositoryFactory.CustomerDossierBOMs.Add(
                        new CustomerDossierBOMs
                        {
                            CustomerDossierID = _newObject.CustomerDossierID,
                            BOMID = x.BOMID,
                            StartDate = x.StartDate,
                            EndDate = x.EndDate,
                            StartTime = x.StartTime,
                            EndTime = x.EndTime,
                            Ver = x.Ver,
                            SerialNumber = x.SerialNumber,
                            Describe = x.Describe,
                            IsActive = x.IsActive,
                        }));

                    statuse &= _unitOfWork.Commit() > 0;

                    #endregion

                    t.Commit();

                    if (statuse)
                        return _newObject.CustomerDossierID;
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


        public bool Update(CustomerDossier customerDossier)
        {
            using (var t = _unitOfWork.StartTransaction())
            {
                try
                {

                    _repositoryFactory.CustomerDossier.UpdateBy(x => x.CustomerDossierID == customerDossier.CustomerDossierID,
                        new CustomerDossier
                        {
                            CustomerDossierID = customerDossier.CustomerDossierID,
                            DossierNo = customerDossier.DossierNo,
                            RefDossierID = customerDossier.RefDossierID,
                            CustomerID = customerDossier.CustomerID,
                            ProductID = customerDossier.ProductID,
                            DefaultBOMID = customerDossier.DefaultBOMID,
                            IsActive = customerDossier.IsActive,
                            IsDraft = customerDossier.IsDraft,
                            TestPlanAssignID = customerDossier.TestPlanAssignID,
                            InsUserID = customerDossier.InsUserID,
                            InsDate = customerDossier.InsDate,
                            InsTime = customerDossier.InsTime,
                            EditUserID = customerDossier.EditUserID,
                            EditDate = customerDossier.EditDate,
                            EditTime = customerDossier.EditTime,
                            Describe = customerDossier.Describe,
                            Status = customerDossier.Status,


                        });
                    var statuse = _unitOfWork.Commit() > 0;

                    #region Append CustomerDossierBOMs

                    customerDossier.CustomerDossierBOMList?.ForEach(x =>
                    _repositoryFactory.CustomerDossierBOMs.Add(
                        new CustomerDossierBOMs
                        {
                            CustomerDossierID = customerDossier.CustomerDossierID,
                            BOMID = x.BOMID,
                            StartDate = x.StartDate,
                            EndDate = x.EndDate,
                            StartTime = x.StartTime,
                            EndTime = x.EndTime,
                            Ver = x.Ver,
                            SerialNumber = x.SerialNumber,
                            Describe = x.Describe,
                            IsActive = x.IsActive,
                        }));

                    statuse &= _unitOfWork.Commit() > 0;

                    #endregion


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

        public long Delete(int customerDossierID)
        {
            try
            {
                var customerDossier = _repositoryFactory.CustomerDossier
                    .FirstOrDefault(x => x.CustomerDossierID == customerDossierID);

                if (customerDossier == null)
                    throw new System.Exception("CustomerDossier Notfound.");

                _repositoryFactory.CustomerDossier.Delete(customerDossier);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<CustomerDossier> GetByDossierNoAsync(int dossierNo)
        {
            try
            {

                return await _repositoryFactory.CustomerDossier.FirstOrDefaultAsync(x => x.DossierNo == dossierNo);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CustomerDossier>> GetListByCustomerIdAsync(int customerId)
        {
            try
            {

                var customerDossier = await _repositoryFactory.CustomerDossier
                    .Where(x => x.CustomerID == customerId)
                    .Include(x => x.Product)
                    .Include(x => x.Customer)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    .Include(x => x.DefaultBOM)
                    .Include(x => x.RefDossier)
                    .ToListAsync();
                return customerDossier;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<CustomerDossier>> GetListByProductIdAsync(int productId)
        {
            try
            {

                var customerDossier = await _repositoryFactory.CustomerDossier                    
                    .Where(x => x.ProductID == productId)
                    .Include(x => x.Product)
                    .Include(x => x.Customer)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    .Include(x => x.DefaultBOM)
                    .Include(x => x.RefDossier)
                    .ToListAsync();
                return customerDossier;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<CustomerDossier>> GetListByCustomerIdProductIdAsync(int customerId, int productId)
        {
            try
            {

                var customerDossier = await _repositoryFactory.CustomerDossier
                    .Where(x => x.CustomerID == customerId && x.ProductID == productId)
                    .Include(x => x.Product)
                    .Include(x => x.Customer)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    .Include(x => x.DefaultBOM)
                    .Include(x => x.RefDossier)
                    .ToListAsync();
                return customerDossier;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<CustomerDossier> GetInstanceByMaxDossierNoAsync()
        {
            try
            {

                var customerDossier = await _repositoryFactory.CustomerDossier.Table
                    .Include(x => x.Product)
                    .Include(x => x.Customer)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    .Include(x => x.DefaultBOM)
                    .Include(x => x.RefDossier)
                    .OrderByDescending(x => x.DossierNo).FirstOrDefaultAsync();

                return customerDossier;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }



    }
}
