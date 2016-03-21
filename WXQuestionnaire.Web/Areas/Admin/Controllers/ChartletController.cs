using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WXQuestionnaire.Web.Areas.Admin.Controllers
{
    public class ChartletController : Controller
    {
        WXQuestionnaire.BLL.Chartlet.ChartletService _chartletService = new BLL.Chartlet.ChartletService();
        // GET: Admin/Chartlet
        public ActionResult Index()
        {
            var chartlets = _chartletService.GetAllChartlet();
            return View(chartlets);
        }
    }
}