using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Models.Enums;

namespace NewProject.Models.Entities
{
    public class Booking : BaseEntity
    {
        
        public DateTime CheckedIn;
        public DateTime CheckedOut;
        public int Duration;
        public BookingStatus Status;
        public string RoomName;
        public string RoomNumber;
        public string ReferenceNo;
       

        public Booking(int id,DateTime checkedIn, DateTime checkedOut, int duration, BookingStatus status,string roomNumber, string roomName,string referenceNo, bool isDeleted,DateTime dateCreated) : base(id,isDeleted,dateCreated)
        {
            
            CheckedIn = checkedIn;
            CheckedOut = checkedOut;
            Duration = duration;
            Status = status;
            RoomName = roomName;
            RoomNumber = roomNumber;
            ReferenceNo = referenceNo;
            
        }

        public override string ToString()
        {
            return $"{Id} {CheckedIn} {CheckedOut} {Duration} {Status} {RoomName} {RoomNumber} {ReferenceNo}";
        }

        public static Booking ToBooking(string data)
        {
            var obj = data.Split(" ");
            var id = int.Parse(obj[0]);
            var checkedIn = DateTime.Parse(obj[1]);
            var checkedOut = DateTime.Parse(obj[2]);
            var duration = int.Parse(obj[3]);
            var status = Enum.TryParse(obj[4],out BookingStatus val);
            var roomNumber = obj[5];
            var roomName = obj[6];
            var referenceNo = obj[7];
            var isDeleted = bool.Parse(obj[8]);
            var dateCreated = DateTime.Parse(obj[9]);

            return new Booking(id,checkedIn,checkedOut,duration,val,roomNumber,roomName,referenceNo,isDeleted,dateCreated);
        }

    }
}