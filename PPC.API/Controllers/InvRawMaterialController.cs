using PPC.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using PPC.Base.Models.Exceptions;
using PPC.Core.Interface;
using PPC.Core.Log;
using PPC.Core.Models;
using PPC.Response.DTOs;
using PPC.Response.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
using AC_PPC.Common;
namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class InvRawMaterialController : Controller
    {

        #region Prop

        private readonly IInvRawMaterialsService _invRawMaterialsService;

        #endregion

        #region Ctor

        public InvRawMaterialController(IInvRawMaterialsService invRawMaterialsService)
        {
            _invRawMaterialsService = invRawMaterialsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetInvRawMaterials()
        {
            try
            {

                List<Core.Models.InvRawMaterials> invRawMaterials = await _invRawMaterialsService.GetListAsync();

                //var res = invRawMaterials == null
                //    ? null
                //    : invRawMaterials.ConvertToListDto();

                var res = ExtAutoMapper.JsonMap<List<InvRawMaterials>, List<InvRawMaterialsDTO>>(invRawMaterials);


                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get InvRawMaterials List failed");
                return Ok(ResponseFactory.OKCreator(new List<InvRawMaterialsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<InvRawMaterialsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetInvRawMaterialsByID(int id)
        {
            try
            {

                //Core.Models.InvRawMaterials invRawMaterials = await _invRawMaterialsService.GetInvRawMaterialsByIdAsync(id);

                var includes = new List<Expression<Func<InvRawMaterials, object>>>
                {
                    x => x.RawMaterial.Units, 
                    x => x.RawMaterial.RawMaterialGroups 
                };

                var invRawMaterials = await _invRawMaterialsService.GetInvRawMaterialsByIdAsync(
                    id,
                    includes.ToArray()
                );

                //var res = invRawMaterials == null
                //    ? null
                //    : (new List<Core.Models.InvRawMaterials> { invRawMaterials }).ConvertToListDto();

                var res = new List<InvRawMaterialsDTO> { ExtAutoMapper.JsonMap<InvRawMaterials, InvRawMaterialsDTO>(invRawMaterials) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get invRawMaterials failed");
                return Ok(ResponseFactory.OKCreator(new List<InvRawMaterialsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<InvRawMaterialsDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{financialRequestNo}")]
        public async Task<IActionResult> GetInvRawMaterialByFinancialRequestNo(string financialRequestNo)
        {
            try
            {

                var result = _invRawMaterialsService.GetInvRawMaterialByFinancialRequestNoAsync(financialRequestNo);

                var res = new List<InvRawMaterials> { await result };

                return Ok(ResponseFactory.OKCreator<List<InvRawMaterials>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get InvRawMaterials failed");
                return Ok(ResponseFactory.OKCreator<List<InvRawMaterials>>(new List<InvRawMaterials>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<InvRawMaterials>>(e));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] InvRawMaterials invRawMaterial)
        {
            try
            {

                int result = _invRawMaterialsService.Append(invRawMaterial);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"InvRawMaterials append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] InvRawMaterials invRawMaterial)
        {
            try
            {

                bool result = await _invRawMaterialsService.Update(invRawMaterial);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"InvRawMaterials update failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                long result = _invRawMaterialsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"InvRawMaterials delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetInvRawMaterialWithLotsByID(int id)
        {
            try
            {

                Core.Models.InvRawMaterials invRawMaterials = await _invRawMaterialsService.GetInvRawMaterialWithLotsByIdAsync(id);

                //var res = invRawMaterials == null
                //    ? null
                //    : (new List<Core.Models.InvRawMaterials> { invRawMaterials }).ConvertToListDto();

                var res = new List<InvRawMaterialsDTO> { ExtAutoMapper.JsonMap<InvRawMaterials, InvRawMaterialsDTO>(invRawMaterials) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get invRawMaterials failed");
                return Ok(ResponseFactory.OKCreator(new List<InvRawMaterialsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<InvRawMaterialsDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{startDate}/{endDate}")]
        public async Task<IActionResult> GetListByDate(int startDate, int endDate)
        {
            try
            {
                var includes = new Expression<Func<InvRawMaterials, object>>[]
                {
                    //x=>x.RawMaterial.Units,
                    x=>x.RawMaterial.RawMaterialGroups,
                    //x=>x.InvRawMaterialLotsList.Select(x=>x.RawMaterial).Select(x=>x.RawMaterialGroups)
                    x=>x.InvRawMaterialLotsList.Select(x=>x.PackagingType)//.Select(x=>x.RawMaterialGroups)
                };

                string dateFrom=Utility.ConvertDateNumToStr(startDate);
                string dateTo=Utility.ConvertDateNumToStr(endDate);
                List<Core.Models.InvRawMaterials> invRawMaterials = await _invRawMaterialsService.GetListByDateAsync(
                    dateFrom,
                    dateTo,
                    includes);

                //var res = invRawMaterials == null
                //    ? null
                //    : invRawMaterials.ConvertToListDto();

                var res = ExtAutoMapper.JsonMap<List<InvRawMaterials>, List<InvRawMaterialsDTO>>(invRawMaterials);


                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get InvRawMaterials List failed");
                return Ok(ResponseFactory.OKCreator(new List<InvRawMaterialsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<InvRawMaterialsDTO>>(e));
            }

        }

        //[HttpGet("[Controller]/[Action]/{partlotNo}")]
        //public async Task<IActionResult> GetInstanceByPartOfLotNo(string partlotNo)
        //{
        //    try
        //    {

        //        var result = _invRawMaterialsService.GetInstanceByPartOfLotNoAsync(partlotNo);

        //        var res = new List<InvRawMaterials> { await result }.ConvertToListDto();

        //        return Ok(ResponseFactory.OKCreator<List<InvRawMaterialsDTO>>(res, res.Count()));

        //    }
        //    catch (HttpResponseException)
        //    {
        //        LogManager.Warn($"Get InvRawMaterials failed");
        //        return Ok(ResponseFactory.OKCreator<List<InvRawMaterialsDTO>>(new List<InvRawMaterialsDTO>(), 0));
        //    }
        //    catch (System.Exception e)
        //    {
        //        LogManager.Error("Error ... ", e);
        //        return Ok(ResponseFactory.NotOKCreator<List<InvRawMaterialsDTO>>(e));
        //    }
        //}

        //[HttpGet("[Controller]/[Action]/{generalLotNo}")]
        //public async Task<IActionResult> GetListByGeneralLotNo(string generalLotNo)
        //{
        //    try
        //    {

        //        var result = await _invRawMaterialsService.GetListByGeneralLotNoAsync(generalLotNo);

        //        var res = ExtAutoMapper.Mapper.Map<List<InvRawMaterials>, List<InvRawMaterialsDTO>>(result);

        //        return Ok(ResponseFactory.OKCreator<List<InvRawMaterialsDTO>>(res, res.Count()));

        //    }
        //    catch (HttpResponseException)
        //    {
        //        LogManager.Warn($"Get InvRawMaterials failed");
        //        return Ok(ResponseFactory.OKCreator<List<InvRawMaterialsDTO>>(new List<InvRawMaterialsDTO>(), 0));
        //    }
        //    catch (System.Exception e)
        //    {
        //        LogManager.Error("Error ... ", e);
        //        return Ok(ResponseFactory.NotOKCreator<List<InvRawMaterialsDTO>>(e));
        //    }
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetLotnumbersByRawMaterialId(int id)
        //{
        //    try
        //    {
        //        var lotNumbers = await _invRawMaterialsService.GetLotnumbersByRawMaterialIdAsync(id);

        //        return Ok(ResponseFactory.OKCreator(lotNumbers, lotNumbers != null ? 1 : 0));
        //    }
        //    catch (HttpResponseException)
        //    {
        //        LogManager.Warn($"Get LotNumbers failed");
        //        return Ok(ResponseFactory.OKCreator(new List<string>(), 0));
        //    }
        //    catch (System.Exception e)
        //    {
        //        LogManager.Error("Error Login", e);
        //        return Ok(ResponseFactory.NotOKCreator<List<string>>(e));
        //    }

        //}

    }
}
