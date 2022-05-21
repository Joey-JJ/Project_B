using System;
using System.Collections.Generic;

public abstract class BaseUser
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
    public List<Review> Reviews { get; set; }
    public Customer(string Username, string Password, string FullName) : base(Username, Password, FullName) 
    {
        this.Reservations = new();
        this.Reviews = new();
    }

    public void ListReservations() 
    {
        Console.Clear();
        if (Reservations.Count < 1) Console.WriteLine("You don't have any reservations currently");
        else
        {
            for (var i = 0; i < this.Reservations.Count; i++)
            Console.WriteLine($"{i+1}. {Reservations[i].StartTime} with {Reservations[i].PersonCount} people.");
        }
        
        Console.Write("Press 'Enter' to continue");
        Console.ReadLine();
    }

    public void ListReviews()
    {
        Console.Clear();
        if (Reviews.Count < 1) Console.WriteLine("You don't have any reviews currently");
        else
        {
            for (var i = 0; i < this.Reviews.Count; i++)
                Console.WriteLine($"{i+1}. {Reviews[i].Date.ToShortDateString()} at {Reviews[i].Date.ToShortTimeString()}: {Reviews[i].ReviewText} - {Reviews[i].Rating} stars");
        }
        Console.Write("Press 'Enter' to continue");
        Console.ReadLine();
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