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
        /// <summary>
        /// 店长D1
        /// </summary>
        public int D1DZPrizeNum { get; set; }
        /// <summary>
        /// 品牌经理/督导D1
        /// </summary>
        public int D1PPJLDDPrizeNum { get; set; }
        /// <summary>
        /// 陈列/培训D1
        /// </summary>
        public int D1CLPXPrizeNum { get; set; }
        /// <summary>
        /// 商品D1
        /// </summary>
        public int D1SPPrizeNum { get; set; }
        /// <summary>
        /// 店长D2
        /// </summary>
        public int D2DZPrizeNum { get; set; }
        /// <summary>
        /// 品牌经理/督导D2
        /// </summary>
        public int D2PPJLDDPrizeNum { get; set; }
        /// <summary>
        /// 陈列兼培训D2
        /// </summary>
        public int D2CLPXPrizeNum { get; set; }
        /// <summary>
        /// 陈列D2
        /// </summary>
        public int D2CLPrizeNum { get; set; }
    }
}
