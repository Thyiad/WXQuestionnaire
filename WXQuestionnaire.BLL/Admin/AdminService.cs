using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WXQuestionnaire.DAL;
using WXQuestionnaire.Tool;
using mAdmin = WXQuestionnaire.Model.Admin;

namespace WXQuestionnaire.BLL.Admin
{
    public class AdminService
    {
        public const string SESSION_ADMIN = "Session_Admin";
        public const string COOKIE_ADMIN = "Cookie_Admin";
        public static mAdmin.Admin CurrrentAdmin
        {
            get
            {
                string jsonStr = HttpContext.Current.Session[SESSION_ADMIN] as string;
                mAdmin.Admin admin = null;
                if (!string.IsNullOrEmpty(jsonStr))
                    admin = JsonConvert.DeserializeObject<mAdmin.Admin>(jsonStr);
                else
                {
                    // 暂不记住
                    //var cookieAdmin = HttpContext.Current.Request.Cookies[COOKIE_ADMIN];
                    //if (cookieAdmin == null)
                    //    return null;
                    //else
                    //{//adminJsonStrin = HttpContext.Current.Server.UrlDecode(cookieAdmin.Value);
                    //    jsonStr = System.Web.HttpUtility.UrlDecode(cookieAdmin.Value, Encoding.UTF8);
                    //    // TODO adminJsonStr 需要解密
                    //    // TODO 需要更新该用户的最新登录时间、获取该用户信息的数据库最新值
                    //    admin = JsonConvert.DeserializeObject<mAdmin.Admin>(jsonStr);
                    //}
                }

                return admin;
            }
        }

        public static void SetCurrentAdmin(mAdmin.Admin admin, bool remember)
        {
            try
            {
                string jsonStr = JsonConvert.SerializeObject(admin);
                HttpContext.Current.Session[SESSION_ADMIN] = jsonStr;
                if (remember)
                {
                    //jsonStr = HttpContext.Current.Server.UrlEncode(jsonStr);
                    jsonStr = System.Web.HttpUtility.UrlEncode(jsonStr, Encoding.UTF8);
                    // TODO jsonstr需要加密
                    var cookieAdmin = new HttpCookie(COOKIE_ADMIN, jsonStr);
                    cookieAdmin.Expires = DateTime.Now.AddMonths(1);
                    HttpContext.Current.Response.Cookies.Add(cookieAdmin);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
        }

        public static void QuitCurrentAdmin()
        {
            HttpContext.Current.Session[SESSION_ADMIN] = null;
            var cookieAdmin = new HttpCookie(COOKIE_ADMIN, null);
            cookieAdmin.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookieAdmin);
        }

        public mAdmin.Admin GetAdminByAccount(string account)
        {
            try
            {
                using (EFContext context = new EFContext())
                    return context.Admins.FirstOrDefault(a => a.Account.Equals(account, StringComparison.InvariantCultureIgnoreCase));
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return null;
            }

        }

        public bool UpdateAdmin(mAdmin.Admin admin)
        {
            try
            {
                using (EFContext context = new EFContext())
                {
                    context.Entry(admin).State = EntityState.Modified;  // 修改State为Modified等同于Attach
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
