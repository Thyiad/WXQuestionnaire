using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WXQuestionnaire.BLL.Admin;
using WXQuestionnaire.Model.Questionaire;

namespace WXQuestionnaire.Web.Areas.Admin.Infrastructure
{
    public class Menu
    {
        public string Title { get; set; }
        public string Href { get; set; }
        public List<Menu> SubMenus { get; set; }
    }

    public static class ViewService
    {
        public static List<Menu> Menus;
        public static Model.Admin.Admin CurrentAdmin
        {
            get
            {
                return AdminService.CurrrentAdmin;
            }
        }
        static ViewService()
        {
            Menus = new List<Menu>();
            var enums = Enum.GetNames(typeof(QuestionaireTypes));
            foreach (var item in enums)
            {
                int typeInt = (int)(QuestionaireTypes)Enum.Parse(typeof(QuestionaireTypes), item);
                Menus.Add(new Menu
                {
                    Title = item.ToString(),
                    Href = "javascript:;",
                    SubMenus = new List<Menu> {
                        new Menu {
                            Title = "问卷详情",
                            Href = "/Admin/Questionaire/QueryStat?qtype="+typeInt,
                        },
                        new Menu {
                            Title = "问卷明细",
                            Href= "/Admin/Questionaire/QueryDetail?qtype="+typeInt,
                        }
                    },
                });
            }
        }
    }
}