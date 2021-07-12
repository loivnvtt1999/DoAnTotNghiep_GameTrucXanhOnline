using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BUS;
using ModelGame;
namespace TrucXanh_WebVersion.Models
{
    public class _modelPlayerScore
    {
        busPlayerScore busPS = new busPlayerScore();
        public void insertPlayerUser(tblPlayerScore playerScore)
        {
             busPS.addPlayerScore(playerScore);
        }
        public List<tblPlayerScore> getTop5HighScore()
        {
            return busPS.getTop5HighScore();
        }
        public int getHighestLevel(int userID)
        {
            return busPS.getHighestLevelByPlayer(userID);
        }
        public List<tblPlayerScore> getAllScore()
        {
            return busPS.getAllScore();
        }
    }
}