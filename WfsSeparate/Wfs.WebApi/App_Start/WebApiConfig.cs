using System.Web.Http;
using System.Web.Http.Cors;
using Wfs.Core;
using Microsoft.Owin.Security.OAuth;
namespace Wfs.WebApi
{
    public static class WebApiConfig
    {
        #region private field

        private static readonly string Orgins = ConfigurationHelper.GetString("cors:enableOrgins");
        private static readonly string Headers = ConfigurationHelper.GetString("cors:enableHeaders");
        private static readonly string Methods = ConfigurationHelper.GetString("cors:enableMethods");
        #endregion
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            config.EnableCors(new EnableCorsAttribute(Orgins, Headers, Methods));
            config.SuppressHostPrincipal();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            // Web API 路由
            config.MapHttpAttributeRoutes();
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Routes.MapHttpRoute(
               name: "ActionApi",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
