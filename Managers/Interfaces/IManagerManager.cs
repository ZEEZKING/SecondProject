using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Models.Entities;
using NewProject.Models.Enums;

namespace NewProject.Managers.Interfaces
{
    public interface IManagerManager
    {
        Manager register(string name, string email, string password, string phoneNumber, string address, Gender gender);
        Manager Get(string email);
        List<Manager> GetAll();
    }
}