using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WXQuestionnaire.Tool
{
    public static class EncryptUtil
    {
        /// <summary>
        /// MD5加密字符串
        /// </summary>
        /// <param name="encypStr"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetMD5(string encypStr, Encoding encoding)
        {
            string retStr;
            MD5CryptoServiceProvider m5 = new MD5CryptoServiceProvider();

            //创建md5对象
            byte[] inputBye;
            byte[] outputBye;

            //使用GB2312编码方式把字符串转化为字节数组．
            try
            {
                inputBye = encoding.GetBytes(encypStr);
            }
            catch (Exception ex)
            {
                inputBye = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
            }
            outputBye = m5.ComputeHash(inputBye);

            retStr = System.BitConverter.ToString(outputBye);
            retStr = retStr.Replace("-", "").ToUpper();
            return retStr;
        }

        /// <summary>
        /// SHA1加密字符串
        /// </summary>
        /// <param name="EncryptText"></param>
        /// <returns></returns>
        public static string SHA1Encrypt(string EncryptText)
        {
            byte[] StrRes = Encoding.Default.GetBytes(EncryptText);
            SHA1CryptoServiceProvider mySHA = new SHA1CryptoServiceProvider();
            StrRes = mySHA.ComputeHash(StrRes);
            StringBuilder EnText = new StringBuilder();
            foreach (byte Byte in StrRes)
            {
                EnText.AppendFormat("{0:x2}", Byte);
            }
            return EnText.ToString();
        }
    }
}
