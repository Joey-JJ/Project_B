using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

class Reservation
{
    public static List<Reservation> Reservations = new();
    private static string FileName = "Reservations.json";
    public string Name { get; set; }
    public string Email { get; set; }
    public string DateTime { get; set; }
    public int PersonCount { get; set; }

    public Reservation(
            string name,
            string email,
            string datetime,
            int personcount)
    {
        this.Name = name;
        this.Email = email;
        this.DateTime = datetime;
        this.PersonCount = personcount;
    }

    public static void SaveReservations()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(Reservation.Reservations, options);
        File.WriteAllText(FileName, jsonString);
        System.Console.WriteLine("Saved Reservations");
    }

    public static void LoadReservations()
    {
        string jsonString = File.ReadAllText(FileName);
        Reservations = JsonSerializer.Deserialize<List<Reservation>>(jsonString);
        System.Console.WriteLine("Loaded Reservations");
    }

    public static void ListReservations()
    {
        foreach (var item in Reservations)
            Console.WriteLine($"{item.Name} at {item.DateTime} with {item.PersonCount} persons.");
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
    public static void AddReservation(
        string name,
        string email,
        string date_time,
        int person_count)
    {
        var newRes = new Reservation(name, email, date_time, person_count);
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
    public static void EditDateTime(string nameOfRes, string valueToChangeTo)
    {
        int editIndex = FindReservationIndex(nameOfRes);

        if (editIndex != -1)
        {
            Reservations[editIndex].DateTime = valueToChangeTo;
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
