using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace DevTest
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(
                string Username,
                string Email,
                string Password
                )
        {
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;
        }
    }

    public class Program
    {

        public class UserHandler
        {
            public static List<User> users = new();
            public static string filename = "Userdata.json";

            public static void LoadAllUsers()
            {
                List<User> unsanitizedusers = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(filename));
                foreach (User user in unsanitizedusers)
                {
                    users.Add(user);
                }

            }
            public static void ListAllUsers()
            {
                bool endreached = false;
                while (!endreached)
                {

                    if (users.Count < 1)
                    {
                        LoadAllUsers();
                    }
                    else
                    {

                        foreach (User user in users)
                        {
                            Console.WriteLine(user.Username);
                        }
                    }
                    endreached = true;
                }
            }



            public static void SaveChanges() // saves all user changes made 
            {
                File.WriteAllText(filename, JsonSerializer.Serialize(users));
            }

            public static void searchUser(string username)
            {
                bool repeat = true;
                while (repeat)
                {

                    if (users.Count < 0)
                    {
                        LoadAllUsers();
                    }
                    else
                    {
                        for (int i = 0; i < users.Count; i++)
                        {
                            if (users[i].Username == username)
                            {
                                Console.WriteLine("user found!");
                                repeat = false;
                            }
                        }
                        Console.WriteLine("user not found");
                    }
                }
            }
            public static int UserIndexSearch(string username) // returns index or -1 if not found
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Username == username)
                    {
                        return i;
                    }
                }
                return -1;
            }
            public static void editUsername(string username, string newUsername)
            {

                int index = UserIndexSearch(username);
                if (index == -1)
                {
                    Console.WriteLine("Person not found!");
                }
                else
                {
                    users[index].Username = newUsername;
                    SaveChanges();
                }
            }
            public static void editemail(string username, string NewEmail)
            {
                int index = UserIndexSearch(username);
                if (index == -1)
                {
                    Console.WriteLine("Couldn't find the person!");
                }
                else
                {
                    users[index].Email = NewEmail;
                    SaveChanges();
                }
            }
            public static void editPassword(string username, string email, string Password, string NewPassword)
            {
                int index = UserIndexSearch(username);
                if (index == -1)
                {
                    Console.WriteLine("Person could not be found!");
                }
                else
                {
                    User user = users[index];
                    if (username == user.Username && email == user.Email && Password == user.Password)
                    {
                        Console.WriteLine("Password succesfully changed");
                        users[index].Password = NewPassword;
                        SaveChanges();
                    }
                    else if (username == user.Username && email == user.Email)
                    {
                        Console.WriteLine("Wrong Password, try again");
                    }
                    else if (username == user.Username)
                    {
                        Console.WriteLine("Wrong Email, try again");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong, try again");
                    }
                }
            }
            public static void addUser(User user)
            {
                users.Add(user);
                SaveChanges();
            }
            public static void DeleteUser(string username)
            {

                int index = UserIndexSearch(username);
                users.RemoveAt(index);
                SaveChanges();
            }
        }


        public static void Main()
        {
            UserHandler.LoadAllUsers();

        }
    }
}
