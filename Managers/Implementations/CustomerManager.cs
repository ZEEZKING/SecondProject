using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Managers.Interfaces;
using NewProject.Models.Entities;
using NewProject.Models.Enums;

namespace NewProject.Managers.Implementations
{
    public class CustomerManager : ICustomerManager
    {
        public static List<Customer> CustomerDb = new List<Customer>();
        public Customer CheckWallet(string email)
        {
            foreach (var item in CustomerManager.CustomerDb)
            {
                if (item.UserEmail == email)
                {
                    //    System.Console.WriteLine($"Your wallet balance is {item.Wallet}");
                    return item;
                }

            }
            return null;
        }

        public Customer FundWallet(int customerId, double amount)
        {
            var customer = Get(customerId);
            if (customer == null)
            {
                System.Console.WriteLine("Customer not found");
            }
            else if (amount > 0)
            {
                customer.Wallet += amount;
            }
            else
            {
                System.Console.WriteLine("Insufficient Funds");
            }
            return customer;
        }

        public Customer Get(string email)
        {
            foreach (var customer in CustomerDb)
            {
                if (customer.UserEmail == email)
                {
                    return customer;
                }
            }
            return null;
        }

        public Customer Get(int id)
        {
            foreach (var customer in CustomerDb)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }

        public List<Customer> GetAll()
        {
            return CustomerDb;
        }

        public Customer Register(string name, string email, string password, string phoneNumber, string address, Gender gender)
        {
            var customerExist = check(email);
            if (customerExist)
            {
                return null;
            }
            else
            {
                var user = new User(UserManager.UserDB.Count+1,name,email,password,phoneNumber,address,gender,"Customer",false,DateTime.Now);
                UserManager.UserDB.Add(user);
                var customer = new Customer(CustomerDb.Count+1,email,0,false,DateTime.Now);
                CustomerDb.Add(customer);
                return customer;
            }
        }

        private bool check(string email)
        {
            foreach (var customer in CustomerDb)
            {
                if (customer.UserEmail == email )
                {
                    return true;
                }
            }
            return false;
        }

           string path =  @"C:\Users\Harzeez\Desktop\New project\File\customer.txt";

        // public CustomerManager()
        // {
        //     ReadCustomerFromFile();
        // }

        public void ReadCustomerFromFile()
        {
            if (File.Exists(path))
            {
                var customers = File.ReadAllLines(path);
                foreach (var customer in customers)
                {
                    CustomerDb.Add(Customer.ToCustomer(customer));
                }
            }
            else
            {
                string path = @"C:\Users\Harzeez\Desktop\New project\File\";
                Directory.CreateDirectory(path);
                string fileName = "customer.txt";
                var filepath = Path.Combine(path,fileName);
                File.Create(filepath);
            }
        }
        public void AddCustomerToFile(Customer customer)
        {
            using (StreamWriter  str = new StreamWriter(path,true))
            {
                str.WriteLine(customer.ToString());
            }
        }

        public void RefreshCustomrtFile()
        {
            using (StreamWriter  str = new StreamWriter(path,true))
            {
                foreach (var customer in  CustomerDb)
                {
                    str.WriteLine(customer.ToString());
                }
            }
        }
    }
}