using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXQuestionnaire.Model.Questionaire
{
    public class QuestionaireConstants
    {
        public static List<string> Q11Names = new List<string> { 
            "SU16 开季指引-市场推广",
            "SU16 开季指引-新品发布",
            "SU16 开季指引－陈列指引",
            "商品规划",
            "零售规划",
            "视觉营销管理",
            "零售日志的运用",
            "后仓管理",
            "MSP带教培训",
        };
        public static List<string> Q12Names = new List<string> {
            "Leadership领导力",
            "零售日志的运用",
            "后仓管理",
            "MSP带教培训",
            "慧眼识人-店铺人员招聘与管理系列",
            "知人善用-优质新员工的养成",
        };
        public static List<string> Q13Names = new List<string> {
            "开季指引-SU16市场推广",
            "开季指引-SU16新品发布-鞋类",
            "开季指引-SU16新品发布-服装",
            "开季指引－SU16陈列指引",
        };
        //public static List<string> Q14Names = new List<string> { 
        //    "零售规划",
        //    "商品规划",
        //    "SU16市场推广",
        //    "SU16新品发布-鞋",
        //    "SU16新品发布-服装",
        //};
        public static List<string> Q21Names = new List<string> {
            "慧眼识人-店铺人员招聘与管理系列",
            "知人善用-优质新员工的养成",
            "行动计划",
        };
        public static List<string> Q22Names = new List<string> {
            "视觉营销管理",
            "零售规划",
            "商品规划",
            "行动计划",
        };
        public static List<string> Q23Names = new List<string> {
            "开季指引－SU16陈列指引",
            "开季指引－SU16陈列实操",
            "行动计划",
        };
        public static List<string> Q24Names = new List<string> {
            "知人善用-优质新员工的养成",
            "零售日志的运用",
            "后仓管理",
            "MSP带教培训",
            "行动计划",
        };
    }

    public class QuestionaireStatVM
    {
        public class QuestionStat
        {
            public string QuestionName { get; set; }
            public int SubQ1Num { get; set; }
            public int SubQ2Num { get; set; }
            public int SubQ3Num { get; set; }
            public int SubQ4Num { get; set; }
            public int SubQ5Num { get; set; }
            public int SubQ6Num { get; set; }
        }

        public List<QuestionStat> QuestionStats { get; set; }

        public int Q01Num { get; set; }
        public int Q02Num { get; set; }
        public int Q03Num { get; set; }

        public int QuestionaireCount { get; set; }
    }
}
