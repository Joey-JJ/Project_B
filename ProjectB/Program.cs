using System;


namespace ProjectB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello");
            bool startingscreeninValidAnswer = true;
            while (startingscreeninValidAnswer)
            {
                try
                {
                    string startingscreen = "Hello, welcome to paps patat \n Press 1 for login and account creation \n Press 2 to see reservations";
                    Console.WriteLine(startingscreen);
                    int startingscreenoutput = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Something went wrong, try again!");
                }
            }
         }
    }
}
