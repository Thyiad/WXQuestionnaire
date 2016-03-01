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
        public ContentResult AuthWX(string signature, string timestamp, string nonce, string echostr)
        {
            List<string> strList = new List<string>() { TOKEN, timestamp, nonce };
            strList.Sort();
            var result = string.Join("", strList.ToArray());
            var hashResult = WXQuestionnaire.Tool.EncryptUtil.SHA1Encrypt(result);

            if (hashResult == signature)
                return Content(echostr);
            else
                return Content("false"); ;
        }

        [HttpPost]
        public ActionResult AuthWX()
        {
            var msg = WXUtil.GetReplyMsg();
            return Content(msg);
        }

        public ActionResult Other()
        {
            return View();
        }
    }
}