using ModelGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrucXanh_WebVersion.Models;

namespace TrucXanh_WebVersion.Controllers
{
    public class _playerScoreController : Controller
    {
        _modelPlayerScore mdlPlayerScore = new _modelPlayerScore();
        _modelUser mdlUser = new _modelUser();
        public JsonResult endGame(int userID, int score, int levelIDLose)
        {
            tblPlayerScore playerScore = new tblPlayerScore();
            playerScore.userID = userID;
            playerScore.score = score;
            playerScore.levelIdLose = levelIDLose;
            mdlPlayerScore.insertPlayerUser(playerScore);
            List<tblPlayerScore> lstTop5 = new List<tblPlayerScore>();
            lstTop5 = mdlPlayerScore.getTop5HighScore();
            return Json(lstTop5, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getListScore()
        {
            List<tblPlayerScore> lstScore = new List<tblPlayerScore>();
            lstScore = mdlPlayerScore.getAllScore();
            return Json(lstScore, JsonRequestBehavior.AllowGet);
        }
    }
}