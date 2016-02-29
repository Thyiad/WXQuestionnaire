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
        #region 微信常量
        /// <summary>
        /// 微信常量
        /// </summary>
        public class WXConstant
        {
            public const string APP_ID = "wx74f022031760391f";
            public const string APP_SECRET = "933b53bfa644568c20bfc12c337cea4b";

            public const string KEY_ToUserName = "ToUserName";
            public const string KEY_FromUserName = "FromUserName";
            public const string KEY_CreateTime = "CreateTime";
            public const string KEY_MsgType = "MsgType";
            public const string KEY_Content = "Content";
            public const string KEY_MsgId = "MsgId";

            public const string MsgType_Text = "text";

            public const string TPL_ReplyTxt = "~/Data/WXTemplate/WXReply_Text.xml";
        }
        #endregion

        #region AccessToken管理类
        /// <summary>
        /// AccessToken管理类
        /// </summary>
        public class WXAccessTokenManager
        {
            private class AccessToken
            {
                public string Token { get; set; }
                public DateTime ExpiresTime { get; set; }
                public bool IsValid
                {
                    get
                    {
                        if (ExpiresTime < DateTime.Now) return false;
                        else return true;
                    }
                }
            }

            private static AccessToken _token;

            public static string GetToken()
            {
                try
                {
                    if (_token == null || !_token.IsValid)
                    {
                        string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", WXConstant.APP_ID, WXConstant.APP_SECRET);
                        HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                        HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                        StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                        string content = reader.ReadToEnd();

                        DateTime now = DateTime.Now;
                        var jobject = JObject.Parse(content);
                        string token = jobject["access_token"].ToString();
                        int expires = Convert.ToInt32(jobject["expires_in"]);
                        _token = new AccessToken
                        {
                            Token = token,
                            ExpiresTime = now.AddSeconds(expires),
                        };
                    }

                    return _token.Token;
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex);
                    return null;
                }
            }
        }
        #endregion


        public static string GetReplyMsg()
        {
            var doc = WXUtil.GetMsgXML();
            var mType = WXUtil.GetContentFromWX(doc, WXUtil.WXConstant.KEY_MsgType);
            if (mType == WXUtil.WXConstant.MsgType_Text)
                return ReplyText(doc);

            return "success";   // success 或空字符串，微信不会提示服务器无法响应
        }

        private static XmlDocument GetMsgXML()
        {
            Stream stream = HttpContext.Current.Request.InputStream;
            byte[] byteArray = new byte[stream.Length];
            stream.Read(byteArray, 0, (int)stream.Length);
            string postXmlStr = System.Text.Encoding.UTF8.GetString(byteArray);
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(postXmlStr);
            return xmldoc;
        }

        private static string GetContentFromWX(XmlDocument doc, string key)
        {
            return doc.SelectSingleNode("xml").SelectSingleNode(key).InnerText;
        }

        private static string ReplyText(XmlDocument doc)
        {
            var con = WXUtil.GetContentFromWX(doc, WXUtil.WXConstant.KEY_Content);
            var frm = WXUtil.GetContentFromWX(doc, WXUtil.WXConstant.KEY_FromUserName);
            var to = WXUtil.GetContentFromWX(doc, WXUtil.WXConstant.KEY_ToUserName);
            var cre = WXUtil.GetContentFromWX(doc, WXUtil.WXConstant.KEY_CreateTime);
            var msgId = WXUtil.GetContentFromWX(doc, WXUtil.WXConstant.KEY_MsgId);

            string tpl_txt = HttpContext.Current.Server.MapPath(WXUtil.WXConstant.TPL_ReplyTxt);
            var outDoc = new XmlDocument();
            outDoc.Load(tpl_txt);
            outDoc.SelectSingleNode("xml").SelectSingleNode(WXUtil.WXConstant.KEY_ToUserName).InnerText = frm;
            outDoc.SelectSingleNode("xml").SelectSingleNode(WXUtil.WXConstant.KEY_FromUserName).InnerText = to;
            outDoc.SelectSingleNode("xml").SelectSingleNode(WXUtil.WXConstant.KEY_CreateTime).InnerText = DateUtil.ConvertDateTimeInt(DateTime.Now).ToString();
            outDoc.SelectSingleNode("xml").SelectSingleNode(WXUtil.WXConstant.KEY_MsgType).InnerText = WXUtil.WXConstant.MsgType_Text;
            outDoc.SelectSingleNode("xml").SelectSingleNode(WXUtil.WXConstant.KEY_Content).InnerText = TuLingUtil.GetReply(con);

            string outStr = XmlUtil.ConvertXmlToString(outDoc);

            return outStr;
        }
    }
}
