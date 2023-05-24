using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Managers.Interfaces;
using NewProject.Models.Entities;
using NewProject.Models.Enums;

namespace NewProject.Managers.Implementations
{
    public class RoomManager : IRoomManager
    {
        public static List<Room> RoomDb = new List<Room>();
        public Room Create(string roomType, int quantity, double price)
        {
            var roomsExist = Check(roomType);
            if (roomsExist)
            {
                return null;
            }
            if (quantity > 0)
            {
             var numbers = GenerateRoomNumber(quantity);
            Room room = new Room(RoomManager.RoomDb.Count + 1, roomType, quantity, price, numbers, false, DateTime.Now);
            RoomDb.Add(room);
            return room;  
            }
            else
            {
                System.Console.WriteLine("Quantity should be greater than zero");
            }
            return null;

        }
    

        public Room Get(string roomnumbers)
        {
            foreach (var room in RoomDb)
            {
                foreach (var item in room.RoomNumbers)
                {
                    if (item == roomnumbers)
                    {
                        return room;
                    }
                }
            }
            return null;
        }

        public List<Room> GetAll()
        {
            return RoomDb;
        }

        public Room GetRoom(int id)
        {
            foreach (var room in RoomDb)
            {
                if (room.Id == id)
                {
                    return room;
                }
            }
            return null;
        }
        public Room GetRoombyName(string roomName)
        {
            foreach (var item in RoomDb)
            {
                if (item.RoomName == roomName)
                {
                    return item;
                }
            }
            return null;
        }
        public Room Getby(string roomName)
        {
            foreach (var booking in RoomDb)
            {
                if (booking.RoomName == roomName)
                {
                    return booking;
                }
            }
            return null;
        }
        public Room CheckIfRoomisAvailable(string roomName)
        {
            var roomGet = Getby(roomName);
            if (roomGet.Quantity > 0)
            {
                return roomGet;
            }
            return null;
        }

        private List<string> GenerateRoomNumber(int quantity)
        {
            List<string> numbers = new List<string>();
            
            for (int i = 0; i < quantity; i++)
            {
                numbers.Add($"Room/Num/{numbers.Count + 1}");
            }
            return numbers;
        }

        private bool Check(string roomName)
        {
            foreach (var room in RoomDb)
            {
                if (room.RoomName == roomName)
                {
                    return true;
                }
            }
            return false;
        }

        string path =  @"C:\Users\Harzeez\Desktop\New project\File\Room.txt";

        // public RoomManager()
        // {
        //     ReadRoomFromFile();
        // }

        public void ReadRoomFromFile()
        {
            if (File.Exists(path))
            {
                var Rooms = File.ReadAllLines(path);
                foreach (var rooms in Rooms)
                {
                    RoomDb.Add(Room.ToRoom(rooms));
                }
            }
            else
            {
                string path = @"C:\Users\Harzeez\Desktop\New project\File\";
                Directory.CreateDirectory(path);
                string fileName = "Room.txt";
                var filepath = Path.Combine(path,fileName);
                File.Create(filepath);
            }
        }
        public void AddRoomFile(Room room)
        {
            using (StreamWriter  str = new StreamWriter(path,true))
            {
                str.WriteLine(room.ToString());
            }
        }

        public void RefreshRoomFile()
        {
            using (StreamWriter  str = new StreamWriter(path,true))
            {
                foreach (var rooms in  RoomDb)
                {
                    str.WriteLine(rooms.ToString());
                }
            }
        }


    }
}