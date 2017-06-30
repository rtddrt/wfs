using Wfs.Application;

namespace Wfs.WebApi
{
    /// <summary>
    /// 缓存初始化
    /// </summary>
    public  class CacheRegister
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            var cacheApplication = IocRegister.GetType<CacheApplication>();
            cacheApplication.InitAll();
        }
    }
}