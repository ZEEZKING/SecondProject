using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Managers.Interfaces;
using NewProject.Models.Entities;

namespace NewProject.Managers.Implementations
{
    public class AccountManager : IAccountManager
    {
        public static List<Account> AccountDb = new List<Account>()
        {
               new Account(1,"YusufAhmad", "0123456789",0,false,DateTime.Now)
        };
        
         
        public Account Get(int id)
        {
            throw new NotImplementedException();
        }

        public Account Get(string accountNumber)
        {
            foreach (var account in AccountDb)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return account;
                }
            }
            return null;
        }

        public List<Account> GetAll()
        {
            return AccountDb;
        }
    }
}