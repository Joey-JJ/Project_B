using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace WerkRoosterProgram
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.Clear();
            string userInputWorkSchedule;
            string YesOrNo;
            string YesOrNoDelete;
            string ShiftNummer;
            while (true)
            {
                userInputWorkSchedule = Console.ReadLine();

                if (userInputWorkSchedule == "b")

                {
                    Console.Clear();
                    Console.WriteLine("Welcome to the menu for WorkSchedule\n Press [1] to make Schedule \n Press [2] to delete schedule\n Press [3] to edit schedule\n Press [4] to see a list of all shifts");

                }
                else if (userInputWorkSchedule == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Type amount of employee you want to roster in word format (one, two, etc). (maximum of 10)");
                    ShiftNummer = Console.ReadLine();
                    Console.Clear();

                    if (ShiftNummer == "one")
                    {
                        Console.Clear();

                        Console.WriteLine("Type name of worker and press 'Enter' to continue");
                        string name1 = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Type date and timeslot and press 'Enter' to continue");
                        string date1 = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Type duty and press 'Enter' to continue");
                        string duty1 = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine();

                        var list = new List<Shift>
                        {
                        new Shift(name1, date1, duty1)
                        };

                        Console.Clear();
                        Console.WriteLine("Current shift information:");
                        Console.WriteLine("");
                        Console.WriteLine(name1 +" "+ date1 + " "+ duty1 );
                        Console.WriteLine("");

                        Console.WriteLine("Are u Sure you want to save this Shift To the WorkSchedule ?");
                        YesOrNo = Console.ReadLine();
                        if (YesOrNo == "Yes")
                        {
                            string strResultJsonshift1 = JsonConvert.SerializeObject(list, Formatting.Indented);
                            File.WriteAllText(@"Duty.json", strResultJsonshift1);
                            Console.Clear();
                            Console.WriteLine("Shift saved !");
                        }
                        else if (YesOrNo == "No")
                        {
                            Console.WriteLine("Shift is NOT saved, type B and click 'Enter' to go close page");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid response in the format 'Yes' or 'No'");
                            Console.ReadLine();

                        }
                        Console.WriteLine("\n Type 'b' and click 'Enter' and to close page");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("\n Type 'b' and click 'Enter' and to go back to main menu");
                    }


                    if (ShiftNummer == "two")
                    {

                        Console.Clear();

                        Console.WriteLine("Type name of worker and press 'Enter' to continue");
                        string name1 = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Type date and timeslot and press 'Enter' to continue");
                        string date1 = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Type duty and press 'Enter' to continue");
                        string duty1 = Console.ReadLine();
                        Console.WriteLine();

                        Console.Clear();
                        Console.WriteLine("selected :" + name1 + " " + date1 + " " + duty1 );

                        Console.WriteLine();

                        Console.WriteLine("Type name of worker 2 and press 'Enter' to continue");
                        string name2= Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Type date and timeslot and press 'Enter' to continue");
                        string date2 = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Type duty worker 2 and press 'Enter' to continue");
                        string duty2 = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine();


                        var list = new List<Shift>
                        {
                        new Shift(name1, date1, duty1),
                        new Shift(name2, date2, duty2),
                        };

                        Console.Clear();
                        Console.WriteLine("Current shift information:");
                        Console.WriteLine("");
                        Console.WriteLine(name1 + " " + date1 + " " + duty1);
                        Console.WriteLine(name2 + " " + date2 + " " + duty2);
                        Console.WriteLine("");

                        Console.WriteLine("Are u Sure you want to save this Shift To the WorkSchedule ?");
                        YesOrNo = Console.ReadLine();
                        if (YesOrNo == "Yes")
                        {
                            string strResultJsonshift1 = JsonConvert.SerializeObject(list, Formatting.Indented);
                            File.WriteAllText(@"Duty.json", strResultJsonshift1);
                            Console.Clear();
                            Console.WriteLine("Shift saved !");
                        }
                        else if (YesOrNo == "No")
                        {
                            Console.WriteLine("Shift is NOT saved, type B and click 'Enter' to go close page");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid response in the format 'Yes' or 'No'");
                            Console.ReadLine();

                        }
                        Console.WriteLine("\n Type 'b' and click 'Enter' and to close page");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("\n Type 'b' and click 'Enter' and to go back to main menu");
                    }



                    else
                    {
                        Console.WriteLine(" Press b and 'Enter' to go back to menu");

                    }

                }
                else if (userInputWorkSchedule == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Do you really want do delete all shifts ? ");

                    YesOrNoDelete = Console.ReadLine();


                    if (YesOrNoDelete == "Yes")
                    {
                        var list = new List<Shift>
                        {
                        new Shift("", "", ""),
                        };
                        string strResultJsonshift1 = JsonConvert.SerializeObject(list, Formatting.Indented);
                        File.WriteAllText(@"Duty.json", strResultJsonshift1);
                        Console.Clear();
                        Console.WriteLine("All shifts Deleted !");

                    }
                    else if (YesOrNoDelete == "No")
                    {
                        Console.WriteLine("Shift is NOT saved, type B and click 'Enter' to go close page");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid response in the format 'Yes' or 'No'");
                        Console.ReadLine();

                        Console.WriteLine("Press b and 'Enter' to go back to menu");
                    }

                }

                else if (userInputWorkSchedule == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Edit Shifts option not avaiable at this time,contact IT department for status update ");
                    Console.WriteLine("Press b and 'Enter' to go back to menu");

                }
                else if (userInputWorkSchedule == "4")
                {
                    Console.Clear();
                    Console.WriteLine("List of all Shifts");
                    Console.WriteLine("");



                    var result1 = JsonConvert.DeserializeObject <List<Shift>>(File.ReadAllText(@"Duty.json"));
                    foreach (Shift shift in result1)
                    {
                        Console.WriteLine($"\n\"{shift.name}\n\"{shift.date}\n\"{shift.duty}");
                    }


                        Console.WriteLine("");

                    Console.WriteLine("Press b and 'Enter' to go back to menu");

                }
                else
                {
                    System.Console.WriteLine("Please enter a valid number");
                }

            }
        }
    }
}
//string strResultJson = JsonConvert.SerializeObject(shift11);
// Console.WriteLine(strResultJson);
//File.WriteAllText(@"Medewerker.json", strResultJson);
//Console.WriteLine("Stored!");


//Shift strResultJson11 = JsonConvert.DeserializeObject<Shift>(shift11);
//Console.WriteLine(strResultJsonShift11.ToString());
//  Shift resultshift11 = JsonConvert.DeserializeObject<Shift>(resultshift11);
//  Console.WriteLine(resultshift11.ToString());
//Shift shift1 = new Shift("nummer", "Lorenzo", "Zaterdag 23 april", "tijdsvak")
//{
//    name = "nummer",
//    day = "Lorenzo",
//    time = "zatersag 23 februari",
//    duty = "16:00-23:00",
//};

//string strResultJson = JsonConvert.SerializeObject(shift1);
//File.WriteAllText(@"Duty.json", strResultJson);
//Console.WriteLine("Stored!");
//strResultJson = File.ReadAllText(@"Duty.json");
//Shift resultShift = JsonConvert.DeserializeObject<Shift>(strResultJson);
//Console.WriteLine(resultShift.ToString());
//Shift resultshift11 = JsonConvert.DeserializeObject<Shift>(strResultJson);
//Console.WriteLine(resultshift11.ToString());