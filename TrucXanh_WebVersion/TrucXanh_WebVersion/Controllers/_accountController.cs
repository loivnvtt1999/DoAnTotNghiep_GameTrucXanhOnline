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
    public class _accountController : Controller
    {
        _modelUser mdlUser = new _modelUser();
        _modelPlayerScore mdlPS = new _modelPlayerScore();
        // GET: _account
        public ActionResult Login()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return View();
        }
        public ActionResult nonAccount(string userName)
        {
            Session.Remove("Old");
            Session.Remove("loginAccount");
            tblUser userNoAccount = new tblUser();
            userNoAccount.userName = userName;
            userNoAccount.role = false;
            mdlUser.insertUserModel(userNoAccount);
            Session["playerID"] = userNoAccount.userID;
            Session["playerName"] = userNoAccount.userName;
            Session["downButton"] = 500;
            Session["countTime"] = 1000;
            Session.Timeout = 60;
            return RedirectToAction("menuGame", "_game");
        }
        [HttpPost]
        public ActionResult Login(tblAccount Account)
        {
            if (ModelState.IsValid)
            {           
                _modelAccount modelAccount = new _modelAccount();
                if (modelAccount.checkLogin(Account) == null)
                {
                    ModelState.AddModelError("","Tài khoản đăng nhập không đúng");
                }
                else
                {
                    tblAccount userSession;
                    userSession = modelAccount.checkLogin(Account);
                    //int checkOldUser = mdlPS.getHighestLevel(userSession.User.userID);
                    //if (checkOldUser != 0)
                    //{
                    //    Session["Old"] = "old";
                    //}
                    Session["loginAccount"] = userSession.User.userName;
                    Session["playerID"] = userSession.userID;
                    Session["playerName"] = userSession.User.userName;
                    Session["downButton"] = 500;
                    Session["countTime"] = 1000;
                    Session.Timeout = 2880;
                    return RedirectToAction("menuGame", "_game");
                }
            }
            return View(Account);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Login", "_account");
        }
    }
}