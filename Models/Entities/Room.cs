using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Models.Enums;

namespace NewProject.Models.Entities
{
    public class Room : BaseEntity
    {
        public string RoomName;
        public int Quantity;
        public double Price;
        public List<string> RoomNumbers = new List<string>();     // to change the roomnumber of the quantity

        public Room(int id, string roomName, int quantity, double price, List<string> roomNumbers, bool isDeleted, DateTime dateCreated) : base(id, isDeleted, dateCreated)
        {
            RoomName = roomName;
            Quantity = quantity;
            Price = price;
            RoomNumbers = roomNumbers;
        }

        public override string ToString()
        {
            return $"{Id} {RoomName} {Quantity} {Price} {RoomNumbers} {IsDeleted} {DateCreated}";
        }

        public static Room ToRoom(string data)
        {
            var obj = data.Split(" ");
            var id = int.Parse(obj[0]);
            var roomName = obj[1];
            var quantity = int.Parse(obj[2]);
            var price = double.Parse(obj[3]);
            var roomNum = obj[3].Split(" ").ToList();
            var isDeleted = bool.Parse(obj[5]);
            var dateCreated = DateTime.Parse(obj[6]);
            
            return new Room(id,roomName,quantity,price,roomNum,isDeleted,dateCreated);
        }
    }
}