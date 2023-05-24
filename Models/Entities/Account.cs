using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewProject.Models.Entities
{
    public class Account : BaseEntity
    {
        public string AccountName;
        public string AccountNumber;
        public double AccountBalance;

         public Account( int id ,string accountName, string accountNumber, double accountBalance,bool isDeleted,DateTime dateCreated) : base(id,isDeleted,dateCreated)
        {
            AccountName = accountName;
            AccountNumber = accountNumber;
            AccountBalance = accountBalance;
        }
    }
}