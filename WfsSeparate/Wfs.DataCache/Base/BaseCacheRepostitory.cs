using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DbContextScope.Interfaces;
using Wfs.Core;
using Wfs.Domain.Base;
using Wfs.Domain.IRepositories;
using Wfs.EntityFramework.Context;

namespace Wfs.DataCache.Base
{
    public class BaseCacheRepostitory<T> : IBaseCacheRepository<T> where T : Entity
    {
        #region private field

        private readonly IRepository<T> _tRepository;

        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        #endregion
        #region Ctor
        public BaseCacheRepostitory(RedisHelper cache,IRepository<T> tRepository,IDbContextScopeFactory dbContextScopeFactory)
        {
            Cache = cache;
            this._dbContextScopeFactory = dbContextScopeFactory;
            this._tRepository = tRepository;

        }
        
        #endregion

        public string CacheName
        {
            get
            {
                var t = typeof(T);
                return t.Name;
            }
        }

        public RedisHelper Cache { get; private set; }

        public List<T> Get()
        {
            if (Cache.KeyExists(CacheName))
            {
                var listT = new List<T>();
                var hashList = Cache.HashValues(CacheName);
                foreach (var item in hashList)
                {
                    listT.Add(JsonHelper.Instance.Deserialize<T>(item));
                }
                return listT;
            }
            else
            {
                using (var db = _dbContextScopeFactory.CreateReadOnly())
                {
                    var list = _tRepository.Find().ToList();
                    SetCache(list);
                    return list;
                }
            }
        }

        public void SetCache(List<T> list)
        {
            foreach (var item in list)
            {
                var value = JsonHelper.Instance.Serialize(item);
                Cache.HashSet(CacheName, item.Id.ToString(), value);
            }

        }


        public void Reload()
        {
            using (var db = _dbContextScopeFactory.CreateReadOnly())
            {
                var list = _tRepository.Find().ToList();
                SetCache(list);
            }
        }

        public void Clear()
        {
            Cache.KeyDelete(this.CacheName);
        }
    }
}
