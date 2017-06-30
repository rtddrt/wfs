using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Wfs.Core
{
    public static class NullHelper
    {
        public static Guid ToGuid(this string src)
        {
            var error = Guid.Empty;
            if (string.IsNullOrEmpty(src))
                return error;

            if(Guid.TryParse(src,out error))
                return new Guid(src);
            return error;
        }

        /// <summary>
        /// 将[guid1,guid2,guid3,guid4]字符串，转换成数组
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Guid[] ToGuidArray(this string src)
        {
            var idArray = src.Split(',');
            var guidArray=new Guid[idArray.Length];
            for (int i = 0; i < idArray.Length; i++)
            {
                guidArray[i] = idArray[i].ToGuid();
            }
            return guidArray;
        }

        public static int ToInt(this string src)
        {
            int error = -1;
            if (string.IsNullOrEmpty(src))
                return error;

            if (int.TryParse(src, out error))
                return int.Parse(src);
            return error;
        }

        public static DateTime ToDateTime(this string src)
        {
            var error = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            if (string.IsNullOrEmpty(src))
                return error;

            if (DateTime.TryParse(src, out error))
                return DateTime.Parse(src);
            return error;
        }

        /// <summary>
        /// 转换为起始时间(1970-01-01 00:00:00:000)
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static DateTime ToInitTime()
        {
            return new DateTime(1970,1,1,0,0,0,0);         
        }

        /// <summary>
        /// 2099-12-31 23:59:59:999
        /// </summary>
        /// <returns></returns>
        public static DateTime ToMaxTime()
        {
            return new DateTime(2099, 12, 31, 23, 59, 59, 999);
        }

        /// <summary>
        /// 内存流转换为字节数组
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        /// <summary>
        /// 字节数组转换为内存流
        /// </summary>
        /// <param name="byteArr"></param>
        /// <returns></returns>
        public static MemoryStream ToStream(this byte[] byteArr)
        {
            MemoryStream stream = new MemoryStream(byteArr);
            return stream;
        }
    }
}
