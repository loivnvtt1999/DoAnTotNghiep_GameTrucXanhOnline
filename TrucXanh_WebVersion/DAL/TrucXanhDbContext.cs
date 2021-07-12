using ModelGame;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class TrucXanhDbContext : DbContext
    {
        public TrucXanhDbContext()
            : base("name=TrucXanhDbContext")
        {
        }
         public virtual DbSet<tblAccount> Accounts { get; set; }
         public virtual DbSet<tblLevel> Levels { get; set; }
         public virtual DbSet<tblPlayerScore> PlayerScores { get; set; }
         public virtual DbSet<tblUser> Users { get; set; }
         public virtual DbSet<tblImage> Images { get; set; }
    }
}