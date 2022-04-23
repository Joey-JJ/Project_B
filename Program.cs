using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace WerkRoosterProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string userInputWorkSchedule;
            Console.WriteLine("Welcome to the WorkSchedule Menu\n [1] to add Shifts\n [2] for deleting shifts\n [3] to edit shift \n [4] to list all shifts ");
            while (true)
            {
                userInputWorkSchedule = Console.ReadLine();
                if (userInputWorkSchedule == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Add shift beneath");
                    Console.ReadLine();
                }

                else if (userInputWorkSchedule == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Delete Shifts");
                }

                else if (userInputWorkSchedule == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Edit Shifts");
                }

                else if (userInputWorkSchedule == "4")
                {
                    Console.Clear();
                    Console.WriteLine("List of all Shifts");


                    Shift shift = new Shift()
                    {
                        Id = 10478,
                        Name = "Lorenzo",
                        dag = "Zaterdag 23 april ",
                        werktijd = "16:00-23:00",
                        functies = new List<string>()
                    {
                    "Koken",
                    "Schoonmaken",
                    "Tavelsbedekken"
                    }
                };

                string strResultJson = JsonConvert.SerializeObject(shift);
                //Console.WriteLine(strResultJson);
                File.WriteAllText(@"Duty.json", strResultJson);
                //Console.WriteLine("Stored!");


                strResultJson = File.ReadAllText(@"Duty.json");
                Shift resultShift = JsonConvert.DeserializeObject<Shift>(strResultJson);
                Console.WriteLine(resultShift.ToString());

                }
                else
                {
                    System.Console.WriteLine("Please enter a valid number");
                }

            }

        }

    }

}
