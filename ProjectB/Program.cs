using System;


namespace ProjectB
{
    public static class Program
    {
        static void Main()
        {   
            // Log out all accounts in case system was closed improperly
            UserAccounts.LogOutAllAccounts();

            // Load database files
            UserAccounts.LoadAccountData();
            ReservationService.LoadReservations();
            ReviewService.LoadReviews();
            
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

                    case 5:
                    PageNumber = EmployeeArea();
                    break;

                    case 6:
                    PageNumber = AdminArea();
                    break;
                }
            }
        }

        private static int InitialLogInMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome!\n");
                Console.WriteLine("You will need to log in to proceed. Select an option from the menu below:\n[1] Log in as a customer\n[2] Create a customer account\n[3] Log in as an employee\n[4] Quit the application\n");
                Console.Write("Please enter your selection: ");
                var user_input = Console.ReadLine();
                switch (user_input)
                {
                    case "1": return 1;
                    case "2": return 2;
                    case "3": return 3;
                    case "4":
                    Console.WriteLine("Closing the application. See you next time!");
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

                var account = UserAccounts.GetCustomer(username);
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

                bool exists = UserAccounts.CheckIfCustomerExists(fullname, username);
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
                    UserAccounts.AddCustomerAccount(username, password, fullname);
                    UserAccounts.SaveAccountData();
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
                Func<Tuple<string, string>> getLogInDetails = () => {
                        Console.Write("Enter your username: ");
                        var username = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        var password = Console.ReadLine();
                        return Tuple.Create(username, password);
                };

                Console.Clear();
                Console.WriteLine("Employee log in\n[1] Log in as an employee\n[2] Log in as an admin\n[3] Go back\n");
                Console.Write("Please enter your selection: ");
                var user_input = Console.ReadLine();

                switch (user_input)
                {
                    case "1": // Employees
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Employee log in\n");

                        var loginDetails = getLogInDetails();
                        var account = UserAccounts.GetEmployee(loginDetails.Item1);
                        if (account != null && account.Password == loginDetails.Item2) 
                        {
                            account.LogIn(loginDetails.Item1, loginDetails.Item2); // Username correct
                            return 5;
                        } 
                        
                        Console.WriteLine("Incorrect log in details, do you want to try again?\n[1] Yes\n[2] No\n");
                        Console.Write("Please enter your selection: ");
                        string userInput = Console.ReadLine();

                        if (userInput == "1") continue;
                        else if (userInput == "2") return 0;
                        else
                        {
                            Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                            Console.ReadLine();
                        }  
                    }

                    case "2": // Admin
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Admin log in\n");

                        var loginDetails = getLogInDetails();

                        var account = UserAccounts.GetAdmin(loginDetails.Item1);
                        if (account != null && account.Password == loginDetails.Item2) 
                        {
                            account.LogIn(loginDetails.Item1, loginDetails.Item2); // Username correct
                            return 6;
                        } 
                        
                        Console.WriteLine("Incorrect log in details, do you want to try again?\n[1] Yes\n[2] No\n");
                        Console.Write("Please enter your selection: ");
                        string userInput = Console.ReadLine();

                        if (userInput == "1") continue;
                        else if (userInput == "2") return 0;
                        else
                        {
                            Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                            Console.ReadLine();
                        }  
                    }
 
                    case "3": return 0; 

                    default: 
                    Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    break;
                }
            }
        }

        private static int CustomerArea()
        {
            // Getting the account that logged in
            var userAccount = UserAccounts.GetLoggedInCustomer();
            string userInput;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Logged in as: {userAccount.FullName}");
                Console.WriteLine("What would you like to do?\n[1] Make a reservation\n[2] See your current reservations\n[3] Cancel a reservation\n[4] Write a review\n[5] List your reviews\n[6] Remove a review\n[7] Log out and go back to the main menu\n");
                Console.Write("Please enter your selection: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1": // Adding a reservation
                    AddReservationMenu(userAccount);
                    break;

                    case "2":  // Listing account reservations
                    userAccount.ListReservations();
                    Console.WriteLine("\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    break;

                    case "3": // Cancel a reservation
                    CancelReservationMenu(userAccount);
                    break;

                    case "4": // Write a review
                    WriteReviewMenu(userAccount);
                    break;

                    case "5": // List reviews
                    userAccount.ListReviews();
                    Console.WriteLine("\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    break;

                    case "6": // Remove a review
                    RemoveReviewMenu(userAccount);
                    break;

                    case "7": // Log out
                    UserAccounts.LogOutAllAccounts();
                    return 0;

                    default: // Incorrect input
                    Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    break;
                }
            }
        }

        private static void AddReservationMenu(Customer userAccount) // Located inside customer area
        {
            Console.Clear();
            var datetime = ReservationService.GetReservationTime(ReservationService.GetReservationDate());
            int persons;
            while (true)
            {
                try
                {
                    Console.Write("How many people will be coming? ");
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
            UserAccounts.SaveAccountData();

            Console.WriteLine("\nPress 'Enter' to go back");
            Console.ReadLine();
        }

        private static void CancelReservationMenu(Customer userAccount) // Located inside customer area
        {
            Console.Clear();
            if (userAccount.Reservations.Count == 0) // User does not have reservations
            {
                Console.WriteLine("You currently don't have any reservations.");
                Console.Write("Press 'Enter' to continue");
                Console.ReadLine();
            }
            else if (userAccount.Reservations.Count == 1) // User has one reservation
            {
                ReservationService.RemoveReservation(0, userAccount);
                ReservationService.SaveReservations();
                UserAccounts.SaveAccountData();
                Console.WriteLine("Removed reservation");
                Console.WriteLine("Press 'Enter' to continue");
                Console.ReadLine();
            }
            else if (userAccount.Reservations.Count > 1) // User has multiple reservations
            {
                while (true)
                {
                    userAccount.ListReservations();
                    Console.WriteLine("\nWhich reservation would you like to cancel?");
                    Console.Write("Please enter your selection: ");
                    var resToDelete = Console.ReadLine();
                    try
                    {
                        var index = Convert.ToInt32(resToDelete);
                        ReservationService.RemoveReservation(index - 1, userAccount);
                        ReservationService.SaveReservations();
                        UserAccounts.SaveAccountData();
                        Console.WriteLine("Reservation deleted.");
                        Console.WriteLine("Press 'Enter' to continue");
                        Console.ReadLine();
                        break;
                    }
                    catch { Console.WriteLine("Invalid input, please try again."); }
                    break;
                }
            }
        }

        private static void WriteReviewMenu(Customer userAccount) // Located inside customer area
        {
            string reviewText;
            int reviewRating = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Write a review");
                Console.Write("Please enter your review: ");
                reviewText = Console.ReadLine();
                try
                {
                    Console.Write("Please enter your rating (1-5): ");
                    reviewRating = Convert.ToInt32(Console.ReadLine());
                    if (reviewRating > 5) reviewRating = 5;
                    else if (reviewRating < 1) reviewRating = 1;
                    // Adding review to account and saving it to JSON
                    ReviewService.AddReview(userAccount, reviewText, reviewRating);
                    ReviewService.SaveReviews();
                    UserAccounts.SaveAccountData();

                    Console.WriteLine("Review saved! Press 'Enter' to continue.");
                    Console.ReadLine();
                    break;
                } 
                catch { Console.WriteLine("Invalid input, please enter a valid rating. Press 'Enter to continue."); }
                Console.ReadLine();
            }
        }

        private static void RemoveReviewMenu(Customer userAccount) // Located inside customer area
        {
            Console.Clear();
            if (userAccount.Reviews.Count == 0) // User does not have reviews
            {
                Console.WriteLine("You currently don't have any reviews.");
                Console.Write("Press 'Enter' to continue");
                Console.ReadLine();
            } else if (userAccount.Reviews.Count == 1) // User has one review
            {
                ReviewService.RemoveReview(0, userAccount);
                ReviewService.SaveReviews();
                UserAccounts.SaveAccountData();
                Console.WriteLine("Removed review");
                Console.WriteLine("Press 'Enter' to continue");
                Console.ReadLine();
            } else if (userAccount.Reviews.Count > 1) // User has multiple reviews
            {
                while (true)
                {
                    userAccount.ListReviews();
                    Console.WriteLine("\nWhich review would you like to cancel?");
                    Console.Write("Please enter your selection: ");
                    var reviewToDelete = Console.ReadLine();
                    try
                    {
                        var index = Convert.ToInt32(reviewToDelete);
                        ReviewService.RemoveReview(index-1, userAccount);
                        ReviewService.SaveReviews();
                        UserAccounts.SaveAccountData();
                        Console.WriteLine("Review removed. Press 'Enter' to continue.");
                        Console.ReadLine();
                        break;           
                    }
                    catch { Console.WriteLine("Invalid input. Please try again."); }
                }
                
            }
        }
    
        private static int EmployeeArea()
        {
            var userAccount = UserAccounts.GetLoggedInEmployee();
            if (userAccount == null) return 0; // In case something goes wrong

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Logged in as {2}");
                Console.WriteLine("What would you like to do?\n[1] See the reservations\n[2] Cancel a reservation\n[3] Make a reservation\n[4] Place an order\n[5] Print the bill for a table\n[6] Log out and go back to the main menu");
                Console.Write("Please enter your selection: ");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1": // List reservations
                    ReservationService.ListReservations();
                    Console.WriteLine("\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    return 5;

                    case "2": // Cancel Reservation
                    CancelReservationEmployee();
                    return 5;

                    case "3": // Make a reservation
                    MakeReservationEmployee();
                    return 5;

                    case "4": // Place an order
                    break;

                    case "5": // Print the bill of an order
                    break;

                    case "6": // Log out
                    UserAccounts.LogOutAllAccounts();
                    return 0;

                    default:
                    Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    break;
                }
            }
        }

        private static Customer GetCustomerAccount() // Used inside other methods in Employee area
        {
            while (true)
            {
                Console.Write("Please enter the username of the customer: ");
    	        var customer = UserAccounts.GetCustomer(Console.ReadLine());
                if (customer == null)
                {
                    Console.WriteLine("Could not find the user, do you want to try again?\n[1] Yes\n[2] No\n");
                    Console.Write("Please enter your selection: ");
                    string userInput = Console.ReadLine();

                    if (userInput == "1") continue;
                    if (userInput == "2") return null;
                    else
                    {
                        Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                        Console.ReadLine();
                    }
                } 
                else return customer;
            }
        }

        private static void CancelReservationEmployee() // Used inside Employee and Admin area
        {
            Console.Clear();
            Console.WriteLine("Cancelling a reservation\n");
            var customer = GetCustomerAccount();
            if (customer == null) return;
            else CancelReservationMenu(customer);
        }

        private static void MakeReservationEmployee() // Used inside Employee and Admin area
        {
            Console.Clear();
            Console.WriteLine("Making a reservation\n");
            var customer = GetCustomerAccount();
            if (customer == null) return;
            else AddReservationMenu(customer);
        }

        private static int AdminArea()
        {
            Admin userAccount = UserAccounts.GetLoggedInAdmin();
            if (userAccount == null) return 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Logged in as {userAccount.FullName} (Admin)\n");
                Console.WriteLine("What would you like to do?\n[1] See the reservations\n[2] Cancel a reservation\n[3] Make a reservation\n[4] Place an order\n[5] Print the bill for a table\n[6] List customer accounts\n[7] Delete customer account\n[8] Add employee account\n[9] Delete employee account\n[10] Add admin account\n[11] Delete admin account\n[12] Log out and go back to the main menu\n");
                Console.Write("Please enter your selection: ");
                var user_input = Console.ReadLine();

                switch (user_input)
                {
                    case "1": // List all of the reservations
                    ReservationService.ListReservations();
                    Console.WriteLine("\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    break;

                    case "2": // Cancel a reservation
                    CancelReservationEmployee();
                    break;

                    case "3": // Make a reservation
                    MakeReservationEmployee();
                    break;

                    case "4": // Place an order
                    // TODO : ORDERS
                    break;

                    case "5": // Print the bill of an order
                    // TODO : PRINT BILL
                    break;

                    case "6": // List all customer accounts
                    UserAccounts.ListCustomerAccounts();
                    Console.WriteLine("\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    break;

                    case "7": // Delete a customer account
                    DeleteCustomerMenu();
                    break;

                    case "8": // Add an employee account
                    AddEmployeeMenu();
                    break;

                    case "9": // Delete an employee account
                    DeleteEmployeeMenu();
                    break;

                    case "10": // Add an admin account
                    AddAdminMenu();
                    break;

                    case "11": // Delete an admin account
                    DeleteAdminMenu();
                    break;

                    case "12": // Log out and go back to main menu
                    UserAccounts.LogOutAllAccounts();
                    UserAccounts.SaveAccountData();
                    return 0;

                    default: // Invalid input
                    Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    break;
                }
            }
        }

        private static void DeleteCustomerMenu() // Used inside admin area
        {
            Console.Clear();
            var account = GetCustomerAccount();            
            if (account == null) return;

            UserAccounts.DeleteCustomerAccount(account);
            UserAccounts.SaveAccountData();
            ReservationService.SaveReservations();

            Console.WriteLine("Customer deleted, changes are saved. Press 'Enter' to continue.");
            Console.ReadLine();
        }

        private static void AddEmployeeMenu() // Used inside admin area
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Employee Account Creation\n");

                Console.Write("Enter your full name: ");
                var fullname = Console.ReadLine();
                Console.Write("Enter your preferred username: ");
                var username = Console.ReadLine();
                Console.Write("Enter your password: ");
                var password = Console.ReadLine();

                bool exists = UserAccounts.CheckIfEmployeeExists(fullname, username);
                if (exists)
                {
                    Console.WriteLine("There already is an account with that information. Please choose different credentials");
                    Console.WriteLine("Do you want to try again?\n[1] Yes\n[2] No\n");
                    Console.Write("Please enter your selection: ");
                    string userInput = Console.ReadLine();

                    if (userInput == "1") continue;
                    if (userInput == "2") return;
                    else
                    {
                        Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                        Console.ReadLine();
                    }
                } 
                else
                {
                    UserAccounts.AddEmployeeAccount(username, password, fullname);
                    UserAccounts.SaveAccountData();
                    Console.WriteLine("Account created, changes have been saved. Press 'Enter' to continue.");
                    Console.ReadLine();
                    return;
                }
            }
        }

        private static Employee GetEmployeeAccount() // Used inside other methods in admin area
        {
            while (true)
            {
                Console.Write($"Please enter the username of the employee: ");
    	        var account = UserAccounts.GetEmployee(Console.ReadLine());
                if (account == null)
                {
                    Console.WriteLine("Could not find the user, do you want to try again?\n[1] Yes\n[2] No\n");
                    Console.Write("Please enter your selection: ");
                    string userInput = Console.ReadLine();

                    if (userInput == "1") continue;
                    if (userInput == "2") return null;
                    else
                    {
                        Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                        Console.ReadLine();
                    }
                } 
                else return account;
            }
        }

        private static void DeleteEmployeeMenu() // Used inside admin area
        {
            Console.Clear();
            var account = GetEmployeeAccount();            
            if (account == null) return; // In case something goes wrong

            UserAccounts.DeleteEmployeeAccount(account);

            Console.WriteLine("Account deleted, changes are saved. Press 'Enter' to continue.");
            Console.ReadLine();
        }   

        private static Admin GetAdminAccount()
        {
            while (true)
            {
                Console.Write("Please enter the username of the account: ");
    	        var account = UserAccounts.GetAdmin(Console.ReadLine());
                if (account == null)
                {
                    Console.WriteLine("Could not find the user, do you want to try again?\n[1] Yes\n[2] No\n");
                    Console.Write("Please enter your selection: ");
                    string userInput = Console.ReadLine();

                    if (userInput == "1") continue;
                    if (userInput == "2") return null;
                    else
                    {
                        Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                        Console.ReadLine();
                    }
                } 
                else return account;
            }
        }
        
        private static void AddAdminMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Admin Account Creation\n");

                Console.Write("Enter the full name: ");
                var fullname = Console.ReadLine();
                Console.Write("Enter the preferred username: ");
                var username = Console.ReadLine();
                Console.Write("Enter the password: ");
                var password = Console.ReadLine();

                bool exists = UserAccounts.CheckIfAdminExists(fullname, username);
                if (exists)
                {
                    Console.WriteLine("There already is an account with that information. Please choose different credentials");
                    Console.WriteLine("Do you want to try again?\n[1] Yes\n[2] No\n");
                    Console.Write("Please enter your selection: ");
                    string userInput = Console.ReadLine();

                    if (userInput == "1") continue;
                    if (userInput == "2") return;
                    else
                    {
                        Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                        Console.ReadLine();
                    }
                } 
                else
                {
                    UserAccounts.AddAdminAcccount(username, password, fullname);
                    UserAccounts.SaveAccountData();
                    Console.WriteLine("Account created, changes have been saved. Press 'Enter' to continue.");
                    Console.ReadLine();
                    return;
                }
            }
        }

        private static void DeleteAdminMenu()
        {
            if (UserAccounts.Admins.Count <= 1)
            {
                Console.WriteLine("You can not delete the only admin account. Press 'Enter' to continue.");
                Console.ReadLine();
                return;
            }
            Console.Clear();
            var account = GetAdminAccount();            
            if (account == null) return; // In case something goes wrong

            UserAccounts.DeleteAdminAccount(account);

            Console.WriteLine("Account deleted, changes are saved. Press 'Enter' to continue.");
            Console.ReadLine();
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
