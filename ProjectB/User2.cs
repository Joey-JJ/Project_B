using System.Collections.Generic;

public class BaseUser
{
    public string Username;
    public string Password;
    public string FullName;
    public bool LoggedIn;

    public BaseUser(string Username, string Password, string FullName)
    {
        this.Username = Username;
        this.Password = Password;
        this.FullName = FullName;
        this.LoggedIn = false;
    }

    public bool LogIn(string username, string password)
    {
        if(username == this.Username && password == this.Password)
        {
            this.LoggedIn = true;
            return true;
        }
        return false;
    }

    public bool LogOut() => this.LoggedIn = false;
}

public class Customer : BaseUser
{
    public List<Reservation> Reservations;
    public List<ReviewData> Reviews;
    public Customer(string Username, string Password, string FullName) : base(Username, Password, FullName) { }
}

public class Employee : BaseUser
{
    public Employee(string Username, string Password, string FullName) : base(Username, Password, FullName) { }
}

public class Admin : BaseUser
{
    public Admin(string Username, string Password, string FullName) : base(Username, Password, FullName) { }
}