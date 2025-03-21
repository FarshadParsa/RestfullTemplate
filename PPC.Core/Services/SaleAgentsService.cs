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
    public class SaleAgentsService : BaseService, ISaleAgentsService
    {
        IUnitOfWork _unitOfWork;
        public SaleAgentsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<SaleAgents> GetAll()
        {
            try
            {
                var saleAgents = _repositoryFactory.SaleAgents.Table
                    .Include(x => x.Province)
                    .Include(x => x.CustomerGrade).ToList();

                return saleAgents;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<SaleAgents>> GetAllAsync()
        {
            try
            {

                
                var saleAgents = _repositoryFactory.SaleAgents.Table
                    .Include(x => x.Province)
                    .Include(x => x.CustomerGrade)
                    .ToList();

                //var p = (Province)saleAgents.FirstOrDefault().Province;
                return saleAgents;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public SaleAgents GetSaleAgentsById(short saleAgentID)
        {
            try
            {
                var saleAgents = _repositoryFactory.SaleAgents.Table.Include(x => x.Province).Include(x => x.CustomerGrade)
                    .FirstOrDefault(x => x.SaleAgentID == saleAgentID);

                return saleAgents;
            }
            catch
            {
                throw;
            }
        }

        public async Task<SaleAgents> GetSaleAgentsByIdAsync(short saleAgentID)
        {
            try
            {
                var saleAgents = await _repositoryFactory.SaleAgents.Table
                    .Include(x => x.Province)
                    .Include(x => x.CustomerGrade)
                    .FirstOrDefaultAsync(x => x.SaleAgentID == saleAgentID);

                return saleAgents;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(SaleAgents saleAgents)
        {
            try
            {
                _repositoryFactory.SaleAgents.Add(
                    new SaleAgents
                    {
                        SaleAgentCode = saleAgents.SaleAgentCode,
                        SaleAgentName = saleAgents.SaleAgentName,
                        SaleAgentLatinName = saleAgents.SaleAgentLatinName,
                        SaleAgentLocalizedName = saleAgents.SaleAgentLocalizedName,
                        ProvinceID = saleAgents.Province==null ? saleAgents.ProvinceID: saleAgents.Province.ProvinceID,
                        IsForeign = saleAgents.IsForeign,
                        ContactPerson = saleAgents.ContactPerson,
                        IsActive = saleAgents.IsActive,
                        Rating = saleAgents.Rating,
                        CustomerGradeID = saleAgents.CustomerGrade==null? saleAgents.CustomerGradeID : saleAgents.CustomerGrade.CustomerGradeID,
                        StartDate = saleAgents.StartDate,
                        Address = saleAgents.Address,
                        Tel = saleAgents.Tel,
                        ZipCode = saleAgents.ZipCode,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(SaleAgents saleAgents)
        {
            try
            {

                _repositoryFactory.SaleAgents.UpdateBy(x => x.SaleAgentID == saleAgents.SaleAgentID,
                    new SaleAgents
                    {
                        SaleAgentID = saleAgents.SaleAgentID,
                        SaleAgentCode = saleAgents.SaleAgentCode,
                        SaleAgentName = saleAgents.SaleAgentName,
                        SaleAgentLatinName = saleAgents.SaleAgentLatinName,
                        SaleAgentLocalizedName = saleAgents.SaleAgentLocalizedName,
                        ProvinceID = saleAgents.Province == null ? saleAgents.ProvinceID : saleAgents.Province.ProvinceID,
                        IsForeign = saleAgents.IsForeign,
                        ContactPerson = saleAgents.ContactPerson,
                        IsActive = saleAgents.IsActive,
                        Rating = saleAgents.Rating,
                        CustomerGradeID = saleAgents.CustomerGrade == null ? saleAgents.CustomerGradeID : saleAgents.CustomerGrade.CustomerGradeID,
                        StartDate = saleAgents.StartDate,
                        Address = saleAgents.Address,
                        Tel = saleAgents.Tel,
                        ZipCode = saleAgents.ZipCode,


                    });;
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(short saleAgentID)
        {
            try
            {
                var saleAgents = _repositoryFactory.SaleAgents
                    .FirstOrDefault(x => x.SaleAgentID == saleAgentID);

                if (saleAgents == null)
                    throw new System.Exception("SaleAgents Notfound.");

                _repositoryFactory.SaleAgents.Delete(saleAgents);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistSaleAgentsAsync(string name)
        {
            try
            {

                return await _repositoryFactory.SaleAgents.FirstOrDefaultAsync(x => x.SaleAgentName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }


        public async Task<SaleAgents> GetSaleAgentsByCodeAsync(string saleAgentCode)
        {
            try
            {
                var saleAgents = await _repositoryFactory.SaleAgents.Table.Include(x => x.Province).Include(x => x.CustomerGrade)
                    .FirstOrDefaultAsync(x => x.SaleAgentCode == saleAgentCode);

                return saleAgents;
            }
            catch
            {
                throw;
            }
        }


        public async Task<SaleAgents> GetSaleAgentsByNameAsync(string saleAgentName)
        {
            try
            {
                var saleAgents = await _repositoryFactory.SaleAgents.Table.Include(x => x.Province).Include(x => x.CustomerGrade)
                    .FirstOrDefaultAsync(x => x.SaleAgentName == saleAgentName);

                return saleAgents;
            }
            catch
            {
                throw;
            }
        }

    }
}
