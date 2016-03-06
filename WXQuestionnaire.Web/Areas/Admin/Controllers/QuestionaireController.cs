using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WXQuestionnaire.Model.Questionaire;

namespace WXQuestionnaire.Web.Areas.Admin.Controllers
{
    public class QuestionaireController : Controller
    {
        public ActionResult QueryStat(int qtype) {
            ViewBag.QuestionaireType = (QuestionaireTypes)Enum.ToObject(typeof(QuestionaireTypes), qtype);
            return View();
        }

        public ActionResult QueryDetail(int qtype)
        {
            ViewBag.QuestionaireType = (QuestionaireTypes)Enum.ToObject(typeof(QuestionaireTypes), qtype);
            return View();
        }
    }
}