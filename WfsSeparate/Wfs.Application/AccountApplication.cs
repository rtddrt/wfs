using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DbContextScope.Interfaces;
using Wfs.Application.UserDto;
using Wfs.Core;
using Wfs.Domain;
using Wfs.Domain.IRepositories;
using Wfs.EntityFramework.Context;

namespace Wfs.Application
{
    public class AccountApplication : BaseApplication
    {
        #region private field
        private readonly IRepository<SysUser> _sysUserRepository;
        private readonly IRepository<SysUserRole> _sysUserRoleRepository;
        private readonly IRepository<SysRole> _sysRoleRepository;
        private readonly IRepository<SysRoleAction> _sysRoleActionRepository;
        #endregion
        #region Ctor

        public AccountApplication(IDbContextScopeFactory dbContextScopeFactory,
     IRepository<SysUser> sysUserRepository, IRepository<SysUserRole> sysUserRoleRepository,
            IRepository<SysRole> sysRoleRepository,
            IRepository<SysRoleAction> sysRoleActionRepository)
            : base(dbContextScopeFactory)
        {
            this._sysUserRepository = sysUserRepository;
            this._sysUserRoleRepository = sysUserRoleRepository;
            this._sysRoleRepository = sysRoleRepository;
            _sysRoleActionRepository = sysRoleActionRepository;
        }


        #endregion
        #region resources



        /// <summary>
        /// 登陆验证
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public SysUserModelDto LogAuth(string username, string password)
        {
            using (var scope = _dbContextScopeFactory.CreateReadOnly())
            {
                var encryPwd = password.EncryptPwd();
                var result =
                    _sysUserRepository.FindSingle(
                        x => x.SysUserName == username && x.SysUserPwd == encryPwd && x.IsDelete == 0);
                if (result == null) return null;
                var model = new SysUserModelDto
                {
                    Id = result.Id,
                    SysUserName = result.SysUserName,
                };
                var roleList = _sysUserRoleRepository.Find(x => x.UserId == model.Id).ToList();
                model.RoleIdArray = roleList.Select(x => x.RoleId).ToList();
                return model;
            }
        }


        /// <summary>
        /// 获取角色数据
        /// </summary>
        /// <returns></returns>
        public List<SysRole> RoleList()
        {
            using (var db = _dbContextScopeFactory.CreateReadOnly())
            {
                var list = _sysRoleRepository.Find().ToList();
                return list;
            }
        }

        /// <summary>
        /// 根据角色获取动作器
        /// </summary>
        /// <returns></returns>
        public List<SysRoleAction> GetRoleActionList(Guid[] roleId)
        {
            using (var db = _dbContextScopeFactory.CreateReadOnly())
            {
                var actionList = _sysRoleActionRepository.Find(x=>roleId.Contains(x.RoleId)).ToList();
                return actionList.Distinct().ToList();
            }
        }
        #endregion

        #region methods



        #endregion
    }
}
