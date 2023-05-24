using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Models.Entities;

namespace NewProject.Managers.Interfaces
{
    public interface IAccountManager
    {
        Account Get(string accountNumber);
        Account Get(int id);
        List<Account> GetAll();
    }
}