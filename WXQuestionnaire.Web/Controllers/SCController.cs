using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WXQuestionnaire.Web.Controllers
{
    /// <summary>
    /// 公众号SoundCheck的回调页面
    /// </summary>
    public class SCController : Controller
    {
        /// <summary>
        /// 九宫格抽奖页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Lottery()
        {
            return View();
        }

        /// <summary>
        /// 图片及寄语页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Chartlet()
        {
            return View();
        }
    }
}