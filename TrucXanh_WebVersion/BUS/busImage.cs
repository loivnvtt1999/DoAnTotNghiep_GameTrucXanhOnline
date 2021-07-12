using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ModelGame;
namespace BUS
{
    public class busImage
    {
        TrucXanhDbContext db = new TrucXanhDbContext();
        public List<tblImage> getListImage()
        {
            return db.Images.ToList();
        }
        public void insertImage(tblImage img)
        {
            db.Images.Add(img);
            db.SaveChanges();
        }
        public void removeImage(int id)
        {
            tblImage img = db.Images.Where(x => x.idImage == id).FirstOrDefault();
            db.Images.Remove(img);
            db.SaveChanges();
        }
    }
}
