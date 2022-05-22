// using System;
// using System.Text.Json;
// using System.IO;
// using System.Collections.Generic;
// using System.Linq;

// namespace ProjectB
// {
//     public class User
//     {
//         public string Username { get; set; }
//         public string Email { get; set; }
//         public string Password { get; set; }

//         public User(
//                 string Username,
//                 string Email,
//                 string Password
//                 )
//         {
//             this.Username = Username;
//             this.Email = Email;
//             this.Password = Password;
//         }
//     }

//     public class UserHandler
//     {
//         public static List<User> users = new();
//         public static string filename = "Userdata.json";

//         public static void LoadAllUsers() // loads all users, can be accessed manually but you shouldn't have to.
//         {
//             List<User> unsanitizedusers = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(filename));
//             foreach (User user in unsanitizedusers)
//             {
//                 users.Add(user);
//             }

//         } 
//         public static bool login(string username, string email, string password)
//         {
//             int userindex = UserIndexSearch(username);
//             if (userindex > -1)
//             {
//                 User user = users[userindex];
//                 bool loginsuccesfull = user.Password == password && user.Email == email && user.Password == password;
//                 if (loginsuccesfull)
//                 {
//                     Console.WriteLine("Login Succesfull!");
//                     return true;
//                 }
//                 else
//                 {
//                     bool passwordcheck = password == user.Password;
//                     if (!passwordcheck)
//                     {
//                         Console.WriteLine("the password seems incorrect");
//                         return false;
//                     }
//                     else
//                     {
//                         Console.WriteLine("The email seems incorrect");
//                         return false;
//                     }
//                 }
//             }
//             else
//             {
//                 Console.WriteLine("This user does not seem to exist!");
//                 return false;
//             }
//         }
//         public static void ListAllUsers()   //lists only the username of each user
//         {
//             bool endreached = false;
//             while (!endreached)
//             {

//                 if (users.Count < 1)
//                 {
//                     LoadAllUsers();
//                 }
//                 else
//                 {

//                     foreach (User user in users)
//                     {
//                         Console.WriteLine(user.Username);
//                     }
//                 }
//                 endreached = true;
//             }
//         }



//         public static void SaveChanges() // saves all user changes made 
//         {
//             string jsonstring = JsonSerializer.Serialize(users);
//             File.WriteAllText(filename, jsonstring);
//         }

//         public static void searchUser(string username) // searches user by username, confirms wether user exists
//         {
//             bool repeat = true;
//             bool userfound = false;
//             while (repeat)
//             {

//                 if (users.Count < 0)
//                 {
//                     LoadAllUsers();
//                 }
//                 else
//                 {
//                     for (int i = 0; i < users.Count; i++)
//                     {
//                         if (users[i].Username == username)
//                         {
//                             Console.WriteLine("user found!");
//                             repeat = false;
//                             userfound = true;
//                         }
//                     }
//                 }
//                 if (!userfound)
//                 {

//                     Console.WriteLine("User could not be found!");
//                 }
//             }
//         }
//         public static int UserIndexSearch(string username) // returns index of user starting at 0 or -1 if not found
//         {
//             for (int i = 0; i < users.Count; i++)
//             {
//                 if (users[i].Username == username)
//                 {
//                     return i;
//                 }
//             }
//             return -1;
//         }
//         public static void editUsername(string username, string newUsername) // takes old username and lets you change it
//         {

//             int index = UserIndexSearch(username);
//             if (index == -1)
//             {
//                 Console.WriteLine("Person not found!");
//             }
//             else
//             {
//                 users[index].Username = newUsername;
//                 SaveChanges();
//             }
//         }
//         public static void editemail(string username, string NewEmail) // edits email of the user with that username
//         {
//             int index = UserIndexSearch(username);
//             if (index == -1)
//             {
//                 Console.WriteLine("Couldn't find the person!");
//             }
//             else
//             {
//                 users[index].Email = NewEmail;
//                 SaveChanges();
//             }
//         }
//         public static void editPassword(string username, string email, string Password, string NewPassword)
//         {
//             int index = UserIndexSearch(username);
//             if (index == -1)
//             {
//                 Console.WriteLine("Person could not be found!");
//             }
//             else
//             {
//                 User user = users[index];
//                 if (username == user.Username && email == user.Email && Password == user.Password)
//                 {
//                     Console.WriteLine("Password succesfully changed");
//                     users[index].Password = NewPassword;
//                     SaveChanges();
//                 }
//                 else if (username == user.Username && email == user.Email)
//                 {
//                     Console.WriteLine("Wrong Password, try again");
//                 }
//                 else if (username == user.Username)
//                 {
//                     Console.WriteLine("Wrong Email, try again");
//                 }
//                 else
//                 {
//                     Console.WriteLine("Something went wrong, try again");
//                 }
//             }
//         }
//         public static void addUser(User user) // adds user and saves change
//         {
//             users.Add(user);
//             SaveChanges();
//         }
//         public static void DeleteUser(string username)
//         {

