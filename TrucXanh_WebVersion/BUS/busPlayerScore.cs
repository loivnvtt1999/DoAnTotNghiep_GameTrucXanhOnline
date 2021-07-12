using ModelGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class busPlayerScore
    {
        TrucXanhDbContext db = new TrucXanhDbContext();
        public void addPlayerScore(tblPlayerScore playerScore)
        {
            db.PlayerScores.Add(playerScore);
            db.SaveChanges();
        }
        public List<tblPlayerScore> getTop5HighScore()
        {
            return db.PlayerScores.OrderByDescending(x => x.score).Take(5).ToList();
        }
        public  int getHighestLevelByPlayer(int userID)
        {
            List<tblPlayerScore> lstPlayerScore = db.PlayerScores.OrderByDescending(x => x.levelIdLose).ToList();
            tblPlayerScore player = lstPlayerScore.Where(x => x.userID == userID).FirstOrDefault();
            if (player == null)
                return 0;
            return player.levelIdLose;
        }
        public List<tblPlayerScore> getAllScore()
        {
            return db.PlayerScores.OrderByDescending(x => x.score).ToList();
        }

    }
}
