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
namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class CardInvController : Controller
    {

        #region Prop

        private readonly ICardInvService _cardInvService;

        #endregion

        #region Ctor

        public CardInvController(ICardInvService cardInvService)
        {
            _cardInvService = cardInvService;
        }

        #endregion

        //[HttpPost]
        //public async Task<IActionResult> GetAmountList([FromBody] List<CardInv> cardInvList)
        //{
        //    try
        //    {

        //        var cardInv = await _cardInvService.GetListByKeysAsync(cardInvList.First().Year,
        //            cardInvList.First().InvTypeID, 
        //            cardInvList.Select(x=>x.RawMaterialID).Distinct().ToList()
        //            );

        //        var res = ExtAutoMapper.JsonMap<List<CardInv>, List<CardInvDTO>>(cardInv) ;

        //        return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
        //    }
        //    catch (HttpResponseException)
        //    {
        //        LogManager.Warn($"Get cardInv failed");
        //        return Ok(ResponseFactory.OKCreator(new List<CardInvDTO>(), 0));
        //    }
        //    catch (System.Exception e)
        //    {
        //        LogManager.Error("Error Login", e);
        //        return Ok(ResponseFactory.NotOKCreator<List<CardInvDTO>>(e));
        //    }

        //}

        //[HttpGet("[Controller]/[Action]/{year}/{invTypeList}/{RawMaterialIdList}/{entryDate?}")]
        [HttpPost("[Controller]/[Action]/{year}/{invTypeID}")]
        public async Task<IActionResult> GetAmountList([FromBody] List<int> rawMaterialIdList, short year, char invTypeID)
        {
            try
            {
                var cardInv = await _cardInvService.GetListByKeysAsync(year,invTypeID,rawMaterialIdList);

                var res = ExtAutoMapper.JsonMap<List<CardInv>, List<CardInvDTO>>(cardInv);

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get cardInv failed");
                return Ok(ResponseFactory.OKCreator(new List<CardInvDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CardInvDTO>>(e));
            }

        }






    }
}
