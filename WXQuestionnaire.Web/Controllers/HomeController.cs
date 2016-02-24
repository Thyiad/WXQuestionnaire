using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using WXQuestionnaire.Tool;

namespace WXQuestionnaire.Web.Controllers
{
    public class HomeController : Controller
    {
        public const string TOKEN = "haileyz";

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        /// <summary>
        /// 微信验证，参考URL：http://mp.weixin.qq.com/wiki/8/f9a0b8382e0b77d87b3bcc1ce6fbc104.html
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="echostr"></param>
        /// <returns></returns>
        public ContentResult AuthWX(string signature,string timestamp, string nonce, string echostr)
        {
            List<string> strList = new List<string>() { TOKEN, timestamp, nonce };
            strList.Sort();
            var result = string.Join("", strList.ToArray());
            var hashResult = WXQuestionnaire.Tool.Util.SHA1Encrypt(result);

            if (hashResult == signature)
                return Content(echostr);
            else
                return Content("false"); ;
        }

        [HttpPost]
        public ActionResult AuthWX()
        {
            var doc = WXUtil.GetMsgXML();
            var mType = WXUtil.GetContentFromWX(doc,WXUtil.WXConstant.KEY_MsgType);
            if (mType == WXUtil.WXConstant.MsgType_Text)
                return ReplyTxtMsg(doc);

            return Content("success");   // success 或空字符串，微信不会提示服务器无法响应
        }
        public ActionResult Other() {
            return View();
        }

        private ActionResult ReplyTxtMsg(XmlDocument doc) 
        {
            var con = WXUtil.GetContentFromWX(doc, WXUtil.WXConstant.KEY_Content);
            var frm = WXUtil.GetContentFromWX(doc, WXUtil.WXConstant.KEY_FromUserName);
            var to = WXUtil.GetContentFromWX(doc, WXUtil.WXConstant.Key_ToUserName);
            var cre = WXUtil.GetContentFromWX(doc, WXUtil.WXConstant.KEY_CreateTime);
            var msgId = WXUtil.GetContentFromWX(doc, WXUtil.WXConstant.KEY_MsgId);

            string tpl_txt = Server.MapPath(WXUtil.WXConstant.TPL_ReplyTxt);
            var outDoc = new XmlDocument();
            outDoc.Load(tpl_txt);
            outDoc.SelectSingleNode("xml").SelectSingleNode(WXUtil.WXConstant.Key_ToUserName).InnerText = frm;
            outDoc.SelectSingleNode("xml").SelectSingleNode(WXUtil.WXConstant.KEY_FromUserName).InnerText = to;
            outDoc.SelectSingleNode("xml").SelectSingleNode(WXUtil.WXConstant.KEY_CreateTime).InnerText = Util.ConvertDateTimeInt(DateTime.Now).ToString();
            outDoc.SelectSingleNode("xml").SelectSingleNode(WXUtil.WXConstant.KEY_MsgType).InnerText = WXUtil.WXConstant.MsgType_Text;
            outDoc.SelectSingleNode("xml").SelectSingleNode(WXUtil.WXConstant.KEY_Content).InnerText = Util.GetTuLingReply(con);

            string outStr = Util.ConvertXmlToString(outDoc);

            return Content(outStr);
        }
    }
}