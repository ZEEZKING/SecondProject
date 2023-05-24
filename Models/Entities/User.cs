using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Models.Enums;

namespace NewProject.Models.Entities
{
    public class User : BaseEntity
    {
        public string Name;
        public string Email;
        public string Password;
        public string PhoneNumber;
        public string Address;
        public Gender Gender;
        public string Role;

        public User(int id,string name, string email, string password, string phoneNumber, string address, Gender gender, string role,bool isDeleted,DateTime dateCreated) : base(id,isDeleted,dateCreated)
        {
            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Address = address;
            Gender = gender;
            Role = role;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Email} {Password} {PhoneNumber} {Address} {Gender} {IsDeleted} {DateCreated}";
        }

        public static User ToUser(string data)
        {
            var obj = data.Split(" ");
            var id = int.Parse(obj[0]);
            var name = obj[1];
            var email = obj[2];
            var password = obj[3];
            var phoneNumber = obj[4];
            var address = obj[5];
            var gend = Enum.TryParse(obj[6], out Gender  val);
            var role = obj[7];
            var isDeleted = bool.Parse(obj[8]);
            var dateCreated = DateTime.Parse(obj[10]);

            return new User(id,name,email,password,phoneNumber,address,val,role,isDeleted,dateCreated);
        }
    }
}