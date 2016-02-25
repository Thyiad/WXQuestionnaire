using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXQuestionnaire.Model.Admin
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Account { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LoginTime { get; set; }
        public string LoginIP { get; set; }
    }
}
