using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WXQuestionnaire.DAL;
using mAdmin = WXQuestionnaire.Model.Admin;

namespace WXQuestionnaire.BLL.Admin
{
    public class AdminService
    {
        public const string SESSION_ADMIN = "Admin";
        public static mAdmin.Admin CurrrentAdmin
        {
            get
            {
                string adminJsonStrin = HttpContext.Current.Session[SESSION_ADMIN] as string;
                if (adminJsonStrin == null) return null;
                mAdmin.Admin admin = JsonConvert.DeserializeObject<mAdmin.Admin>(adminJsonStrin);

                return admin;
            }
            set
            {
                string jsonStr = JsonConvert.SerializeObject(value);
                HttpContext.Current.Session[SESSION_ADMIN] = jsonStr;
            }
        }

        public mAdmin.Admin GetAdminByAccount(string account)
        {
            try
            {
                using (EFContext context = new EFContext())
                    return context.Admins.FirstOrDefault(a => a.Account.Equals(account, StringComparison.InvariantCultureIgnoreCase));
            }
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }
        }

    }
}
