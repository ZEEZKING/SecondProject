using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Models.Entities;

namespace NewProject.Managers.Interfaces
{
    public interface IUserManager
    {
        User Login(string email, string password);
        User Get(string email);
        User Get(int id);
        List<User> GetAll();
    }
}