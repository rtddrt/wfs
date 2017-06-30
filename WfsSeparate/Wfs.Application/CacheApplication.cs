using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.DataCache.Base;
using Wfs.Domain;

namespace Wfs.Application
{
    /// <summary>
    /// 缓存Application
    /// </summary>
    public class CacheApplication
    {
        #region private cacheRepository

        private readonly IBaseCacheRepository<SysAction> _sysActionCacheRepository;
        private readonly IBaseCacheRepository<SysMenu> _sysMenuCacheRepository;
        private readonly IBaseCacheRepository<SysRole> _sysRoleCacheRepository;
        #endregion

        #region Ctor

        public CacheApplication(IBaseCacheRepository<SysAction> sysActionCacheRepository,
            IBaseCacheRepository<SysMenu> sysMenuCacheRepository,IBaseCacheRepository<SysRole> sysRoleRepository)
        {
            _sysActionCacheRepository = sysActionCacheRepository;
            _sysMenuCacheRepository = sysMenuCacheRepository;
            _sysRoleCacheRepository = sysRoleRepository;
        }
        

        #endregion

        #region Actions

        /// <summary>
        /// 缓存初始化
        /// </summary>
        public void InitAll()
        {
            _sysActionCacheRepository.Get();
            _sysRoleCacheRepository.Get();
            _sysMenuCacheRepository.Get();
        }

        /// <summary>
        /// 缓存刷新
        /// </summary>
        public void ReloadAll()
        {
            _sysActionCacheRepository.Reload();
            _sysRoleCacheRepository.Reload();
            _sysMenuCacheRepository.Reload();
        }

        /// <summary>
        /// 缓存清空
        /// </summary>
        public void ClearAll()
        {
            _sysActionCacheRepository.Clear();
            _sysRoleCacheRepository.Clear();
            _sysMenuCacheRepository.Clear();
        }
        #endregion

        #region list
        /// <summary>
        /// 获取系统配置Action
        /// </summary>
        /// <returns></returns>
        public List<SysAction> GetSysActionList()
        {
            var list = _sysActionCacheRepository.Get().ToList();
            return list;
        }

        /// <summary>
        /// 获取系统菜单缓存
        /// </summary>
        /// <returns></returns>
        public List<SysMenu> GetSysMenuList()
        {
            var list = _sysMenuCacheRepository.Get().ToList();
            return list;
        }

        /// <summary>
        /// 获取系统角色列表
        /// </summary>
        /// <returns></returns>
        public List<SysRole> GetSysRoleList()
        {
            var list = _sysRoleCacheRepository.Get().ToList();
            return list;
        }
        #endregion
    }
}
