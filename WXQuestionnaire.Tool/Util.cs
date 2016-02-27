using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace WXQuestionnaire.Tool
{
    public static class Util
    {


        public static string GetTuLingReply(string question) 
        {
            if (question.Length> 30)    // 不能大于30个字符串
            {
                question = question.Substring(0, 30);
            }

            string result = null;
            try
            {
                String key = "4decb8e92bd3ad7e3d8f538fc243d9ff";
                String info = question;

                UTF8Encoding encoding = new UTF8Encoding();
                  string postData="key="+key;
                  postData += ("&info="+info);
                  byte[] data = encoding.GetBytes(postData);

                  HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create("http://www.tuling123.com/openapi/api");
                  myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentLength = data.Length;
                Stream newStream = myRequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();

                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string content = reader.ReadToEnd();

                result = JObject.Parse(content)["text"].ToString();
            }
            catch (Exception)
            {
                result = "";
            }
            return result;
        }
    }
}
