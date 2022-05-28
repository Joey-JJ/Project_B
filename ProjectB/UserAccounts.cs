using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static class UserAccounts
{
    public static List<Customer> Customers = new List<Customer>();
    public static List<Employee> Employees = new List<Employee>();
    public static List<Admin> Admins = new List<Admin>();
    public static readonly string FileName = "AccountData.json";

    public static void SaveAccountData() 
    {
        var accounts = Tuple.Create(Customers, Employees, Admins);
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(accounts, options);
        File.WriteAllText(FileName, jsonString);
    }
    public static void LoadAccountData() 
    { 
        string jsonString = File.ReadAllText(FileName);
        var accounts = JsonSerializer.Deserialize<Tuple<List<Customer>, List<Employee>, List<Admin>>>(jsonString);
        Customers = accounts.Item1;
        Employees = accounts.Item2;
        Admins = accounts.Item3;
    }

    public static void AddCustomerAccount(string username, string password, string fullname)
    {
        var account = new Customer(username, password, fullname);
        UserAccounts.Customers.Add(account);
    }

    public static void DeleteCustomerAccount(Customer account)
    {
        for (int i = 0; i < account.Reservations.Count; i++)
            ReservationService.RemoveReservation(i, account);
            
        Customers.Remove(account);
    }

    public static void ChangeCustomerPassword(Customer account, string newPassword)
    {
        account.Password = newPassword;
        SaveAccountData();
    }

    public static void DeleteEmployeeAccount(Employee account)
    {
        Employees.Remove(account);
        UserAccounts.SaveAccountData();
    }

    public static void DeleteAdminAccount(Admin account)
    {
        Admins.Remove(account);
        UserAccounts.SaveAccountData();
    }

    public static void AddEmployeeAccount(string username, string password, string fullname)
    {
        var account = new Employee(username, password, fullname);
        UserAccounts.Employees.Add(account);
    }

    public static void AddAdminAcccount(string username, string password, string fullname)
    {
        var account = new Admin(username, password, fullname);
        UserAccounts.Admins.Add(account);
    }

    public static Customer GetCustomer(string username)
    {
        foreach (var item in Customers) 
            if (item.Username == username) return item;
        return null;
    }

    public static Employee GetEmployee(string username)
    {
        foreach (var item in Employees) 
            if (item.Username == username) return item;
        return null;
    }

    public static Admin GetAdmin(string username)
    {
        foreach (var item in Admins) 
            if (item.Username == username) return item;
        return null;
    }

    public static Customer GetLoggedInCustomer()
    {
        foreach (var user in Customers) { if (user.LoggedIn) return user; }
        return null;
    }

    public static Employee GetLoggedInEmployee()
    {
        foreach (var user in Employees) { if (user.LoggedIn) return user; }
        return null;
    }

    public static Admin GetLoggedInAdmin()
    {
        foreach (var user in Admins) { if (user.LoggedIn) return user; }
        return null;
    }
    
    public static bool CheckIfCustomerExists(string fullname, string username)
    {
        foreach(var acc in Customers)
        {
            if (fullname == acc.FullName || username == acc.Username) return true;
        }
        return false;
    }

    public static bool CheckIfEmployeeExists(string fullname, string username)
    {
        foreach(var acc in Employees)
        {
            if (fullname == acc.FullName || username == acc.Username) return true;
        }
        return false;
    }

    public static bool CheckIfAdminExists(string fullname, string username)
    {
        foreach(var acc in Admins)
        {
            if (fullname == acc.FullName || username == acc.Username) return true;
        }
        return false;
    }

    public static void ListCustomerAccounts()
    {
        if (Customers.Count < 1) 
        {
            Console.WriteLine("There are no customer accounts at the moment."); 
            return; 
        }
        foreach (var user in Customers)
        {
            Console.WriteLine($"Name: {user.FullName}, username: {user.Username}");
        }
    }

    public static void ListEmployeeAccounts()
    {
        if (Employees.Count < 1) 
        {
            Console.WriteLine("There are no employee accounts at the moment."); 
            return; 
        }
        foreach (var user in Employees)
        {
            Console.WriteLine($"Name: {user.FullName}, username: {user.Username}");
        }
    }

    public static void ListAdminAccounts()
    {
        foreach (var user in Admins)
        {
            Console.WriteLine($"Name: {user.FullName}, username: {user.Username}");
        }
    }

    public static void LogOutAllAccounts()
    {
        foreach (var user in Customers) user.LogOut();
        foreach (var user in Employees) user.LogOut();
        foreach (var user in Admins) user.LogOut();
    }
}
