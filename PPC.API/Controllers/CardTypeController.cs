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
    public class CardTypeController : Controller
    {

        #region Prop

        private readonly ICardTypesService _cardTypesService;

        #endregion

        #region Ctor

        public CardTypeController(ICardTypesService cardTypesService)
        {
            _cardTypesService = cardTypesService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetCardTypes()
        {
            try
            {

                List<Core.Models.CardTypes> cardTypes = await _cardTypesService.GetAllAsync();

                var res = ExtAutoMapper.JsonMap<List<CardTypes>, List<CardTypesDTO>>(cardTypes);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get CardTypes List failed");
                return Ok(ResponseFactory.OKCreator(new List<CardTypesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CardTypesDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetCardTypesByID(byte id)
        {
            try
            {

                Core.Models.CardTypes cardTypes = await _cardTypesService.GetCardTypesByIdAsync(id);

                var res = new List<CardTypesDTO> { ExtAutoMapper.JsonMap<CardTypes, CardTypesDTO>(cardTypes) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get cardTypes failed");
                return Ok(ResponseFactory.OKCreator(new List<CardTypesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CardTypesDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] CardTypes cardType)
        {
            try
            {

                byte result = _cardTypesService.Append(cardType);

                var res = new List<byte> { result };

                return Ok(ResponseFactory.OKCreator<List<byte>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CardTypes append failed");
                return Ok(ResponseFactory.OKCreator<List<byte>>(new List<byte>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<byte>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] CardTypes cardType)
        {
            try
            {

                bool result = _cardTypesService.Update(cardType);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CardTypes update failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        public IActionResult Delete(byte id)
        {
            try
            {
                long result = _cardTypesService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CardTypes delete failed");
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
