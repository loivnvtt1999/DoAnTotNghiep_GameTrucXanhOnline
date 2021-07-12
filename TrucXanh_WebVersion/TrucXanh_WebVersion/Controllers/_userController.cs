using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelGame;
using TrucXanh_WebVersion.Data;
using TrucXanh_WebVersion.Models;

namespace TrucXanh_WebVersion.Controllers
{
    public class _userController : Controller
    {
        _modelUser mdlUser = new _modelUser();
        _modelAccount mdlAccount = new _modelAccount();
       public JsonResult getUser(int userID)
        {
            tblUser user = mdlUser.GetUser(userID);
            Session["userName"] = user.userName;
            return Json(user, JsonRequestBehavior.AllowGet);
        }
        public ActionResult insertUser(string userName, string email, string phone, string nameAccount, string password)
        {
            tblUser checkUser = mdlUser.checkInfoUser(email, phone);
            tblAccount checkAccount = mdlAccount.checkInfoAccount(nameAccount);
            string s="";
            if(checkUser!=null)
            {
                s = "Email hoặc số điện thoại đã tồn tại, vui lòng kiểm tra lại";
                return Json(s, JsonRequestBehavior.AllowGet);
            }
            else if(checkAccount!=null)
            {
                s = "Tên tài khoản đã tồn tại, vui lòng kiểm tra lại";
                return Json(s, JsonRequestBehavior.AllowGet);
            }
            else
            {
                tblUser user = new tblUser();
                user.userName = userName;
                user.email = email;
                user.phone = phone;
                user.role = false;
                mdlUser.insertUserModel(user);
                tblAccount acc = new tblAccount();
                acc.nameAccount = nameAccount;
                acc.password = password;
                acc.userID = user.userID;
                mdlAccount.insertAccount(acc);
                Session["loginAccount"] = user.userName;
                Session["playerID"] = user.userID;
                Session["playerName"] = user.userName;
                Session["downButton"] = 500;
                Session["countTime"] = 1000;
                return Json(s, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
