using System;
using System.Collections.Generic;


namespace ProjectB
{
    public static class Schedule
    {
        static readonly List<Reservation> Reservations = new();

        public static void ListReservations()
        {
            foreach (var item in Reservations)
                Console.WriteLine($"{item.Name} at {item.Date_time} with {item.Person_count} persons.");
        }

        static int FindReservationIndex(string name_of_res)
        {
            int index = -1;
            for (int i = 0; i < Reservations.Count; i++)
            {
                if (Reservations[i].Name.ToLower() == name_of_res.ToLower())
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
            var new_res = new Reservation(name, email, date_time, person_count);
            Reservations.Add(new_res);
            Console.WriteLine("Added Reservation");
        }

        public static void RemoveReservation(string name_of_res)
        {
            int remove_index = FindReservationIndex(name_of_res);

            if (remove_index != -1)
            {
                Reservations.RemoveAt(remove_index);
                Console.WriteLine("Removed reservation.");
            }
            else
            {
                Console.WriteLine("Could not find reservation");
            }

        }

        public static void EditName(string name_of_res, string value_to_change_to)
        {
            int edit_index = FindReservationIndex(name_of_res);

            if (edit_index != -1)
            {
                Reservations[edit_index].Name = value_to_change_to;
                Console.WriteLine("Edited name of reservation.");
            }
            else
            {
                Console.WriteLine("Could not find reservation");
            }
        }
        public static void EditEmail(string name_of_res, string value_to_change_to)
        {
            int edit_index = FindReservationIndex(name_of_res);

            if (edit_index != -1)
            {
                Reservations[edit_index].Email = value_to_change_to;
                Console.WriteLine("Edited email of reservation.");
            }
            else
            {
                Console.WriteLine("Could not find reservation");
            }
        }
        public static void EditDateTime(string name_of_res, string value_to_change_to)
        {
            int edit_index = FindReservationIndex(name_of_res);

            if (edit_index != -1)
            {
                Reservations[edit_index].Date_time = value_to_change_to;
                Console.WriteLine("Edited DateTime of reservation.");
            }
            else
            {
                Console.WriteLine("Could not find reservation");
            }
        }
        public static void EditPersonCount(string name_of_res, int value_to_change_to)
        {
            int edit_index = FindReservationIndex(name_of_res);

            if (edit_index != -1)
            {
                Reservations[edit_index].Person_count = value_to_change_to;
                Console.WriteLine("Edited person count of reservation.");
            }
            else
            {
                Console.WriteLine("Could not find reservation");
            }
        }

    }
}
