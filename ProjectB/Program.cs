using System;


namespace ProjectB
{
    public static class Program
    {
        static void Main()
        {   
            // Load database files
            UserAccounts.LoadAccountData();
            ReservationService.LoadReservations();
            ReviewService.LoadReviews();
            FoodMenu.LoadOrders();

            // Log out all accounts in case system was closed improperly
            UserAccounts.LogOutAllAccounts();
            
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

                    case 7: // Food menu
                    Console.Clear();
                    FoodMenu.ListMenu();
                    Console.WriteLine("\nPress 'enter' to go back.");
                    Console.ReadLine();
                    PageNumber = 0;
                    break;

                    case 8: // List reviews
                    Console.Clear();
                    ReviewService.ListReviews();
                    Console.WriteLine("\nPress 'enter' to go back.");
                    Console.ReadLine();
                    PageNumber = 0;
                    break;

                    case 9:
                    PageNumber = AddOrderMenu();
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
                Console.WriteLine("You will need to log in to proceed. Select an option from the menu below:\n[1] Log in as a customer\n[2] See our menu\n[3] See our reviews\n[4] Create a customer account\n[5] Log in as an employee\n[6] Quit the application\n");
                Console.Write("Please enter your selection: ");
                var user_input = Console.ReadLine();
                switch (user_input)
                {
                    case "1": return 1; // Log in as customer
                    case "2": return 7; // See the menu
                    case "3": return 8; // See the reviews
                    case "4": return 2; // Create a customer account
                    case "5": return 3; // Log in as employee
                    
                    case "6": // Quit application
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
                var password = UserAccounts.EncryptOrDecryptPassword(Console.ReadLine(), false);

                var account = UserAccounts.GetCustomer(username);
                if (account != null && account.Password == password) 
                {
                    account.LogIn(username, password); // Username correct
                    return 4;
                } 
                
                Console.WriteLine("Incorrect log in details, do you want to try again?\n[1] Yes\n[2] No\n[3] I forgot my password\n[4] I forgot my username\n");
                Console.Write("Please enter your selection: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1": break; // User wants to try again
                    case "2": return 0; // User wants to return to main menu

                    case "3": // Forgot password
                    return ForgotPasswordMenu();

                    case "4": // Forgot username
                    ForgotUsernameMenu();
                    break;

                    default:
                    Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    break;
                }
            }
        }

