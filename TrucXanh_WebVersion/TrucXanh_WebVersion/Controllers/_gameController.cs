using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrucXanh_WebVersion.Models;
using ModelGame;
namespace TrucXanh_WebVersion.Controllers
{
    public class _gameController : Controller
    {
        _modelPlayerScore mdlPS = new _modelPlayerScore();
        _modelImage modelImageObject = new _modelImage();
        _modelLevel modelLevelObject = new _modelLevel();
        // GET: _game
        public ActionResult menuGame()
        {
            if (Session["playerID"] != null )
            {
                int checkOldUser = mdlPS.getHighestLevel(int.Parse(Session["playerID"].ToString()));
                if (checkOldUser != 0)
                {
                    Session["Old"] = "old";
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "_account");
            }
            
        }
        public ActionResult playGame()
        {
            if (Session["countTime"] == null)
            {
                return RedirectToAction("Login", "_account");
            }
            List<tblImage> lstImage = modelImageObject.getListImage();
            tblLevel firstLevel = modelLevelObject.getFirstLevel();
            if (firstLevel == null)
            {
                return Content("Hệ thống chưa có màn chơi");
            }
            else
            {
                Session["listImage"] = lstImage.ToArray();
                Session["levelID"] = firstLevel.levelID;
                Session["levelName"] = firstLevel.levelName;
                Session["timeGame"] = firstLevel.time;
                Session["rangeScore"] = firstLevel.rangeScore;
                Session["totalScore"] = 0;
            }    
            return View();
        }
        public JsonResult nextLevel(int currentLevelID)
        {
            Session.Remove("NextlevelID");
            Session.Remove("NextlevelName");
            _modelLevel modelLevelObject = new _modelLevel();
            tblLevel nextLevel = modelLevelObject.getNextLevel(currentLevelID);
            if (nextLevel == null)
            {
                nextLevel = new tblLevel();
            }
            System.Threading.Thread.Sleep(2000);
            return Json(nextLevel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult continueGame(int Alias= 0)
        {
            if (Alias == 0)
            {
                return RedirectToAction("Login", "_account");
            }
            if (string.IsNullOrEmpty(Alias.ToString()))
            {
                return RedirectToAction("Login", "_account");
            }
            int highestLevel= mdlPS.getHighestLevel(Alias);
            if (highestLevel == 0)
            {
                highestLevel = 1;
            }
            //tblLevel preLevel = modelLevelObject.getPreLevel(highestLevel);
            List<tblImage> lstImage = modelImageObject.getListImage();
            Session["listImage"] = lstImage.ToArray();
            Session["levelID"] = highestLevel;
            Session["levelName"] = modelLevelObject.getLevelByID(highestLevel).levelName;
            Session["timeGame"] = modelLevelObject.getLevelByID(highestLevel).time;
            Session["rangeScore"] = modelLevelObject.getLevelByID(highestLevel).rangeScore;
            Session["totalScore"] = modelLevelObject.calculateScorePreLevel(highestLevel);
            return View();
        }
        public ActionResult backMenu()
        {
            return RedirectToAction("menuGame", "_game");
        }
        public ActionResult settingGame (int id)
        {
            if (id == 1)
            {
                Session["downButton"] = 500;
                Session["countTime"] = 1000;
            }
            else
            {
                Session["downButton"] = 200;
                Session["countTime"] = 600;
            }
            return RedirectToAction("menuGame", "_game");
        }
    }
}