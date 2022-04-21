using System;
using System.Collections.Generic;


public class TestClass {
    public static Dictionary<DateTime, List<Reservation>> Reservations = new();

    public static void ListReservations() {
        foreach (var item in Reservations)
        {
            Console.WriteLine($"{item.Key.ToShortDateString()}\n----------------");
            for(int i = 0; i < item.Value.Count; i++) {
                System.Console.WriteLine($"{i+1}. {item.Value[i].Name}");
            }
        }
    }
}

// foreach(KeyValuePair<string, string> entry in myDictionary)
// {
//     // do something with entry.Value or entry.Key
// }
