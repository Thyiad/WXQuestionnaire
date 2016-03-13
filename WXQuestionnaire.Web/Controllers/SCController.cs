using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WXQuestionnaire.BLL.Admin;
using WXQuestionnaire.BLL.Chartlet;
using WXQuestionnaire.Model.Questionaire;
using WXQuestionnaire.Tool;
using WXQuestionnaire.BLL.Questionaire;
using Newtonsoft.Json.Linq;

namespace WXQuestionnaire.Web.Controllers
{
    /// <summary>
    /// 公众号SoundCheck的回调页面
    /// </summary>
    public class SCController : Controller
    {
        private StatService _statService = new StatService();
        private ChartletService _chartletService = new ChartletService();
        private QuestionaireService _questionaireService = new QuestionaireService();

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

        /// <summary>
        /// 调查问卷页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Questionaire() {
            return View();
        }

        private const int LotteryPrizerNum = 8;
        private const int QuestionairePrizerNum = 1;
        public ActionResult AddPrizeWinner(string type)
        {
            bool ok = false;

            try
            {
                var stat = _statService.GetStart();
                switch (type)
                {
                    // 九宫格抽奖
                    case "00":
                        ok = (stat != null && stat.PrizeWinnerNum < LotteryPrizerNum);
                        if(ok) stat.PrizeWinnerNum++;
                        break;
                    // 店长D1
                    case "11":
                        ok = (stat != null && stat.D1DZPrizeNum < QuestionairePrizerNum);
                        if (ok) stat.D1DZPrizeNum++;
                        break;
                    // 品牌经理兼督导D1
                    case "12":
                        ok = (stat != null && stat.D1PPJLDDPrizeNum < QuestionairePrizerNum);
                         if (ok) stat.D1PPJLDDPrizeNum++;
                        break;
                    // 培训兼陈列D1
                    case "13":
                        ok = (stat != null && stat.D1CLPXPrizeNum < QuestionairePrizerNum);
                         if (ok) stat.D1CLPXPrizeNum++;
                        break;
                    // 商品D1
                    case "14":
                        ok = (stat != null && stat.D1SPPrizeNum < QuestionairePrizerNum);
                         if (ok) stat.D1SPPrizeNum++;
                        break;
                    // 店长D2
                    case "21":
                        ok = (stat != null && stat.D2DZPrizeNum < QuestionairePrizerNum);
                        if (ok) stat.D2DZPrizeNum++;
                        break;
                    // 品牌经理兼督导D2
                    case "22":
                        ok = (stat != null && stat.D2PPJLDDPrizeNum < QuestionairePrizerNum);
                        if (ok) stat.D2PPJLDDPrizeNum++;
                        break;
                    // 陈列兼培训D2
                    case "23":
                        ok = (stat != null && stat.D2CLPXPrizeNum < QuestionairePrizerNum);
                        if (ok) stat.D2CLPXPrizeNum++;
                        break;
                    // 陈列D2
                    case "24":
                        ok = (stat != null && stat.D2CLPrizeNum < QuestionairePrizerNum);
                        if (ok) stat.D2CLPrizeNum++;
                        break;
                    default:
                        break;
                }

                
                if (ok)
                    ok = _statService.UpdateStat(stat);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }

            return Json(new { ok = ok }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GenerateChartlet(string serverID, string msg, string signName)
        {
            try
            {
                var chartlet = _chartletService.GenerateChartlet(serverID, msg, signName);
                if (chartlet == null)
                    return Json(new { ok = false, msg = "生成图片失败" });
                return Json(new { ok = true,id=chartlet.ID,msg = "生成图片成功" },JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return Json(new { ok = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult PreDownloadChartlet()
        {
            return View();
        }

        public ActionResult DownloadChartlet(int id)
        {
            if (id<=0)
                return Content("未传入id");
            var chartlet = _chartletService.GetChartlet(id);
            if (chartlet == null)
                return Content("找不到 ["+id+"] 对应的图片");

            return File(Server.MapPath(chartlet.BuildImgPath), "image/jpeg", "Chartlet.jpg");
        }

        public JsonResult UploadQuestionaire(int qtype, string qdata, string user)
        {
            try
            {
                // 转换一下，确定参数合法
                QuestionaireTypes type = (QuestionaireTypes)Enum.ToObject(typeof(QuestionaireTypes), qtype);
                QuestionaireDetail data = JsonConvert.DeserializeObject<QuestionaireDetail>(qdata);
                var juser = JObject.Parse(user);
                string uname = juser["name"].ToString();
                string customerType = juser["customerType"].ToString();
                string position = juser["position"].ToString();
                if (string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(customerType) ||string.IsNullOrEmpty(position))
                {
                    throw new Exception("用户信息不正确");
                }

                Questionaire questionaire = new Questionaire() { 
                    Name = uname,
                    CustomerType = customerType,
                    Position = position,
                    QuestionaireType = qtype,
                    QuestionaireDetail = qdata,
                    QTime= DateTime.Now,
                };

                if (!_questionaireService.AddQuestionaire(questionaire))
                    throw new Exception("保存问卷信息失败");

                return Json(new { ok=true, msg="提交问卷成功"},JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return Json(new { ok = false,msg="提交问卷失败" },JsonRequestBehavior.AllowGet);
            }
        }
    }
}