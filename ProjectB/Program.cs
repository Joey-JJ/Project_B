using System;


namespace ProjectB
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = new(2000, 1, 1);
            var rest = new RestaurantDay(date);
            rest.Tables[0] = new Table(99, 99);
            System.Console.WriteLine(Restaurant.RestaurantLayout[0].TableNumber);
            // ReservationService.LoadReservations();
            // int pageNumber = 0;

            // while (true)
            // {
            //     switch (pageNumber)
            //     {
            //         case 0:
            //             pageNumber = MainPage();
            //             break;
            //         case 1:
            //             pageNumber = AccountCreation();
            //             break;
            //         case 2:
            //             pageNumber = ReservationMenu();
            //             break;
            //         case 3:
            //             Console.Clear();
            //             FoodMenu.PrintMainCourses();
            //             Console.WriteLine("\nPress 'Enter' to go back.");
            //             Console.ReadLine();
            //             pageNumber = 0;
            //             break;
            //         case 99:
            //             return;

            //     }
            // }
        }

        private static int ReservationMenu()
        {
            Console.Clear();
            string userInput;
            Console.WriteLine($"Welcome to the reservation menu!\n\nPress 1 to add a reservation \nPress 2 to delete a reservation\nPress 3 to edit a reservation\nPress 4 to list all reservations\nPress 5 to go back to the main menu");
            while (true)
            {
                userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    Console.Clear();
                    var datetime = ReservationService.GetReservationTime(ReservationService.GetReservationDate());
                    int persons;
                    while (true)
                    {
                        try
                        {
                            Console.Write("With how many persons are you coming? ");
                            persons = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch (System.Exception)
                        {
                            System.Console.WriteLine("Invalid input, please try again...");
                            throw;
                        }
                    }

                    ReservationService.AddReservation(datetime, persons);
                    ReservationService.SaveReservations();

                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 0;
                }
                else if (userInput == "2")
                {
                    Console.Clear();
                    ReservationService.ListReservations();
                    Console.Write("\nEnter the name of the reservation you want to delete: ");
                    string nameToDelete = Console.ReadLine();
                    ReservationService.RemoveReservation(nameToDelete);
                    ReservationService.SaveReservations();
                    System.Console.WriteLine("\nPress 'Enter' to go back");
                    System.Console.ReadLine();
                    return 2;
                }
                else if (userInput == "3")
                {
                    System.Console.Write("Enter the name of the reservation you want to edit: ");
                    string nameToEdit = Console.ReadLine();
                    Console.Clear();
                    System.Console.WriteLine("What do you want to edit?\nPress 1 to alter the name\nPress 2 to alter the email\nPress 3 to alter the date\nPress 4 to edit the amount of people");
                    string thingToEdit;
                    string editName;
                    string editEmail;
                    DateTime editDate;
                    int editPersons;

                    while (true)
                    {
                        thingToEdit = Console.ReadLine();

                        if (thingToEdit == "1")
                        {
                            System.Console.Write("Enter the name you want to change it into: ");
                            editName = Console.ReadLine();
                            ReservationService.EditName(nameToEdit, editName);
                            break;
                        }
                        else if (thingToEdit == "2")
                        {
                            System.Console.Write("Enter the email you want to change it into: ");
                            editEmail = Console.ReadLine();
                            ReservationService.EditEmail(nameToEdit, editEmail);
                            break;
                        }
                        else if (thingToEdit == "3")
                        {
                            System.Console.Write("Enter the date you want to change it into: ");
                            Console.ReadLine();
                            editDate = new DateTime(1999, 1, 1);
                            ReservationService.EditDateTime(nameToEdit, editDate);
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
                    return 2;
                }
                else if (userInput == "4")
                {
                    Console.Clear();
                    ReservationService.ListReservations();
                    System.Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 2;
                }
                else if (userInput == "5")
                {
                    return 0;
                }
                else
                {
                    System.Console.WriteLine("Please enter a valid number");
                }
            }
        }

        private static int AccountCreation()
        {
            Console.Clear();
            Console.WriteLine("Account Creation. Press 'Enter' to go back");
            Console.ReadLine();
            return 0;
        }

        private static int MainPage()
        {
            Console.Clear();
            Console.WriteLine("Welcome!\n\nPress 1 for login and account creation \nPress 2 to go to the reservations section \nPress 3 to see the menu\nPress 4 to quit the application\n");
            string userInput;
            while (true)
            {
                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    return 1;
                }
                else if (userInput == "2")
                {
                    return 2;
                }
                else if (userInput == "3")
                {
                    return 3;
                }
                else if (userInput == "4")
                {
                    return 99;
                }
                else
                {
                    System.Console.WriteLine("Please enter a valid number");
                }
            }
        }
    }
}
