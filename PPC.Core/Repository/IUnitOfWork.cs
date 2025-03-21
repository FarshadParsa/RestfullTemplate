using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace PPC.Core.Repository
{
    public interface IUnitOfWork
    {
        int Commit();
        IDbContextTransaction StartTransaction();
        void CommitTransaction();
        void Rollback();

        Task<IDbContextTransaction> StartTransactionAsync();
        void CommitTransactionAsync();
        void RollbackAsync();

        Task<int> CommitAsync();
    }

    public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        //private IDbContextTransaction _transaction;

        public UnitOfWork(TDbContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int Commit()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public IDbContextTransaction StartTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _dbContext.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _dbContext.Database.RollbackTransaction();
        }

        public async Task<IDbContextTransaction> StartTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }

        public async void CommitTransactionAsync()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public async void RollbackAsync()
        {
           await _dbContext.Database.RollbackTransactionAsync();
        }
    }





}

/* OK to 14031220
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace PPC.Core.Repository
{
    public interface IUnitOfWork
    {
        int Commit();
        IDbContextTransaction StartTransaction();
        void CommitTransaction();
        void Rollback();

        Task<IDbContextTransaction> StartTransactionAsync();
        void CommitTransactionAsync();
        void RollbackAsync();

        Task<int> CommitAsync();
    }

    public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public UnitOfWork(TDbContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int Commit()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public IDbContextTransaction StartTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _dbContext.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _dbContext.Database.RollbackTransaction();
        }

        public async Task<IDbContextTransaction> StartTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }

        public async void CommitTransactionAsync()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public async void RollbackAsync()
        {
           await _dbContext.Database.RollbackTransactionAsync();
        }
    }





}

*/