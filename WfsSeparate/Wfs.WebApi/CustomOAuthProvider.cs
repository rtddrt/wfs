using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Wfs.Application;
using Wfs.Core;

namespace Wfs.WebApi
{
    /// <summary>
    /// 自定义验证用户
    /// </summary>
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //return base.ValidateClientAuthentication(context);
            context.Validated();
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// password 模式
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //支持跨域调用
            context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var username = context.UserName;
            var password = context.Password;
            Guid? userId;
            List<Guid> Roles;
            if (!CheckUser(username, password, out userId,out Roles))
            {
                context.SetError("invalid_grant","the username or password is not correct");
                context.Rejected();
                return Task.FromResult<object>(null);
            }

            //设置票据
            var ticket=new AuthenticationTicket(SetClaimIdentity(context,userId.Value,username,Roles),new AuthenticationProperties());
            context.Validated(ticket);
            return Task.FromResult<object>(null);
        }

        #region Private Methods
        private static ClaimsIdentity SetClaimIdentity(OAuthGrantResourceOwnerCredentialsContext context, Guid userId, string username, List<Guid> roles)
        {
            var roleId = string.Join(",", roles);
            var identity = new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim(identity.NameClaimType, username));
            identity.AddClaim(new Claim("UserId", userId.ToString()));
            identity.AddClaim(new Claim("RoleId",roleId));
            return identity;
        }

        private static bool CheckUser(string username, string password, out Guid? userId, out List<Guid> Roles)
        {
            var accountApplication = IocRegister.GetType<AccountApplication>();
            var result = false;
            var model = accountApplication.LogAuth(username, password);
            if (model != null)
            {
                result = true;
                userId = model.Id;
                Roles = model.RoleIdArray;
            }
            else
            {
                userId = null;
                Roles = new List<Guid>();
            }
            return result;
        }
        #endregion

    }
}