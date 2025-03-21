using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class TestPlanAssignService : BaseService, ITestPlanAssignService
    {
        IUnitOfWork _unitOfWork;
        public TestPlanAssignService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<TestPlanAssign> GetAll()
        {
            try
            {
                var testPlanAssign = _repositoryFactory.TestPlanAssign.Table.Include(x => x.Product).Include(x => x.RawMaterialGroupType)
                    .Include(x => x.TestPlan).Include(x => x.User_InsUser).Include(x => x.User_EditUser)
                    .ToList();

                return testPlanAssign;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TestPlanAssign>> GetAllAsync()
        {
            try
            {

                var testPlanAssign = await _repositoryFactory.TestPlanAssign.Table.Include(x => x.Product).Include(x => x.RawMaterialGroupType)
                    .Include(x => x.TestPlan).Include(x => x.User_InsUser).Include(x => x.User_EditUser).ToListAsync();
                return testPlanAssign;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


        public TestPlanAssign GetTestPlanAssignById(int testPlanAssignID)
        {
            try
            {
                var testPlanAssign = _repositoryFactory.TestPlanAssign.Table.Include(x => x.Product).Include(x => x.RawMaterialGroupType)
                    .Include(x => x.TestPlan).Include(x => x.User_InsUser).Include(x => x.User_EditUser)
                    .FirstOrDefault(x => x.TestPlanAssignID == testPlanAssignID);

                return testPlanAssign;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TestPlanAssign> GetTestPlanAssignByIdAsync(int testPlanAssignID)
        {
            try
            {
                var testPlanAssign = await _repositoryFactory.TestPlanAssign.Table.Include(x => x.Product).Include(x => x.RawMaterialGroupType)
                    .Include(x => x.TestPlan).Include(x => x.User_InsUser).Include(x => x.User_EditUser)
                    .FirstOrDefaultAsync(x => x.TestPlanAssignID == testPlanAssignID);

                return testPlanAssign;
            }
            catch
            {
                throw;
            }
        }


        public int Append(TestPlanAssign testPlanAssign)
        {

                try
                {
                    var _newObject = new TestPlanAssign
                    {
                        //TestPlanAssignID = testPlanAssign.TestPlanAssignID,
                        MaterialTypeID = testPlanAssign.MaterialTypeID,
                        ProductID = testPlanAssign.ProductID,
                        RawMaterialGroupTypeID = testPlanAssign.RawMaterialGroupTypeID,
                        TestPlanID = testPlanAssign.TestPlanID,
                        TestPlanAssignedCode = testPlanAssign.TestPlanAssignedCode,
                        AssignedCodeNum = testPlanAssign.AssignedCodeNum,
                        Version = testPlanAssign.Version,
                        InsUserID = testPlanAssign.InsUserID,
                        InsUserName = testPlanAssign.InsUserName,
                        InsUserFullName = testPlanAssign.InsUserFullName,
                        InsDate = testPlanAssign.InsDate,
                        InsTime = testPlanAssign.InsTime,
                        EditUserID = testPlanAssign.EditUserID,
                        EditUserName = testPlanAssign.EditUserName,
                        EditUserFullName = testPlanAssign.EditUserFullName,
                        EditDate = testPlanAssign.EditDate,
                        EditTime = testPlanAssign.EditTime,
                        IsActive = testPlanAssign.IsActive,
                        TestPlanAssignDetails = testPlanAssign.TestPlanAssignDetails,

                    };

                    _repositoryFactory.TestPlanAssign.Add(_newObject);
                    var statuse = _unitOfWork.Commit() > 0;

                    if (statuse)
                        return _newObject.TestPlanAssignID;
                    else
                        return int.MinValue;
                }
                catch (System.Exception)
                {
                    throw;
                }
        }



        //public int Append(TestPlanAssign testPlanAssign)
        //{
        //    using (var t = _unitOfWork.StartTransaction())
        //    {


        //        try
        //        {
        //            var _newObject = new TestPlanAssign
        //            {
        //                //TestPlanAssignID = testPlanAssign.TestPlanAssignID,
        //                MaterialTypeID = testPlanAssign.MaterialTypeID,
        //                ProductID = testPlanAssign.ProductID,
        //                RawMaterialGroupTypeID = testPlanAssign.RawMaterialGroupTypeID,
        //                TestPlanID = testPlanAssign.TestPlanID,
        //                TestPlanAssignedCode = testPlanAssign.TestPlanAssignedCode,
        //                AssignedCodeNum = testPlanAssign.AssignedCodeNum,
        //                Version = testPlanAssign.Version,
        //                InsUserID = testPlanAssign.InsUserID,
        //                InsUserName = testPlanAssign.InsUserName,
        //                InsUserFullName = testPlanAssign.InsUserFullName,
        //                InsDate = testPlanAssign.InsDate,
        //                InsTime = testPlanAssign.InsTime,
        //                EditUserID = testPlanAssign.EditUserID,
        //                EditUserName = testPlanAssign.EditUserName,
        //                EditUserFullName = testPlanAssign.EditUserFullName,
        //                EditDate = testPlanAssign.EditDate,
        //                EditTime = testPlanAssign.EditTime,
        //                IsActive = testPlanAssign.IsActive,
        //            };

        //            _repositoryFactory.TestPlanAssign.Add(_newObject);
        //            var statuse = _unitOfWork.Commit() > 0;

        //            testPlanAssign.TestPlanAssignDetails.ForEach(x =>
        //                _repositoryFactory.TestPlanAssignDetail.Add(
        //                    new TestPlanAssignDetail
        //                    {
        //                        TestPlanAssignID = _newObject.TestPlanAssignID,
        //                        TestPlanIndexID = x.TestPlanIndexID,
        //                        MinVal = x.MinVal,
        //                        MaxVal = x.MaxVal,
        //                        TextPhrase = x.TextPhrase,
        //                        UnitID = x.UnitID,
        //                        DiagnosisMethod = x.DiagnosisMethod,
        //                        TestTool = x.TestTool,
        //                        TestStage = x.TestStage,
        //                        InstructionID = x.InstructionID,
        //                        Describe = x.Describe,
        //                    }));

        //            statuse &= _unitOfWork.Commit() > 0;

        //            t.Commit();
        //            if (statuse)
        //                return _newObject.TestPlanAssignID;
        //            else
        //                return int.MinValue;
        //        }
        //        catch (System.Exception)
        //        {
        //            t.Rollback();
        //            throw;
        //        }
        //    }
        //}


        public bool Update(TestPlanAssign testPlanAssign)
        {
            try
            {
                throw new NotImplementedException();

                _repositoryFactory.TestPlanAssign.UpdateBy(x => x.TestPlanAssignID == testPlanAssign.TestPlanAssignID,
                    new TestPlanAssign
                    {
                        TestPlanAssignID = testPlanAssign.TestPlanAssignID,
                        MaterialTypeID = testPlanAssign.MaterialTypeID,
                        ProductID = testPlanAssign.ProductID,
                        RawMaterialGroupTypeID = testPlanAssign.RawMaterialGroupTypeID,
                        TestPlanID = testPlanAssign.TestPlanID,
                        TestPlanAssignedCode = testPlanAssign.TestPlanAssignedCode,
                        AssignedCodeNum = testPlanAssign.AssignedCodeNum,
                        Version = testPlanAssign.Version,
                        InsUserID = testPlanAssign.InsUserID,
                        InsUserName = testPlanAssign.InsUserName,
                        InsUserFullName = testPlanAssign.InsUserFullName,
                        InsDate = testPlanAssign.InsDate,
                        InsTime = testPlanAssign.InsTime,
                        EditUserID = testPlanAssign.EditUserID,
                        EditUserName = testPlanAssign.EditUserName,
                        EditUserFullName = testPlanAssign.EditUserFullName,
                        EditDate = testPlanAssign.EditDate,
                        EditTime = testPlanAssign.EditTime,
                        IsActive = testPlanAssign.IsActive,

                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int testPlanAssignID)
        {
            try
            {
                var testPlanAssign = _repositoryFactory.TestPlanAssign.Table.Include(x=>x.TestPlanAssignDetails)
                    .FirstOrDefault(x => x.TestPlanAssignID == testPlanAssignID);

                if (testPlanAssign == null)
                    throw new System.Exception("TestPlanAssign Notfound.");

                _repositoryFactory.TestPlanAssign.Delete(testPlanAssign);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<TestPlanAssign> ExistTestPlanAssignAsync(string code)
        {
            try
            {

                return await _repositoryFactory.TestPlanAssign.Table.Include(x => x.Product).Include(x => x.RawMaterialGroupType)
                    .Include(x => x.TestPlan).Include(x => x.User_InsUser).Include(x => x.User_EditUser)
                    .FirstOrDefaultAsync(x => x.TestPlanAssignedCode.ToUpper() == code.ToUpper());
            }
            catch
            {
                throw;
            }
        }

        public async Task<TestPlanAssign> GetLatestTestPlanAssignByTestPlanCodeAsync(string testPlanCode)
        {
            try
            {
                var testPlan = _repositoryFactory.TestPlans.Where(x => x.TestPlanCode == testPlanCode)
                    .OrderByDescending(x => x.TestPlanCode + "-" + x.TestPlanCodeVersion).FirstOrDefault();

                return await GetLatestTestPlanAssignByTestPlanIdAsync(testPlan == null ? int.MinValue : testPlan.TestPlanID);

            }
            catch
            {
                throw;
            }
        }


        public async Task<TestPlanAssign> GetLatestTestPlanAssignByTestPlanIdAsync(int testPlanId)
        {

            try
            {

                var testPlan = _repositoryFactory.TestPlans.Table.Where(x => x.TestPlanID == testPlanId).FirstOrDefault();

                TestPlansService testPlansService = new TestPlansService(_repositoryFactory,_unitOfWork);
                var latestTestPlan = testPlansService.GetTestPlanMaxCodeByCodeChar(testPlan.TestPlanCodeChar);


                var testPlanAssignMax = await _repositoryFactory.TestPlanAssign.Table.Include(x => x.TestPlan)
                    .Where(x => x.TestPlanAssignedCode.StartsWith(latestTestPlan.Result.TestPlanCode))
                    .OrderByDescending(x => x.TestPlanAssignedCode).FirstOrDefaultAsync();

                return testPlanAssignMax;
            }
            catch
            {
                throw;
            }

            //try
            //{
            //    var testPlan = _repositoryFactory.TestPlans.Table.Where(x => x.TestPlanID == testPlanId).FirstOrDefault();


            //    var testPlanAssignMax = await _repositoryFactory.TestPlanAssign.Table.Include(x => x.TestPlan)
            //        .OrderByDescending(x => x.TestPlanID).OrderByDescending(x => x.Version)
            //        .Where(x => x.TestPlanID == (testPlan == null ? null : testPlan.TestPlanID)).FirstOrDefaultAsync();

            //    return testPlanAssignMax;
            //}
            //catch
            //{
            //    throw;
            //}
        }


        //public async Task<List<TestPlanAssignViewModel>> GetAllForDropDownAsync()
        //{
        //    try
        //    {
        //        var db = _repositoryFactory;
        //        var q = await (from TestPlanAssign in db.TestPlanAssign.Table
        //                       join TestPlan in db.TestPlans.Table on TestPlanAssign.TestPlanID equals TestPlan.TestPlanID
        //                       //join TestPlanGroup in db.TestPlanGroups.Table on TestPlan.TestPlanGroupID equals TestPlanGroup.TestPlanGroupID
        //                       //join TestPlanGroup in db.TestPlanGroups.Table on TestPlan.TestPlanGroupID equals TestPlanGroup.TestPlanGroupID

        //                       join ProductGroupType in db.ProductGroupTypes.Table on TestPlanAssign.ProductID equals ProductGroupType.ProductGroupTypeID into productGroupTypes_Join
        //                       from productGroupType_Join in productGroupTypes_Join.DefaultIfEmpty()
        //                       join RawMaterialGroupType in db.RawMaterialGroupTypes.Table on TestPlanAssign.RawMaterialGroupTypeID equals RawMaterialGroupType.RawMaterialGroupTypeID into RawMaterialGroupTypes_Join
        //                       from RawMaterialGroupType_Join in RawMaterialGroupTypes_Join.DefaultIfEmpty()
        //                       select new TestPlanAssignViewModel
        //                       {
        //                           TestPlanAssign_TestPlanAssignID = TestPlanAssign.TestPlanAssignID,
        //                           TestPlanAssign_MaterialTypeID = TestPlanAssign.MaterialTypeID,
        //                           TestPlanAssign_ProductID = TestPlanAssign.ProductID,
        //                           TestPlanAssign_RawMaterialGroupTypeID = TestPlanAssign.RawMaterialGroupTypeID,
        //                           TestPlanAssign_TestPlanID = TestPlanAssign.TestPlanID,
        //                           TestPlanAssign_TestPlanAssignedCode = TestPlanAssign.TestPlanAssignedCode,
        //                           TestPlanAssign_AssignedCodeNum = TestPlanAssign.AssignedCodeNum,
        //                           TestPlanAssign_Version = TestPlanAssign.Version,
        //                           //TestPlanAssign_InsSysTime = TestPlanAssign.InsSysTime,
        //                           TestPlanAssign_InsUserID = TestPlanAssign.InsUserID,
        //                           TestPlanAssign_InsUserName = TestPlanAssign.InsUserName,
        //                           TestPlanAssign_InsUserFullName = TestPlanAssign.InsUserFullName,
        //                           TestPlanAssign_InsDate = TestPlanAssign.InsDate,
        //                           TestPlanAssign_InsTime = TestPlanAssign.InsTime,
        //                           TestPlanAssign_EditUserID = TestPlanAssign.EditUserID,
        //                           TestPlanAssign_EditUserName = TestPlanAssign.EditUserName,
        //                           TestPlanAssign_EditUserFullName = TestPlanAssign.EditUserFullName,
        //                           TestPlanAssign_EditDate = TestPlanAssign.EditDate,
        //                           TestPlanAssign_EditTime = TestPlanAssign.EditTime,
        //                           TestPlanAssign_IsActive = TestPlanAssign.IsActive,
        //                           TestPlan_MaterialTypeID = TestPlan.MaterialTypeID,
        //                           TestPlan_TestPlanMCode = TestPlan.TestPlanMCode,
        //                           TestPlan_TestPlanCode = TestPlan.TestPlanCode,
        //                           TestPlan_TestPlanCodeChar = TestPlan.TestPlanCodeChar,
        //                           TestPlan_TestPlanCodeNum = TestPlan.TestPlanCodeNum,
        //                           TestPlan_TestPlanCodeSeri = TestPlan.TestPlanCodeSeri,
        //                           TestPlan_TestPlanCodeVersion = TestPlan.TestPlanCodeVersion,
        //                           TestPlan_Version = TestPlan.Version,
        //                           //TestPlanGroup_TestPlanGroupCode = TestPlanGroup.TestPlanGroupCode,
        //                           //TestPlanGroup_TestPlanGroupName = TestPlanGroup.TestPlanGroupName,
        //                           //TestPlanGroup_TestPlanGroupSign = TestPlanGroup.TestPlanGroupSign,
        //                           ProductGroupType_ProductGroupTypeName = productGroupType_Join.ProductGroupTypeName,
        //                           RawMaterialGroupType_RawMaterialGroupTypeName = RawMaterialGroupType_Join.RawMaterialGroupTypeName,
        //                       }


        //            ).ToListAsync();

        //        //var testPlanAssign = await _repositoryFactory.TestPlanAssign.Table.ToListAsync();
        //        return q;// new List<TestPlanAssignViewModel>();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw;
        //    }
        //}




        //public async Task<TestPlanAssign> GetTestPlanAssignMaxCodeByCodeChar(string codeChar)
        //{
        //    try
        //    {


        //        TestPlanAssign tp = await _repositoryFactory.TestPlanAssign
        //            .Where(x => x.TestPlanCodeChar.ToUpper() == codeChar.ToString().ToUpper())
        //            .OrderByDescending(x => x.TestPlanCode).FirstOrDefaultAsync();

        //        return tp == null
        //            ? null
        //            : GetTestPlansById(tp.TestPlanID);

        //        //var testPlanGrouped = (from testPlan in db.TestPlans.Table
        //        //                       //where testPlan.ProductGroupID == productGroupID && testPlan.TestPlanCodeChar.ToUpper()== codeChar.ToString().ToUpper()
        //        //                       where testPlan.ProductGroupID.Value >0 && testPlan.TestPlanCodeChar.ToUpper()== codeChar.ToString().ToUpper()
        //        //                       group testPlan by testPlan.TestPlanMCode into groupedTestPlan
        //        //                       select new TestPlans
        //        //                       {
        //        //                           //TestPlanID = groupedTestPlan.Max(x => x.TestPlanID),
        //        //                           TestPlanID = groupedTestPlan.Max(x => x.TestPlanID),
        //        //                           TestPlanMCode = groupedTestPlan.Key,
        //        //                       });
        //        //int testPlanId = testPlanGrouped.Any() ?
        //        //    testPlanGrouped.Max(x => x.TestPlanID)
        //        //    : int.MinValue;

        //        //return GetTestPlansById(testPlanId);

        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }
}
