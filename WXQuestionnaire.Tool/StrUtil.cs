using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXQuestionnaire.Tool
{
    public static class StrUtil
    {
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <returns></returns>
        public static string GetNonceStr()
        {
            Random random = new Random();
            return EncryptUtil.GetMD5(random.Next(1000).ToString(), Encoding.UTF8);
        }
    }
}
