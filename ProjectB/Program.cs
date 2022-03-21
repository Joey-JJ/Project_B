using System;


namespace ProjectB
{
    class StartingScreen
    {
        static void  Main()
        {
            string startingscreen = "Hello, welcome to paps patat \n Press 1 for login and account creation \n Press 2 to see reservations";
            Console.WriteLine(startingscreen);
            var Unsanitized_MenuSelection = Console.ReadLine();
            var StartingScreenOutput = InputErrorChecker(Unsanitized_MenuSelection);
            if (StartingScreenOutput == 1)
            {
                Console.WriteLine($"you picked Login and account creation");
                Console.Clear();
                Console.WriteLine("Thanks for participating in the demo.");
            }
            else if (StartingScreenOutput == 2)
            {
                Console.WriteLine("You picked: Reservations");
                Console.Clear();
                ReservationMenu();
            }
        }
        static void ReservationMenu()//Helps the user navigate to the reservation functionality
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the reservation menu,\n press 1 to add a reservation, press 2 to delete a reservation, \n press 3 to edit a reservation, press 4 to list all reservations");
          int  SanitizedInteger =  InputErrorChecker(Console.ReadLine());
            while (SanitizedInteger<1) 
            {
               SanitizedInteger =  InputErrorChecker(Console.ReadLine());
            }
            if (SanitizedInteger == 1)
            {
                Console.Clear();
                Console.WriteLine("What is your name?");
                string name = Console.ReadLine();
                Console.WriteLine("What is your E-mail address?");
                string Email = Console.ReadLine();
                Console.WriteLine("At what date would you like to be seated?");
                string DateTime = Console.ReadLine();
                Console.WriteLine("how many people will be attending?");
                string UnsanitizedPersonCount = Console.ReadLine();
                int SanitizedPersonCount = InputErrorChecker(UnsanitizedPersonCount);
                Console.WriteLine($"made a reservation for: {SanitizedPersonCount} people registered under the name: {name} at the following date: {DateTime}. \n Thanks for making a reservation!");
                Schedule.AddReservation(name, Email, DateTime, SanitizedPersonCount);
            }
            else if (SanitizedInteger == 2)
            {
                Console.Clear();
                Console.WriteLine("Under what name was the reservation registered?");
                string name = Console.ReadLine();
                Schedule.RemoveReservation(name);
            }
            else if (SanitizedInteger == 3)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the reservation altering menu. \n To get started, under which name was the reservation registered?");
                bool VerifiedName = false;
                string ReservationName = "";
                while (!VerifiedName)
                {
                    try
                    {
                        ReservationName = Console.ReadLine();
                        VerifiedName = true;
                    }
                    catch
                    {
                        Console.WriteLine("Something went wrong, Try again!");
                    }
                }
                Console.Clear();
                Console.WriteLine($"For the reservation under the name {VerifiedName},\n press 1 to alter the name, press 2 to alter the email, \n press 3 to alter the date (HH/DD/MM/YY), press 4 to edit the amount of people");
                int ReservationAlterChoice = InputErrorChecker(Console.ReadLine());
                switch (ReservationAlterChoice)
                {
                    case 1: //alter the name
                        Console.Clear();
                        Console.WriteLine("What would you like the name to be?");
                        Schedule.EditName(ReservationName, Console.ReadLine());
                        break;
                    case 2: //alter the email
                        Console.Clear();
                        Console.WriteLine($"What would you like the email to be?");
                        Schedule.EditName(ReservationName, Console.ReadLine());
                        break;
                    case 3: // alter the date
                        Console.Clear();
                        Console.WriteLine("What would you like the Date to be? \n Please input the DateTime in the format: (HH/DD/MM/YY).");
                        Schedule.EditName(ReservationName, Console.ReadLine());
                        break;
                    case 4: // alter the personcount
                        Console.Clear();
                        Console.WriteLine("What would you like the person count to be instead?0");
                        Schedule.EditName(ReservationName, Console.ReadLine());

                        break;
                }
            



            }
           
            else if(SanitizedInteger == 4)
            {
                Console.WriteLine(SanitizedInteger);
                Schedule.ListReservations();
            }
        }
        static int InputErrorChecker(string UnsanitizedString) //creates a Sanitized integer from an Unsanitized string
        {
            int SanitizedInteger = 0;
            try
            {
                SanitizedInteger = Convert.ToInt32(UnsanitizedString);
                return SanitizedInteger;

            }
            catch
            {

                Console.WriteLine("Something went wrong, Try again!");
                InputErrorChecker(Console.ReadLine());
                return SanitizedInteger;
            }
        }


    }
}
