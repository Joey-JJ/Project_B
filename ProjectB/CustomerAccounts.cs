using System.Collections.Generic;

public static class CustomerAccounts
{
    public static List<Customer> Users = new List<Customer>();

    public static void AddAccount(string username, string password, string fullname)
    {
        var account = new Customer(username, password, fullname);
        CustomerAccounts.Users.Add(account);
    }

    public static Customer GetCustomer(string username)
    {
        foreach (var item in Users) 
        {
            if (item.Username == username) return item;
        }
        return null;
    }
}
