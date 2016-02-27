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
