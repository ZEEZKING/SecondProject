using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Managers.Implementations;
using NewProject.Managers.Interfaces;

namespace NewProject.Menu
{
    public class BookingMenu
    {
        IAccountManager _accountManager = new AccountManager();
        ICustomerManager _customerManager = new CustomerManager();
        IRoomManager _roomManager = new RoomManager();
        IBookingManager _bookingManager = new BookingManager();
        IPaymentManager _paymentManager = new PaymentManager();
        public void BookingMain()
        {
            System.Console.WriteLine("Enter 1 to book\nEnter 2 to checkin\nEnter 3 to checkout\nEnter 4 to logout");
            int opt = int.Parse(Console.ReadLine());
            switch (opt)
            {
                case 1:
                    Booking();
                    BookingMain();
                    break;
                case 2:
                    CheckIn();
                    BookingMain();
                    break;
                case 3:
                    CheckOut();
                    BookingMain();
                    break;
                case 4:
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Main();
                    break;
                default:
                    System.Console.WriteLine("Invalid input");
                    BookingMain();
                    break;
            }
        }

        public void Booking()
        {
            
            Console.WriteLine("Enter the RoomName you picked");
            string roomName = Console.ReadLine();
            var get = _roomManager.Getby(roomName);
            if (get == null)
            {
                System.Console.WriteLine("Room Not Found");
                BookingMain();
            }
            System.Console.WriteLine("Enter the Numbers of days you want to lodge");
            int duration = int.Parse(Console.ReadLine());
               MaKePayment(roomName,duration);

            var books = _bookingManager.CreateBooking(roomName, duration);
            if (books == null)
            {
                System.Console.WriteLine("Booking not available ");
            }
            else
            {
                System.Console.WriteLine($"You have booked in sucessful {books.ReferenceNo}");
            }


        }

        public void MaKePayment(string roomName, int days)
        {
            var roomg = _roomManager.Getby(roomName);
        Start:
            System.Console.WriteLine("The Hotel AccountNumber is 0123456789");
            System.Console.WriteLine();

            Console.Write("Enter the Hotel account Number : ");
            string accountnum = Console.ReadLine();
            var getAcct = _accountManager.Get(accountnum);
            if (getAcct == null)
            {
                System.Console.WriteLine("Wrong account Number");
                goto Start;
            }
            Console.Write("Enter your email : ");
            string email = Console.ReadLine();
            var customer = _customerManager.Get(email);
            if (customer == null)
            {
                System.Console.WriteLine("Customer not found");
                goto Start;
            }
            System.Console.WriteLine($"The amount you are required to pay is {roomg.Price * days}");
            System.Console.Write("Enter the Amount : ");
            double amt = double.Parse(Console.ReadLine());

            var payment = _paymentManager.MaKePayment(accountnum, email, amt, roomg.RoomName, days);
            if (payment == null)
            {
                System.Console.WriteLine("Trensaction unsucessful");
            }
            else
            {
                System.Console.WriteLine($"Transaction sucessfully {payment.CustomerAcctNumber} and {payment.DateCreated}");
            }
        }
        public void CheckIn()
        {
            System.Console.Write("Enter your CardReferenceNo to check in: ");
            string refr = Console.ReadLine();

            var getCheck = _bookingManager.CheckIn(refr);
            if (getCheck == null)
            {
                System.Console.WriteLine("The booking number doesnt exist or you have checkedin before");
                BookingMenu bookingMenu = new BookingMenu();
                bookingMenu.BookingMain();
            }
            else
            {
                System.Console.WriteLine($"You have successful checked in {DateTime.Now} ");
            }
        }
        public void CheckOut()
        {
            System.Console.Write("Enter your CardReferenceNo number to check out : ");
            string booking = Console.ReadLine();
            var getOut = _bookingManager.CheckOut(booking);
            if (getOut == null)
            {
                System.Console.WriteLine("The booking number doesnt exist");
                BookingMenu bookingMenu = new BookingMenu();
                bookingMenu.BookingMain();

            }
            else
            {
                System.Console.WriteLine($"You Have successfully Checked Out {DateTime.Now}");
                System.Console.WriteLine("Thanks for patronizing us We appericiate you");

            }
        }
    }
}