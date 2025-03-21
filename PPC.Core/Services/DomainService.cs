using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
using PPC.Response.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Services
{
    public class DomainService : BaseService, IDomainService
    {
        IUnitOfWork _unitOfWork;
        public DomainService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;

        }

        public List<Domain> GetDomain(bool? isActive=null)
        {
            try
            {
                if(isActive==null)
                    return _repositoryFactory.Domain.Table.ToList();
                else if(isActive==true)
                    return _repositoryFactory.Domain.Where(x=> x.IsActive).ToList();
                else
                    return _repositoryFactory.Domain.Where(x => !x.IsActive).ToList();
            }
            catch
            {
                throw;
            }
        }

        public bool Append(Domain domain)
        {
            try
            {
                _repositoryFactory.Domain.Add(
                    new Domain
                    {
                        DomainID = domain.DomainID,
                        DomainName = domain.DomainName,
                        DomainAddress = domain.DomainAddress,
                        Describe = domain.Describe,
                        IsActive = domain.IsActive,
                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch
            {
                throw ;
            }
        }


        public bool Update(Domain domain)
        {
            try
            {

                _repositoryFactory.Domain.UpdateBy(x => x.DomainID == domain.DomainID,
                    new Domain
                    {
                        DomainID = domain.DomainID,
                        DomainName = domain.DomainName,
                        DomainAddress = domain.DomainAddress,
                        Describe = domain.Describe,
                        IsActive = domain.IsActive,
                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch
            {
                throw ;
            }
        }

        public long DeleteDomain(int domainId)
        {
            try
            {
                var domain = _repositoryFactory.Domain.FirstOrDefault(x => x.DomainID == domainId);

                if (domain == null)
                    throw new System.Exception("Domain Not found.");

                _repositoryFactory.Domain.Delete(domain);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public Domain GetDomainById(int domainId)
        {
            try
            {
                var domain = _repositoryFactory.Domain.FirstOrDefault(x => x.DomainID == domainId);

                return domain;
            }
            catch
            {
                throw;
            }
        }


        public Task<Domain> FindDomainAsync(string domainName)
        {
            throw new NotImplementedException();
        }

        public Task<Domain> GetDomainByIdAsync(int domainId)
        {
            throw new NotImplementedException();
        }

    }
}
