using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class SuppliersService : BaseService, ISuppliersService
    {
        IUnitOfWork _unitOfWork;
        public SuppliersService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<Suppliers> GetAll()
        {
            try
            {
                var suppliers = _repositoryFactory.Suppliers.Table.Include(x=>x.Province).ThenInclude(x=>x.Countries).ToList();

                return suppliers;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Suppliers>> GetAllAsync()
        {
            try
            {

                var suppliers = await _repositoryFactory.Suppliers.Table.Include(x => x.Province).ThenInclude(x => x.Countries).ToListAsync();
                return suppliers;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public Suppliers GetSuppliersById(short supplierID)
        {
            try
            {
                var suppliers = _repositoryFactory.Suppliers.Table.Include(x => x.Province).ThenInclude(x => x.Countries)
                    .FirstOrDefault(x => x.SupplierID == supplierID);

                return suppliers;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Suppliers> GetSuppliersByIdAsync(short supplierID)
        {
            try
            {
                var suppliers = await _repositoryFactory.Suppliers.Table.Include(x => x.Province).ThenInclude(x => x.Countries)
                    .FirstOrDefaultAsync(x => x.SupplierID == supplierID);

                return suppliers;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(Suppliers suppliers)
        {
            try
            {
                _repositoryFactory.Suppliers.Add(
                    new Suppliers
                    {
                        SupplierID = suppliers.SupplierID,
                        SupplierCode = suppliers.SupplierCode,
                        SupplierName = suppliers.SupplierName,
                        SupplierLatinName = suppliers.SupplierLatinName,
                        SupplierOriginName = suppliers.SupplierOriginName,
                        ContactPerson = suppliers.ContactPerson,
                        ProvinceID = suppliers.ProvinceID,
                        Tel = suppliers.Tel,
                        Address = suppliers.Address,
                        ZipCode = suppliers.ZipCode,
                        NationalIdentity = suppliers.NationalIdentity,
                        RegistrationNumber = suppliers.RegistrationNumber,
                        EconomicCode = suppliers.EconomicCode,
                        Rating = suppliers.Rating,
                        CustomerGradeID = suppliers.CustomerGradeID,
                        StartDate = suppliers.StartDate,
                        CEO = suppliers.CEO,
                        InsUserID = suppliers.InsUserID,
                        InsDate = suppliers.InsDate,
                        InsTime = suppliers.InsTime,
                        EditUserID = suppliers.EditUserID,
                        EditDate = suppliers.EditDate,
                        EditTime = suppliers.EditTime,
                        IsForeign = suppliers.IsForeign,
                        IsActive = suppliers.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(Suppliers suppliers)
        {
            try
            {

                _repositoryFactory.Suppliers.UpdateBy(x => x.SupplierID == suppliers.SupplierID,
                    new Suppliers
                    {
                        SupplierID = suppliers.SupplierID,
                        SupplierCode = suppliers.SupplierCode,
                        SupplierName = suppliers.SupplierName,
                        SupplierLatinName = suppliers.SupplierLatinName,
                        SupplierOriginName = suppliers.SupplierOriginName,
                        ContactPerson = suppliers.ContactPerson,
                        ProvinceID = suppliers.ProvinceID,
                        Tel = suppliers.Tel,
                        Address = suppliers.Address,
                        ZipCode = suppliers.ZipCode,
                        NationalIdentity = suppliers.NationalIdentity,
                        RegistrationNumber = suppliers.RegistrationNumber,
                        EconomicCode = suppliers.EconomicCode,
                        Rating = suppliers.Rating,
                        CustomerGradeID = suppliers.CustomerGradeID,
                        StartDate = suppliers.StartDate,
                        CEO = suppliers.CEO,
                        InsUserID = suppliers.InsUserID,
                        InsDate = suppliers.InsDate,
                        InsTime = suppliers.InsTime,
                        EditUserID = suppliers.EditUserID,
                        EditDate = suppliers.EditDate,
                        EditTime = suppliers.EditTime,
                        IsForeign = suppliers.IsForeign,
                        IsActive = suppliers.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(short supplierID)
        {
            try
            {
                var suppliers = _repositoryFactory.Suppliers
                    .FirstOrDefault(x => x.SupplierID == supplierID);

                if (suppliers == null)
                    throw new System.Exception("Suppliers Notfound.");

                _repositoryFactory.Suppliers.Delete(suppliers);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistSuppliersAsync(string name)
        {
            try
            {

                return await _repositoryFactory.Suppliers.FirstOrDefaultAsync(x => x.SupplierName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }


    }
}
