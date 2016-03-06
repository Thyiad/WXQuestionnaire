using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WXQuestionnaire.BLL.Admin;
using WXQuestionnaire.Model.Admin;
using WXQuestionnaire.Web.Areas.Admin.Infrastructure;

namespace WXQuestionnaire.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private AdminService _adminService = new AdminService();

        // GET: Admin/Home
        [AdminAuthentication]
        public ActionResult Index()
        {
            ViewBag.AdminName = AdminService.CurrrentAdmin.Name;
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (AdminService.CurrrentAdmin != null)
                return RedirectToAction("Index");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var admin = _adminService.GetAdminByAccount(loginVM.Account);
                if (admin == null)
                {
                    ModelState.AddModelError("Account", "账号不存在");
                }
                else if (loginVM.Password != admin.Password)
                {
                    ModelState.AddModelError("Password", "密码不正确");
                }
                else
                {
                    admin.LoginTime = DateTime.Now;
                    admin.LoginIP = Request.UserHostAddress;
                    _adminService.UpdateAdmin(admin);
                    AdminService.SetCurrentAdmin(admin,loginVM.RememberMe);
                    string returnUrl = Request.QueryString["returnUrl"];
                    if (!string.IsNullOrEmpty(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index");
                }
            }

            return View(loginVM);
        }

        public ActionResult Logout() {
            AdminService.QuitCurrentAdmin();
            return RedirectToAction("Login");
        }
    }
}