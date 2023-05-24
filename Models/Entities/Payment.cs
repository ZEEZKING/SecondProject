using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewProject.Models.Entities
{
    public class Payment : BaseEntity
    {
       public string HotelAcctNumber;
       public string CustomerAcctNumber;
       public double Amount;
       public string ReferenceNo;
       

        public Payment(int id,string hotelAcctNumber, string customerAcctNumber, double amount, string referenceNo,bool isDeleted,DateTime dateCreated) : base(id,isDeleted,dateCreated)
        {
            HotelAcctNumber = hotelAcctNumber;
            CustomerAcctNumber = customerAcctNumber;
            Amount = amount;
            ReferenceNo = referenceNo;
           
        }

        public override string ToString()
        {
            return $"{Id} {HotelAcctNumber} {CustomerAcctNumber} {Amount} {ReferenceNo}";
        }
        public static Payment ToPayment(string data)
        {
            var obj = data.Split(" ");
            var id = int.Parse(obj[0]);
            var hotelAcctNumber = obj[1];
            var customerAcctNumber = obj[2];
            var amt = double.Parse(obj[3]);
            var referenceNo = obj[4];
            var isDeleted = bool.Parse(obj[5]);
            var dateCreated = DateTime.Parse(obj[6]);

            return new Payment(id,hotelAcctNumber,customerAcctNumber,amt,referenceNo,isDeleted,dateCreated);
        }
    }
}