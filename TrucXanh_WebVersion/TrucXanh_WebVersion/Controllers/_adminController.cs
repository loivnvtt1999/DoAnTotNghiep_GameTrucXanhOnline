using ModelGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TrucXanh_WebVersion.Models;

namespace TrucXanh_WebVersion.Controllers
{
    public class _adminController : Controller
    {
        // GET: _admin
        public ActionResult Login()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return View();
        }
        [HttpPost]
        public ActionResult Login(tblAccount acc)
        {
            if (ModelState.IsValid)
            {
                _modelAccount modelAccount = new _modelAccount();
                if (modelAccount.checkLogin(acc) == null)
                {
                    ModelState.AddModelError("", "Tài khoản đăng nhập không đúng");
                }
                else
                {
                    tblAccount userSession = modelAccount.checkLogin(acc);
                    if (userSession.User.role == true)
                    {
                        FormsAuthentication.SetAuthCookie("admin", true);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Tài khoản đăng nhập không đúng");
                        return View();
                    }
                    Session["admin"] = userSession.User.userName;
                    Session.Timeout = 2880;
                    return RedirectToAction("getListImage", "_image");
                }
            }
            return View(acc);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Login", "_admin");
        }
    }
}