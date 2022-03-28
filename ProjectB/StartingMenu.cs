using System;


namespace ProjectB
{
    class StartingScreen
    {
        static public void  StartMenu()
        {
            Console.Clear();
            // page 1
            Console.WriteLine("Welcome! \n Press 1 for login and account creation \n Press 2 to see reservations  \n Press 3 to see the menu");
            
            var StartingScreenOutput = WithinBounds(1, 3);


            switch (StartingScreenOutput)
            {
                case 1:
                    Console.WriteLine("You picked Login and account creation");
                    Console.Clear();
                    AccountMenu();
                    break;
                case 2:
                    Console.WriteLine("You picked: Reservations");
                    Console.Clear();
                    ReservationMenu();
                    break;
                case 3:
                    Console.WriteLine("You picked to see the menu");
                    Console.Clear();
                    FullMenu.PrintMenu();
                    break;
            }
        }
        static void ReservationMenu()//Helps the user navigate to the reservation functionality
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the reservation menu,\n Press 1 to add a reservation \n Press 2 to delete a reservation \n Press 3 to edit a reservation \n Press 4 to list all reservations \n Press 5 to go back to the main menu");
            int SanitizedInteger = WithinBounds(1, 5);
            string name = "";
            string Email = "";
            string DateTime = "";
            Action<string> RouteBackToReservationMenu = input =>
            {
                bool isthisstringanumber = IsThisStringaNumber(input);
                if (isthisstringanumber)
                {
                    ReservationMenu();
                }
            };
            int SanitizedPersonCount = 0;
           switch(SanitizedInteger) {
                case 1:
                    {
                        int page = 1;
                        switch (page)
                        {
                            case 1:
                                Console.Clear(); 
                                Console.WriteLine("What is your name?, \n\n Press 1 to go back to the reservation menu");
                                RouteBackToReservationMenu(Console.ReadLine());
                                name = Console.ReadLine();
                                page++;
                                break;
                            case 2:
                                Console.WriteLine("What is your E-mail address? \n\n Press 1 to go back to the reservation menu");
                                RouteBackToReservationMenu(Console.ReadLine());
                                Email = Console.ReadLine();
                                page++;
                                break;


                            case 3:
                                Console.WriteLine("How many people do you want to place reservations for?");
                                SanitizedPersonCount = WithinBounds(1, 30);
                                page++;
                                break;
                            case 4:
                                Console.WriteLine("At what date would you like to be seated? \n\n Press 1 to go back to the reservation menu");
                                RouteBackToReservationMenu(Console.ReadLine());
                                DateTime = Console.ReadLine();

                                break;
                            case 5:
                                
                                Console.Clear();
                                Console.WriteLine($"made a reservation for: {SanitizedPersonCount} people registered under the name: {name} at the following date: {DateTime}. \n Thanks for making a reservation!");
                                Console.WriteLine(" \n if there is anything wrong with the name, press 1" +
                                    "\n if there is anything wrong with the DateTime, press 2" +
                                    "\n if there is anything wrong with the amount of people visiting press 3 " +
                                    "\n if there is anything wrong with the date of visit press 4" +
                                    "\n To continue press 5 and you will be routed back to the starting screen");
                                page = WithinBounds(1, 5);
                                Reservation.AddReservation(name, Email, DateTime, SanitizedPersonCount);
                                Reservation.SaveReservations();
                                Console.Clear();
                                StartMenu();
                                break;
                        }  
                        break;
                    }

                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("Under what name was the reservation registered? \n\n Press 1 to go back to the reservation menu");
                        RouteBackToReservationMenu(Console.ReadLine());
                        name = Console.ReadLine();
                        Reservation.RemoveReservation(name);
                        Reservation.SaveReservations();
                        break;
                    }

