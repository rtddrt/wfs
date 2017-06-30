using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Wfs.Application;
using Wfs.DataCache.Base;
using Wfs.Domain;

namespace Wfs.WebApi.Base
{
    public static class UserClaimsIdentity
    {
        #region private field

        private static readonly ClaimsPrincipal Principal;
        private static readonly CacheApplication CacheApplication;
        private static readonly AccountApplication AccountApplication;
        #endregion

        #region Ctor

        static UserClaimsIdentity()
        {
            Principal=ClaimsPrincipal.Current;
            CacheApplication = IocRegister.GetType<CacheApplication>();
            AccountApplication = IocRegister.GetType<AccountApplication>();
        }
        

        #endregion

        #region Public String 
        /// <summary>
        /// 是否验证成功!
        /// </summary>
        /// <returns></returns>
        public static bool IsAuthenticate()
        {
            var result = Principal.Identity.IsAuthenticated;
            return result;
        }
        /// <summary>
        /// 获取用户名称
        /// </summary>
        /// <returns></returns>
        public static string GetUserName()
        {
            return Principal.Identity.Name;
        }

        /// <summary>
        /// 获取用户Id
        /// </summary>
        /// <returns></returns>
        public static Guid GetUserId()
        {
            var user = Principal.Claims.FirstOrDefault(x => x.Type == "UserId");
            return user == null ? Guid.Empty : new Guid(user.Value);
        }

        /// <summary>
        /// 获取RoleId
        /// </summary>
        /// <returns></returns>
        public static string [] GetRoleIdArray()
        {
            var list = new string[0];
            var role = Principal.Claims.FirstOrDefault(x => x.Type == "RoleId");
            if (role != null)
            {
                var roleString = role.Value;
                list = roleString.Split(',');
            }
            return list;
        }

        /// <summary>
        /// 是否是超级管理员用户
        /// </summary>
        /// <returns></returns>
        public static bool IsSuperadmin(string [] roles)
        {
            var superAdmin = CacheApplication.GetSysRoleList().FirstOrDefault(x => x.RoleName == "SuperAdmin");
            return superAdmin!=null && roles.Contains(superAdmin.Id.ToString());
        }

        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <returns></returns>
        public static List<SysRoleAction> GetListActonByRoles(string[] roles)
        {
            var roleGuid = new Guid[roles.Length];
            for (int i = 0; i < roles.Length; i++)
            {
                roleGuid[i] = new Guid(roles[i]);
            }
            var list = AccountApplication.GetRoleActionList(roleGuid);
            return list;
        }
        #endregion
    }
}