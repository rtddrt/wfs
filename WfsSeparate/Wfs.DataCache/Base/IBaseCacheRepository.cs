using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Wfs.Core;
using Wfs.Domain.Base;

namespace Wfs.DataCache.Base
{
    /// <summary>
    /// 缓存仓储
    /// </summary>
    public interface IBaseCacheRepository<T> : IDependency where T:Entity
    {
        /// <summary>
        /// 缓存名称
        /// </summary>
        string CacheName { get; }

        /// <summary>
        /// 缓存对象
        /// </summary>
        RedisHelper Cache { get; }

        /// <summary>
        /// 获取Cache对象
        /// </summary>
        /// <returns></returns>
        List<T> Get();

        /// <summary>
        /// 缓存刷新
        /// </summary>
        void Reload();

        /// <summary>
        /// 缓存清除
        /// </summary>
        void Clear();
    }
}