//             int index = UserIndexSearch(username);
//             users.RemoveAt(index);
//             SaveChanges();
//         }
//     }

//     /* very primitive debugging
//     public static void Main()
//     {
//         User user = new User("Mees", "Meeszelst@hotmail","password");
//         UserHandler.addUser(user);
//         UserHandler.searchUser(user.Username);
//         Console.WriteLine("searchUser executed");
//         UserHandler.editemail(user.Username, "newemail");

//         Console.WriteLine("editEmail executed");
//         UserHandler.ListAllUsers();

//         Console.WriteLine("listallusers executed ");
//         Console.WriteLine(UserHandler.UserIndexSearch(user.Username));

//         Console.WriteLine("UserIndexSearch executed");

//     }*/
//     public class Admin
//     {
//         public string Username { get; set; }
//         public string Email { get; set; }
//         public string Password { get; set; }



//         public Admin(
//                 string Username,
//                 string Email,
//                 string Password
//                 )
//         {
//             this.Username = Username;
//             this.Email = Email;
//             this.Password = Password;
//         }
//         public static string filename = "AdminData.json";
//         public static List<Admin> allAdmins = new();

//         public static bool Login(string username, string password, string email)
//         {
//             int adminindex = AdminIndexSearch(username);
//             if (adminindex >= 0)
//             {
//                 bool passwordcheck = allAdmins[adminindex].Password == password;
//                 if (!passwordcheck)
//                 {
//                     Console.WriteLine("this password seems incorrect!");
//                     return false;
//                 }
//                 bool emailcheck = allAdmins[adminindex].Email == email;
//                 if (!emailcheck)
//                 {

//                     Console.WriteLine("This email seems incorrect!");
//                     return false;
//                 }

//                 if (passwordcheck && emailcheck)
//                 { 
//                     Console.WriteLine("you've succesfully logged in!");
//                     return true;
//                 }
//             }
//             Console.WriteLine("This person could not be found");
//             return false;
//         }
//         public static int AdminIndexSearch(string username)
//         {
//             for(int i = 0; i < allAdmins.Count; i++)
//             {
//                 var admin = allAdmins[i];
//                 if(admin.Username == username)
//                 {
//                     return i;
//                 }
//             }
//             return -1;
//         }
//         public static void LoadAllAdmins()
//         {
//             List<Admin> unsanitizedusers = JsonSerializer.Deserialize<List<Admin>>(File.ReadAllText(filename));
//             foreach (Admin user in unsanitizedusers)
//             {
//                 allAdmins.Add(user);
//             }
//         }
//         public static void saveChanges()
//         {
//             string stage = JsonSerializer.Serialize(allAdmins);
//             File.WriteAllText(filename, stage);
//         }

//         public static void addAdmin(Admin admin)
//         {
//             allAdmins.Add(admin);
//             saveChanges();
//         }
//         public static void deleteAdmin(string usernameofadmin)
//         {
//             LoadAllAdmins();
//             for (int i = 0; i < allAdmins.Count; i++)
//             {
//                 LoadAllAdmins();
//                 if (allAdmins[i].Username == usernameofadmin)
//                 { 
//                     Console.WriteLine("Admin deleted!");
//                     allAdmins.RemoveAt(i);
//                 }
//             }
//             saveChanges();
//         }

//         public static void editInformation(string usernameofaccounttoeddit)
//         {
//             int index = 0;
//             bool done = false;
//             while (!done)
//             {
//                 for (int i = 0; i < allAdmins.Count; i++)
//                 {
//                     if (allAdmins[i].Username == usernameofaccounttoeddit)
//                     {
//                         index = i;
//                         done = true;
//                     }
//                 }
//                 if (!done)
//                 {
//                     Console.WriteLine("no one was found under that username");
//                 }

