using System.Collections.Generic;

public class BaseUser
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public bool LoggedIn { get; set; }

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
    public List<Reservation> Reservations { get; set; }
    public List<ReviewData> Reviews { get; set; }
    public Customer(string Username, string Password, string FullName) : base(Username, Password, FullName) 
    {
        this.Reservations = new();
        this.Reviews = new();
    }
}

public class Employee : BaseUser
{
    public Employee(string Username, string Password, string FullName) : base(Username, Password, FullName) { }
}

public class Admin : BaseUser
{
    public Admin(string Username, string Password, string FullName) : base(Username, Password, FullName) { }
}