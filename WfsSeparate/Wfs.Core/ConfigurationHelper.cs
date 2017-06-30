using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wfs.Core
{
    /// <summary>
    /// 配置管理器
    /// </summary>
    public static class ConfigurationHelper
    {
        /// <summary>
        /// 获取配置文件 int类型
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static int GetInt(string key)
        {
            return Convert.ToInt32(ConfigurationManager.AppSettings[key]??"-1");
        }

        /// <summary>
        /// 获取配置文件,double类型
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static double GetDouble(string key)
        {
            var doublestring = GetString(key);
            if (string.IsNullOrEmpty(doublestring))
                return -1;
            double error;
            var result = double.TryParse(doublestring, out error);
            if (result)
                return double.Parse(doublestring);
            return -1;
        }
        /// <summary>
        /// 获取配置文件， 字符串
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static string GetString(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? "";
        }

        /// <summary>
        /// 获取配置文件，IP类型
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static IPAddress GetIp(string key)
        {
            var ip = GetString(key);
            if (ip == "")
                return null;
            IPAddress address;
            bool result= IPAddress.TryParse(ip, out address);
            if(result)
                return IPAddress.Parse(ip);
            return null;
        }

        /// <summary>
        /// 获取配置文件,时间类型
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static DateTime? GetDateTime(string key)
        {
            var time = GetString(key);
            if (time == "")
                return null;
            DateTime error;
            var result = DateTime.TryParse(time, out error);
            if (result)
                return DateTime.Parse(time);
            return null;
        }

        /// <summary>
        /// 获取配置文件,数组类型
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="seperator">分隔符</param>
        /// <returns></returns>
        public static string[] GetArray(string key, char seperator=',')
        {
            var arrayString = GetString(key);
            var arr = arrayString.Split(seperator).ToArray();
            return arr;
        }
    }
}
