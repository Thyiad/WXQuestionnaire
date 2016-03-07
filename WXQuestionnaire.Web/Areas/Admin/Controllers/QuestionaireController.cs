using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WXQuestionnaire.Model.Questionaire;
using WXQuestionnaire.Web.Areas.Admin.Infrastructure;

namespace WXQuestionnaire.Web.Areas.Admin.Controllers
{
    [AdminAuthentication]
    public class QuestionaireController : Controller
    {
        private WXQuestionnaire.BLL.Questionaire.QuestionaireService _questionaireService = new BLL.Questionaire.QuestionaireService();

        public ActionResult QueryStat(int qtype) {
            var questionaireType = (QuestionaireTypes)Enum.ToObject(typeof(QuestionaireTypes), qtype);
            ViewBag.QuestionaireType = questionaireType;
            var statVM = _questionaireService.GetQuestionaireStat(questionaireType);
            return View(statVM);
        }

        public ActionResult QueryDetail(int qtype)
        {
            var questionaireType = (QuestionaireTypes)Enum.ToObject(typeof(QuestionaireTypes), qtype);
            ViewBag.QuestionaireType = questionaireType;
            var qlist = _questionaireService.GetQuestionaires(questionaireType);
            return View(qlist);
        }

        public ActionResult QueryDetailByQID(int qid) {
            var qdetail = _questionaireService.GetQuestionaireDetailStat(qid);
            return View(qdetail);
        }
    }
}