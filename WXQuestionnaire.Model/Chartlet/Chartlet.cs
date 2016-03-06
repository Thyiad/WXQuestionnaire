using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXQuestionnaire.Model.Chartlet
{
    public class Chartlet
    {
        [Key]
        public int ID { get; set; }
        public string OriginalImgPath { get; set; }
        public string MsgText { get; set; }
        public string SignName { get; set; }
        public string BuildImgPath { get; set; }
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 原始图片在微信服务器上的资源编号，ServerID
        /// </summary>
        public string ServerIDWX { get; set; }
    }
}
