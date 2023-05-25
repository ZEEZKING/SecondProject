using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Managers.Interfaces;
using NewProject.Models.Entities;
using NewProject.Models.Enums;

namespace NewProject.Managers.Implementations
{
    public class PaymentManager : IPaymentManager
    {
        ICustomerManager customerManager = new CustomerManager();
        IAccountManager accountManager = new AccountManager();
        IRoomManager roomManager = new RoomManager();
        public static List<Payment> PaymentDb = new List<Payment>();
        public List<Payment> GetAll()
        {
            return PaymentDb;
        }

        public Payment MaKePayment(string hotelAcctNumber, string customerAcctNumber, double amount, string roomType, int days)
        {
            var referenceNo = GenerateRefNo();
            var roomp = roomManager.Getby(roomType);
            var custAcct = customerManager.Get(customerAcctNumber);
            var hotelAcctnum = accountManager.Get(hotelAcctNumber);
            if (hotelAcctnum == null)
            {
                System.Console.WriteLine("Account Number not found");
            }
            if (roomp == null)
            {
                System.Console.WriteLine("Room not found");
            }
            else
            {
                if (amount >= roomp.Price * days)
                {
                    custAcct.Wallet -= roomp.Price * days;
                    hotelAcctnum.AccountBalance += roomp.Price * days;
                    Payment payment = new Payment(PaymentDb.Count + 1, hotelAcctnum.AccountNumber, custAcct.UserEmail, amount, GenerateRefNo(), false, DateTime.Now);
                    PaymentDb.Add(payment);
                    return payment;
                }
                else
                {
                    System.Console.WriteLine("Not enough funds");
                    
                }
            }
            return null;
        }

        private string GenerateRefNo()
        {
            Random rand = new Random();
            return "Ref/Pay/No" + rand.Next(20, 100);
        }

         string path =  @"C:\Users\Harzeez\Desktop\New project\File\payment.txt";

        // public PaymentManager()
        // {
        //     ReadPaymentFromFile();
        // }

        public void ReadPaymentFromFile()
        {
            if (File.Exists(path))
            {
                var Payments = File.ReadAllLines(path);
                foreach (var pays in Payments)
                {
                    PaymentDb.Add(Payment.ToPayment(pays));
                }
            }
            else
            {
                string path = @"C:\Users\Harzeez\Desktop\New project\File\";
                Directory.CreateDirectory(path);
                string fileName = "payment.txt";
                var filepath = Path.Combine(path,fileName);
                File.Create(filepath);
            }
        }
        public void AddPaymentFile(Payment payment)
        {
            using (StreamWriter  str = new StreamWriter(path,true))
            {
                str.WriteLine(payment.ToString());
            }
        }

        public void RefreshPaymentFile()
        {
            using (StreamWriter  str = new StreamWriter(path,true))
            {
                foreach (var paymment in  PaymentDb)
                {
                    str.WriteLine(paymment.ToString());
                }
            }
        }
    }
}
