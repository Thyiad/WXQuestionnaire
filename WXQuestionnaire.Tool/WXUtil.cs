using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace WXQuestionnaire.Tool
{
    public static class WXUtil
    {
        public class WXConstant
        {
            public const string Key_ToUserName = "ToUserName";
            public const string KEY_FromUserName = "FromUserName";
            public const string KEY_CreateTime = "CreateTime";
            public const string KEY_MsgType = "MsgType";
            public const string KEY_Content = "Content";
            public const string KEY_MsgId = "MsgId";

            public const string MsgType_Text = "text";

            public const string TPL_ReplyTxt = "~/Data/WXTemplate/WXReply_Text.xml";
        }

        public static XmlDocument GetMsgXML()
        {
            Stream stream = HttpContext.Current.Request.InputStream;
            byte[] byteArray = new byte[stream.Length];
            stream.Read(byteArray, 0, (int)stream.Length);
            string postXmlStr = System.Text.Encoding.UTF8.GetString(byteArray);
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(postXmlStr);
            return xmldoc;
        }

        public static string GetContentFromWX(XmlDocument doc, string key) 
        {
            return doc.SelectSingleNode("xml").SelectSingleNode(key).InnerText;
        }
    }
}
