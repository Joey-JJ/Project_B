using System;


namespace ProjectB
{
    class Program
    {
        static void Main()
        {   
            // Testing (TODO: REMOVE)
            CustomerAccounts.AddAccount("test", "test123", "test test");
            CustomerAccounts.AddAccount("test2", "test123", "test test");
            CustomerAccounts.AddAccount("test3", "test123", "test test");
            
            // Load database files
            // ReservationService.LoadReservations();
            // ReviewStuff.LoadReviews();
            
            // Welcome message
            Console.Clear();
            Console.WriteLine("Welcome!\n");
            
            // Page handling
            int PageNumber = 0;
            while (PageNumber != -1)
            {
                switch (PageNumber)
                {
                    case 0:
                    PageNumber = InitialLogInMenu();
                    break;

                    case 1:
                    PageNumber = CostumerLoginMenu();
                    break;

                    case 2:
                    PageNumber = CostumerAccountCreationMenu();
                    break;

                    case 3:
                    PageNumber = EmployeeLoginMenu();
                    break;

                    case 4:
                    PageNumber = CustomerArea();
                    break;
                }
            }
        }

        private static int InitialLogInMenu()
        {
            while (true)
            {
                Console.WriteLine("You will need to log in to proceed. Select an option from the menu below:\n[1] Log in as a costumer\n[2] Create a costumer account\n[3] Log in as an employee\n[4] Quit the application\n");
                Console.Write("Please enter your selection: ");
                var user_input = Console.ReadLine();
                switch (user_input)
                {
                    case "1": return 1;
                    case "2": return 2;
                    case "3": return 3;
                    case "4":
                    Console.WriteLine("Quitting application ...");
                    return -1;

                    default:
                    Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    break;
                }
            }
            
        }

        private static int CostumerLoginMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Customer log in\n");

                Console.Write("Please enter your username: ");
                var username = Console.ReadLine();
                Console.Write("Please enter your password: ");
                var password = Console.ReadLine();

                var account = CustomerAccounts.GetCustomer(username);
                if (account != null && account.Password == password) 
                {
                    account.LogIn(username, password); // Username correct
                    return 4;
                } 
                
                Console.WriteLine("Incorrect log in details, do you want to try again?\n[1] Yes\n[2] No\n");
                Console.Write("Please enter your selection: ");
                string userInput = Console.ReadLine();

                if (userInput == "1") continue;
                if (userInput == "2") return 0;
                else
                {
                    Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                    Console.ReadLine();
                }
            }
        }

        private static int CostumerAccountCreationMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Customer Account Creation\n");

                Console.Write("Enter your full name: ");
                var fullname = Console.ReadLine();
                Console.Write("Enter your preferred username: ");
                var username = Console.ReadLine();
                Console.Write("Enter your password: ");
                var password = Console.ReadLine();

                bool exists = CustomerAccounts.CheckIfAccExists(fullname, username);
                if (exists)
                {
                    Console.WriteLine("There already is an account with that information. Please log in to your account or choose different credentials");
                    Console.WriteLine("Do you want to try again?\n[1] Yes\n[2] No\n");
                    Console.Write("Please enter your selection: ");
                    string userInput = Console.ReadLine();

                    if (userInput == "1") continue;
                    if (userInput == "2") return 0;
                    else
                    {
                        Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                        Console.ReadLine();
                    }
                } 
                else
                {
                    CustomerAccounts.AddAccount(username, password, fullname);
                    Console.WriteLine("Account created, routing you to the log in screen.\nPress 'Enter' to go to the log in screen.");
                    Console.ReadLine();
                    return 1;
                }
            }
        }

        private static int EmployeeLoginMenu() 
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Employee log in\n[1] Log in as a regular employee\n[2] Log in as an admin\n[3] Go back\n");
                Console.Write("Please enter your selection: ");
                var user_input = Console.ReadLine();
                switch (user_input)
                {
                    case "1":
                    
                    break;

                    case "2":
                    // TODO
                    break;

                    case "3":
                    // TODO
                    break;

                    default: 
                    Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    break;
                }
                break;
            }
            return 1;
        }

        private static int CustomerArea()
        {
            // Getting the account that logged in
            var userAccount = CustomerAccounts.GetLoggedInCustomer();
            string userInput;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Logged in as: {userAccount.FullName}");
                Console.WriteLine("What would you like to do?\n[1] Make a reservation\n[2] See your current reservations\n[3] Write a review\n");
                Console.Write("Please enter your selection: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1": // Adding a reservation
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
                        }
                    }

                    ReservationService.AddReservation(datetime, persons, userAccount);
                    ReservationService.SaveReservations();

                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    break;

                    case "2": 
                    break;

                    case "3": 
                    break;

                    default: 
                    Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}

