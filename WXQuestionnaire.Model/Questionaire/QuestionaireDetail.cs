using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXQuestionnaire.Model.Questionaire
{
    public enum QuestionaireTypes
    {
        // 第一天
        店长兼商品场D1 = 11,
        品牌经理兼督导D1 = 12,
        培训兼陈列D1 = 13,
        //商品D1 = 14,

        // 第二天
        店长兼商品场D2 = 21,
        品牌经理兼督导D2 = 22,
        陈列D2 = 23,
        培训D2 = 24,
    }

    public class QuestionaireDetail
    {
        public bool Q01 { get; set; }
        public bool Q02 { get; set; }
        public bool Q03 { get; set; }

        public bool Q11 { get; set; }
        public bool Q12 { get; set; }
        public bool Q13 { get; set; }
        public bool Q14 { get; set; }
        public bool Q15 { get; set; }
        public bool Q16 { get; set; }

        public bool Q21 { get; set; }
        public bool Q22 { get; set; }
        public bool Q23 { get; set; }
        public bool Q24 { get; set; }
        public bool Q25 { get; set; }
        public bool Q26 { get; set; }

        public bool Q31 { get; set; }
        public bool Q32 { get; set; }
        public bool Q33 { get; set; }
        public bool Q34 { get; set; }
        public bool Q35 { get; set; }
        public bool Q36 { get; set; }

        public bool Q41 { get; set; }
        public bool Q42 { get; set; }
        public bool Q43 { get; set; }
        public bool Q44 { get; set; }
        public bool Q45 { get; set; }
        public bool Q46 { get; set; }

        public bool Q51 { get; set; }
        public bool Q52 { get; set; }
        public bool Q53 { get; set; }
        public bool Q54 { get; set; }
        public bool Q55 { get; set; }
        public bool Q56 { get; set; }

        public bool Q61 { get; set; }
        public bool Q62 { get; set; }
        public bool Q63 { get; set; }
        public bool Q64 { get; set; }
        public bool Q65 { get; set; }
        public bool Q66 { get; set; }
        
        public bool Q71 { get; set; }
        public bool Q72 { get; set; }
        public bool Q73 { get; set; }
        public bool Q74 { get; set; }
        public bool Q75 { get; set; }
        public bool Q76 { get; set; }

        public bool Q81 { get; set; }
        public bool Q82 { get; set; }
        public bool Q83 { get; set; }
        public bool Q84 { get; set; }
        public bool Q85 { get; set; }
        public bool Q86 { get; set; }

        public bool Q91 { get; set; }
        public bool Q92 { get; set; }
        public bool Q93 { get; set; }
        public bool Q94 { get; set; }
        public bool Q95 { get; set; }
        public bool Q96 { get; set; }
    }
}
