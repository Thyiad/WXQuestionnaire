using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mQuestionaire = WXQuestionnaire.Model.Questionaire;
using WXQuestionnaire.DAL;
using WXQuestionnaire.Tool;

namespace WXQuestionnaire.BLL.Questionaire
{
    public class QuestionaireService
    {
        public bool AddQuestionaire(mQuestionaire.Questionaire questionaire)
        {
            if (questionaire == null)
            {
                return false;
            }

            try
            {
                using (EFContext context = new EFContext())
                {
                    context.Questionaires.Add(questionaire);
                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return false;
            }

        }
    }
}
