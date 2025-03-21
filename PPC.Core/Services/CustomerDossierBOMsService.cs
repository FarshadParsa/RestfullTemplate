using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class CustomerDossierBOMsService : BaseService, ICustomerDossierBOMsService
    {
        IUnitOfWork _unitOfWork;
        public CustomerDossierBOMsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<CustomerDossierBOMs> GetAll()
        {
            try
            {
                var customerDossierBOMs = _repositoryFactory.CustomerDossierBOMs.Table.ToList();

                return customerDossierBOMs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CustomerDossierBOMs>> GetAllAsync()
        {
            try
            {

                var customerDossierBOMs = await _repositoryFactory.CustomerDossierBOMs.Table.ToListAsync();
                return customerDossierBOMs;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public CustomerDossierBOMs GetCustomerDossierBOMsById(int customerDossierBOMID)
        {
            try
            {
                var customerDossierBOMs = _repositoryFactory.CustomerDossierBOMs.Table
                    .Include(x=>x.BOM)
                    .Include(x=>x.CustomerDossier)
                    .FirstOrDefault(x => x.CustomerDossierBOMID == customerDossierBOMID);

                return customerDossierBOMs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<CustomerDossierBOMs> GetCustomerDossierBOMsByIdAsync(int customerDossierBOMID)
        {
            try
            {
                var customerDossierBOMs = await _repositoryFactory.CustomerDossierBOMs.Table
                    .Include(x => x.BOM)
                    .Include(x => x.CustomerDossier)
                    .FirstOrDefaultAsync(x => x.CustomerDossierBOMID == customerDossierBOMID);

                return customerDossierBOMs;
            }
            catch
            {
                throw;
            }
        }

        public int Append(CustomerDossierBOMs customerDossierBOMs)
        {
            try
            {
                var _newObject = new CustomerDossierBOMs
                {
                    CustomerDossierBOMID = customerDossierBOMs.CustomerDossierBOMID,
                    CustomerDossierID = customerDossierBOMs.CustomerDossierID,
                    BOMID = customerDossierBOMs.BOMID,
                    StartDate = customerDossierBOMs.StartDate,
                    StartTime = customerDossierBOMs.StartTime,
                    EndDate = customerDossierBOMs.EndDate,
                    EndTime = customerDossierBOMs.EndTime,
                    Ver = customerDossierBOMs.Ver,
                    SerialNumber = customerDossierBOMs.SerialNumber,
                    Describe = customerDossierBOMs.Describe,
                    IsActive = customerDossierBOMs.IsActive,


                };

                _repositoryFactory.CustomerDossierBOMs.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.CustomerDossierBOMID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(CustomerDossierBOMs customerDossierBOMs)
        {
            try
            {

                _repositoryFactory.CustomerDossierBOMs.UpdateBy(x => x.CustomerDossierBOMID == customerDossierBOMs.CustomerDossierBOMID,
                    new CustomerDossierBOMs
                    {
                        CustomerDossierBOMID = customerDossierBOMs.CustomerDossierBOMID,
                        CustomerDossierID = customerDossierBOMs.CustomerDossierID,
                        BOMID = customerDossierBOMs.BOMID,
                        StartDate = customerDossierBOMs.StartDate,
                        StartTime = customerDossierBOMs.StartTime,
                        EndDate = customerDossierBOMs.EndDate,
                        EndTime = customerDossierBOMs.EndTime,
                        Ver = customerDossierBOMs.Ver,
                        SerialNumber = customerDossierBOMs.SerialNumber,
                        Describe = customerDossierBOMs.Describe,
                        IsActive = customerDossierBOMs.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int customerDossierBOMID)
        {
            try
            {
                var customerDossierBOMs = _repositoryFactory.CustomerDossierBOMs
                    .FirstOrDefault(x => x.CustomerDossierBOMID == customerDossierBOMID);

                if (customerDossierBOMs == null)
                    throw new System.Exception("CustomerDossierBOMs Notfound.");

                _repositoryFactory.CustomerDossierBOMs.Delete(customerDossierBOMs);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CustomerDossierBOMs>> GetListByCustomerIdAsync(int customerId)
        {
            try
            {

                var bOM = await _repositoryFactory.CustomerDossierBOMs.Table
                    .Include(x => x.BOM).ThenInclude(x => x.Parent)
                    .Include(x => x.BOM).ThenInclude(x => x.Product)
                    .Include(x => x.CustomerDossier)
                    .Where(x => x.CustomerDossier.CustomerID == customerId)
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

        public async Task<List<CustomerDossierBOMs>> GetListByCustomerDossierIdAsync(int customerDossierId)
        {
            try
            {

                var bOM = await _repositoryFactory.CustomerDossierBOMs.Table
                    .Include(x => x.BOM).ThenInclude(x => x.Parent)
                    .Include(x => x.BOM).ThenInclude(x => x.Product)
                    .Include(x => x.CustomerDossier)
                    .Where(x => x.CustomerDossierID == customerDossierId)
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


        public async Task<List<CustomerDossierBOMs>> GetAllByBOMIdAsync(int bomId)
        {
            try
            {

                var customerDossierBOMs = await _repositoryFactory.CustomerDossierBOMs.Table
                    .Where(x => x.BOMID == bomId)
                    .Include(x => x.CustomerDossier).ThenInclude(x => x.Customer)
                    .Include(x => x.BOM).ThenInclude(x => x.Parent)
                    .Include(x => x.BOM).ThenInclude(x => x.Product)
                    .ToListAsync();
                return customerDossierBOMs;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public bool SetActive(int customerDossierBOMId, bool isActive)
        {
            try
            {

                var instance = GetCustomerDossierBOMsById(customerDossierBOMId);
                var statuse = false;
                if (instance != null)
                {
                    instance.IsActive = isActive;
                    _repositoryFactory.CustomerDossierBOMs.Update(instance);
                    statuse = _unitOfWork.Commit() > 0;
                }

                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


    }
}
