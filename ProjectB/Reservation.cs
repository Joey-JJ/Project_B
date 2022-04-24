using System;
using System.Collections.Generic;

public class Reservation
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime Endtime { get; set; }
    public int PersonCount { get; set; }
    public int? TableNumber { get; set; }
    public RestaurantDay Day { get; set; }

    public Reservation(
            string name,
            string email,
            DateTime starttime,
            int personcount)
    {
        this.Name = name;
        this.Email = email;
        this.PersonCount = personcount;
        this.StartTime = starttime;
        this.Endtime = this.StartTime.AddHours(2.0);
        this.Day = this.AssignRestaurantDay();
        int? table = this.AssignTableNumber();
        if (table != null) this.TableNumber = table;
        else Console.WriteLine("No tables available, please choose another date");

        try { ReservationService.Reservations[this.StartTime.Date].Add(this); }
        catch (KeyNotFoundException) { ReservationService.Reservations.Add(this.StartTime.Date, new List<Reservation>() { this }); }
    }

    private RestaurantDay AssignRestaurantDay()
    {
        for (int i = 0; i < Restaurant.Schedule.Count; i++)
        {
            if (Restaurant.Schedule[i].Date == this.StartTime.Date)
            {
                return Restaurant.Schedule[i];
            }
        }
        RestaurantDay day = new(this.StartTime.Date);
        Restaurant.Schedule.Add(day);
        return day;
    }

    private int? AssignTableNumber()
    {
        for (int i = this.Day.Tables.Count - 1; i >= 0; i--)
        {
            if ((this.PersonCount <= this.Day.Tables[i].NumberOfSeats ) && (!this.Day.Tables[i].Taken))
            {
                this.Day.Tables[i].Taken = true;
                return this.Day.Tables[i].TableNumber;
            }
        }
        return null;
    }
}
