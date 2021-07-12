using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ModelGame;
namespace BUS
{
    public class busLevel
    {
        TrucXanhDbContext db = new TrucXanhDbContext();
        public tblLevel getFirstLevel()
        {
            return db.Levels.FirstOrDefault();
        }
        public void deleteLevel(int id)
        {
            tblLevel lv = db.Levels.Where(x => x.levelID == id).FirstOrDefault();
            List<tblPlayerScore> lstscore = db.PlayerScores.Where(x => x.levelIdLose == id).ToList();
            foreach (var item in lstscore)
            {
                db.PlayerScores.Remove(item);
                db.SaveChanges();
            }
            db.Levels.Remove(lv);
            db.SaveChanges();
        }
        public int insertLevel(string name, int range, int time)
        {
            tblLevel lv = new tblLevel();
            tblLevel lastLevel = getLastLevel();
            int colCurrent = int.Parse(name.Substring(0, 1));
            int rowCurrent = int.Parse(name.Substring(2));
            lv.levelName = name;
            lv.rangeScore = range;
            lv.time = time;
            lv.totalScore = ((colCurrent * rowCurrent) / 2) * range;
            if (lastLevel != null)
            {
                int colLast = int.Parse(lastLevel.levelName.Substring(0, 1));
                int rowLast = int.Parse(lastLevel.levelName.Substring(2));
                if ((colCurrent * rowCurrent) <= (colLast * rowLast) || time <= lastLevel.time || range <= lastLevel.rangeScore)
                {
                    return 0;
                }
            }
            db.Levels.Add(lv);
            db.SaveChanges();
            return 1;
        }
        public void updateLevel (int id ,string name, int range, int time)
        {
            int colCurrent = int.Parse(name.Substring(0, 1));
            int rowCurrent = int.Parse(name.Substring(2));
            tblLevel lv = db.Levels.Where(x => x.levelID == id).FirstOrDefault();
            lv.levelName = name;
            lv.rangeScore = range;
            lv.time = time;
            lv.totalScore= ((colCurrent * rowCurrent) / 2) * range;
            db.SaveChanges();
        }
        public tblLevel getLastLevel()
        {
            return db.Levels.ToList().OrderByDescending(x => x.levelID).FirstOrDefault();
        }
        public tblLevel getLevelByID(int id)
        {
            return db.Levels.Where(x => x.levelID == id).FirstOrDefault();
        }
        public tblLevel getNextLevel(int id)
        {
            List<tblLevel> allListLevel = db.Levels.ToList();
            int flag = -1;
            for(int i=0; i < allListLevel.Count(); i++)
            {
                if (allListLevel[i].levelID == id)
                {
                    flag = i;
                }
            }
            if (flag == allListLevel.Count()-1)
                return null;
            return allListLevel[flag + 1]; ;
        }
        public tblLevel getPreLevel(int id)
        {
            List<tblLevel> allListLevel = db.Levels.ToList();
            int flag = -1;
            for (int i = 0; i < allListLevel.Count(); i++)
            {
                if (allListLevel[i].levelID == id)
                {
                    flag = i;
                }
            }
            if (flag == 0)
            {
                return allListLevel[0];
            }
            return allListLevel[flag - 1];
        }
        public int calculateScorePreLevel(int id)
        {
            tblLevel lv = getLevelByID(id);
            List<tblLevel> lstLV = db.Levels.ToList();
            int total = 0;
            foreach (var item in lstLV)
            {
                if (item.levelID != lv.levelID)
                {
                    total += item.totalScore;
                }
                else
                {
                    break;
                }
            }
            return total;
        }
        public List<tblLevel> getAllLevel()
        {
            return db.Levels.ToList();
        }
    }
}
