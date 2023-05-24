using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Managers.Interfaces;
using NewProject.Models.Entities;
using NewProject.Models.Enums;

namespace NewProject.Managers.Implementations
{
    public class UserManager : IUserManager
    {
        public static List<User> UserDB = new List<User>()
        {
           new User( 1, "AbdulAzeez", "ade@email.com", "123","07051459639","Lagos",Gender.male,"SuperAdmin",false,DateTime.Now)
        };
        public User Get(string email)
        {
            foreach (var user in UserDB)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }

        public User Get(int id)
        {
            foreach (var user in UserDB)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        public List<User> GetAll()
        {
            return UserDB;
        }

        public User Login(string email, string password)
        {
            foreach (var user in UserDB)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }

        string path = @"C:\Users\Harzeez\Desktop\New project\File\user.txt";

        public UserManager()
        {
            ReadUserFromFile();
            
        }

        public void ReadUserFromFile()
        {
            if (File.Exists(path))
            {
                var Users = File.ReadAllLines(path);
                foreach (var user in Users)
                {
                  UserManager.UserDB.Add(User.ToUser(user));
                }
            }
            else
            {
                string paths = @"C:\Users\Harzeez\Desktop\New project\File\";
                Directory.CreateDirectory(paths);
                string fileName = "user.txt";
                string fullPath = Path.Combine(paths,fileName);
                File.Create(fullPath);
            }
        }

        public void AddUserToFile(User user)
        {
            using (StreamWriter str = new StreamWriter(path,true))
            {
                str.WriteLine(user.ToString());
            }
        }
         public void RefreshFile()
        {
            using (StreamWriter str = new StreamWriter(path,true))
            {
                foreach (var user in UserManager.UserDB)
                {
                    str.WriteLine(user.ToString());
                }
            }
        }
    }
}