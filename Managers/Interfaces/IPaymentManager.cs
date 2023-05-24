using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Models.Entities;
using NewProject.Models.Enums;

namespace NewProject.Managers.Interfaces
{
    public interface IPaymentManager
    {
        Payment MaKePayment(string hotelAcctNumber, string customerAcctNumber, double amount,string roomType,int days);
        List<Payment> GetAll();
    }
}