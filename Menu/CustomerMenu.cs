using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Managers.Implementations;
using NewProject.Managers.Interfaces;

namespace NewProject.Menu
{
    public class CustomerMenu
    {
        ICustomerManager _customerManager = new CustomerManager();
        IRoomManager _roomManager = new RoomManager();
        IBookingManager _bookingManager = new BookingManager();
        public void CustomerMain()
        {
            try
            {
                System.Console.WriteLine("Enter 1 to fund your Wallet\nEnter 2 to check wallet \nEnter 3 to view all rooms \nEnter 4 to book ");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        FundWallet();
                        CustomerMain();
                        break;
                    case 2:
                        CheckWallet();
                        CustomerMain();
                        break;
                    case 3:
                        ViewRooms();
                        CustomerMain();
                        break;
                    case 4:
                        BookingMenu bookingMenu = new BookingMenu();
                        bookingMenu.BookingMain();
                        break;
                    default:
                        System.Console.WriteLine("Invalid input");
                        CustomerMain();
                        break;

                }
            }
           catch (NullReferenceException e)
            {
                System.Console.WriteLine(e.Message);
                  CustomerMain();
            }
            catch(FormatException e)
            {
                System.Console.WriteLine(e.Message);
                  CustomerMain();
            }

        }
        public void FundWallet()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            var customer = _customerManager.Get(email);
            if (customer == null)
            {
                System.Console.WriteLine("email not found");
                CustomerMenu customerMenu = new CustomerMenu();
                customerMenu.CustomerMain();

            }
            Console.Write("Enter your Amount : ");
            double amount = double.Parse(Console.ReadLine());
            if (amount > 0)
            {

            }
            else
            {
                System.Console.WriteLine("Amount should be greater than Zero");
                CustomerMain();
            }
            var funds = _customerManager.FundWallet(customer.Id, amount);
            if (funds == null)
            {
                System.Console.WriteLine("Transaction Unsucessfull");
            }
            else
            {
                System.Console.WriteLine($"Transaction sucessfull {customer.UserEmail} {customer.DateCreated}");
            }
        }
        public void CheckWallet()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            var customer = _customerManager.Get(email);
            if (customer == null)
            {
                System.Console.WriteLine("email not found");
                CustomerMenu customerMenu = new CustomerMenu();
                customerMenu.CustomerMain();
            }

            var customerWall = _customerManager.CheckWallet(email);
            if (customer == null)
            {
                System.Console.WriteLine("Wallet not found");
            }
            else
            {
                System.Console.WriteLine($"Your wallet balance is {customerWall.Wallet}");
            }
        }
        public void ViewRooms()
        {
            var roomViews = _roomManager.GetAll();
            if (roomViews.Count == 0)
            {
                System.Console.WriteLine("Rooms are not available");
            }
            else
            {
                foreach (var item in roomViews)
                {
                    if (item.Quantity == 0)
                    {
                        System.Console.WriteLine("Rooms are not available");
                        CustomerMain();
                    }
                    System.Console.WriteLine($"The Room available is the Number{item.RoomNumbers[item.RoomNumbers.Count - 1]} the roomname {item.RoomName} and the quantity {item.Quantity} And the price {item.Price}");
                }
            }
        }
        // string roomName,int duration,string referenceNo

    }
}