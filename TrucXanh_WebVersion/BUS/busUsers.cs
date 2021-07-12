using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelGame;
using DAL;
namespace BUS
{
    public class busUsers
    {
        TrucXanhDbContext db = new TrucXanhDbContext();
        public int insertUser(tblUser user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return 1;
        }
        public tblUser getUser(int userID)
        {
            return db.Users.Where(x => x.userID == userID).FirstOrDefault();
        }
        public tblUser checkInfoUser(string email, string phone)
        {
            tblUser checkInfo = db.Users.Where(x => x.email.Equals(email) || x.phone.Equals(phone)).FirstOrDefault();
            return checkInfo;
        }
    }
}
