using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewProject.Models.Entities
{
    public class Customer : BaseEntity
    {
        public string UserEmail;
        public double Wallet;

        public Customer(int id,string userEmail, double wallet,bool isDeleted,DateTime dateCreated) : base(id,isDeleted,dateCreated)
        {
            UserEmail = userEmail;
            Wallet = wallet;
        }

        public override string ToString()
        {
            return $"{Id} {UserEmail} {Wallet} {IsDeleted} {DateCreated}";
        }

        public static Customer ToCustomer(string data)
        {
            var obj = data.Split(" ");
            var id = int.Parse(obj[0]);
            var userEmail = obj[1];
            var wallet = double.Parse(obj[2]);
            var isDeleted = bool.Parse(obj[3]);
            var dateCreated = DateTime.Parse(obj[4]);

            return new Customer(id,userEmail,wallet,isDeleted,dateCreated);
        }
    }
}