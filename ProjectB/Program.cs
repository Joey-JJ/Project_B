using System;


namespace ProjectB
{
    class Program
    {
        static void Main(string[] args)
        {
            Reservation.LoadReservations();
            Console.Clear();
            bool keepRunning = true;
            int pageNumber = 0;
            string userInput;

            while (keepRunning)
            {
                switch (pageNumber)
                {
                    case 0:
                        MainPage(out pageNumber, out userInput);
                        break;

                    case 1:
                        AccountCreation(out pageNumber, out userInput);
                        break;

                    case 2:
                        userInput = ReservationMenu(ref pageNumber);
                        break;

                    case 3:
                            FullMenu.PrintMenu();
                            pageNumber = 0;
                            break;
                }
            }
        }

        private static string ReservationMenu(ref int pageNumber)
        {
            string userInput;
            Console.WriteLine($"\nWelcome to the reservation menu,\n Press 1 to add a reservation \n Press 2 to delete a reservation \n Press 3 to edit a reservation \n Press 4 to list all reservations \n Press 5 to go back to the main menu");
            while (true)
            {
                userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    // Console.Clear();
                    Console.Write("Enter your name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter your email: ");
                    string email = Console.ReadLine();
                    Console.Write("When do you want to come? ");
                    string datetime = Console.ReadLine();
                    Console.Write("With how many persons are you coming? ");
                    int persons = Convert.ToInt32(Console.ReadLine());

                    Reservation.AddReservation(name, email, datetime, persons);
                    Reservation.SaveReservations();
                    pageNumber = 0;
                    break;
                }
                else if (userInput == "2")
                {
                    // Console.Clear();
                    Console.Write("Enter the name of the reservation you want to delete");
                    string nameToDelete = Console.ReadLine();
                    Reservation.RemoveReservation(nameToDelete);
                    Reservation.SaveReservations();
                    break;
                }
                else if (userInput == "3")
                {
                    System.Console.Write("Enter the name of the reservation you want to edit: ");
                    string nameToEdit = Console.ReadLine();
                    System.Console.WriteLine("What do you want to edit?\nPress 1 to alter the name\nPress 2 to alter the email\nPress 3 to alter the date\nPress 4 to edit the amount of people");
                    string thingToEdit;
                    string editName;
                    string editEmail;
                    string editDate;
                    int editPersons;

                    while (true)
                    {
                        thingToEdit = Console.ReadLine();

                        if (thingToEdit == "1")
                        {
                            System.Console.Write("Enter the name you want to change it into: ");
                            editName = Console.ReadLine();
                            Reservation.EditName(nameToEdit, editName);
                            break;
                        }
                        else if (thingToEdit == "2")
                        {
                            System.Console.Write("Enter the email you want to change it into: ");
                            editEmail = Console.ReadLine();
                            Reservation.EditEmail(nameToEdit, editEmail);
                            break;
                        }
                        else if (thingToEdit == "3")
                        {
                            System.Console.Write("Enter the date you want to change it into: ");
                            editDate = Console.ReadLine();
                            Reservation.EditDateTime(nameToEdit, editDate);
                            break;
                        }
                        else if (thingToEdit == "4")
                        {
                            System.Console.Write("How many persons are you coming with? ");
                            editPersons = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        else
                        {
                            System.Console.WriteLine("Please enter a valid number");
                        }
                    }
                    pageNumber = 0;
                    break;
                }
                else if (userInput == "4")
                {
                    Reservation.ListReservations();
                    pageNumber = 0;
                    break;
                }
                else if (userInput == "5")
                {
                    pageNumber = 0;
                    break;
                }
                else
                {
                    System.Console.WriteLine("Please enter a valid number");
                }
            }

            return userInput;
        }

        private static void AccountCreation(out int pageNumber, out string userInput)
        {
            // Console.Clear();
            Console.WriteLine("Account Creation. Press 1 to go back");

            while (true)
            {
                userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    pageNumber = 0;
                    break;
                }
                else
                {
                    System.Console.WriteLine("Invalid input, try again");
                }
            }
        }

        private static void MainPage(out int pageNumber, out string userInput)
        {
            // Console.Clear();
            Console.WriteLine("\nWelcome! \n Press 1 for login and account creation \n Press 2 to go to the reservations section \n Press 3 to see the menu");

            while (true)
            {
                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    pageNumber = 1;
                    break;
                }
                else if (userInput == "2")
                {
                    pageNumber = 2;
                    break;
                }
                else if (userInput == "3")
                {
                    pageNumber = 3;
                    break;
                }
                else
                {
                    System.Console.WriteLine("Please enter a valid number");
                }
            }
        }
    }
}
