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
            "慧眼识人-店铺人员招聘与管理 系列一",
            "人才储备-培养",
            "零售锦囊",
        };
        public static List<string> Q12Names = new List<string> { 
            "零售锦囊",
            "零售管理",
            "慧眼识人-店铺人员招聘与管理 系列一",
            "人才储备-培养",
        };
        public static List<string> Q13Names = new List<string> { 
            "SU16市场推广",
            "SU16新品发布-鞋",
            "SU16新品发布-服装",
            "VM:陈列实操",
            "SU16陈列指引",
        };
        public static List<string> Q14Names = new List<string> { 
            "零售规划",
            "商品规划",
            "SU16市场推广",
            "SU16新品发布-鞋",
            "SU16新品发布-服装",
        };
        public static List<string> Q21Names = new List<string> { 
            "零售规划",
            "商品规划",
            "视觉营销管理",
            "行动计划",
        };
        public static List<string> Q22Names = new List<string> { 
            "零售规划",
            "商品规划",
            "视觉营销管理",
            "行动计划",
        };
        public static List<string> Q23Names = new List<string> { 
            "培训:人才储备-培养",
            "培训:零售锦囊",
            "VM:陈列指引",
            "VM:陈列实操",
            "行动计划",
        };
        public static List<string> Q24Names = new List<string> { 
            "VM:陈列指引",
            "VM:陈列实操",
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
    }
}
