using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

class ReservationService
{
    public static List<Reservation> Reservations = new();
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
        Reservations = JsonSerializer.Deserialize<List<Reservation>>(jsonString);
    }

    public static void ListReservations()
    {
        if (Reservations.Count > 0)
        {
            foreach (var item in Reservations)
            {
                Console.WriteLine($"{item.Name} at {item.StartTime} with {item.PersonCount} persons.");
            }
        }
        else
        {
            Console.WriteLine("There are no reservations at the moment");
        }
    }

    static int FindReservationIndex(string nameOfRes)
    {
        int index = -1;
        for (int i = 0; i < Reservations.Count; i++)
        {
            if (Reservations[i].Name.ToLower() == nameOfRes.ToLower())
                index = i;
        }
        return index;
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
            System.Console.WriteLine($"[12] Go back and select another date");
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
                case "12":
                    // TODO
                    break;
            }
        }
        Console.WriteLine(res);
        return res;
    }

    public static void AddReservation(
        DateTime dateTime,
        int personCount)
    {
        var name = "test"; // Replace with account info
        var email = "test"; // Replace with account info
        var newRes = new Reservation(name, email, dateTime, personCount);
        Reservations.Add(newRes);
        Console.WriteLine("Added Reservation");
    }

    public static void RemoveReservation(string nameOfRes)
    {
        int removeIndex = FindReservationIndex(nameOfRes);

        if (removeIndex != -1)
        {
            Reservations.RemoveAt(removeIndex);
            Console.WriteLine("Removed reservation.");
        }
        else
        {
            Console.WriteLine("Could not find reservation");
        }

    }

    public static void EditName(string nameOfRes, string valueToChangeTo)
    {
        int editIndex = FindReservationIndex(nameOfRes);

        if (editIndex != -1)
        {
            Reservations[editIndex].Name = valueToChangeTo;
            Console.WriteLine("Edited name of reservation.");
        }
        else
        {
            Console.WriteLine("Could not find reservation");
        }
    }
    public static void EditEmail(string nameOfRes, string valueToChangeTo)
    {
        int editIndex = FindReservationIndex(nameOfRes);

        if (editIndex != -1)
        {
            Reservations[editIndex].Email = valueToChangeTo;
            Console.WriteLine("Edited email of reservation.");
        }
        else
        {
            Console.WriteLine("Could not find reservation");
        }
    }
    public static void EditDateTime(string nameOfRes, DateTime valueToChangeTo)
    {
        int editIndex = FindReservationIndex(nameOfRes);

        if (editIndex != -1)
        {
            Reservations[editIndex].StartTime = valueToChangeTo;
            Reservations[editIndex].Endtime = Reservations[editIndex].StartTime.AddHours(2.0);
            Console.WriteLine("Edited DateTime of reservation.");
        }
        else
        {
            Console.WriteLine("Could not find reservation");
        }
    }
    public static void EditPersonCount(string nameOfRes, int valueToChangeTo)
    {
        int editIndex = FindReservationIndex(nameOfRes);

        if (editIndex != -1)
        {
            Reservations[editIndex].PersonCount = valueToChangeTo;
            Console.WriteLine("Edited person count of reservation.");
        }
        else
        {
            Console.WriteLine("Could not find reservation");
        }
    }

}