                case 3:
                    {
                        Console.Clear();
                        Console.WriteLine("Welcome to the reservation altering menu. \n To get started, under which name was the reservation registered? \n\n Press 1 to go back to the reservation menu");
                        RouteBackToReservationMenu(Console.ReadLine());
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
                        int ReservationAlterChoice = WithinBounds(1, 4);
                        switch (ReservationAlterChoice)
                        {

                            case 1: //alter the name
                                Console.Clear();
                                Console.WriteLine("What would you like the name to be?");
                                Reservation.EditName(ReservationName, Console.ReadLine());
                                Reservation.SaveReservations();
                                Console.WriteLine("Alteration completed! Routing you back to the main menu");
                                Console.Clear();
                                StartMenu();
                                break;

                            case 2: //alter the email
                                Console.Clear();
                                Console.WriteLine($"What would you like the email to be?");
                                Reservation.EditName(ReservationName, Console.ReadLine());
                                Reservation.SaveReservations();
                                Console.WriteLine("Alteration completed! Routing you back to the main menu");
                                Console.Clear();
                                StartMenu();
                                break;

                            case 3: // alter the date
                                Console.Clear();
                                Console.WriteLine("What would you like the Date to be? \n Please input the DateTime in the format: (HH/DD/MM/YY).");
                                Reservation.EditName(ReservationName, Console.ReadLine());
                                Reservation.SaveReservations();
                                Console.WriteLine("Alteration completed! Routing you back to the main menu");
                                Console.Clear();
                                StartMenu();
                                break;

                            case 4: // alter the personcount
                                Console.Clear();
                                Console.WriteLine("What would you like the person count to be instead?");
                                Reservation.EditName(ReservationName, Console.ReadLine());
                                Reservation.SaveReservations();
                                Console.WriteLine("Alteration completed! Routing you back to the main menu");
                                Console.Clear();
                                StartMenu();
                                break;
                        }

                        break;
                    }

                case 4:
                    Console.WriteLine("You chose to list all the current reservations");
                    Reservation.ListReservations();
                    Console.WriteLine("Listing complete! Routing you back to the main menu");
                    StartMenu();
                    break;

                case 5:
                    Console.WriteLine("You chose to go back to the main menu, Routing you back now.");
                    StartMenu();
                    break;
            }
        }
        static void AccountMenu()
        {
            Action<string> RouteBackToReservationMenu = input =>
            {
                bool isthisstringanumber = IsThisStringaNumber(input);
                if (isthisstringanumber)
                {
                    ReservationMenu();
                }
            };
            Console.WriteLine("Press 1 to log in, press 2 to make an account, press 3 to go back to the main menu.");
            int input = WithinBounds(1, 3);
            switch (input)
            {
                case 1:
                                    
                    Console.WriteLine("You chose to log in");
                    Console.Clear();
                    Console.WriteLine("What is your e-mailaddress? \n\n Press 1 to go back to the main menu.");
                    string e_mail = Console.ReadLine();
                    RouteBackToReservationMenu(Console.ReadLine());
                    Console.WriteLine("What is your Pasword?");
                    string Password = Console.ReadLine();
                    break;


                case 2:
                    Console.WriteLine("You chose account creation.");
                    Console.Clear();
                    Console.WriteLine("What is your name? \n\n Press 1 to go back to the main menu.");
                    string name = Console.ReadLine();
                    RouteBackToReservationMenu(Console.ReadLine());
                    Console.WriteLine("What is your e-mail adress? \n\n Press 1 to go back to the main menu.");
                    string E_mail = Console.ReadLine();
                    RouteBackToReservationMenu(Console.ReadLine());
                    string PassWord = PasswordVerifier();
                    break;

                case 3:
                    Console.WriteLine("Routing you back to the main menu!");
                    StartMenu();
                    break;


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
        static bool IsThisStringaNumber(string input) // returns true if the string can be converted to a number
        {
            try
            {
                Convert.ToInt32(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        static int WithinBounds(int LowerBound, int UpperBound) // checks if the users given input is within the bounds of the menu
        {
            int input = InputErrorChecker(Console.ReadLine());
            try
            {
                if (input <= UpperBound && input >= LowerBound)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine($"{input} Is not part of the selection \n please try again");
                    return WithinBounds(LowerBound, UpperBound);
                }
            }
            catch
            {
                Console.WriteLine("Something went wrong. \n Please try again");
                return WithinBounds(LowerBound, UpperBound);
            }
        } 
        static string PasswordVerifier()
        {
            Console.WriteLine("What do you want your password to be?");
            string passwordentry1 = Console.ReadLine();
            Console.WriteLine("to verify password enter it again please.");
            string passwordentry2 = Console.ReadLine();
            if (passwordentry1 == passwordentry2)
            {
 
                Console.WriteLine("Password verification complete! routing you back to the main menu.");
                return passwordentry1;
                StartMenu();
            }
            else
            {
                Console.WriteLine("Something went wrong please try again");
                return PasswordVerifier();
            }


        }

    }


}
