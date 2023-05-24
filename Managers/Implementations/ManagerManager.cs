using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Managers.Interfaces;
using NewProject.Models.Entities;
using NewProject.Models.Enums;

namespace NewProject.Managers.Implementations
{
    public class ManagerManager : IManagerManager
    {
        public static List<Manager> ManagerDb = new List<Manager>();
        public List<Manager> GetAll()
        {
            return ManagerDb;
        }
        public Manager Get(string email)
        {
            foreach (var manager in ManagerDb)
            {
                if (manager.UserEmail == email)
                {
                    return manager;
                }
            }
            return null;
        }

        public Manager register(string name, string email, string password, string phoneNumber, string address, Gender gender)
        {
            var manager = Check(email);
            if (manager)
            {
                return null;
            }
            var user = new User(UserManager.UserDB.Count+1,name,email,password,phoneNumber,address,gender,"Manager",false,DateTime.Now);
            UserManager.UserDB.Add(user);

            Manager managers = new Manager(ManagerDb.Count+1,email,false,DateTime.Now);
            ManagerDb.Add(managers);
            return managers;
        }

          private bool Check(string email)
        {
            foreach (var item in ManagerDb)
            {
                if (item.UserEmail == email)
                {
                   return true; 
                }
            }
            return false;
        }

          string path =  @"C:\Users\Harzeez\Desktop\New project\File\manager.txt";

        // public ManagerManager()
        // {
        //     ReadManagerFromFile();
        // }

        public void ReadManagerFromFile()
        {
            if (File.Exists(path))
            {
                var manager = File.ReadAllLines(path);
                foreach (var manage in manager)
                {
                    ManagerDb.Add(Manager.ToManager(manage));
                }
            }
            else
            {
                string path = @"C:\Users\Harzeez\Desktop\New project\File\";
                Directory.CreateDirectory(path);
                string fileName = "manager.txt";
                var filepath = Path.Combine(path,fileName);
                File.Create(filepath);
            }
        }
        public void AddManagerToFile(Manager manager)
        {
            using (StreamWriter  str = new StreamWriter(path,true))
            {
                str.WriteLine(manager.ToString());
            }
        }

        public void RefreshManagerFile()
        {
            using (StreamWriter  str = new StreamWriter(path,true))
            {
                foreach (var manager in  ManagerDb)
                {
                    str.WriteLine(manager.ToString());
                }
            }
        }
    }
}