using System;


namespace ProjectB
{
    class Program
    {
        static void Main(string[] args)
        {
            ReservationService.LoadReservations();
            ReviewStuff.LoadReviews();
            int pageNumber = 0;

            while (true)
            {
                switch (pageNumber)
                {
                    case 0:
                        pageNumber = MainPage();
                        break;
                    case 1:
                        pageNumber = AccountCreation();
                        break;
                    case 2:
                        pageNumber = ReservationMenu();
                        break;
                    case 3:
                        pageNumber = ReviewMenu();
                        break;
                    case 4:
                        pageNumber = OrderMenu();
                        break;
                    case 5:
                        Console.Clear();
                        FoodMenu.PrintMainCourses();
                        Console.WriteLine("\nPress 'Enter' to go back.");
                        Console.ReadLine();
                        pageNumber = 0;
                        break;
                    case 99:
                        return;

                }
            }
        }

        private static int OrderMenu()
        {
            Console.Clear();
            string menuOptions;
            Console.WriteLine("Press 1 for the appetizers\nPress 2 for the main course\nPress 3 for the vegan main course\nPress 4 for the desserts\nPress 5 for the vegan deserts\nPress 6 for the drinks\nPress 7 to end order and go back");
            while (true)
            {
                menuOptions = Console.ReadLine();
                if (menuOptions == "1")
                {
                    Console.Clear();
                    FoodMenu.PrintAppetizers();

                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 4;
                }
                else if (menuOptions == "2")
                {
                    Console.Clear();
                    FoodMenu.PrintMainCourses();

                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 4;
                }
                else if (menuOptions == "3")
                {
                    Console.Clear();
                    FoodMenu.PrintVeganMainCourses();

                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 4;
                }
                else if (menuOptions == "4")
                {
                    Console.Clear();
                    FoodMenu.PrintDesserts();

                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 4;
                }
                else if (menuOptions == "5")
                {
                    Console.Clear();
                    FoodMenu.PrintVeganDesserts();

                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 4;
                }
                else if (menuOptions == "6")
                {
                    Console.Clear();
                    FoodMenu.PrintDrinks();

                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 4;
                }
                else if (menuOptions == "7")
                {
                    Console.Clear();
                    FoodMenu.SaveOrder();

                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 0;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }

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

        private static int ReviewMenu()
        {
            Console.Clear();
            string reviewInput;
            Console.WriteLine($"Welcome to the review menu!\n\nPress 1 to write a review\nPress 2 to read all reviews\nPress 3 to delete a review\nPress 4 to go back to the main menu");
            while (true)
            {
                reviewInput = Console.ReadLine();
                if (reviewInput == "1")
                {
                    Console.Clear();
                    
                    Console.Write("Enter your name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter your email: ");
                    string email = Console.ReadLine();
                    Console.Write("Write your review: ");
                    string reviewtext = Console.ReadLine();
                    
                    bool RatingStatus = false;

                    while (RatingStatus == false)
                    {
                        Console.Write("How many stars(1 - 5) would you rate your visit?: ");
                        string rating = Console.ReadLine();

                        if (rating == "1" | rating == "2" | rating == "3" | rating == "4" | rating == "5")
                        {
                            RatingStatus = true;
                            ReviewStuff.WriteReview(name, email, reviewtext, rating);
                            ReviewStuff.SaveReviews();
                        }
                        else
                        {
                            RatingStatus = false;
                            Console.WriteLine("Please enter a valid rating, between 1 and 5");
                        }
                    }
                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 3;
                }
                else if (reviewInput == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Written Reviews:\n");
                    ReviewStuff.ListReviews();

                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 3;
                }
                else if (reviewInput == "3")
                {
                    Console.Clear();
                    ReviewStuff.ListReviews();
                    Console.Write("\nWhat is the name that wrote the review you wish to delete?: ");
                    string ReviewToDelete = Console.ReadLine();
                    ReviewStuff.DeleteReviews(ReviewToDelete);
                    ReviewStuff.SaveReviews();
                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 3;
                }
                else if (reviewInput == "4")
                {
                    return 0;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }
    
        private static int MainPage()
        {
            Console.Clear();
            Console.WriteLine("Welcome!\n\nPress 1 for login and account creation \nPress 2 to go to the reservations section \nPress 3 to open the review section\nPress 4 to place an order\nPress 5 to look at the menu\nPress 6 exit the application\n");
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
                    return 4;
                }
                else if (userInput == "5")
                {
                    return 5;
                }
                else if (userInput == "6")
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
