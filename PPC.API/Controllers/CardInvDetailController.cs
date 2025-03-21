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
    public class CardInvDetailController : Controller
    {

        #region Prop

        private readonly ICardInvDetailsService _cardInvDetailsService;

        #endregion

        #region Ctor

        public CardInvDetailController(ICardInvDetailsService cardInvDetailsService)
        {
            _cardInvDetailsService = cardInvDetailsService;
        }

        #endregion


        //[HttpGet]
        //public async Task<IActionResult> GetCardInvDetailsByID(byte id)
        //{
        //    try
        //    {

        //        Core.Models.CardInvDetails cardInvDetails = await _cardInvDetailsService.GetCardInvDetailsByIdAsync(id);


        //        var res = new List<CardInvDetailsDTO> { ExtAutoMapper.JsonMap<CardInvDetails, CardInvDetailsDTO>(cardInvDetails) };

        //        return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
        //    }
        //    catch (HttpResponseException)
        //    {
        //        LogManager.Warn($"Get cardInvDetails failed");
        //        return Ok(ResponseFactory.OKCreator(new List<CardInvDetailsDTO>(), 0));
        //    }
        //    catch (System.Exception e)
        //    {
        //        LogManager.Error("Error Login", e);
        //        return Ok(ResponseFactory.NotOKCreator<List<CardInvDetailsDTO>>(e));
        //    }

        //}


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] CardInvDetails cardInvDetail)
        {
            try
            {
                CardInvDetails result = _cardInvDetailsService.Append(cardInvDetail);

                var res = new List<CardInvDetails> { result };

                return Ok(ResponseFactory.OKCreator<List<CardInvDetails>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CardInvDetails append failed");
                return Ok(ResponseFactory.OKCreator<List<CardInvDetails>>(new List<CardInvDetails>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<CardInvDetails>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] CardInvDetails cardInvDetail)
        {
            try
            {

                bool result = _cardInvDetailsService.Update(cardInvDetail);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CardInvDetails update failed");
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

                var result = _cardInvDetailsService.DeleteByInvRawMaterialID(1250);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CardInvDetails update failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }


    }
}
