//using PPC.Core.Extensions;
//using Microsoft.AspNetCore.Mvc;
//using System.Linq;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Cors;
//using PPC.Base.Models.Exceptions;
//using PPC.Core.Interface;
//using PPC.Core.Log;
//using PPC.Core.Models;
//using PPC.Response.DTOs;
//using PPC.Response.Result;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//namespace PPC.API.Controllers
//{
//    [Authorize]
//    [EnableCors("CorsPolicy")]
//    [IgnoreAntiforgeryToken]
//    public class RawMaterialConfirmationController : Controller
//    {

//        #region Prop

//        private readonly IRawMaterialConfirmationService _rawMaterialConfirmationService;

//        #endregion

//        #region Ctor

//        public RawMaterialConfirmationController(IRawMaterialConfirmationService rawMaterialConfirmationService)
//        {
//            _rawMaterialConfirmationService = rawMaterialConfirmationService;
//        }

//        #endregion

//        [HttpGet]
//        public async Task<IActionResult> GetRawMaterialConfirmation()
//        {
//            try
//            {

//                List<Core.Models.RawMaterialConfirmation> rawMaterialConfirmation = await _rawMaterialConfirmationService.GetAllAsync();

//                var res = rawMaterialConfirmation == null
//                    ? null
//                    : rawMaterialConfirmation.ConvertToListDto();
//                return Ok(ResponseFactory.OKCreator(res, res.Count()));

//            }
//            catch (HttpResponseException)
//            {
//                LogManager.Warn($"Get RawMaterialConfirmation List failed");
//                return Ok(ResponseFactory.OKCreator(new List<RawMaterialConfirmationDto>(), 0));
//            }
//            catch (System.Exception e)
//            {
//                LogManager.Error("Error Login", e);
//                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialConfirmationDto>>(e));
//            }

//        }

//        [HttpGet]
//        public async Task<IActionResult> GetRawMaterialConfirmationByID(int id)
//        {
//            try
//            {

//                Core.Models.RawMaterialConfirmation rawMaterialConfirmation = await _rawMaterialConfirmationService.GetRawMaterialConfirmationByIdAsync(id);

//                var res = rawMaterialConfirmation == null
//                    ? null
//                    : (new List<Core.Models.RawMaterialConfirmation> { rawMaterialConfirmation }).ConvertToListDto();
//                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
//            }
//            catch (HttpResponseException)
//            {
//                LogManager.Warn($"Get rawMaterialConfirmation failed");
//                return Ok(ResponseFactory.OKCreator(new List<RawMaterialConfirmationDto>(), 0));
//            }
//            catch (System.Exception e)
//            {
//                LogManager.Error("Error Login", e);
//                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialConfirmationDto>>(e));
//            }

//        }

//        [HttpPost]
//        public async Task<IActionResult> Append([FromBody] RawMaterialConfirmation rawMaterialConfirmation)
//        {
//            try
//            {

//                int result = _rawMaterialConfirmationService.Append(rawMaterialConfirmation);

//                var res = new List<int> { result };

//                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
//            }
//            catch (HttpResponseException)
//            {
//                LogManager.Warn($"RawMaterialConfirmation append failed");
//                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
//            }
//            catch (System.Exception e)
//            {
//                LogManager.Error("Error ... ", e);
//                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
//            }
//        }

//        [HttpPost]
//        public IActionResult Update([FromBody] RawMaterialConfirmation rawMaterialConfirmation)
//        {
//            try
//            {

//                bool result = _rawMaterialConfirmationService.Update(rawMaterialConfirmation);

//                var res = new List<bool> { result };

//                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
//            }
//            catch (HttpResponseException)
//            {
//                LogManager.Warn($"RawMaterialConfirmation update failed");
//                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
//            }
//            catch (System.Exception e)
//            {
//                LogManager.Error("Error ... ", e);
//                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
//            }
//        }

//        [HttpGet]
//        public IActionResult Delete(int id)
//        {
//            try
//            {
//                long result = _rawMaterialConfirmationService.Delete(id);

//                var res = new List<long> { result };

//                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
//            }
//            catch (HttpResponseException)
//            {
//                LogManager.Warn($"RawMaterialConfirmation delete failed");
//                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
//            }
//            catch (System.Exception e)
//            {
//                LogManager.Error("Error ... ", e);
//                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
//            }
//        }


//    }
//}
