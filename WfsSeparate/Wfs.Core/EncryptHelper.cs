using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Wfs.Core
{
    /// <summary>
    /// 加密解密类
    /// </summary>
    public static class EncryptHelper
    {
        private static string encryptKey = "!]=-o%SCxN,v+i0za}w_`yR[s;/dp^K2";

        //默认密钥向量
        private static byte[] Keys = { 0x11, 0x12, 0x13, 0x14, 0x15, 0x1F, 0x23, 0x21, 0x1F, 0x20, 0x1E, 0x22, 0x23, 0x23, 0x1E, 0x23 };
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptString"></param>
        /// <returns></returns>
        public static string Encrypt(string encryptString)
        {
            if (string.IsNullOrEmpty(encryptString))
                return string.Empty;
            RijndaelManaged rijndaelProvider = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32)),
                IV = Keys
            };
            ICryptoTransform rijndaelEncrypt = rijndaelProvider.CreateEncryptor();

            byte[] inputData = Encoding.UTF8.GetBytes(encryptString);
            byte[] encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData, 0, inputData.Length);

            return Convert.ToBase64String(encryptedData);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptString"></param>
        /// <returns></returns>
        public static string Decrypt(string decryptString)
        {
            if (string.IsNullOrEmpty(decryptString))
                return string.Empty;
            try
            {
                RijndaelManaged rijndaelProvider = new RijndaelManaged
                {
                    Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32)),
                    IV = Keys
                };
                ICryptoTransform rijndaelDecrypt = rijndaelProvider.CreateDecryptor();
                byte[] inputData = Convert.FromBase64String(decryptString);
                byte[] decryptedData = rijndaelDecrypt.TransformFinalBlock(inputData, 0, inputData.Length);

                return Encoding.UTF8.GetString(decryptedData);
            }
            catch
            {
                return "";
            }
        }
    }
}
