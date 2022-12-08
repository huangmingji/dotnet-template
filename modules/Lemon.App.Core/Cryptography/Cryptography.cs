using System;
using System.Security.Cryptography;
using System.Text;

namespace Lemon.App.Core
{
    /// <summary>
    /// 加密相关类
    /// </summary>
    public partial class Cryptography
    {
        /// <summary>
        /// 256位AES加密
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <returns></returns>
        public static string AESEncrypt(string toEncrypt, string key)
        {
            try
            {
                // 256-AES key
                byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = keyArray;
                    aes.Mode = CipherMode.ECB;
                    aes.Padding = PaddingMode.PKCS7;

                    using (ICryptoTransform cTransform = aes.CreateEncryptor())
                    {
                        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
                    }
                }
            }
            catch (Exception)
            {
                //Logs.Utilitylogger.Error(ex, "加密失败--{0}--{1}", key, toEncrypt);
                return "";
            }
        }

        /// <summary>
        /// 256位AES解密
        /// </summary>
        /// <param name="toDecrypt"></param>
        /// <returns></returns>
        public static string AESDecrypt(string toDecrypt, string key)
        {
            if (string.IsNullOrWhiteSpace(toDecrypt))
            {
                return "";
            }

            try
            {
                // 256-AES key
                byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
                byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = keyArray;
                    aes.Mode = CipherMode.ECB;
                    aes.Padding = PaddingMode.PKCS7;

                    using (ICryptoTransform cTransform = aes.CreateDecryptor())
                    {
                        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                        return UTF8Encoding.UTF8.GetString(resultArray);
                    }
                }
            }
            catch (Exception)
            {
                //Logs.Utilitylogger.Error(ex, "解密失败--{0}--{1}", key, toDecrypt);
                return "";
            }
        }
    }
}
