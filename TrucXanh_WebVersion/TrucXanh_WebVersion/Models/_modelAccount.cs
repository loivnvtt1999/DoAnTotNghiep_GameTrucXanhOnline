using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelGame;
using BUS;
namespace TrucXanh_WebVersion.Models
{
    
    public class _modelAccount
    {
        busAccounts busAccount = new busAccounts();
        public tblAccount checkLogin(tblAccount account)
        {
            return busAccount.checkLogin(account);
        }
        public tblAccount checkInfoAccount(string name)
        {
            return busAccount.checkInfoAccount(name);
        }
        public void insertAccount(tblAccount acc)
        {
            busAccount.insertAccount(acc);
        }
    }
}