using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PPC.Base.Models.Exceptions;
using PPC.Core.Interface;
using PPC.Core.Log;
using PPC.Response.DTOs;
using PPC.Response.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPC.Core.Extensions;

namespace PPC.API.Controllers
{


    [Route("api/AtlasCell/[controller]")]
    [EnableCors("CorsPolicy")]
    [Authorize]
    public class RawMaterialController : Controller
    {

        #region Prop
        private readonly IRawMaterialService _rawMaterialService;


        #endregion

        #region Ctor

        public RawMaterialController(IRawMaterialService rawMaterialService)
        {
            _rawMaterialService = rawMaterialService;
        }

        #endregion


        [HttpGet]
        [Route("GetRawMaterialLists")]
        public async Task<IActionResult> GetRawMaterialLists()
        {

            try
            {

                List<PPC.Core.Models.RawMaterial> rawMaterial = _rawMaterialService.GetAll();
                
                var res = rawMaterial.ConvertToListDto();

                return Ok(ResponseFactory.OKCreator<List<RawMaterialDTO>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RawMaterial List failed");
                return Ok(ResponseFactory.OKCreator<List<RawMaterialDTO>>(new List<RawMaterialDTO>(), 0));
            }
            catch (Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialDTO>>(e));
            }

        }



    }
}