        private static int ForgotPasswordMenu() 
        {
            // Function to generate random e-mail code
            Func<int, string> getCode = length => {
            var rnd = new Random();
            var result = "";
            for (var i = 0; i < length; i++)
            {
                var num = rnd.Next(0, 10);
                var chance = rnd.Next(0, 10);
                if (chance < 5)
                    result += (char)(rnd.Next(65, 91));
                else 
                    result += num;
            }
            return result;
            };

            string userInput;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Password recovery\nPlease enter your username below. If the username is entered correctly, an e-mail will be send with a recovery code.");
                Console.WriteLine("Enter the recovery code in the next screen and you will be able to set a new password.\n");
                Console.Write("Please enter your username here: ");
                string username = Console.ReadLine();

                var account = UserAccounts.GetCustomer(username);
                if (account == null) // Account not found
                {
                    Console.WriteLine("There is no account with that username. Would you like to try again?\n[1] Yes\n[2] No\n");
                    Console.Write("Please enter your selection: ");
                    userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "1": continue;
                        case "2": return 0;
                        default:
                        Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                        Console.ReadLine();
                        break;
                    }
                }
                else // Account found
                {
                    Console.Clear();
                    Console.WriteLine("************ Fake e-mail ************\n");
                    Console.WriteLine($"Dear {account.FullName},\nYou stated you would like to recover your password. Enter the code below into the recovery page to be able to set a new password.");
                    Console.WriteLine("If you did not request a new password, please contact the restaurant.");
                    var random_code = getCode(15);
                    Console.WriteLine($"\nYour code: {random_code}\nMake sure to copy it before you continue.");
                    Console.WriteLine("\n***********************************");
                    Console.WriteLine("\nPress 'enter' to continue.");
                    Console.ReadLine();
                    
                    Console.Clear();
                    Console.Write("Please enter your recovery code: ");
                    var code_entered = Console.ReadLine();

                    if (code_entered == random_code) // User entered correct random code
                    {
                        while (true)
                        {
                            Console.Write("Please enter your new password: ");
                            var newPassword = Console.ReadLine();
                            if (newPassword.Length < 5)
                            {
                                Console.WriteLine("Please enter a longer password.");
                                continue;
                            }
                            newPassword = UserAccounts.EncryptOrDecryptPassword(newPassword, false);
                            UserAccounts.ChangeCustomerPassword(account, newPassword);
                            Console.WriteLine("New password changed! You can now log in again.");
                            Console.WriteLine("Press 'enter' to continue.");
                            Console.ReadLine();
                            return 1;
                        }
                    }
                    else // User entered an incorrect code
                    {
                        Console.WriteLine("Code incorrect. Please try again.");
                        Console.WriteLine("Press 'enter' to continue.");
                        Console.ReadLine();
                        return 0;
                    }
                }
            }
        }

        private static void ForgotUsernameMenu() 
        {
            Console.Clear();
            Console.WriteLine("Username recovery\nEnter your e-mail address below and your username will be e-mailed to you.\n");
            Console.Write("Please enter your e-mail address here: ");
            string email = Console.ReadLine();
            var account = UserAccounts.GetCustomerByEmail(email);
            if (account != null)
            {
                Console.Clear();
                Console.WriteLine("************ Fake e-mail ************\n");
                Console.WriteLine($"Dear {account.FullName},\nYou requested your account username. Your username is: {account.Username}");
                Console.WriteLine("We hope you will be able to log in without any further problems.");
                Console.WriteLine("\n***********************************");
                Console.WriteLine("\nPress 'enter' to continue.");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("We currently don't have an account registered with that e-mail address.");
                Console.WriteLine("\nPress 'enter' to continue.");
                Console.ReadLine();
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
                Console.Write("Enter your e-mail address: ");
                var email = Console.ReadLine();
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
                    password = UserAccounts.EncryptOrDecryptPassword(password, false);
                    UserAccounts.AddCustomerAccount(username, email, password, fullname);
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
                        password = UserAccounts.EncryptOrDecryptPassword(password, false);
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
                    Console.Write("How many people will be coming? (max. 8 people): ");
                    persons = Convert.ToInt32(Console.ReadLine());
                    if (persons > 0 && persons <= 8)
                        break;
                    else
                    {
                        Console.WriteLine("Please enter a valid number, try again.");
                    }
                }
                catch (System.Exception)
                {
                    System.Console.WriteLine("Invalid input, please try again...");
                }
            }

            ReservationService.AddReservation(datetime, persons, userAccount);
            ReservationService.SaveReservations();
            UserAccounts.SaveAccountData();

            Console.WriteLine("Reservation added.");
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

        private static int AddOrderMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to order?\n[1] Appetizers\n[2] Main Courses\n[3] Vegan Main Courses\n[4] Desserts\n[5] Vegan Deserts\n[6] Drinks\n[7] Save Order\n[8] Exit menu");
            while (true)
            {
                var options = Console.ReadLine();
                switch (options)
                {
                    case "1":
                    Console.Clear();
                    FoodMenu.PrintAppetizers();
                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 9;

                    case "2":
                    Console.Clear();
                    FoodMenu.PrintMainCourses();
                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 9;

                    case "3":
                    Console.Clear();
                    FoodMenu.PrintVeganMainCourses();
                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 9;

                    case "4":
                    Console.Clear();
                    FoodMenu.PrintDesserts();
                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 9;

                    case "5":
                    Console.Clear();
                    FoodMenu.PrintVeganDesserts();
                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 9;

                    case "6":
                    Console.Clear();
                    FoodMenu.PrintDrinks();
                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 9;

                    case "7":
                    Console.Clear();
                    FoodMenu.AddOrder();
                    FoodMenu.SaveOrder();
                    FoodMenu.CheckOrders();
                    Console.WriteLine("\nPress 'Enter' to go back");
                    Console.ReadLine();
                    return 5;

                    case "8":
                    return 5;

                    default:
                    Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    break;
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
                Console.WriteLine($"Logged in as {userAccount.FullName}");
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

                    case "4": // Place an order;
                    FoodMenu.WhatTable();
                    return 9;

                    case "5": // List all orders --> make it print bill
                    Console.Clear();
                    FoodMenu.ListOrders();
                    Console.WriteLine("\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    return 5;

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
                Console.WriteLine("What would you like to do?\n[1] See the reservations\n[2] Cancel a reservation\n[3] Make a reservation\n[4] Place an order\n[5] Print the bill for a table\n[6] List customer accounts\n[7] Delete customer account\n[8] List all employee accounts\n[9] Add employee account\n[10] Delete employee account\n[11] List all admin accounts\n[12] Add admin account\n[13] Delete admin account\n[14] Log out and go back to the main menu\n");
                Console.Write("Please enter your selection: ");
                var user_input = Console.ReadLine();

                switch (user_input)
                {
                    case "1": // List all of the reservations
                    Console.Clear();
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

                    case "4": // Place an order;
                    return 9;

                    case "5": // List all orders --> make it print bill
                    Console.Clear();
                    FoodMenu.ListOrders();
                    Console.WriteLine("\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    break;

                    case "6": // List all customer accounts
                    Console.Clear();
                    UserAccounts.ListCustomerAccounts();
                    Console.WriteLine("\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    break;

                    case "7": // Delete a customer account
                    DeleteCustomerMenu();
                    break;

                    case "8": // List employee accounts
                    Console.Clear();
                    UserAccounts.ListEmployeeAccounts();
                    Console.WriteLine("\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    break;

                    case "9": // Add an employee account
                    AddEmployeeMenu();
                    break;

                    case "10": // Delete an employee account
                    DeleteEmployeeMenu();
                    break;

                    case "11": // List all admin accounts
                    UserAccounts.ListAdminAccounts();
                    Console.WriteLine("\nPress 'Enter' to continue.");
                    Console.ReadLine();
                    break;

                    case "12": // Add an admin account
                    AddAdminMenu();
                    break;

                    case "13": // Delete an admin account
                    DeleteAdminMenu();
                    break;

                    case "14": // Log out and go back to main menu
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
                password = UserAccounts.EncryptOrDecryptPassword(password, false);

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

        private static Admin GetAdminAccount() // // Used inside other methods in admin area
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
        
        private static void AddAdminMenu() // Used inside admin area
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
                password = UserAccounts.EncryptOrDecryptPassword(password, false);

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

        private static void DeleteAdminMenu() // Used inside admin area
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
