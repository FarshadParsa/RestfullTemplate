using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class CustomerGradesService : BaseService, ICustomerGradesService
    {
        IUnitOfWork _unitOfWork;
        public CustomerGradesService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<CustomerGrades> GetAll()
        {
            try
            {
                var customerGrades = _repositoryFactory.CustomerGrades.Table.ToList();

                return customerGrades;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CustomerGrades>> GetAllAsync()
        {
            try
            {

                var customerGrades = await _repositoryFactory.CustomerGrades.Table.ToListAsync();
                return customerGrades;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public CustomerGrades GetCustomerGradesById(byte customerGradeID)
        {
            try
            {
                var customerGrades = _repositoryFactory.CustomerGrades
                    .FirstOrDefault(x => x.CustomerGradeID == customerGradeID);

                return customerGrades;
            }
            catch
            {
                throw;
            }
        }

        public async Task<CustomerGrades> GetCustomerGradesByIdAsync(byte customerGradeID)
        {
            try
            {
                var customerGrades = await _repositoryFactory.CustomerGrades
                    .FirstOrDefaultAsync(x => x.CustomerGradeID == customerGradeID);

                return customerGrades;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(CustomerGrades customerGrades)
        {
            try
            {
                _repositoryFactory.CustomerGrades.Add(
                    new CustomerGrades
                    {
                        CustomerGradeName = customerGrades.CustomerGradeName,
                        IsActive = customerGrades.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(CustomerGrades customerGrades)
        {
            try
            {

                _repositoryFactory.CustomerGrades.UpdateBy(x => x.CustomerGradeID == customerGrades.CustomerGradeID,
                    new CustomerGrades
                    {
                        CustomerGradeName = customerGrades.CustomerGradeName,
                        IsActive = customerGrades.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(byte customerGradeID)
        {
            try
            {
                var customerGrades = _repositoryFactory.CustomerGrades
                    .FirstOrDefault(x => x.CustomerGradeID == customerGradeID);

                if (customerGrades == null)
                    throw new System.Exception("CustomerGrades Notfound.");

                _repositoryFactory.CustomerGrades.Delete(customerGrades);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistCustomerGradesAsync(string name)
        {
            try
            {

                return await _repositoryFactory.CustomerGrades.FirstOrDefaultAsync(x => x.CustomerGradeName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }

    }
}
