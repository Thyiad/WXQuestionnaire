using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace WXQuestionnaire.Web.Areas.Admin.Infrastructure
{
    public class AdminAuthenticationAttribute : FilterAttribute, IAuthenticationFilter
    {

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (BLL.Admin.AdminService.CurrrentAdmin == null)
                filterContext.Result = new HttpUnauthorizedResult();
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result is HttpUnauthorizedResult )
            {
                filterContext.Result = new RedirectToRouteResult("Admin_default", new RouteValueDictionary { 
                    {"controller","Home"},
                    {"action","Login"},
                    {"returnUrl",filterContext.HttpContext.Request.RawUrl}
                });
            }
        }
    }
}
