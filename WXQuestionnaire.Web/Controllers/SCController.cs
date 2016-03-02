using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WXQuestionnaire.BLL.Admin;
using WXQuestionnaire.Tool;

namespace WXQuestionnaire.Web.Controllers
{
    /// <summary>
    /// 公众号SoundCheck的回调页面
    /// </summary>
    public class SCController : Controller
    {
        private StatService _statService = new StatService();

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
            try
            {
                var config = WXUtil.GetJsSdkConfig();
                ViewBag.JsSdkConfig = config;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }

            return View();
        }

        public ActionResult AddPrizeWinner()
        {
            bool ok = false;

            try
            {
                var stat = _statService.GetStart();
                ok = (stat != null && stat.PrizeWinnerNum < 8);
                if (ok)
                {
                    stat.PrizeWinnerNum++;
                    ok = _statService.UpdateStat(stat);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }

            return Json(new { ok = ok }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetImg() {
            return File(Server.MapPath("~/Data/WXImages/test.jpg"), "application/octet-stream", "Chartlet.jpg");
        }
    }
}