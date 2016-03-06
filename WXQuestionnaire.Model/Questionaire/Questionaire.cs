using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXQuestionnaire.Model.Questionaire
{
    public class Questionaire
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string CustomerType { get; set; }
        public string Position{ get; set; }
        public int QuestionaireType { get; set; }
        public string QuestionaireDetail { get; set; }
    }
}
