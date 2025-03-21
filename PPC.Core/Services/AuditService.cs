using Microsoft.Extensions.Options;
using PPC.Base;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPC.Core.Services
{
    [ServiceMapTo(typeof(IAuditService))]
    public class AuditService : BaseService, IAuditService
    {

        #region ctor
        public AuditService(IUnitOfWork unitOfWork, RepositoryFactory repositoryFactory)
        {
            _unitOfWork = unitOfWork;
            _repositoryFactory = repositoryFactory;
        }
        #endregion

        #region Public Method

        public bool InsertData(SysAuditData model)
        {
            _repositoryFactory.SysAuditData.Add(model);
            return _unitOfWork.Commit() > 0;
        } 
        #endregion
    }
}
