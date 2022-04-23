using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Orders
{
    public static void MenuCourses()
    {
        Console.Clear();
        string menuOptions;
        Console.WriteLine("Press 1 for the appetizers\nPress 2 for the main course\nPress 3 for the vegan main course\nPress 4 for the desserts\nPress 5 for the vegan deserts\nPress 6 for the drinks\nPress 7 to go back");
        while (true)
        {
            menuOptions = Console.ReadLine();
            if (menuOptions == "1")
            {
                Console.Clear();
                FoodMenu.PrintAppetizers();
                break;
            }
            else if (menuOptions == "2")
            {
                Console.Clear();
                FoodMenu.PrintMainCourses();
                break;
            }
            else if (menuOptions == "3")
            {
                Console.Clear();
                FoodMenu.PrintVeganMainCourses();
                break;
            }
            else if (menuOptions == "4")
            {
                Console.Clear();
                FoodMenu.PrintDesserts();
                break;
            }
            else if (menuOptions == "5")
            {
                Console.Clear();
                FoodMenu.PrintVeganDesserts();
                break;
            }
            else if (menuOptions == "6")
            {
                Console.Clear();
                FoodMenu.PrintDrinks();
                break;
            }
            else if (menuOptions == "7")
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter a valid number");
                break;
            }
        }

    }

    //public static void PlaceOrder(string ProductName)
    //{
    //    string product = Console.ReadLine();
    //    int index = product
    //    for (int a = 0; a < Reviews.Count; a++)
    //    {
    //        if (Reviews[a].Name.ToLower() == ProductName.ToLower())
    //            index = a;
    //    }

    //    if (index != -1)
    //    {
    //        Reviews.RemoveAt(index);
    //        Console.Clear();
    //        Console.WriteLine("Review removed");
    //        ListReviews();
    //    }
    //    else
    //    {
    //        Console.WriteLine("No review has been written by this name");
    //    }
    //}
}

