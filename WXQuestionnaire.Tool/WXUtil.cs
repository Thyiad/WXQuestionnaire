using Newtonsoft.Json;
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

        #region 获取AccessToken
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
        public static string GetAccessToken()
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
        #endregion

        #region 获取 jsapi_ticket
        private class JsApiTicket
        {
            public string Ticket { get; set; }
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

        private static JsApiTicket _ticket;
        public static string GetJsApiTicket()
        {
            if (_ticket == null || !_ticket.IsValid)
            {
                string url = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi", GetAccessToken());
                HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string content = reader.ReadToEnd();

                DateTime now = DateTime.Now;
                var jobject = JObject.Parse(content);
                string ticket = jobject["ticket"].ToString();
                int expires = Convert.ToInt32(jobject["expires_in"]);
                _ticket = new JsApiTicket
                {
                    Ticket = ticket,
                    ExpiresTime = now.AddSeconds(expires),
                };
            }

            return _ticket.Ticket;
        }
        #endregion

        #region 获取 Js Sdk 配置
        public class WXJsSdkConfig
        {
            [JsonProperty("debug")]
            public bool Debug { get; set; }
            [JsonProperty("appId")]
            public string AppId
            {
                get
                {
                    return WXConstant.APP_ID;
                }
            }
            [JsonProperty("timestamp")]
            public string TimeStamp { get; set; }
            [JsonProperty("nonceStr")]
            public string NonceStr { get; set; }
            [JsonProperty("signature")]
            public string Signature { get; set; }
            [JsonProperty("jsApiList")]
            public string JsApiList
            {
                get{
                    return "\"chooseImage\", \"previewImage\", \"uploadImage\", \"downloadImage\"";
                }
            }
        }

        public static WXJsSdkConfig GetJsSdkConfig()
        {
            string timestamp = DateUtil.GetTimestamp();
            string noncestr = StrUtil.GetNonceStr();

            // 获取signature
            string ticket = GetJsApiTicket();
            string url =  "http://"+HttpContext.Current.Request.Url.Host+HttpContext.Current.Request.Url.AbsolutePath;
            // string url = HttpContext.Current.Request.Url.AbsoluteUri;
            if (url.IndexOf("#") > 0)
                url = url.Substring(0, url.IndexOf("#"));
            List<string> strNonce = new List<string>() 
            { 
                string.Format("noncestr={0}", noncestr),
                string.Format("jsapi_ticket={0}",ticket),
                string.Format("timestamp={0}",timestamp),
                string.Format("url={0}",url)    // url 不包含#及其后面部分
            };
            strNonce.Sort();
            string jointStr = string.Join("&", strNonce.ToArray());
            string sha1Str = EncryptUtil.SHA1Encrypt(jointStr);

            string signature = sha1Str;
            WXJsSdkConfig config = new WXJsSdkConfig()
            {
                Debug = true,
                TimeStamp = timestamp,
                NonceStr = noncestr,
                Signature = signature,
            };

            return config;
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
            outDoc.SelectSingleNode("xml").SelectSingleNode(WXUtil.WXConstant.KEY_CreateTime).InnerText = DateUtil.GetTimestamp();
            outDoc.SelectSingleNode("xml").SelectSingleNode(WXUtil.WXConstant.KEY_MsgType).InnerText = WXUtil.WXConstant.MsgType_Text;
            outDoc.SelectSingleNode("xml").SelectSingleNode(WXUtil.WXConstant.KEY_Content).InnerText = TuLingUtil.GetReply(con);

            string outStr = XmlUtil.ConvertXmlToString(outDoc);

            return outStr;
        }
    }
}
