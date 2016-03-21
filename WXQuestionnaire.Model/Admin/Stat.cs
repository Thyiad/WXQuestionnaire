using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXQuestionnaire.Model.Admin
{
    public class Stat
    {
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 九宫格抽奖获奖者总数
        /// </summary>
        public int PrizeWinnerNum { get; set; }

        // 问卷获奖者信息
        public int Day1WinnerNum { get; set; }
        public int Day2WinnerNum { get; set; }
    }
}