//             }
//             Console.WriteLine("What information would you like to change about the account? \n Press: \n [1] to edit email [2] to edit username \n [3] to edit Password");
//             string output = Console.ReadLine();
//             switch (output)
//             {
//                 case "1": // edit email
//                     Console.WriteLine("What would you like the new email to be?");
//                     break;
//                 case "2": // edit username
//                     Console.WriteLine("What would you like the new username to be?");
//                     string newusername = Console.ReadLine();
//                     allAdmins[index].Username = newusername;
//                     saveChanges();
//                     break;
//                 case "3": // edit password
//                     Console.WriteLine("To edit password, please enter the old password of the account");
//                     string oldpassword = Console.ReadLine();
//                     if (oldpassword == allAdmins[index].Password)
//                     {
//                         Console.WriteLine("Password verification complete! \n  What would you like the new password to be?");
//                         string newpassword = Console.ReadLine();
//                         allAdmins[index].Password = newpassword;
//                         saveChanges();
//                     }
//                     break;
//             }

//         }
//         public static void listadmins()
//         {
//             LoadAllAdmins();
//             foreach(Admin admin in allAdmins)
//             {
//                 Console.WriteLine(admin.Username);
//             }
//         } /*
//         public static void Main()
//         {
//             Admin admin = new Admin("admin", "adminsemail", "12342");
//             Admin.addAdmin(admin);
//             Admin.listadmins();
//             Admin.deleteAdmin(admin.Username);
//             Admin.listadmins();
//         } */
//     }
//     public class Worker
//     {
//         public string Username { get; set; }
//         public string Email { get; set; }
//         public string Password { get; set; }



//         public Worker(
//                 string Username,
//                 string Email,
//                 string Password
//                 )
//         {
//             this.Username = Username;
//             this.Email = Email;
//             this.Password = Password;
//         }
//         public static string filename = "WorkerData.json";
//         public static List<Worker> allWorkers = new();

//         public static void loadAllWorkers()
//         {
//             allWorkers = JsonSerializer.Deserialize<List<Worker>>(File.ReadAllText(filename));
//         }
//         public static void saveChanges()
//         {
//             var serialized = JsonSerializer.Serialize(allWorkers);
//             File.WriteAllText(filename, serialized);
//         }
//         public static void addWorker(Worker worker)
//         {
//             allWorkers.Add(worker);
//             Console.WriteLine("Worker succesfully added");
//             saveChanges();
//         }

//         public static void deleteWorker(string usernameofworker)
//         {
//             bool done = false;
//             while (!done)
//             {

//                 for (int I = 0; I < allWorkers.Count; I++)
//                 {
//                     if (allWorkers[I].Username == usernameofworker)
//                     {
//                         Console.WriteLine("Worker deleted!");
//                         allWorkers.RemoveAt(I);
//                         saveChanges();
//                         done = true;
//                     }
//                 }
//                 if (!done)
//                 {
//                     Console.WriteLine("Couldn't find user!");
//                 }

//             }
//         }
//         public static void editInformation(string usernameofaccounttoeddit)
//         {
//             int index = 0;
//             bool done = false;
//             while (!done)
//             {
//                 for (int i = 0; i < allWorkers.Count; i++)
//                 {
//                     if (allWorkers[i].Username == usernameofaccounttoeddit)
//                     {
//                         index = i;
//                         done = true;
//                     }
//                 }
//                 if (!done)
//                 {
//                     Console.WriteLine("no one was found under that username");
//                 }
//             }
//             Console.WriteLine("What information would you like to change about the account? \n Press: \n [1] to edit email [2] to edit username \n [3] to edit Password [4] to return to main menu");
//             string output = Console.ReadLine();
//             switch (output)
//             {
//                 case "1": // edit email
//                     Console.WriteLine("What would you like the new email to be?");
//                     break;
//                 case "2": // edit username
//                     Console.WriteLine("What would you like the new username to be?");
//                     string newusername = Console.ReadLine();
//                     allWorkers[index].Username = newusername;
//                     saveChanges();
//                     break;
//                 case "3": // edit password
//                     Console.WriteLine("To edit password, please enter the old password of the account");
//                     string oldpassword = Console.ReadLine();
//                     if (oldpassword == allWorkers[index].Password)
//                     {
//                         Console.WriteLine("Password verification complete! \n  What would you like the new password to be?");
//                         string newpassword = Console.ReadLine();
//                         allWorkers[index].Password = newpassword;
//                         saveChanges();
//                     }
//                     break;
//                 case "4":  // dont delete, this exits
//                     break;

//             }
//         }/*
//         static void Main()
//         {
//             Worker worker = new("bb", "bb@", "MM");
//             Worker.addWorker(worker);
//             Worker.loadAllWorkers();
//         }*/
//     }

// }