// -------------------------------
// ------------- OLD -------------
// -------------------------------


//         private static int OrderMenu()
//         {
//             Console.Clear();
//             string menuOptions;
//             Console.WriteLine("Press 1 for the appetizers\nPress 2 for the main course\nPress 3 for the vegan main course\nPress 4 for the desserts\nPress 5 for the vegan deserts\nPress 6 for the drinks\nPress 7 to end order and go back");
//             while (true)
//             {
//                 menuOptions = Console.ReadLine();
//                 if (menuOptions == "1")
//                 {
//                     Console.Clear();
//                     FoodMenu.PrintAppetizers();

//                     Console.WriteLine("\nPress 'Enter' to go back");
//                     Console.ReadLine();
//                     return 4;
//                 }
//                 else if (menuOptions == "2")
//                 {
//                     Console.Clear();
//                     FoodMenu.PrintMainCourses();

//                     Console.WriteLine("\nPress 'Enter' to go back");
//                     Console.ReadLine();
//                     return 4;
//                 }
//                 else if (menuOptions == "3")
//                 {
//                     Console.Clear();
//                     FoodMenu.PrintVeganMainCourses();

//                     Console.WriteLine("\nPress 'Enter' to go back");
//                     Console.ReadLine();
//                     return 4;
//                 }
//                 else if (menuOptions == "4")
//                 {
//                     Console.Clear();
//                     FoodMenu.PrintDesserts();

//                     Console.WriteLine("\nPress 'Enter' to go back");
//                     Console.ReadLine();
//                     return 4;
//                 }
//                 else if (menuOptions == "5")
//                 {
//                     Console.Clear();
//                     FoodMenu.PrintVeganDesserts();

//                     Console.WriteLine("\nPress 'Enter' to go back");
//                     Console.ReadLine();
//                     return 4;
//                 }
//                 else if (menuOptions == "6")
//                 {
//                     Console.Clear();
//                     FoodMenu.PrintDrinks();

//                     Console.WriteLine("\nPress 'Enter' to go back");
//                     Console.ReadLine();
//                     return 4;
//                 }
//                 else if (menuOptions == "7")
//                 {
//                     Console.Clear();
//                     FoodMenu.SaveOrder();

//                     Console.WriteLine("\nPress 'Enter' to go back");
//                     Console.ReadLine();
//                     return 0;
//                 }
//                 else
//                 {
//                     Console.WriteLine("Please enter a valid number");
//                 }
//             }

//         }
//         private static int ReservationMenu()
//         {
//             Console.Clear();
//             string userInput;
//             Console.WriteLine($"Welcome to the reservation menu!\n\nPress 1 to add a reservation \nPress 2 to delete a reservation\nPress 3 to edit a reservation\nPress 4 to list all reservations\nPress 5 to go back to the main menu");
//             while (true)
//             {
//                 userInput = Console.ReadLine();
//                 if (userInput == "1")
//                 {
//                     Console.Clear();
//                     var datetime = ReservationService.GetReservationTime(ReservationService.GetReservationDate());
//                     int persons;
//                     while (true)
//                     {
//                         try
//                         {
//                             Console.Write("With how many persons are you coming? ");
//                             persons = Convert.ToInt32(Console.ReadLine());
//                             break;
//                         }
//                         catch (System.Exception)
//                         {
//                             System.Console.WriteLine("Invalid input, please try again...");
//                         }
//                     }

//                     ReservationService.AddReservation(datetime, persons, );
//                     ReservationService.SaveReservations();

