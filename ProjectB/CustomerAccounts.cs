using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static class UserAccounts
{
    public static List<Customer> Customers = new List<Customer>();

    public static void SaveCustomerAccounts() 
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(Customers, options);
        File.WriteAllText("Customers.json", jsonString);
    }
    public static void LoadCustomerAccounts() 
    { 
        string jsonString = File.ReadAllText("Customers.json");
        Customers = JsonSerializer.Deserialize<List<Customer>>(jsonString);
    }

    public static void AddAccount(string username, string password, string fullname)
    {
        var account = new Customer(username, password, fullname);
        UserAccounts.Customers.Add(account);
    }

    public static Customer GetCustomer(string username)
    {
        foreach (var item in Customers) 
        {
            if (item.Username == username) return item;
        }
        return null;
    }

    public static Customer GetLoggedInCustomer()
    {
        foreach (var user in Customers) { if (user.LoggedIn) return user; }
        return null;
    }

    public static bool CheckIfAccExists(string fullname, string username)
    {
        foreach(var acc in Customers)
        {
            if (fullname == acc.FullName || username == acc.Username) return true;
        }
        return false;
    }

    public static void LogOutAllCustomers()
    {
        foreach (var user in Customers) user.LogOut();
    }
}
