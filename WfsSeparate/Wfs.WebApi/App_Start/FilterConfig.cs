using System.Web.Http;
using Wfs.WebApi.Filters;

namespace Wfs.WebApi{
    public class FilterConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            // api 添加认证保护
            config.Filters.Add(new WfsAuthenticateAttribute());
        }
    }
}