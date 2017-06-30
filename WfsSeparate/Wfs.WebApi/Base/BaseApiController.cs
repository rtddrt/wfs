using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wfs.Application;
using Wfs.Core;
using Wfs.WebApi.Filters;

namespace Wfs.WebApi.Base
{
    public class BaseApiController : ApiController
    {
        public RedisHelper RedisCache;
        public CacheApplication CacheTable;
        public BaseApiController()
        {
            RedisCache = IocRegister.GetType<RedisHelper>();
            CacheTable = IocRegister.GetType<CacheApplication>();
        }
    }
}
