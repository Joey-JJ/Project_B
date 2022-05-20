using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

class ReservationService
{
    public static Dictionary<DateTime, List<Reservation>> Reservations = new();
    public static List<RestaurantDay> Schedule = new();
    private static readonly string FileName = "./Reservations.json";

    public static void SaveReservations()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(Reservations, options);
        File.WriteAllText(FileName, jsonString);
    }

    public static void LoadReservations()
    {
        string jsonString = File.ReadAllText(FileName);
        Reservations = JsonSerializer.Deserialize<Dictionary<DateTime, List<Reservation>>>(jsonString);
        foreach (var date in Reservations)
        {
            foreach (var res in date.Value)
            {
                foreach (var user in CustomerAccounts.Users)
                {
                    if (res.Username == user.Username) user.Reservations.Add(res);
                }
            }
        }
    }

    public static void ListReservations()
    {
        foreach (var item in Reservations)
        {
            Console.WriteLine($"{item.Key.ToShortDateString()}");
            for (int i = 0; i < item.Value.Count; i++)
            {
                System.Console.WriteLine($"{i + 1}. {item.Value[i].Name} at table {item.Value[i].TableNumber}");
            }
            Console.Write("\n");
        }
    }

    public static DateTime GetReservationDate()
    {
        List<DateTime> dates = new();
        var foundDate = false;
        var result = new DateTime(1999, 1, 1);
        var week = 0;

        while (!foundDate)
        {
            Console.Clear();
            Console.WriteLine("Which day would you like to come?");
            for (var i = week * 7; i < (week * 7) + 7; i++)
            {
                dates.Add(DateTime.Now.Date.AddDays(i));
                System.Console.WriteLine($"[{i % 7 + 1}] {dates[i].Date.ToShortDateString()}");
            }

            Console.WriteLine("[8] Next week");
            Console.WriteLine("[9] Previous week");
            Console.Write("Enter your selection: ");
            var date_number = Console.ReadLine();

            switch (date_number)
            {
                case "1":
                    foundDate = true;
                    result = dates[0 + (week * 7)];
                    break;
                case "2":
                    foundDate = true;
                    result = dates[1 + (week * 7)];
                    break;
                case "3":
                    foundDate = true;
                    result = dates[2 + (week * 7)];
                    break;
                case "4":
                    foundDate = true;
                    result = dates[3 + (week * 7)];
                    break;
                case "5":
                    foundDate = true;
                    result = dates[4 + (week * 7)];
                    break;
                case "6":
                    foundDate = true;
                    result = dates[5 + (week * 7)];
                    break;
                case "7":
                    foundDate = true;
                    result = dates[6 + (week * 7)];
                    break;
                case "8":
                    week++;
                    break;
                case "9":
                    if (week != 0) week--;
                    break;
                default:
                    break;
            }
        }
        return result;
    }

    public static DateTime GetReservationTime(DateTime dt)
    {
        var res = new DateTime(dt.Year, dt.Month, dt.Day, 17, 0, 0);
        var times = new List<DateTime>();
        bool timeFound = false;
        while (!timeFound)
        {
            Console.Clear();
            System.Console.WriteLine($"Selecting a time for {dt.ToShortDateString()}");
            for (int i = 0; i < 11; i++)
            {
                times.Add(res.AddMinutes(30 * i));
                System.Console.WriteLine(
                    $"[{i + 1}] {res.AddMinutes(30 * i).ToShortTimeString()} untill {res.AddHours(2.0).AddMinutes(30 * i).ToShortTimeString()}");
            }
            System.Console.WriteLine("At what time would you like to come?");
            Console.Write("Please enter your selection: ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    timeFound = true;
                    res = times[0];
                    break;
                case "2":
                    timeFound = true;
                    res = times[1];
                    break;
                case "3":
                    timeFound = true;
                    res = times[2];
                    break;
                case "4":
                    timeFound = true;
                    res = times[3];
                    break;
                case "5":
                    timeFound = true;
                    res = times[4];
                    break;
                case "6":
                    timeFound = true;
                    res = times[5];
                    break;
                case "7":
                    timeFound = true;
                    res = times[6];
                    break;
                case "8":
                    timeFound = true;
                    res = times[7];
                    break;
                case "9":
                    timeFound = true;
                    res = times[8];
                    break;
                case "10":
                    timeFound = true;
                    res = times[9];
                    break;
                case "11":
                    timeFound = true;
                    res = times[10];
                    break;
            }
        }
        Console.WriteLine(res);
        return res;
    }

    public static void AddReservation(DateTime dateTime, int personCount, Customer acc)
    {
        var newRes = new Reservation(acc.FullName, acc.Username, dateTime, personCount);
        try { acc.Reservations.Add(newRes); }
        catch (System.NullReferenceException) { Console.WriteLine($"{newRes}"); }
        Console.WriteLine("Added Reservation");
    }

    public static void RemoveReservation(int index, Customer user) 
    {
        var reservation = user.Reservations[index];
        user.Reservations.RemoveAt(index);
        foreach (var date in Reservations)
        {
            foreach (var res in date.Value)
            {
                if (res.Username == reservation.Username && res.StartTime == reservation.StartTime)
                    Reservations[date.Key].Remove(reservation);
                    break;
            }
        }
    }
}