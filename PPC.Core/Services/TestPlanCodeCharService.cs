using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class TestPlanCodeCharService : BaseService, ITestPlanCodeCharService
    {
        IUnitOfWork _unitOfWork;
        public TestPlanCodeCharService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<TestPlanCodeChar> GetAll()
        {
            try
            {
                var testPlanCodeChar = _repositoryFactory.TestPlanCodeChar.Table.ToList();

                return testPlanCodeChar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TestPlanCodeChar>> GetAllAsync()
        {
            try
            {

                var testPlanCodeChar = await _repositoryFactory.TestPlanCodeChar.Table.ToListAsync();
                return testPlanCodeChar;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public TestPlanCodeChar GetTestPlanCodeCharById(short testPlanCodeCharID)
        {
            try
            {
                var testPlanCodeChar = _repositoryFactory.TestPlanCodeChar
                    .FirstOrDefault(x => x.TestPlanCodeCharID == testPlanCodeCharID);

                return testPlanCodeChar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TestPlanCodeChar> GetTestPlanCodeCharByIdAsync(short testPlanCodeCharID)
        {
            try
            {
                var testPlanCodeChar = await _repositoryFactory.TestPlanCodeChar
                    .FirstOrDefaultAsync(x => x.TestPlanCodeCharID == testPlanCodeCharID);

                return testPlanCodeChar;
            }
            catch
            {
                throw;
            }
        }

        public short Append(TestPlanCodeChar testPlanCodeChar)
        {
            try
            {
                var _newObject = new TestPlanCodeChar
                {
                    TestPlanCodeCharID = testPlanCodeChar.TestPlanCodeCharID,
                    CodeChar = testPlanCodeChar.CodeChar,
                    IsProductType = testPlanCodeChar.IsProductType,


                };

                _repositoryFactory.TestPlanCodeChar.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.TestPlanCodeCharID;
                else
                    return short.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(TestPlanCodeChar testPlanCodeChar)
        {
            try
            {

                _repositoryFactory.TestPlanCodeChar.UpdateBy(x => x.TestPlanCodeCharID == testPlanCodeChar.TestPlanCodeCharID,
                    new TestPlanCodeChar
                    {
                        TestPlanCodeCharID = testPlanCodeChar.TestPlanCodeCharID,
                        CodeChar = testPlanCodeChar.CodeChar,
                        IsProductType = testPlanCodeChar.IsProductType,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(short testPlanCodeCharID)
        {
            try
            {
                var testPlanCodeChar = _repositoryFactory.TestPlanCodeChar
                    .FirstOrDefault(x => x.TestPlanCodeCharID == testPlanCodeCharID);

                if (testPlanCodeChar == null)
                    throw new System.Exception("TestPlanCodeChar Notfound.");

                _repositoryFactory.TestPlanCodeChar.Delete(testPlanCodeChar);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistTestPlanCodeCharAsync(string code)
        {
            try
            {

                return await _repositoryFactory.TestPlanCodeChar.FirstOrDefaultAsync(x => x.CodeChar.ToUpper() == code.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }


    }
}
