using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Core;
using Wfs.Domain;
using Wfs.EntityFramework.Context;

namespace Wfs.EntityFramework.Migrations.Seed
{
    public static class SystemSeed
    {
        public static void InitSysRole(WfsContext context)
        {
            var admin = new SysRole()
            {
                Id = new Guid("1E58F01D-EB1B-467F-A594-B241CDAE4653"),
                RoleName = "SuperAdmin",
                RoleDescription = "超级管理员用户",
                IsActive = 1
            };

            if (context.SysRole.FirstOrDefault(x => x.Id == admin.Id) == null)
            {
                context.SysRole.Add(admin);
                context.SaveChanges();
            }
        }

        public static void InitSysUser(WfsContext context)
        {
            var user = new SysUser()
            {
                Id = new Guid("169C5F63-4FA8-4E36-A5A2-878B8BA2893D"),
                IsActive = 1,
                SysUserName = "root",
                SysUserPwd = "root@pwd".EncryptPwd(),
                CreationTime = DateTime.Now,
                IsDelete = 0,
                SysUserRandomCode = Guid.NewGuid().ToString("N")
            };

            var userinfo = new SysUserInfo()
            {
                Id = new Guid("072B5AE0-83AB-4D10-8453-178CCE8AEC5E"),
                UserId = user.Id,
                IsDelete = 0,
                Sex = 1,
                RealName = "超级管理员"
            };

            if (context.SysUser.FirstOrDefault(x => x.Id == user.Id) == null)
            {
                context.SysUser.Add(user);
                if (context.SysUserInfo.FirstOrDefault(x => x.Id == userinfo.Id) == null)
                    context.SysUserInfo.Add(userinfo);
                context.SaveChanges();
            }
        }

        public static void InitSysUserRole(WfsContext context)
        {
            var userRole = new SysUserRole()
            {
                Id = new Guid("C9C731C2-2412-4F54-9321-36BFF7C38801"),
                RoleId = new Guid("1E58F01D-EB1B-467F-A594-B241CDAE4653"),
                UserId = new Guid("169C5F63-4FA8-4E36-A5A2-878B8BA2893D")
            };

            if (context.SysUser.FirstOrDefault(x => x.Id == userRole.UserId) != null
                && context.SysRole.FirstOrDefault(x => x.Id == userRole.RoleId) != null)
            {
                if (context.SysUserRole.FirstOrDefault(x => x.Id == userRole.Id) == null)
                {
                    context.SysUserRole.Add(userRole);
                    context.SaveChanges();
                }
            }
        }

        public static void InitSysMenu(WfsContext context)
        {
            var root=new SysMenu()
            {
                Description = "根目录",
                Id =Guid.Empty,
                MenuUrl = "/",
                MenuName = "/",
                ActionName = "/",
                ControllerName = "/",
                IsActive = 1,
                Order = 0
            };
            if (context.SysMenu.FirstOrDefault(x => x.Id == root.Id) == null)
            {
                context.SysMenu.Add(root);
                context.SaveChanges();
            }
        }
    }
}
