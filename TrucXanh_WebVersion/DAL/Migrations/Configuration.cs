namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.TrucXanhDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.TrucXanhDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Users.Add(new ModelGame.tblUser() { userID = 1, userName = "Phạm Đức Lợi", email = "loi9a2thcsttt@gmail.com", phone = "0774771559", role = true });
            context.Accounts.Add(new ModelGame.tblAccount() { accountID = 1, nameAccount = "loi", password = "1", userID = 1 });
        }
    }
}
