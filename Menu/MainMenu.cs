using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Managers.Implementations;
using NewProject.Managers.Interfaces;
using NewProject.Models.Enums;

namespace NewProject.Menu
{
    public class MainMenu
    {
        ICustomerManager _customerManager = new CustomerManager();
        IUserManager _userManager = new UserManager();
        SuperAdminMenu superAdminMenu = new SuperAdminMenu();
        ManagerMenu managerMenu = new ManagerMenu();
        CustomerMenu customerMenu = new CustomerMenu();
        public void Main()
        {
            try
            {
                System.Console.WriteLine(".......Welcome To CLH Hotel.............");
                System.Console.WriteLine("Enter 1 to register\nEnter 2 to login");
                int opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        Register();
                        break;
                    case 2:
                        Login();
                        break;
                    default:
                        System.Console.WriteLine("Invalid input");
                        Main();
                        break;
                }
            }
            catch (NullReferenceException e)
            {
                System.Console.WriteLine(e.Message);
                Main();
            }
            catch(FormatException e)
            {
                System.Console.WriteLine(e.Message);
                Main();
            }


        }

        public void Register()
        {
            Console.Write("Enter your FullName : ");
            string name = Console.ReadLine();
            Console.Write("Enter your EmailAddress : ");
            string email = Console.ReadLine();
            Console.Write("Enter your Password : ");
            string password = Console.ReadLine();
            Console.Write("Enter your PhoneNumber : ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter your Address : ");
            string address = Console.ReadLine();
            Console.Write("Enter 1 for male and 2 for female : ");
            int gender;
            while (!int.TryParse(Console.ReadLine(), out gender))
            {
                Console.WriteLine("wrong input");
                Main();
            }

            var customer = _customerManager.Register(name, email, password, phoneNumber, address, (Gender)gender);
            if (customer == null)
            {
                System.Console.WriteLine("Account not found");
            }
            else
            {
                System.Console.WriteLine($"Congratulation {name} You have sucessfully Created an Account.");
                Main();
            }

        }
        public void Login()
        {
            Console.Write("Enter your EmailAddress : ");
            string email = Console.ReadLine();
            Console.Write("Enter your Password : ");
            string password = Console.ReadLine();

            var user = _userManager.Login(email, password);
            if (user == null)
            {
                System.Console.WriteLine("Invalid Information");
                Login();
            }
            else
            {
                System.Console.WriteLine("You Have login sucessful");

                if (user.Role == "SuperAdmin")
                {
                    superAdminMenu.SuperMain();
                }
                else if (user.Role == "Manager")
                {
                    managerMenu.ManagerMain();
                }
                else if (user.Role == "Customer")
                {
                    customerMenu.CustomerMain();
                }
            }
        }
    }
}