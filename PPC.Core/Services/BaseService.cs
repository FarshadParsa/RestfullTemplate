using PPC.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPC.Core.Services
{
    public abstract class BaseService
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public RepositoryFactory _repositoryFactory { get; set; }//=> new RepositoryFactory(_unitOfWork);
        public BaseService(//RepositoryFactory repositoryFactory,IUnitOfWork unitOfWork
            )
        {
            //_repositoryFactory = repositoryFactory;
            //_unitOfWork = unitOfWork;

        }
    }
}
