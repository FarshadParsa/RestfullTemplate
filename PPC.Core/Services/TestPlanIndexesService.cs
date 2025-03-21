using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Models;

using PPC.Core.Repository;
using PPC.Core.Interface;
namespace PPC.Core.Services
{
    public class TestPlanIndexesService : BaseService, ITestPlanIndexesService
    {
        IUnitOfWork _unitOfWork;
        public TestPlanIndexesService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<TestPlanIndexes> GetAll()
        {
            try
            {
                var testPlanIndexes = _repositoryFactory.TestPlanIndexes.Table.ToList();

                return testPlanIndexes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TestPlanIndexes>> GetAllAsync()
        {
            try
            {

                var testPlanIndexes = await _repositoryFactory.TestPlanIndexes.Table.ToListAsync();
                return testPlanIndexes;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public TestPlanIndexes GetTestPlanIndexesById(int testPlanIndexID)
        {
            try
            {
                var testPlanIndexes = _repositoryFactory.TestPlanIndexes
                    .FirstOrDefault(x => x.TestPlanIndexID == testPlanIndexID);

                return testPlanIndexes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TestPlanIndexes> GetTestPlanIndexesByIdAsync(int testPlanIndexID)
        {
            try
            {
                var testPlanIndexes = await _repositoryFactory.TestPlanIndexes
                    .FirstOrDefaultAsync(x => x.TestPlanIndexID == testPlanIndexID);

                return testPlanIndexes;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(TestPlanIndexes testPlanIndexes)
        {
            try
            {
                _repositoryFactory.TestPlanIndexes.Add(
                    new TestPlanIndexes
                    {
                        TestPlanIndexID = testPlanIndexes.TestPlanIndexID,
                        TestPlanIndexName = testPlanIndexes.TestPlanIndexName,
                        Describe = testPlanIndexes.Describe,
                        IsRawMaterialIndex = testPlanIndexes.IsRawMaterialIndex,
                        IsProductIndex = testPlanIndexes.IsProductIndex,
                        TestPlanIndexFieldTypeID = testPlanIndexes.TestPlanIndexFieldTypeID,
                        IsActive = testPlanIndexes.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(TestPlanIndexes testPlanIndexes)
        {
            try
            {

                _repositoryFactory.TestPlanIndexes.UpdateBy(x => x.TestPlanIndexID == testPlanIndexes.TestPlanIndexID,
                    new TestPlanIndexes
                    {
                        TestPlanIndexID = testPlanIndexes.TestPlanIndexID,
                        TestPlanIndexName = testPlanIndexes.TestPlanIndexName,
                        Describe = testPlanIndexes.Describe,
                        IsRawMaterialIndex = testPlanIndexes.IsRawMaterialIndex,
                        IsProductIndex = testPlanIndexes.IsProductIndex,
                        TestPlanIndexFieldTypeID = testPlanIndexes.TestPlanIndexFieldTypeID,
                        IsActive = testPlanIndexes.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int testPlanIndexID)
        {
            try
            {
                var testPlanIndexes = _repositoryFactory.TestPlanIndexes
                    .FirstOrDefault(x => x.TestPlanIndexID == testPlanIndexID);

                if (testPlanIndexes == null)
                    throw new System.Exception("TestPlanIndexes Notfound.");

                _repositoryFactory.TestPlanIndexes.Delete(testPlanIndexes);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistTestPlanIndexesAsync(string name)
        {
            try
            {

                return await _repositoryFactory.TestPlanIndexes.FirstOrDefaultAsync(x => x.TestPlanIndexName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }


    }
}
