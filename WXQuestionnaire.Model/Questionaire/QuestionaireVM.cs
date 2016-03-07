using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXQuestionnaire.Model.Questionaire
{
    public class QuestionaireVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CustomerType { get; set; }
        public string Position { get; set; }
        public DateTime? QTime { get; set; }
    }
}