//                     Console.WriteLine("\nPress 'Enter' to go back");
//                     Console.ReadLine();
//                     return 0;
//                 }
//                 else if (userInput == "2")
//                 {
//                     Console.Clear();
//                     ReservationService.ListReservations();
//                     Console.Write("\nEnter the name of the reservation you want to delete: ");
//                     string nameToDelete = Console.ReadLine();
//                     ReservationService.RemoveReservation(nameToDelete);
//                     ReservationService.SaveReservations();
//                     System.Console.WriteLine("\nPress 'Enter' to go back");
//                     System.Console.ReadLine();
//                     return 2;
//                 }
//                 else if (userInput == "3")
//                 {
//                     System.Console.Write("Enter the name of the reservation you want to edit: ");
//                     string nameToEdit = Console.ReadLine();
//                     Console.Clear();
//                     System.Console.WriteLine("What do you want to edit?\nPress 1 to alter the name\nPress 2 to alter the email\nPress 3 to alter the date\nPress 4 to edit the amount of people");
//                     string thingToEdit;
//                     string editName;
//                     string editEmail;
//                     DateTime editDate;
//                     int editPersons;

//                     while (true)
//                     {
//                         thingToEdit = Console.ReadLine();

//                         if (thingToEdit == "1")
//                         {
//                             System.Console.Write("Enter the name you want to change it into: ");
//                             editName = Console.ReadLine();

//                             break;
//                         }
//                         else if (thingToEdit == "2")
//                         {
//                             System.Console.Write("Enter the email you want to change it into: ");
//                             editEmail = Console.ReadLine();

//                             break;
//                         }
//                         else if (thingToEdit == "3")
//                         {
//                             System.Console.Write("Enter the date you want to change it into: ");
//                             Console.ReadLine();
//                             editDate = new DateTime(1999, 1, 1);
//                             ReservationService.EditDateTime(nameToEdit, editDate);
//                             break;
//                         }
//                         else if (thingToEdit == "4")
//                         {
//                             System.Console.Write("How many persons are you coming with? ");
//                             editPersons = Convert.ToInt32(Console.ReadLine());
//                             break;
//                         }
//                         else
//                         {
//                             System.Console.WriteLine("Please enter a valid number");
//                         }
//                     }
//                     return 2;
//                 }
//                 else if (userInput == "4")
//                 {
//                     Console.Clear();
//                     ReservationService.ListReservations();
//                     System.Console.WriteLine("\nPress 'Enter' to go back");
//                     Console.ReadLine();
//                     return 2;
//                 }
//                 else if (userInput == "5")
//                 {
//                     return 0;
//                 }
//                 else
//                 {
//                     System.Console.WriteLine("Please enter a valid number");
//                 }
//             }
//         }
//         private static int AccountCreation()
//         {

//             Console.Clear();
//             Console.WriteLine("Press: [1] to log in \n[2] to make an account ");
//             switch (Console.ReadLine())
//             {
//                 case "1": // log in

//                     bool wantstotryagain = true;
//                     while (wantstotryagain)
//                     {
//                         Console.WriteLine("What is your e-mail?");
//                         string email = Console.ReadLine();
//                         Console.WriteLine("What is your Username?");
//                         string Username = Console.ReadLine();
//                         Console.WriteLine("What is your password?");
//                         string password = Console.ReadLine();
//                         Console.WriteLine("Press [1] to log in as an admin, [2] to log in as a user \n    [3] to log in as a worker");
//                         switch (Console.ReadLine())
//                         {
//                             case "1":

//                                 if (Admin.Login(Username, password, email))
//                                 {
//                                     Console.WriteLine("press: [1] to see the roster  [2] to alter the menu \n   [3] to alter account information"); // TODO: add roster and menu functionality
//                                     switch (Console.ReadLine())
//                                     {
//                                         case "1": // todo: add roster functionality here
//                                             break;
//                                         case "2": // todo: add menu functionality here
//                                             break;
//                                         case "3":
//                                             Console.WriteLine("Press: [1] to alter account information, [2] to delete your profile "); // todo: add altering functionality
//                                             switch (Console.ReadLine())
//                                             {
//                                                 case "1": //alter info
//                                                     Admin.editInformation(Username);
//                                                     break;
//                                                 case "2": // delete account
//                                                     Console.WriteLine("are you sure you wish to delete your account?\n  press [1] to delete account, press [2] to stop");
//                                                     switch (Console.ReadLine())
//                                                     {
//                                                         case "1":
//                                                             Console.WriteLine("Account deleted!");
//                                                             Admin.deleteAdmin(Username);
//                                                             Console.Clear();
//                                                             break;
//                                                         case "2":
//                                                             Console.WriteLine("Account deletion cancelled!");
//                                                             break;
//                                                     }
//                                                     break;

