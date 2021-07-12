using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelGame;
using BUS;
namespace TrucXanh_WebVersion.Models
{
    public class _modelLevel
    {
        busLevel busLevelObject = new busLevel();
        public tblLevel getFirstLevel()
        {
            return busLevelObject.getFirstLevel();
        }
        public tblLevel getLastLevel()
        {
            return busLevelObject.getLastLevel();
        }
        public void deleteLevel(int id)
        {
            busLevelObject.deleteLevel(id);
        }
        public int insertLevel(string name, int range, int time)
        {
            return busLevelObject.insertLevel(name, range, time);
        }
        public void updateLevel(int id, string name, int range, int time)
        {
             busLevelObject.updateLevel(id, name, range, time);
        }
        public tblLevel getLevelByID(int id)
        {
            return busLevelObject.getLevelByID(id);
        }
        public tblLevel getNextLevel(int id)
        {
            return busLevelObject.getNextLevel(id);
        }
        public int calculateScorePreLevel(int id)
        {
            return busLevelObject.calculateScorePreLevel(id);
        }
        public tblLevel getPreLevel(int id)
        {
            return busLevelObject.getPreLevel(id);
        }
        public List<tblLevel> getAllLevel()
        {
            return busLevelObject.getAllLevel();
        }
    }
}