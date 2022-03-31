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
        if(Reservations.Count > 0) 
        {
            foreach (var item in Reservations)
            {
                Console.WriteLine($"{item.Name} at {item.DateTime} with {item.PersonCount} persons.");
            }
        } else
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
    public static void AddReservation(
        string name,
        string email,
        string dateTime,
        int personCount)
    {
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