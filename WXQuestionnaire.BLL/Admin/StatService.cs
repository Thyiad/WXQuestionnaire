using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXQuestionnaire.Model.Admin;
using WXQuestionnaire.DAL;
using WXQuestionnaire.Tool;

namespace WXQuestionnaire.BLL.Admin
{
    public class StatService
    {
        public Stat GetStart()
        {
            try
            {
                using (EFContext context = new EFContext())
                {
                    var stat = context.Stats.SingleOrDefault();

                    if (stat == null)
                    {
                        // 未初始化时就执行初始化
                        stat = new Stat
                        {
                            PrizeWinnerNum = 0,
                            Day1WinnerNum = 0,
                            Day2WinnerNum = 0,
                        };

                        context.Stats.Add(stat);
                        // context.Entry(stat).State = System.Data.Entity.EntityState.Added; // 作用同上，两者皆可
                        context.SaveChanges();  // 添加失败应该会报错
                    }
                    return stat;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return null;
            }
        }

        public bool UpdateStat(Stat stat)
        {
            try
            {
                using (EFContext context = new EFContext())
                {
                    context.Entry(stat).State = System.Data.Entity.EntityState.Modified;
                    return context.SaveChanges() > 0 ? true : false;
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
