using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WXQuestionnaire.Model.Admin
{
    public class LoginVM
    {
        [Required(ErrorMessage="请输入账号")]
        [StringLength(20,MinimumLength=2,ErrorMessage="{0}长度{2}-{1}个字符")]
        [Display(Name="账号")]
        public string Account;

        [Required(ErrorMessage="请输入密码")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{0}长度{2}-{1}个字符")]
        [Display(Name = "密码")]
        [DataType(dataType:DataType.Password)]
        public string Password;
    }
}
