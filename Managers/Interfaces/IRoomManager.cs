using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Models.Entities;
using NewProject.Models.Enums;

namespace NewProject.Managers.Interfaces
{
    public interface IRoomManager
    {
        Room Create(string roomType, int quantity, double price);
        Room Get(string roomnumbers);
        Room GetRoom(int id);
        Room Getby(string roomName);
        Room CheckIfRoomisAvailable(string roomName);
        List<Room> GetAll();
    }
}