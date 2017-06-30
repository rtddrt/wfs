using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Wfs.Core.Web
{
    public class CookieHelper
    {
        /// <summary>
        /// 添加一个 Cookie
        /// </summary>
        /// <param name="name">名</param>
        /// <param name="value">值</param>
        public static void Add(string name, string value)
        {
            var cookie = new HttpCookie(name, value);

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 添加一个 Cookie
        /// </summary>
        /// <param name="name">名</param>
        /// <param name="value">值</param>
        /// <param name="expires">过期日期和时间</param>
        public static void Add(string name, string value, DateTime expires)
        {
            var cookie = new HttpCookie(name, value)
            {
                Expires = expires
            };

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 获取 Cookie 值
        /// </summary>
        /// <param name="name">名</param>
        /// <returns></returns>
        public static string Get(string name)
        {
            var cookie = HttpContext.Current.Request.Cookies[name];

            return cookie == null ? string.Empty : cookie.Value;
        }
    }
}
