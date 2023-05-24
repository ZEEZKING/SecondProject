using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Managers.Interfaces;
using NewProject.Models.Entities;
using NewProject.Models.Enums;

namespace NewProject.Managers.Implementations
{
    public class BookingManager : IBookingManager
    {
        IRoomManager _roomManager = new RoomManager();
        public static List<Booking> BookingDb = new List<Booking>();
        public Booking CheckIn(string referenceNo)
        {
            var bookCheck = Getby(referenceNo);
            if (bookCheck.Status != BookingStatus.pending)
            {
                System.Console.WriteLine("You have either checkedin before or checked out");
                return null;
            }
            else
            {
                bookCheck.CheckedIn = DateTime.Now;
                bookCheck.Status = BookingStatus.CheckedIn;
                return bookCheck;
            }
        }

        public Booking CheckOut(string referenceNo)
        {
            var bookCheck = Getby(referenceNo);
            if (bookCheck == null)
            {
                System.Console.WriteLine("Booking Not found");
            }
            if (bookCheck.Status != BookingStatus.CheckedIn)
            {
                return null;
            }
            else
            {
                var room = _roomManager.Getby(bookCheck.RoomName);
                if (room == null)
                {
                    System.Console.WriteLine("Room Not Found");
                }
                room.Quantity += 1;
                room.RoomNumbers.Add(bookCheck.RoomNumber);
                bookCheck.CheckedOut = DateTime.Now;
                bookCheck.Status = BookingStatus.CheckOut; 
                return bookCheck;
            }

        }

        public Booking CreateBooking(string roomName, int duration)
        {
            var bookingAvailable = _roomManager.CheckIfRoomisAvailable(roomName);
            if (bookingAvailable == null)
            {
                return null;
            }
            else
            {
                bookingAvailable.Quantity -= 1;
                var booking = new Booking(BookingDb.Count + 1, DateTime.Now, DateTime.Now, CheckBookingDuration(duration), BookingStatus.pending, bookingAvailable.RoomNumbers[bookingAvailable.RoomNumbers.Count - 1], roomName, GenerateRefNo(), false, DateTime.Now);
                BookingDb.Add(booking);
                bookingAvailable.RoomNumbers.Remove(bookingAvailable.RoomNumbers[bookingAvailable.RoomNumbers.Count - 1]);
                return booking;
            }


        }

        public Booking Get(string roomNumber)
        {
            foreach (var booking in BookingDb)
            {
                if (booking.RoomNumber == roomNumber)
                {
                    return booking;
                }
            }
            return null;
        }

        public List<Booking> GetAll()
        {
            return BookingDb;
        }

        public int CheckBookingDuration(int duration)
        {
            foreach (var booking in BookingDb)
            {
                if (booking.Status == BookingStatus.CheckedIn && booking.CheckedIn.AddHours(12 * duration) >= DateTime.Now)
                {
                    booking.CheckedOut = DateTime.Now;
                    booking.Status = BookingStatus.CheckOut;

                }
            }
            return duration;

        }


        //  public Room ReduceQuantity(string roomType, string roomnumbers)
        // {
        //     var room = GetRoomType(roomType);
        //     var roomNum = Get(roomnumbers);
        //     if (room == null)
        //     {
        //         System.Console.WriteLine("room not found");
        //     }
        //     room.Quantity -= 1;
        //     room.RoomNumbers.Remove(roomnumbers.ToString());

        //     return room;
        // }

        public string GenerateRefNo()
        {
            Random and = new Random();
            return $"Ref/Bk/Num{and.Next(1, 200)}";
        }

        public Booking Getby(string referenceNo)
        {
            foreach (var item in BookingDb)
            {
                if (item.ReferenceNo == referenceNo)
                {
                    return item;
                }
            }
            return null;
        }
        string path = @"C:\Users\Harzeez\Desktop\New project\File\booking.txt";

        // public BookingManager()
        // {
        //     ReadBookingFromFile();
        // }

        public void ReadBookingFromFile()
        {
            if (File.Exists(path))
            {
                var booking = File.ReadAllLines(path);
                foreach (var bookings in booking)
                {
                    BookingDb.Add(Booking.ToBooking(bookings));
                }
            }
            else
            {
                string path = @"C:\Users\Harzeez\Desktop\New project\File\";
                Directory.CreateDirectory(path);
                string fileName = "booking.txt";
                var filepath = Path.Combine(path, fileName);
                File.Create(filepath);
            }
        }
        public void AddBookingToFile(Booking booking)
        {
            using (StreamWriter str = new StreamWriter(path, true))
            {
                str.WriteLine(booking.ToString());
            }
        }

        public void RefreshBookingFile()
        {
            using (StreamWriter str = new StreamWriter(path, true))
            {
                foreach (var booking in BookingDb)
                {
                    str.WriteLine(booking.ToString());
                }
            }
        }
    }
}