//                                             }
//                                             break;
//                                     }
//                                     break;
//                                 }
//                                 else
//                                 {
//                                     Console.WriteLine("Do you want to try again?`\n     Press [1] for yes and [2] for no");
//                                     switch (Console.ReadLine())
//                                     {
//                                         case "1":
//                                             Console.Clear();
//                                             break;
//                                         case "2":
//                                             wantstotryagain = false;
//                                             break;
//                                     }
//                                 }
//                                 break;

//                             case "2": // login as a user
//                                 if (UserHandler.login(Username, email, password))
//                                 {
//                                     Console.WriteLine("press: [1] to place a reservation, [2] to see my reservations \n     [3] to alter my info, [4] to delete account");
//                                     switch (Console.ReadLine())
//                                     {
//                                         case "1":
//                                             Console.WriteLine("this functionality hasn't been added yet");
//                                             break;
//                                         case "2":
//                                             Console.WriteLine("This functionality hasn't been added yet");
//                                             break;
//                                         case "3": // todo: altering info
//                                             Console.WriteLine("What information do you want to alter? \n Press: [1] to alter username, [2] to alter your email address \n [3] to alter your password [4] to delete your account");
//                                             switch (Console.ReadLine())
//                                             {
//                                                 case "1": // username altering
//                                                     Console.WriteLine("What do you want your new username to be?");

//                                                     UserHandler.editUsername(Username, Console.ReadLine());
//                                                     Console.WriteLine("Your username was successfully changed!");
//                                                     break;
//                                                 case "2": // alter email
//                                                     Console.WriteLine("What do you want your new email to be?");
//                                                     UserHandler.editemail(Username, Console.ReadLine());
//                                                     break;
//                                                 case "3": // alter password
//                                                     Console.WriteLine("what was your previous password?");

//                                                     while (true)
//                                                     {
//                                                         if (Console.ReadLine() == password)
//                                                         {
//                                                             Console.WriteLine("What do you want your new password to be?");
//                                                             UserHandler.editPassword(Username, email, password, Console.ReadLine());
//                                                             Console.WriteLine("Password succesfully changed!");
//                                                             break;
//                                                         }
//                                                         else
//                                                         {
//                                                             Console.WriteLine("you got your password wrong! \n press: [1] to try again [2] to quit");
//                                                             if (Console.ReadLine() != "1")
//                                                             {
//                                                                 break;
//                                                             }
//                                                         }
//                                                         break;
//                                                     }
//                                                     break;
//                                                 case "4": // delete user
//                                                     Console.WriteLine("Do you know for sure you want to delete this user? \n Press: [1] for yes, delete this user, [2] for no, dont delete this user");
//                                                     switch (Console.ReadLine())
//                                                     {
//                                                         case "1":
//                                                             UserHandler.DeleteUser(Username);
//                                                             Console.WriteLine("User succesfully delted");
//                                                             break;
//                                                         case "2":
//                                                             Console.WriteLine("Succesfully cancelled the deletion of your account");
//                                                             break;
//                                                     }

//                                                     break;
//                                             }
//                                             break;
//                                     }
//                                 }
//                                 break;
//                             case "3": // login as a worker
//                                 Console.WriteLine("Press [1] to see your roster, [2] to see your orders  \n [3] to see all orders, [4] to alter account information");
//                                 switch (Console.ReadLine())
//                                 {
//                                     case "1": // see roster as worker                                
//                                         Console.WriteLine("This functionality has not been added yet, sorry!");
//                                         break;
//                                     case "2": // see orders as worker                                
//                                         Console.WriteLine("This functionality has not been added yet, sorry!");
//                                         break;
//                                     case "3": // see all orders
//                                         Console.WriteLine("This functionality has not been added yet, sorry!");
//                                         break;
//                                     case "4": // alter account information
//                                         Worker.editInformation(Username);
//                                         break;
//                                 }
//                                 break;
//                         }
//                     }
//                     break;
//                 case "2": // account creation
//                     Console.WriteLine("What do you want your username to be?");
//                     string username = Console.ReadLine();
//                     Console.WriteLine("What do you want your email to be?");
//                     string emailaddress = Console.ReadLine();
//                     Console.WriteLine("What do you want your password to be?");
//                     string Password = Console.ReadLine();
//                     Console.WriteLine("Enter your password again to verify please.");
//                     if (Console.ReadLine() == Password)
//                     {
//                         Console.WriteLine("What kind of account do you want to create? \n Press: [1] to make a user account, [2] to make a worker account [3] to make an admin account");
//                         switch (Console.ReadLine())
//                         {
//                             case "1": // user account 
//                                 User user = new User(username, emailaddress, Password);
//                                 Console.WriteLine("New user account succesfully created!");
//                                 UserHandler.addUser(user);
//                                 break;
//                             case "2": // worker account
//                                 Worker worker = new Worker(username, emailaddress, Password);
//                                 Worker.addWorker(worker);
//                                 Console.WriteLine("New worker account succesfully created!");
//                                 break;
//                             case "3": // admin account 
//                                 Admin admin = new Admin(username, emailaddress, Password);
//                                 Admin.addAdmin(admin);
//                                 Console.WriteLine("New admin account succesfully created!");
//                                 break;
//                         }                        
//                     }
//                     break;
//             }
//             return 0;
//         }

