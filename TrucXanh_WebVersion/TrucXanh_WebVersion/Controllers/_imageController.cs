using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrucXanh_WebVersion.Models;
using ModelGame;
using System.IO;
using System.Web.Security;
using System.Runtime.Remoting.Contexts;

namespace TrucXanh_WebVersion.Controllers
{
    public class _imageController : Controller
    {
        // GET: image
        _modelImage mdlImage = new _modelImage();
        [Authorize (Users ="admin")]
        public ActionResult getListImage()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Logout", "_admin");
            }
            return View(mdlImage.getListImage());
        }
        [Authorize(Users = "admin")]
        public ActionResult insertImage(HttpPostedFileBase file)
        {
            string s = "";
            if (Session["admin"]==null)
            {
                s = "Phiên làm việc hết hạn, vui lòng đăng nhập lại";
                return Json(s, JsonRequestBehavior.AllowGet);
            }
            var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };
            var fileName = Path.GetFileName(file.FileName);
            var ext = Path.GetExtension(file.FileName);
            if (allowedExtensions.Contains(ext))
            {
                string name = Path.GetFileNameWithoutExtension(fileName);
                string myfile = name + ext;
                // Lưu S3
                Path.Combine(Server.MapPath("~/Image/"), myfile);
                file.SaveAs(Server.MapPath("~/Image/") + file.FileName);
                tblImage img = new tblImage();
                img.nameImage = myfile;
                mdlImage.insertImage(img);
            }
            else
            {
                s = "Vui lòng chọn file khác";
                return Json(s, JsonRequestBehavior.AllowGet);
            }
            return Json(s, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Users = "admin")]
        public ActionResult removeImage (int id)
        {
            string s = "";
            if (Session["admin"] == null)
            {
                s = "Phiên làm việc hết hạn, vui lòng đăng nhập lại";
                return Json(s, JsonRequestBehavior.AllowGet);
            }
            else
            {
                mdlImage.removeImage(id);
                //s = "Xóa thành công";
            }
            return Json(s, JsonRequestBehavior.AllowGet);
        }
    }
}