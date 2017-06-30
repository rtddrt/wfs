using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Wfs.Core
{
    public static class StringHelper
    {
        /// <summary>
        /// Md5加密
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static string ToMd5(this string origin)
        {
            if (string.IsNullOrWhiteSpace(origin))
            {
                return string.Empty;
            }

            var md5Algorithm = MD5.Create();
            var utf8Bytes = Encoding.UTF8.GetBytes(origin);
            var md5Hash = md5Algorithm.ComputeHash(utf8Bytes);
            var hexString = new StringBuilder();
            foreach (var hexByte in md5Hash)
            {
                hexString.Append(hexByte.ToString("x2"));
            }
            return hexString.ToString();
        }

        /// <summary>
        /// 密码加密(两次MD5加密)
        /// </summary>
        /// <param name="plainPwd"></param>
        /// <returns></returns>
        public static string EncryptPwd(this string plainPwd)
        {
            if (string.IsNullOrWhiteSpace(plainPwd))
            {
                return string.Empty;
            }

            return (plainPwd.ToMd5()).ToMd5();
        }

        /// <summary>
        /// 获取当前的时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetNowTimespan()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ToTimespan(this DateTime time)
        {
            TimeSpan ts = time - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        public static string TimeToString(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
