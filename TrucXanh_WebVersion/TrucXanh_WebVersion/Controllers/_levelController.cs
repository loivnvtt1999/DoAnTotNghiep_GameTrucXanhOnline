using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrucXanh_WebVersion.Models;
using ModelGame;
namespace TrucXanh_WebVersion.Controllers
{
    public class _levelController : Controller
    {
        _modelLevel mdlLevel = new _modelLevel();
        // GET: _level
        [Authorize(Users = "admin")]
        public ActionResult getListLevel()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Logout", "_admin");
            }
            return View(mdlLevel.getAllLevel());
        }
        [Authorize(Users = "admin")]
        public ActionResult insertLevel(int col, int row, int range, int time)
        {
            string s = "";
            if (Session["admin"] == null)
            {
                s = "Phiên làm việc hết hạn, vui lòng đăng nhập lại";
                return Json(s, JsonRequestBehavior.AllowGet);
            }
            string levelName = col.ToString() + "x" + row.ToString();
            int check = mdlLevel.insertLevel(levelName,range,time);
            if (check == 0)
            {
                s = "Thêm thất bại vui lòng kiểm tra lại";
                return Json(s, JsonRequestBehavior.AllowGet);
            }
            return Json(s, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Users = "admin")]
        public ActionResult updateLevel (int id, int col, int row, int range, int time)
        {
            string s = "";
            if (Session["admin"] == null)
            {
                s = "Phiên làm việc hết hạn, vui lòng đăng nhập lại";
                return Json(s, JsonRequestBehavior.AllowGet);
            }
            string levelName = col.ToString() + "x" + row.ToString();
            mdlLevel.updateLevel(id, levelName, range, time);
            return Json(s, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Users = "admin")]
        public ActionResult deleteLevel(int id)
        {
            string s = "";
            if (Session["admin"] == null)
            {
                s = "Phiên làm việc hết hạn, vui lòng đăng nhập lại";
                return Json(s, JsonRequestBehavior.AllowGet);
            }
            mdlLevel.deleteLevel(id);
            return Json(s, JsonRequestBehavior.AllowGet);
        }
    }
}