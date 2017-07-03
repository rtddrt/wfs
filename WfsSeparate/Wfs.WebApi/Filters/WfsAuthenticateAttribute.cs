using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.UI;
using Wfs.Application;
using Wfs.Application.LogDto;
using Wfs.Core;
using Wfs.DataCache.Base;
using Wfs.Domain;
using Wfs.WebApi.Base;

namespace Wfs.WebApi.Filters
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    public class WfsAuthenticateAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            #region 基础信息
            var controllerName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = actionContext.ActionDescriptor.ActionName;
            var actionId = new Guid((controllerName + actionName).ToMd5());
            #endregion

            var application = IocRegister.GetType<LogApplication>();
            var entity=new UsingApiLogDto()
            {
                ActionId = actionId,
                Ip = GetIp(),
                CreationTime = DateTime.Now,
                BrowserInfo = HttpContext.Current.Request.UserAgent
            };
            application.AddApiUsingLogs(entity);
            //检验是否需要忽略权限
            var parentType = actionContext.ActionDescriptor.ControllerDescriptor.ControllerType;
            var ignore = parentType.GetCustomAttributes(typeof(IgnoreAttribute), true).ToList();
            if (ignore.Count > 0)
                return;
            if (actionContext.ActionDescriptor.GetCustomAttributes<IgnoreAttribute>().Count > 0)
                return;
            if (!base.IsAuthorized(actionContext))
            {
                HandleUnauthorizedRequest(actionContext); 
                return;
            }
            //获取用户ID和角色ID
            var userId = UserClaimsIdentity.GetUserId();
            var roleIdArr = UserClaimsIdentity.GetRoleIdArray();
            bool isSuperAdmin = UserClaimsIdentity.IsSuperadmin(roleIdArr);
            //管理员具有所有权限
            if (isSuperAdmin) return;

            //其他权限继续判断
            //判断Action权限
            var list = UserClaimsIdentity.GetListActonByRoles(roleIdArr);
            var actionEntity = list.FirstOrDefault(x => x.ActionId == actionId);
            if (actionEntity == null)
            {
                HandleUnauthorizedRequest(actionContext);
                return;
            }
            base.OnAuthorization(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            var content = new ResponseMessage()
            {
                code = ResponseCode.UNAUTHORIZE,
                message = "unauthorized!"
            };
            actionContext.Response.Content = new StringContent(Json.Encode(content), Encoding.UTF8,
                "application/json");
        }

        private string GetIp()
        {
            //可以透过代理服务器
            string userIp = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            //判断是否有代理服务器
            if (string.IsNullOrEmpty(userIp))
            {
                //没有代理服务器,如果有代理服务器获取的是代理服务器的IP
                userIp = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return userIp == "::1" ? "127.0.0.1" : userIp;
        }
    }

}