using System;

namespace WorkSchedule
{
    public class Person
    {
        public string Name;
        public int Age;
        public bool HasPet;

        public void Greeting()
        {
            Console.WriteLine("WerkRoosters 2022");
        }
    }

    public class Person2
    {
        public string Name;
        public int Age;
        public bool HasPet;

        public void Greeting2()
        {
            Console.WriteLine("Hi! My name is is " + Name + " and my age age age " + Age);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "John";
            person.Age = 28;
            person.HasPet = true;

            person.Greeting();

            
            Console.Write("Enter Day: ");
            string Day = Console.ReadLine();



            if (Day == "maandag")
            {
                Console.WriteLine("Werk Rooster Maandag");

                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("| [Isabella]  [ x     ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Lorenzo ]  [       ] [  x    ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Mario   ]  [       ] [       ] [  x     ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Luciano ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Sergio  ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Danilo  ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]"); 
            }

            else if (Day == "dinsdag") 
            {
                Console.WriteLine("Dinsdag");

                Console.WriteLine("Werk Rooster Dinsdag");

                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("| [Isabella]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Lorenzo ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Mario   ]  [       ] [x      ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Luciano ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Sergio  ]  [       ] [       ] [     x  ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Danilo  ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
            }

            else if (Day == "woensdag") 

            {
                Console.WriteLine("Werk Rooster Woensdag");

                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("| [Isabella]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Lorenzo ]  [ x     ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Mario   ]  [       ] [ x     ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Luciano ]  [       ] [       ] [ x      ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Sergio  ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Danilo  ]  [       ] [       ] [        ] [    x    ] [       ] [        ] [      ]");
            }


            else if (Day == "donderdag") 

            {
                Console.WriteLine("Werk Rooster Donderdag");

                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("| [Isabella]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Lorenzo ]  [  x    ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Mario   ]  [       ] [  x    ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Luciano ]  [       ] [       ] [    x   ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Sergio  ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Danilo  ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
            }


            else if (Day == "vrijdag") 

            {
                Console.WriteLine("Werk Rooster Vrijdag");

                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("| [Isabella]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Lorenzo ]  [       ] [  x    ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Mario   ]  [       ] [       ] [        ] [     x   ] [       ] [        ] [      ]");
                Console.WriteLine("| [Luciano ]  [       ] [       ] [ x      ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Sergio  ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Danilo  ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
            }


            else if (Day == "zaterdag") 
            {
                Console.WriteLine("Werk Rooster zaterdag");

                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("| [Isabella]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Lorenzo ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Mario   ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Luciano ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Sergio  ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
                Console.WriteLine("| [Danilo  ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
            }


            else if (Day == "zondag")
            {
                Console.WriteLine("zondag");
            }

            else
            {
                Console.WriteLine("Input is geen dag");

            }

        }
    }
}
//Console.Write("Enter Time: ");
//string time = Console.ReadLine();
//string mpeach = ("--Free--");
//Console.WriteLine("");
//Console.Write("Enter Day: ");
//string Day = Console.ReadLine();
//Console.WriteLine();
//Console.Write("Enter Time: ");
//string Time = Console.ReadLine();
//Console.WriteLine();
//Console.Write("Enter Workers: ");
//string Worker = Console.ReadLine();
//Console.WriteLine(Day + " " + Time + " " + Worker);


//Console.Write("Klik enter voor Werkrooster: ");
//string time = Console.ReadLine();

//Console.WriteLine("");

//Console.WriteLine("Werk Rooster maandag");

//Console.WriteLine("-------------------------------------------------------------------------------------");
//Console.WriteLine("| [Isabella]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
//Console.WriteLine("| [Lorenzo ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
//Console.WriteLine("| [Mario   ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
//Console.WriteLine("| [Luciano ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
//Console.WriteLine("| [Sergio  ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");
//Console.WriteLine("| [Danilo  ]  [       ] [       ] [        ] [         ] [       ] [        ] [      ]");