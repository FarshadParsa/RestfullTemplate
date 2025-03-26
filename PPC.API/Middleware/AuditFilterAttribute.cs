using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Core.Interface;
using WebApi.Core.Models;

namespace WebApi.API.Middleware
{
    public class AuditFilterAttribute : ActionFilterAttribute
    {
        public IAuditService _auditService { get; set; }


        private readonly IHttpContextAccessor _httpContextAccessor;


        public AuditFilterAttribute(IHttpContextAccessor httpContextAccessor, IAuditService auditService)
        {
            _auditService = auditService;
            _httpContextAccessor = httpContextAccessor;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                SysAuditData objaudit = new SysAuditData();

                var controllerName = ((ControllerBase)context.Controller)
                    .ControllerContext.ActionDescriptor.ControllerName;
                var actionName = ((ControllerBase)context.Controller)
                    .ControllerContext.ActionDescriptor.ActionName;

                if (!string.IsNullOrEmpty(Convert.ToString(context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier))))
                {
                    objaudit.UserId = Convert.ToInt32(context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
                else
                {
                    objaudit.UserId = 0;
                }
                objaudit.IpAddress = Convert.ToString(_httpContextAccessor.HttpContext.Connection.RemoteIpAddress);
                objaudit.ServiceAccessed = Convert.ToString(context.HttpContext.Request.Path); // URL User Requested
                objaudit.LoggedInAt = DateTime.Now;
                objaudit.ControllerName = controllerName; // ControllerName 
                objaudit.ActionName = actionName;
                _auditService.InsertData(objaudit);
            }
            catch (System.Exception ex)
            {

                throw;
            }
         
        }
    }
}
