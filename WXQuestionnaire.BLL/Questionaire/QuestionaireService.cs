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

        /// <summary>
        /// 获取每个问卷的统计信息
        /// </summary>
        /// <param name="qtype"></param>
        /// <returns></returns>
        public mQuestionaire.QuestionaireStatVM GetQuestionaireStat(mQuestionaire.QuestionaireTypes qtype)
        {
            mQuestionaire.QuestionaireStatVM statVM = new mQuestionaire.QuestionaireStatVM();

            try
            {
                using (EFContext context = new EFContext())
                {
                    var qList = context.Questionaires.Where(q => q.QuestionaireType == (int)qtype).ToList();
                    statVM.QuestionaireCount = qList.Count;
                    var detailList = qList.Select(q => Newtonsoft.Json.JsonConvert.DeserializeObject<mQuestionaire.QuestionaireDetail>(q.QuestionaireDetail)).ToList();
                    // 项目组织安排
                    statVM.Q01Num = detailList.Count(d => d.Q01);
                    statVM.Q02Num = detailList.Count(d => d.Q02);
                    statVM.Q03Num = detailList.Count(d => d.Q03);
                    // 课程及讲师反馈
                    statVM.QuestionStats = InitQStat(detailList, qtype);       // 智能插入子问题数量

                    // 根据问卷类型设置每个问题的名字
                    for (int i = 0; i < statVM.QuestionStats.Count; i++)
                    {
                        statVM.QuestionStats[i].QuestionName = GetQName(qtype, i);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }

            return statVM;
        }
        /// <summary>
        /// 获取指定类型的所有问卷
        /// </summary>
        /// <param name="qtype"></param>
        /// <returns></returns>
        public List<mQuestionaire.QuestionaireVM> GetQuestionaires(mQuestionaire.QuestionaireTypes qtype)
        {
            List<mQuestionaire.QuestionaireVM> qvms = new List<mQuestionaire.QuestionaireVM>();
            try
            {
                using (EFContext context = new EFContext())
                {
                    var qlist = context.Questionaires.Where(q => q.QuestionaireType == (int)qtype).ToList();
                    qlist.ForEach(q => qvms.Add(new mQuestionaire.QuestionaireVM
                    {
                        ID = q.ID,
                        Name=q.Name,
                        CustomerType = q.CustomerType,
                        Position = q.Position,
                        QTime = q.QTime
                    }));
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return qvms;
        }

        /// <summary>
        /// 获取问卷详情
        /// </summary>
        /// <param name="qid"></param>
        /// <returns></returns>
        public mQuestionaire.QuestionaireStatVM GetQuestionaireDetailStat(int qid)
        {
            mQuestionaire.QuestionaireStatVM statVM = new mQuestionaire.QuestionaireStatVM();

            try
            {
                using (EFContext context = new EFContext())
                {
                    var questionaire = context.Questionaires.Where(q => q.ID == qid).FirstOrDefault();
                    statVM.QuestionaireCount = 1;
                    var detail = Newtonsoft.Json.JsonConvert.DeserializeObject<mQuestionaire.QuestionaireDetail>(questionaire.QuestionaireDetail);
                    // 项目组织安排
                    statVM.Q01Num = detail.Q01 ? 1 : 0;
                    statVM.Q02Num = detail.Q02 ? 1 : 0;
                    statVM.Q03Num = detail.Q03 ? 1 : 0;
                    // 课程及讲师反馈
                    mQuestionaire.QuestionaireTypes qtype = (mQuestionaire.QuestionaireTypes)Enum.ToObject(typeof(mQuestionaire.QuestionaireTypes), questionaire.QuestionaireType);
                    statVM.QuestionStats = InitQStat(new List<mQuestionaire.QuestionaireDetail> { detail }, qtype);       // 智能插入子问题数量

                    // 根据问卷类型设置每个问题的名字
                    for (int i = 0; i < statVM.QuestionStats.Count; i++)
                    {
                        statVM.QuestionStats[i].QuestionName = GetQName(qtype, i);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }

            return statVM;
        }

        private List<mQuestionaire.QuestionaireStatVM.QuestionStat> InitQStat(List<mQuestionaire.QuestionaireDetail> detailList, mQuestionaire.QuestionaireTypes qtype)
        {
            var qstartlist = new List<mQuestionaire.QuestionaireStatVM.QuestionStat>(){
                new mQuestionaire.QuestionaireStatVM.QuestionStat { 
                            QuestionName= "第1个问题",
                            SubQ1Num = detailList.Count(d => d.Q11),
                            SubQ2Num = detailList.Count(d => d.Q12),
                            SubQ3Num = detailList.Count(d => d.Q13),
                            SubQ4Num = detailList.Count(d => d.Q14),
                            SubQ5Num = detailList.Count(d => d.Q15),
                            SubQ6Num = detailList.Count(d => d.Q16),
                        },
                        new mQuestionaire.QuestionaireStatVM.QuestionStat { 
                            QuestionName= "第2个问题",
                            SubQ1Num = detailList.Count(d => d.Q21),
                            SubQ2Num = detailList.Count(d => d.Q22),
                            SubQ3Num = detailList.Count(d => d.Q23),
                            SubQ4Num = detailList.Count(d => d.Q24),
                            SubQ5Num = detailList.Count(d => d.Q25),
                            SubQ6Num = detailList.Count(d => d.Q26),
                        },
                        new mQuestionaire.QuestionaireStatVM.QuestionStat { 
                            QuestionName= "第3个问题",
                            SubQ1Num = detailList.Count(d => d.Q31),
                            SubQ2Num = detailList.Count(d => d.Q32),
                            SubQ3Num = detailList.Count(d => d.Q33),
                            SubQ4Num = detailList.Count(d => d.Q34),
                            SubQ5Num = detailList.Count(d => d.Q35),
                            SubQ6Num = detailList.Count(d => d.Q36),
                        },
                        new mQuestionaire.QuestionaireStatVM.QuestionStat { 
                            QuestionName= "第4个问题",
                            SubQ1Num = detailList.Count(d => d.Q41),
                            SubQ2Num = detailList.Count(d => d.Q42),
                            SubQ3Num = detailList.Count(d => d.Q43),
                            SubQ4Num = detailList.Count(d => d.Q44),
                            SubQ5Num = detailList.Count(d => d.Q45),
                            SubQ6Num = detailList.Count(d => d.Q46),
                        },
                        new mQuestionaire.QuestionaireStatVM.QuestionStat { 
                            QuestionName= "第5个问题",
                            SubQ1Num = detailList.Count(d => d.Q51),
                            SubQ2Num = detailList.Count(d => d.Q52),
                            SubQ3Num = detailList.Count(d => d.Q53),
                            SubQ4Num = detailList.Count(d => d.Q54),
                            SubQ5Num = detailList.Count(d => d.Q55),
                            SubQ6Num = detailList.Count(d => d.Q56),
                        },
                        new mQuestionaire.QuestionaireStatVM.QuestionStat { 
                            QuestionName= "第6个问题",
                            SubQ1Num = detailList.Count(d => d.Q61),
                            SubQ2Num = detailList.Count(d => d.Q62),
                            SubQ3Num = detailList.Count(d => d.Q63),
                            SubQ4Num = detailList.Count(d => d.Q64),
                            SubQ5Num = detailList.Count(d => d.Q65),
                            SubQ6Num = detailList.Count(d => d.Q66),
                        },
            };
            int length = 6;
            switch (qtype)
            {
                case WXQuestionnaire.Model.Questionaire.QuestionaireTypes.店长D1:
                    length = mQuestionaire.QuestionaireConstants.Q11Names.Count;
                    break;
                case WXQuestionnaire.Model.Questionaire.QuestionaireTypes.品牌经理兼督导D1:
                    length = mQuestionaire.QuestionaireConstants.Q12Names.Count;
                    break;
                case WXQuestionnaire.Model.Questionaire.QuestionaireTypes.培训兼陈列D1:
                    length = mQuestionaire.QuestionaireConstants.Q13Names.Count;
                    break;
                case WXQuestionnaire.Model.Questionaire.QuestionaireTypes.商品D1:
                    length = mQuestionaire.QuestionaireConstants.Q14Names.Count;
                    break;
                case WXQuestionnaire.Model.Questionaire.QuestionaireTypes.店长D2:
                    length = mQuestionaire.QuestionaireConstants.Q21Names.Count;
                    break;
                case WXQuestionnaire.Model.Questionaire.QuestionaireTypes.品牌经理兼督导D2:
                    length = mQuestionaire.QuestionaireConstants.Q22Names.Count;
                    break;
                case WXQuestionnaire.Model.Questionaire.QuestionaireTypes.陈列兼培训D2:
                    length = mQuestionaire.QuestionaireConstants.Q23Names.Count;
                    break;
                case WXQuestionnaire.Model.Questionaire.QuestionaireTypes.陈列D2:
                    length = mQuestionaire.QuestionaireConstants.Q24Names.Count;
                    break;
                default:
                    break;
            }

            qstartlist = qstartlist.Take(length).ToList(); ;

            return qstartlist;
        }


        private string GetQName(mQuestionaire.QuestionaireTypes qtype, int qidx)
        {
            switch (qtype)
            {
                case WXQuestionnaire.Model.Questionaire.QuestionaireTypes.店长D1:
                    return mQuestionaire.QuestionaireConstants.Q11Names[qidx];
                case WXQuestionnaire.Model.Questionaire.QuestionaireTypes.品牌经理兼督导D1:
                    return mQuestionaire.QuestionaireConstants.Q12Names[qidx];
                case WXQuestionnaire.Model.Questionaire.QuestionaireTypes.培训兼陈列D1:
                    return mQuestionaire.QuestionaireConstants.Q13Names[qidx];
                case WXQuestionnaire.Model.Questionaire.QuestionaireTypes.商品D1:
                    return mQuestionaire.QuestionaireConstants.Q14Names[qidx];
                case WXQuestionnaire.Model.Questionaire.QuestionaireTypes.店长D2:
                    return mQuestionaire.QuestionaireConstants.Q21Names[qidx];
                case WXQuestionnaire.Model.Questionaire.QuestionaireTypes.品牌经理兼督导D2:
                    return mQuestionaire.QuestionaireConstants.Q22Names[qidx];
                case WXQuestionnaire.Model.Questionaire.QuestionaireTypes.陈列兼培训D2:
                    return mQuestionaire.QuestionaireConstants.Q23Names[qidx];
                case WXQuestionnaire.Model.Questionaire.QuestionaireTypes.陈列D2:
                    return mQuestionaire.QuestionaireConstants.Q24Names[qidx];
                default:
                    throw new Exception("找不到 qtype");
            }
        }


    }
}
