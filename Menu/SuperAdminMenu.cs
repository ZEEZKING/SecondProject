using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Managers.Implementations;
using NewProject.Managers.Interfaces;
using NewProject.Models.Enums;

namespace NewProject.Menu
{
    public class SuperAdminMenu
    {
        IManagerManager _ManagerManager = new ManagerManager();
        IAccountManager _accountManager = new AccountManager();
        public void SuperMain()
        {
            try
            {
            System.Console.WriteLine("Enter 1 to register Manager\nEnter 2 to view all Manager\nEnter 3 to check AccountBalance\nEnter 4 to Logout");
            int opt = int.Parse(Console.ReadLine());
            
                switch (opt)
                {
                    case 1:
                        Register();
                        SuperMain();
                        break;
                    case 2:
                        ViewManagers();
                        SuperMain();
                        break;
                    case 3:
                        CheckBalance();
                        SuperMain();
                        break;
                    case 4:
                        MainMenu mainMenu = new MainMenu();
                        mainMenu.Main();
                        break;
                    default:
                        System.Console.WriteLine("Invalid input");
                        SuperMain();
                        break;
                }
            }
            catch (NullReferenceException e)
            {
                System.Console.WriteLine(e.Message);
                  SuperMain();
            }
            catch(FormatException e)
            {
                System.Console.WriteLine(e.Message);
                  SuperMain();
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
                SuperMain();
            }
            var manager = _ManagerManager.register(name, email, password, phoneNumber, address, (Gender)gender);
            if (manager == null)
            {
                System.Console.WriteLine("Manager wasnt sucessfully created or manager email already exist");
            }
            else
            {
                System.Console.WriteLine($"You have sucessfully created a Manager is Name {name} and his email is {manager.UserEmail}");
            }
        }
        public void ViewManagers()
        {
            var manage = _ManagerManager.GetAll();
            if (manage == null)
            {
                System.Console.WriteLine("Manager doesnt exist");
            }
            else
            {
                foreach (var item in ManagerManager.ManagerDb)
                {
                    System.Console.WriteLine($"The manager {item.UserEmail} is sucessfully added");
                }
            }
        }
        public void CheckBalance()
        {
        Start:
            System.Console.WriteLine("Enter your account Number");
            string acctNum = Console.ReadLine();

            var acctBalance = _accountManager.Get(acctNum);
            if (acctBalance == null)
            {
                System.Console.WriteLine("Account Not found");
                goto Start;
            }
            else
            {
                System.Console.WriteLine($"Your AccountBalance is {acctBalance.AccountBalance}");
            }

        }
    }
}