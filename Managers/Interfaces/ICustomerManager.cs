using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Models.Entities;
using NewProject.Models.Enums;

namespace NewProject.Managers.Interfaces
{
    public interface ICustomerManager
    {
        Customer Register(string name, string email, string password, string phoneNumber, string address, Gender gender);
        Customer Get(string email);
        List<Customer> GetAll();
        Customer Get(int id);
        Customer FundWallet(int customerId, double amount);
        Customer CheckWallet(string email);
    }
}