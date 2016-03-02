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
        /// 获奖者总数
        /// </summary>
        public int PrizeWinnerNum { get; set; }
    }
}
