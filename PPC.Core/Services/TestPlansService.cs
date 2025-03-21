using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class TestPlansService : BaseService, ITestPlansService
    {
        IUnitOfWork _unitOfWork;
        public TestPlansService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<TestPlans> GetAll()
        {
            try
            {
                var testPlans = _repositoryFactory.TestPlans.Table
                    //.Include(x => x.TestPlanGroups)
                    .ToList();

                return testPlans;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TestPlans>> GetAllAsync()
        {
            try
            {

                var testPlans = await _repositoryFactory.TestPlans.Table
                    //.Include(x => x.TestPlanGroups)
                    .ToListAsync();
                return testPlans;
                //var db = _repositoryFactory;
                //var testPlans = await (from testPlan in db.TestPlans.Table
                //                       join testPlanGroup in db.TestPlanGroups.Table on testPlan.TestPlanGroupID equals testPlanGroup.TestPlanGroupID
                //                       join testPlanLastNode in db.TestPlans.Table on testPlan.LastNodeID equals testPlanLastNode.TestPlanID
                //                       select new TestPlans
                //                       {
                //                           TestPlanID = testPlan.TestPlanID,
                //                           MaterialTypeID = testPlan.MaterialTypeID,
                //                           TestPlanGroupID = testPlan.TestPlanGroupID,
                //                           TestPlanGroups = testPlanGroup,
                //                           TestPlanMCode = testPlan.TestPlanMCode,
                //                           TestPlanCode = testPlan.TestPlanCode,
                //                           TestPlanCodeChar = testPlan.TestPlanCodeChar,
                //                           TestPlanCodeNum = testPlan.TestPlanCodeNum,
                //                           TestPlanCodeSeri = testPlan.TestPlanCodeSeri,
                //                           TestPlanCodeVersion = testPlan.TestPlanCodeVersion,
                //                           Version = testPlan.Version,
                //                           InsUserID = testPlan.InsUserID,
                //                           InsUserName = testPlan.InsUserName,
                //                           InsUserFullName = testPlan.InsUserFullName,
                //                           InsDate = testPlan.InsDate,
                //                           InsTime = testPlan.InsTime,
                //                           EditUserID = testPlan.EditUserID,
                //                           EditUserName = testPlan.EditUserName,
                //                           EditUserFullName = testPlan.EditUserFullName,
                //                           EditDate = testPlan.EditDate,
                //                           EditTime = testPlan.EditTime,
                //                           IsActive = testPlan.IsActive,
                //                           LastNodeID = testPlan.LastNodeID,
                //                           LastNode = testPlanLastNode,
                //                           ParentID = testPlan.ParentID,
                //                           Parent = testPlan.Parent,
                //                       }).ToListAsync();
                //return testPlans;


            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public TestPlans GetTestPlansById(int testPlanID)
        {
            try
            {
                var testPlans = _repositoryFactory.TestPlans.Table
                    //.Include(x => x.TestPlanGroups)
                    .FirstOrDefault(x => x.TestPlanID == testPlanID);

                return testPlans;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TestPlans> GetTestPlansByIdAsync(int testPlanID)
        {
            try
            {
                var testPlans = await _repositoryFactory.TestPlans.Table
                    //.Include(x => x.TestPlanGroups)
                    .FirstOrDefaultAsync(x => x.TestPlanID == testPlanID);

                return testPlans;
            }
            catch
            {
                throw;
            }
        }

        public int Append(TestPlans testPlans)
        {
            using (var t = _unitOfWork.StartTransaction())
            {
                try
                {
                    var statuse = false;

                    if (testPlans.LastNodeID != null && testPlans.LastNodeID > 0)
                    {
                        var oldTestPlan = GetTestPlansById(Convert.ToInt32(testPlans.LastNodeID));
                        oldTestPlan.LastNodeID = null;
                    }

                    statuse = _unitOfWork.Commit() > 0;

                    var _testPaln = new TestPlans
                    {
                        MaterialTypeID = testPlans.MaterialTypeID,
                        ProductTypeID = testPlans.ProductTypeID,
                        RawMaterialGroupTypeID = testPlans.RawMaterialGroupTypeID,
                        TestPlanMCode = testPlans.TestPlanMCode,
                        TestPlanCode = testPlans.TestPlanCode,
                        TestPlanCodeChar = testPlans.TestPlanCodeChar,
                        TestPlanCodeNum = testPlans.TestPlanCodeNum,
                        TestPlanCodeSeri = testPlans.TestPlanCodeSeri,
                        TestPlanCodeVersion = testPlans.TestPlanCodeVersion,
                        Version = testPlans.Version,
                        InsUserID = testPlans.InsUserID,
                        InsUserName = testPlans.InsUserName,
                        InsUserFullName = testPlans.InsUserFullName,
                        InsDate = testPlans.InsDate,
                        InsTime = testPlans.InsTime,
                        EditUserID = testPlans.EditUserID,
                        EditUserName = testPlans.EditUserName,
                        EditUserFullName = testPlans.EditUserFullName,
                        EditDate = testPlans.EditDate,
                        EditTime = testPlans.EditTime,
                        IsActive = testPlans.IsActive,
                        LastNodeID = testPlans.LastNodeID,
                        ParentID = testPlans.ParentID,
                        Status = testPlans.Status,
                        IsConfirmed = testPlans.IsConfirmed,

                    };


                    _repositoryFactory.TestPlans.Add(_testPaln);

                    statuse &=  _unitOfWork.Commit() > 0;

                    if (testPlans.LastNodeID == null || testPlans.LastNodeID == 0)
                    {
                        _testPaln.LastNodeID = _testPaln.TestPlanID;//self
                    }

                    testPlans.TestPlanDetails.ForEach(x =>
                    {
                        x.TestPlanID = _testPaln.TestPlanID;
                        _repositoryFactory.TestPlanDetails.Add(x);

                    });

                    statuse &= _unitOfWork.Commit() > 0;

                    t.Commit();

                    return statuse ? _testPaln.TestPlanID : -1;
                }
                catch (System.Exception)
                {
                    t.Rollback();
                    throw;
                }

            }
        }


        public bool Update(TestPlans testPlans)
        {
            try
            {
                _repositoryFactory.TestPlans.UpdateBy(x => x.TestPlanID == testPlans.TestPlanID,
                    new TestPlans
                    {
                        TestPlanID = testPlans.TestPlanID,
                        MaterialTypeID = testPlans.MaterialTypeID,
                        ProductTypeID = testPlans.ProductTypeID,
                        RawMaterialGroupTypeID = testPlans.RawMaterialGroupTypeID,
                        TestPlanMCode = testPlans.TestPlanMCode,
                        TestPlanCode = testPlans.TestPlanCode,
                        TestPlanCodeChar = testPlans.TestPlanCodeChar,
                        TestPlanCodeNum = testPlans.TestPlanCodeNum,
                        TestPlanCodeSeri = testPlans.TestPlanCodeSeri,
                        TestPlanCodeVersion = testPlans.TestPlanCodeVersion,
                        Version = testPlans.Version,
                        InsUserID = testPlans.InsUserID,
                        InsUserName = testPlans.InsUserName,
                        InsUserFullName = testPlans.InsUserFullName,
                        InsDate = testPlans.InsDate,
                        InsTime = testPlans.InsTime,
                        EditUserID = testPlans.EditUserID,
                        EditUserName = testPlans.EditUserName,
                        EditUserFullName = testPlans.EditUserFullName,
                        EditDate = testPlans.EditDate,
                        EditTime = testPlans.EditTime,
                        IsActive = testPlans.IsActive,
                        LastNodeID = testPlans.LastNodeID,
                        ParentID = testPlans.ParentID,
                        Status = testPlans.Status,
                        IsConfirmed = testPlans.IsConfirmed,

                    });

                var statuse = _unitOfWork.Commit() > 0;

                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int testPlanID)
        {

            using (var t = _unitOfWork.StartTransaction())
            {
                try
                {
                    var testPlanDetails = _repositoryFactory.TestPlanDetails
                        .Where(x => x.TestPlanID == testPlanID).ToList();

                    var testPlans = _repositoryFactory.TestPlans
                        .FirstOrDefault(x => x.TestPlanID == testPlanID);

                    if (testPlans == null)
                        throw new System.Exception("TestPlans Notfound.");

                    var prvTestPlans = _repositoryFactory.TestPlans
                        .FirstOrDefault(x => x.TestPlanID == testPlans.ParentID);

                    if (prvTestPlans != null)
                    {
                        if (prvTestPlans.ParentID == null)
                            prvTestPlans.LastNodeID = prvTestPlans.TestPlanID;
                        else
                            prvTestPlans.LastNodeID = prvTestPlans.ParentID;
                    }

                    testPlanDetails.ForEach(testPlanDetail => _repositoryFactory.TestPlanDetails.Delete(testPlanDetail));
                    _repositoryFactory.TestPlans.Delete(testPlans);

                    var statuse = _unitOfWork.Commit();

                    t.Commit();
                    return statuse;
                }
                catch
                {
                    t.Rollback();
                    throw;
                }
            }
        }


        public async Task<bool> ExistTestPlansAsync(string code)
        {
            try
            {
                return await _repositoryFactory.TestPlans.FirstOrDefaultAsync(x => x.TestPlanMCode.ToUpper() == code.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }
        public async Task<TestPlans> GetTestPlanMaxCodeByProductGroupID(short productGroupID, string codeChar)
        {
            try
            {
                //return await _repositoryFactory.TestPlans.FirstOrDefaultAsync(x => x.TestPlanGroupID == testPlanGroupID);

                var db = _repositoryFactory;

                TestPlans tp = await _repositoryFactory.TestPlans
                    .Where(x=>x.ProductTypeID == productGroupID && x.TestPlanCodeChar.ToUpper() == codeChar.ToString().ToUpper())
                    .OrderByDescending(x=>x.TestPlanCode).FirstOrDefaultAsync();

                return tp==null
                    ?null
                    :GetTestPlansById(tp.TestPlanID);

                //var testPlanGrouped = (from testPlan in db.TestPlans.Table
                //                       //where testPlan.ProductGroupID == productGroupID && testPlan.TestPlanCodeChar.ToUpper()== codeChar.ToString().ToUpper()
                //                       where testPlan.ProductGroupID.Value >0 && testPlan.TestPlanCodeChar.ToUpper()== codeChar.ToString().ToUpper()
                //                       group testPlan by testPlan.TestPlanMCode into groupedTestPlan
                //                       select new TestPlans
                //                       {
                //                           //TestPlanID = groupedTestPlan.Max(x => x.TestPlanID),
                //                           TestPlanID = groupedTestPlan.Max(x => x.TestPlanID),
                //                           TestPlanMCode = groupedTestPlan.Key,
                //                       });
                //int testPlanId = testPlanGrouped.Any() ?
                //    testPlanGrouped.Max(x => x.TestPlanID)
                //    : int.MinValue;

                //return GetTestPlansById(testPlanId);

            }
            catch
            {
                throw;
            }
        }

        public async Task<TestPlans> GetTestPlanMaxCodeByRawMaterialGroupTypeID(short rawMaterialGroupTypeID, string codeChar)
        {
            try
            {
                //return await _repositoryFactory.TestPlans.FirstOrDefaultAsync(x => x.TestPlanGroupID == testPlanGroupID);

                var db = _repositoryFactory;
                //var testPlans = await (from testPlan in db.TestPlans.Table
                //                 where testPlan.TestPlanGroupID== testPlanGroupID
                //                 group testPlan by testPlan.TestPlanMCode into groupedTestPlan
                //                 select new TestPlans
                //                 {
                //                     TestPlanID = groupedTestPlan.Max(x => x.TestPlanID),
                //                     TestPlanMCode = groupedTestPlan.Key,
                //                 }).FirstOrDefaultAsync();

                var testPlanGrouped = (from testPlan in db.TestPlans.Table
                                           //where testPlan.RawMaterialGroupTypeID == rawMaterialGroupTypeID && testPlan.TestPlanCodeChar.ToUpper() == codeChar.ToString().ToUpper()
                                       where testPlan.RawMaterialGroupTypeID.Value>0 && testPlan.TestPlanCodeChar.ToUpper() == codeChar.ToString().ToUpper()
                                       group testPlan by testPlan.TestPlanMCode into groupedTestPlan
                                       select new TestPlans
                                       {
                                           //TestPlanID = groupedTestPlan.Max(x => x.TestPlanID),
                                           TestPlanID = groupedTestPlan.Max(x => x.TestPlanID),
                                           TestPlanMCode = groupedTestPlan.Key,
                                       });
                int testPlanId = testPlanGrouped.Any() ?
                    testPlanGrouped.Max(x => x.TestPlanID)
                    : int.MinValue;

                //var testPlans3 = await (from testPlan in db.TestPlans.Table
                //                        where testPlan.TestPlanGroupID == testPlanGroupID
                //                        group testPlan by testPlan.TestPlanMCode into groupedTestPlan
                //                        select new TestPlans
                //                        {
                //                            //TestPlanID = groupedTestPlan.Max(x => x.TestPlanID),
                //                            //TestPlanID = groupedTestPlan.Max(x => x.TestPlanID),
                //                            TestPlanMCode = groupedTestPlan.Key,
                //                        }).MaxAsync(x => x.TestPlanID);


                return GetTestPlansById(testPlanId);

            }
            catch
            {
                throw;
            }
        }


        public async Task<List<TestPlans>> GetTestPlansForCombo()
        {
            try
            {

                var db = _repositoryFactory;
                var testPlans = (from testPlan in db.TestPlans.Table
                                 group testPlan by testPlan.TestPlanMCode into groupedTestPlan
                                 select new TestPlans
                                 {
                                     TestPlanID = groupedTestPlan.Max(x => x.TestPlanID),
                                     TestPlanMCode = groupedTestPlan.Key,
                                 }).ToList();

                return testPlans;


            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<TestPlans>> GetLatestTestPlansAsync()
        {
            try
            {

                //var testPlans = await _repositoryFactory.TestPlans.Table.Include(x => x.TestPlanGroups).ToListAsync();
                //return testPlans;
                var db = _repositoryFactory;
                var testPlans = await (from testPlan in db.TestPlans.Table
                                       //***join testPlanGroup in db.TestPlanGroups.Table on testPlan.TestPlanGroupID equals testPlanGroup.TestPlanGroupID
                                       join testPlanLastNode in db.TestPlans.Table on testPlan.LastNodeID equals testPlanLastNode.TestPlanID
                                       select new TestPlans
                                       {
                                           TestPlanID = testPlan.TestPlanID,
                                           MaterialTypeID = testPlan.MaterialTypeID,
                                           ProductTypeID = testPlan.ProductTypeID,
                                           RawMaterialGroupTypeID = testPlan.RawMaterialGroupTypeID,
                                           TestPlanMCode = testPlan.TestPlanMCode,
                                           TestPlanCode = testPlan.TestPlanCode,
                                           TestPlanCodeChar = testPlan.TestPlanCodeChar,
                                           TestPlanCodeNum = testPlan.TestPlanCodeNum,
                                           TestPlanCodeSeri = testPlan.TestPlanCodeSeri,
                                           TestPlanCodeVersion = testPlan.TestPlanCodeVersion,
                                           Version = testPlan.Version,
                                           InsUserID = testPlan.InsUserID,
                                           InsUserName = testPlan.InsUserName,
                                           InsUserFullName = testPlan.InsUserFullName,
                                           InsDate = testPlan.InsDate,
                                           InsTime = testPlan.InsTime,
                                           EditUserID = testPlan.EditUserID,
                                           EditUserName = testPlan.EditUserName,
                                           EditUserFullName = testPlan.EditUserFullName,
                                           EditDate = testPlan.EditDate,
                                           EditTime = testPlan.EditTime,
                                           IsActive = testPlan.IsActive,
                                           LastNodeID = testPlan.LastNodeID,
                                           LastNode = testPlanLastNode,
                                           ParentID = testPlan.ParentID,
                                           Parent = testPlan.Parent,
                                       }).ToListAsync();
                return testPlans;


            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<TestPlans>> GetListForDropDownAsync()
        {
            try
            {

                var testPlans = await _repositoryFactory.TestPlans.Table
                    //.Include(x => x.TestPlanGroups)
                    .ToListAsync();
                return testPlans;
                //var db = _repositoryFactory;
                //var testPlans = await (from testPlan in db.TestPlans.Table
                //                       join testPlanGroup in db.TestPlanGroups.Table on testPlan.TestPlanGroupID equals testPlanGroup.TestPlanGroupID
                //                       join testPlanLastNode in db.TestPlans.Table on testPlan.LastNodeID equals testPlanLastNode.TestPlanID
                //                       select new TestPlans
                //                       {
                //                           TestPlanID = testPlan.TestPlanID,
                //                           MaterialTypeID = testPlan.MaterialTypeID,
                //                           TestPlanGroupID = testPlan.TestPlanGroupID,
                //                           TestPlanGroups = testPlanGroup,
                //                           TestPlanMCode = testPlan.TestPlanMCode,
                //                           TestPlanCode = testPlan.TestPlanCode,
                //                           TestPlanCodeChar = testPlan.TestPlanCodeChar,
                //                           TestPlanCodeNum = testPlan.TestPlanCodeNum,
                //                           TestPlanCodeSeri = testPlan.TestPlanCodeSeri,
                //                           TestPlanCodeVersion = testPlan.TestPlanCodeVersion,
                //                           Version = testPlan.Version,
                //                           InsUserID = testPlan.InsUserID,
                //                           InsUserName = testPlan.InsUserName,
                //                           InsUserFullName = testPlan.InsUserFullName,
                //                           InsDate = testPlan.InsDate,
                //                           InsTime = testPlan.InsTime,
                //                           EditUserID = testPlan.EditUserID,
                //                           EditUserName = testPlan.EditUserName,
                //                           EditUserFullName = testPlan.EditUserFullName,
                //                           EditDate = testPlan.EditDate,
                //                           EditTime = testPlan.EditTime,
                //                           IsActive = testPlan.IsActive,
                //                           LastNodeID = testPlan.LastNodeID,
                //                           LastNode = testPlanLastNode,
                //                           ParentID = testPlan.ParentID,
                //                           Parent = testPlan.Parent,
                //                       }).ToListAsync();
                //return testPlans;


            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


        public async Task<TestPlans> GetLatestTestPlansByIdAsync(int testPlanID)
        {
            try
            {
                var ins = GetTestPlansById(testPlanID);

                var testPlans = await _repositoryFactory.TestPlans.Where(x => x.TestPlanCode == ins.TestPlanCode)
                    .OrderBy(x => x.TestPlanCode).OrderByDescending(x => x.Version).FirstOrDefaultAsync();

                return testPlans;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TestPlans> GetTestPlanMaxCodeByCodeChar(string codeChar)
        {
            try
            {
                //return await _repositoryFactory.TestPlans.FirstOrDefaultAsync(x => x.TestPlanGroupID == testPlanGroupID);

                var db = _repositoryFactory;

                TestPlans tp = await _repositoryFactory.TestPlans
                    .Where(x =>x.TestPlanCodeChar.ToUpper() == codeChar.ToString().ToUpper())
                    .OrderByDescending(x => x.TestPlanCode).FirstOrDefaultAsync();

                return tp == null
                    ? null
                    : GetTestPlansById(tp.TestPlanID);

                //var testPlanGrouped = (from testPlan in db.TestPlans.Table
                //                       //where testPlan.ProductGroupID == productGroupID && testPlan.TestPlanCodeChar.ToUpper()== codeChar.ToString().ToUpper()
                //                       where testPlan.ProductGroupID.Value >0 && testPlan.TestPlanCodeChar.ToUpper()== codeChar.ToString().ToUpper()
                //                       group testPlan by testPlan.TestPlanMCode into groupedTestPlan
                //                       select new TestPlans
                //                       {
                //                           //TestPlanID = groupedTestPlan.Max(x => x.TestPlanID),
                //                           TestPlanID = groupedTestPlan.Max(x => x.TestPlanID),
                //                           TestPlanMCode = groupedTestPlan.Key,
                //                       });
                //int testPlanId = testPlanGrouped.Any() ?
                //    testPlanGrouped.Max(x => x.TestPlanID)
                //    : int.MinValue;

                //return GetTestPlansById(testPlanId);

            }
            catch
            {
                throw;
            }
        }


        public async Task<List<TestPlans>> GetAllForDropDownAsync()
        {
            try
            {
                var q = _repositoryFactory.TestPlans.Table
                    .Include(x=>x.TestPlanAssign)
                    .Include(x=>x.TestPlanDetails)
                    .ToList();

                //var testPlanAssign = await _repositoryFactory.TestPlanAssign.Table.ToListAsync();
                return q;// new List<TestPlanAssignViewModel>();
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }



    }
}
