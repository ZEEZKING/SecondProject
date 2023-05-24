using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewProject.Models.Entities
{
    public class Manager : BaseEntity
    {
        public string UserEmail;

        public Manager(int id,string userEmail,bool isDeleted,DateTime dateCreated) : base(id,isDeleted,dateCreated)
        {
            UserEmail = userEmail;
        }

        public override string ToString()
        {
            return $"{Id} {UserEmail} {IsDeleted} {DateCreated}";
        }

        public static Manager ToManager(string data)
        {
            var obj = data.Split(" ");
            var id = int.Parse(obj[0]);
            var userEmail = obj[1];
            var isDeleted = bool.Parse(obj[2]);
            var dateCreated = DateTime.Parse(obj[3]);

            return new Manager(id,userEmail,isDeleted,dateCreated);
        }
    }
}