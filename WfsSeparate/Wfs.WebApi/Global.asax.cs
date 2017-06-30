using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Wfs.Core;

namespace Wfs.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //统一注册接口和类库
            IocRegister.InitAutofac();
            //初始化缓存
            CacheRegister.Init();
            //初始化系统动作器表
            SystemActionsHelper.InitSystemAction();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(FilterConfig.Configure);
            LogHelper.LogInformation("网站启动...");
        }
    }
}
