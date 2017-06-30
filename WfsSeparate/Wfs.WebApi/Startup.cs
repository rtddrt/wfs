using System;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Wfs.Core;

[assembly: OwinStartup(typeof(Wfs.WebApi.Startup))]

namespace Wfs.WebApi
{
    public class Startup
    {
        private readonly string _issuer = ConfigurationHelper.GetString("jwt:issuer");
        private readonly string _secret = ConfigurationHelper.GetString("jwt:secret");
        private readonly int _expireDay = ConfigurationHelper.GetInt("accessToken:expireDay");

        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            var encrySecret = TextEncodings.Base64Url.Decode(Convert.ToBase64String(Encoding.Default.GetBytes(_secret)));
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions()
            {
               AuthenticationMode = AuthenticationMode.Active,
               AllowedAudiences = new []{"Any"},
               IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
               {
                   new SymmetricKeyIssuerSecurityTokenProvider(_issuer,encrySecret), 
               }
            });

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions()
            {

                AllowInsecureHttp = true,
                //token 获取路径
                TokenEndpointPath = new PathString("/oauth2/token"),
                //设置token 失效时间
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(_expireDay),

                //请求token,验证用户名和密码
                Provider = new CustomOAuthProvider(),
                //定义token格式
                AccessTokenFormat = new CustomJwtFormat(_issuer,encrySecret),
            });
        }
    }
}
