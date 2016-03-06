using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static Size MeasureString(string s, Font font)
        {
            Size size = TextRenderer.MeasureText(s, font);
            return size;
        }

        public static string GetSpecificallyWidthStrFromStr(int width, string value, Font font)
        {
            string measuredString = string.Empty;
            try
            {
                char[] charArray = value.ToCharArray();
                StringBuilder sBuilder = new StringBuilder();
                foreach (char cha in charArray)
                {
                    sBuilder.Append(cha);
                    measuredString = sBuilder.ToString();
                    if (TextRenderer.MeasureText(measuredString, font).Width > width)
                    {
                        measuredString.Remove(measuredString.Length - 1);
                        break;
                    }
                }
            }
            catch (Exception exp)
            {
                LogHelper.Error(exp);
                return null;
            }

            return measuredString;
        }

        public static List<string> SplitStringByWidth(string str, int width, Font font)
        {
            List<string> strList = new List<string>();
            try
            {
                var size = MeasureString(str, font);
                if (size.Width < width)
                {
                    strList.Add(str);
                    return strList;
                }

                string leaveStr = str;
                while (!string.IsNullOrEmpty(leaveStr))
                {
                    string line = GetSpecificallyWidthStrFromStr(width, leaveStr, font);
                    strList.Add(line);
                    leaveStr = leaveStr.Remove(0, line.Length);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }

            return strList;
        }
    }
}
