using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WXQuestionnaire.Model.Admin
{
    public class LoginVM
    {
        [Required(ErrorMessage="请输入账号")]
        [Display(Name="账号")]
        public string Account{get;set;}

        [Required(ErrorMessage = "请输入密码")]
        [Display(Name = "密码")]
        [DataType(dataType: DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "记住我")]
        public bool RememberMe { get; set; }
    }
}
