using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using AtlasCellData;
using Newtonsoft.Json;
using System.Data;
using System.Drawing;
using System.Linq.Expressions;
using System.Reflection;
using PPC.Base.Extensions;
using PPC.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AtlasCellData.ADO;

namespace PPC.Core.Services
{
    //[Authorize]
    public class ProvinceService : BaseService, IProvinceService
    {

        IUnitOfWork _unitOfWork;
        public ProvinceService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }

        public List<Province> GetActiveProvinces()
        {
            try
            {

                var province = _repositoryFactory.Province.Table.Where(x => x.IsActive).ToList();

                return province;

                //List<ProvinceDL> provinceDls = ProvinceDL.getInstances("IsActive=1").ToList();
                //List<Province> Provinces = new List<Province>();
                //var mapper = Functions.CreateMapper<ProvinceDL, Province>();
                //provinceDls.ForEach(x => Provinces.Add(mapper(x)));

                //return Provinces;
            }
            catch
            {
                throw;
            }
        }

        public List<Province> GetProvinces()
        {
            try
            {
                var province = _repositoryFactory.Province.Table.ToList();

                return province;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(Province province)
        {
            try
            {
                _repositoryFactory.Province.Add(
                    new Province
                    {
                        ProvinceID = province.ProvinceID,
                        ProvinceName = province.ProvinceName,
                        ProvinceLatinName = province.ProvinceLatinName,
                        IsActive = province.IsActive,
                        ProvinceCode = province.ProvinceCode,
                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Province province)
        {
            try
            {

                _repositoryFactory.Province.UpdateBy(x => x.ProvinceID == province.ProvinceID,
                    new Province
                    {
                        ProvinceID = province.ProvinceID,
                        ProvinceName = province.ProvinceName,
                        ProvinceLatinName = province.ProvinceLatinName,
                        ProvinceCode = province.ProvinceCode,
                        IsActive = province.IsActive,
                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch ( System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int provinceId)
        {
            try
            {
                var province = _repositoryFactory.Province
                    .FirstOrDefault(x => x.ProvinceID == provinceId);

                if (province == null)
                    throw new System.Exception("Province Not found.");

                _repositoryFactory.Province.Delete(province);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public Province FindProvince(int provinceId)
        {
            try
            {
                var province = _repositoryFactory.Province
                    .FirstOrDefault(x => x.ProvinceID == provinceId);

                return province;
            }
            catch
            {
                throw;
            }
        }

        public Province FindProvince(string provinceName)
        {
            try
            {
                var province = _repositoryFactory.Province
                    .FirstOrDefault(x => x.ProvinceName.Equals(provinceName, StringComparison.InvariantCultureIgnoreCase));

                return province;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Province>> GetProvincesAsync()
        {
            try
            {
                var province = _repositoryFactory.Province.Table.ToList();

                return province;
            }
            catch
            {
                throw;
            }
        }

        public Task<Province> FindProvinceAsync(string provincename)
        {
            throw new NotImplementedException();
        }

        //public List<Province> GetAll()
        //{
        //    try
        //    {
        //        var province = _repositoryFactory.Province.Table.ToList();

        //        return province;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        public static Point PointFToPoint(PointF pf)
        {
            return new Point(((int)pf.X), ((int)pf.Y));
        }

        public Task<Province> GetCurrentProvinceAsync()
        {
            throw new NotImplementedException();
        }

        public Province[] GetProvince()
        {
            throw new NotImplementedException();
        }

        public Task<Province[]> GetProvinceAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Province> FindProvinceAsync(int provinceId)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetActiveProvincesAsync()
        {
            throw new NotImplementedException();
        }

        List<Province> IProvinceService.GetProvincesAsync()
        {
            throw new NotImplementedException();
        }
    }

}
