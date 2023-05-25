using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Managers.Implementations;
using NewProject.Managers.Interfaces;

namespace NewProject.Menu
{
    public class ManagerMenu
    {
        IRoomManager _roomManager = new RoomManager();
        ICustomerManager _customerManager = new CustomerManager();
        IBookingManager _bookingManager = new BookingManager();
        public void ManagerMain()
        {
            try
            {
                System.Console.WriteLine("Enter 1 to add rooms\nEnter 2 to view all customers\nEnter 3 to view all booking\nEnter 4 to logout");
                int opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        AddRoom();
                        ManagerMain();
                        break;
                    case 2:
                        ViewCustomers();
                        ManagerMain();
                        break;
                    case 3:
                        ViewBooking();
                        ManagerMain();
                        break;
                    case 4:
                        MainMenu mainMenu = new MainMenu();
                        mainMenu.Main();
                        break;
                    default:
                        System.Console.WriteLine("Invalid input");
                        ManagerMain();
                        break;
                }
            }
            catch (NullReferenceException e)
            {
                System.Console.WriteLine(e.Message);
                  ManagerMain();
            }
            catch(FormatException e)
            {
                System.Console.WriteLine(e.Message);
                  ManagerMain();
            }

        }
        // string roomType, int quantity, double price)
        public void AddRoom()
        {
            Console.Write("Enter the name of the room : ");
            string room = Console.ReadLine();
            Console.Write("Enter the quantity of the room : ");
            int quan = int.Parse(Console.ReadLine());
            Console.Write("Enter the price of the room : ");
            double price = double.Parse(Console.ReadLine());

            var roomCreate = _roomManager.Create(room, quan, price);
            if (roomCreate == null)
            {
                System.Console.WriteLine("Room cannot be created exist");
            }
            else
            {
                System.Console.WriteLine($"You have sucessfully created a room {roomCreate.RoomName} {roomCreate.Quantity} {roomCreate.Price}");
            }
        }
        public void ViewCustomers()
        {
            var customerViews = _customerManager.GetAll();
            if (customerViews.Count == 0)
            {
                System.Console.WriteLine("Customer doesnt exist");
            }
            else
            {
                foreach (var item in CustomerManager.CustomerDb)
                {
                    System.Console.WriteLine($"The email of the Customer {item.UserEmail} and they are sucessfully added {item.DateCreated}");
                }
            }
        }
        public void ViewBooking()
        {
            var bookingViews = _bookingManager.GetAll();
            if (bookingViews == null)
            {
                System.Console.WriteLine("All the rooms are booked");
            }
            else
            {
                foreach (var item in BookingManager.BookingDb)
                {
                    System.Console.WriteLine($"The Booking that are available are {item.RoomName} and {item.RoomNumber} and {item.Status}");
                }
            }

        }
    }
}