//         private static int ReviewMenu()
//         {
//             Console.Clear();
//             string reviewInput;
//             Console.WriteLine($"Welcome to the review menu!\n\nPress 1 to write a review\nPress 2 to read all reviews\nPress 3 to delete a review\nPress 4 to go back to the main menu");
//             while (true)
//             {
//                 reviewInput = Console.ReadLine();
//                 if (reviewInput == "1")
//                 {
//                     Console.Clear();
                    
//                     Console.Write("Enter your name: ");
//                     string name = Console.ReadLine();
//                     Console.Write("Enter your email: ");
//                     string email = Console.ReadLine();
//                     Console.Write("Write your review: ");
//                     string reviewtext = Console.ReadLine();
                    
//                     bool RatingStatus = false;

//                     while (RatingStatus == false)
//                     {
//                         Console.Write("How many stars(1 - 5) would you rate your visit?: ");
//                         string rating = Console.ReadLine();

//                         if (rating == "1" | rating == "2" | rating == "3" | rating == "4" | rating == "5")
//                         {
//                             RatingStatus = true;
//                             ReviewStuff.WriteReview(name, email, reviewtext, rating);
//                             ReviewStuff.SaveReviews();
//                         }
//                         else
//                         {
//                             RatingStatus = false;
//                             Console.WriteLine("Please enter a valid rating, between 1 and 5");
//                         }
//                     }
//                     Console.WriteLine("\nPress 'Enter' to go back");
//                     Console.ReadLine();
//                     return 3;
//                 }
//                 else if (reviewInput == "2")
//                 {
//                     Console.Clear();
//                     Console.WriteLine("Written Reviews:\n");
//                     ReviewStuff.ListReviews();

//                     Console.WriteLine("\nPress 'Enter' to go back");
//                     Console.ReadLine();
//                     return 3;
//                 }
//                 else if (reviewInput == "3")
//                 {
//                     Console.Clear();
//                     ReviewStuff.ListReviews();
//                     Console.Write("\nWhat is the name that wrote the review you wish to delete?: ");
//                     string ReviewToDelete = Console.ReadLine();
//                     ReviewStuff.DeleteReviews(ReviewToDelete);
//                     ReviewStuff.SaveReviews();
//                     Console.WriteLine("\nPress 'Enter' to go back");
//                     Console.ReadLine();
//                     return 3;
//                 }
//                 else if (reviewInput == "4")
//                 {
//                     return 0;
//                 }
//                 else
//                 {
//                     Console.WriteLine("Please enter a valid number");
//                 }
//             }
//         }
    
//         private static int MainPage()
//         {
//             Console.Clear();
//             Console.WriteLine("Welcome!\n\nPress 1 for login and account creation \nPress 2 to go to the reservations section \nPress 3 to open the review section\nPress 4 to place an order\nPress 5 to look at the menu\nPress 6 exit the application\n");
//             string userInput;
//             while (true)
//             {
//                 userInput = Console.ReadLine();

//                 if (userInput == "1")
//                 {
//                     return 1;
//                 }
//                 else if (userInput == "2")
//                 {
//                     return 2;
//                 }
//                 else if (userInput == "3")
//                 {
//                     return 3;
//                 }
//                 else if (userInput == "4")
//                 {
//                     return 4;
//                 }
//                 else if (userInput == "5")
//                 {
//                     return 5;
//                 }
//                 else if (userInput == "6")
//                 {
//                     return 99;
//                 }
//                 else
//                 {
//                     System.Console.WriteLine("Please enter a valid number");
//                 }
//             }
//         }
//     }
// }
