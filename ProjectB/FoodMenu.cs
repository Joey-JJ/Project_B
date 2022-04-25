using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

class FoodMenu
{
    private static readonly string OrderFile = "Orders.json";
    public static Dictionary<string, int> MakeOrder = new() { };


    public static Dictionary<string, double> Appetizers = new()
    {
        { "Oeuf en Cocotte", 8.00 },
        { "French Onionsoup", 8.00 },
        { "Piperade", 8.00 }
    };

    public static Dictionary<string, double> MainCourses = new()
    { 
        { "Entrecote Bordelaise", 25.00 },
        { "Coq au Vin", 25.00 },
        { "Oesters", 30.00 },
        { "Confit de Canard", 25.00 },
        { "Homard aux Aromates", 18.00 }
    };

    public static Dictionary<string, double> VeganMainCourses = new()
    {
        { "Vegan Choucroute Garnie", 14.00 },
        { "Champignon Bourguignon", 20.00 },
        { "Ratatouille", 18.00 },
        { "French Lentil & Greens Soup", 18.00 },
        { "Salad Nicoise", 25.00 },
        { "Vegan Escargot", 20.00 }
    };

    public static Dictionary<string, double> Desserts = new()
    {
        { "Lemon Cake", 8.00 },
        { "Moelleux au Chocolat", 10.00 },
        { "Crepes (with: banana, strawberry, blueberry / whipped cream)", 8.00 },
        { "Chocolate Souffle", 14.00 },
        { "Creme Brulee", 14.00 }
    };

    public static Dictionary<string, double> VeganDesserts = new()
    {
        { "Vegan Icecream scoop (chocolate, vanilla, banana, strawberry, lemon and chocolate sauce)", 8.00 },
        { "Vegan Brownie", 8.00 },
        { "Vegan Vanille Cake", 8.00 },
        { "Vegan Aplle Pie", 8.00 }
    };

    public static Dictionary<string, double> Drinks = new()
    {
        { "Coca Cola", 2.50 },
        { "Sprite", 2.50 },
        { "Mineral Water", 2.00 },
        { "Ice Tea (Peach, Green Tea, Sparkling)", 2.50 },
        { "Oasis", 2.00 },
        { "Chocomel", 2.00 },
        { "Fristi", 2.00 },
        { "Chateau Mouton Rothschild Pauillac", 8.00 },
        { "Chateau Margaux", 8.00 },
        { "Bordeaux red", 8.00 }
    };

    public static void PrintOrder()
    {
        int index = 0;
        foreach (var Item in MakeOrder)
        {
            Console.WriteLine($"{Item.Key} = {Item.Value}");
            index++;
        }
    }
    public static void SaveOrder()
    {
        var indent = new JsonSerializerOptions { WriteIndented = true };
        string orderString = JsonSerializer.Serialize(MakeOrder, indent);
        File.AppendAllText(OrderFile, orderString);
        Console.WriteLine("\nOrder saved!");
    }

    public static int OrderDetails()
    {
        Console.WriteLine("What dish would you like to order?: ");
        int order = Convert.ToInt32(Console.ReadLine());
        return order;
    }

    public static int AmountDetails()
    {
        Console.WriteLine("How many would you like?: ");
        int amount = Convert.ToInt32(Console.ReadLine());
        return amount;
    }
    public static void PrintAppetizers()
    {
        int index = 0;
        if (Appetizers.Count > 0)
        {
            bool makeOrder = true;
            while (makeOrder == true)
            {
                Console.Clear();
                Console.WriteLine("When ordering please use the index numbers\n");
                Console.WriteLine("The appetizers are:");
                foreach (var Item in Appetizers)
                {
                    Console.WriteLine($"[{index}] {Item.Key} = ${Item.Value}");
                    index++;
                }
                index = 0;

                Console.WriteLine("\nWould you like to make an order?\nPress 1 for yes\nPress 2 for no");
                string orderAnswer = Console.ReadLine();
                if (orderAnswer == "1")
                {
                    int order = OrderDetails();
                    if (order <= (Appetizers.Count - 1))
                    {
                        int amount = AmountDetails();
                        string dish = Appetizers.ElementAt(order).Key;
                        MakeOrder.Add(dish, amount);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                }
                else if (orderAnswer == "2")
                {
                    PrintOrder();
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }
        else
        {
            Console.WriteLine("There are no appetizers on the menu");
        }
    }
    public static void PrintMainCourses()
    {
        int index = 0;
        if (MainCourses.Count > 0)
        {
            bool makeOrder = true;
            while (makeOrder == true)
            {
                Console.Clear();
                Console.WriteLine("When ordering please use the index numbers\n");
                Console.WriteLine("The maincourses are:");
                foreach (var Item in MainCourses)
                {
                    Console.WriteLine($"[{index}] {Item.Key} = ${Item.Value}");
                    index++;
                }
                index = 0;

                Console.WriteLine("\nWould you like to make an order?\nPress 1 for yes\nPress 2 for no");
                string orderAnswer = Console.ReadLine();
                if (orderAnswer == "1")
                {
                    int order = OrderDetails();
                    if (order <= (MainCourses.Count - 1))
                    {
                        int amount = AmountDetails();
                        string dish = MainCourses.ElementAt(order).Key;
                        MakeOrder.Add(dish, amount);
                    }
                }
                else if (orderAnswer == "2")
                {
                    PrintOrder();
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }
        else
        {
            Console.WriteLine("There are no maincourses on the menu");
        }
    }
    public static void PrintVeganMainCourses()
    {
        int index = 0;
        if (VeganMainCourses.Count > 0)
        {
            bool makeOrder = true;
            while (makeOrder == true)
            {
                Console.Clear();
                Console.WriteLine("When ordering please use the index numbers\n");
                Console.WriteLine("The vegan maincourses are:");
                foreach (var Item in VeganMainCourses)
                {
                    Console.WriteLine($"[{index}] {Item.Key} = ${Item.Value}");
                    index++;
                }
                index = 0;

                Console.WriteLine("\nWould you like to make an order?\nPress 1 for yes\nPress 2 for no");
                string orderAnswer = Console.ReadLine();
                if (orderAnswer == "1")
                {
                    int order = OrderDetails();
                    if (order <= (VeganMainCourses.Count - 1))
                    {
                        int amount = AmountDetails();
                        string dish = VeganMainCourses.ElementAt(order).Key;
                        MakeOrder.Add(dish, amount);
                    }
                }
                else if (orderAnswer == "2")
                {
                    PrintOrder();
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }
        else
        {
            Console.WriteLine("There are no vegan maincourses on the menu");
        }
    }
    public static void PrintDesserts()
    {
        int index = 0;
        if (Desserts.Count > 0)
        {
            bool makeOrder = true;
            while (makeOrder == true)
            {
                Console.Clear();
                Console.WriteLine("When ordering please use the index numbers\n");
                Console.WriteLine("The Desserts are:");
                foreach (var Item in Desserts)
                {
                    Console.WriteLine($"[{index}] {Item.Key} = ${Item.Value}");
                    index++;
                }
                index = 0;

                Console.WriteLine("\nWould you like to make an order?\nPress 1 for yes\nPress 2 for no");
                string orderAnswer = Console.ReadLine();
                if (orderAnswer == "1")
                {
                    int order = OrderDetails();
                    if (order <= (Desserts.Count - 1))
                    {
                        int amount = AmountDetails();
                        string dish = Desserts.ElementAt(order).Key;
                        MakeOrder.Add(dish, amount);
                    }
                }
                else if (orderAnswer == "2")
                {
                    PrintOrder();
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }
        else
        {
            Console.WriteLine("There are no desserts on the menu");
        }
    }
    public static void PrintVeganDesserts()
    {
        int index = 0;
        if (VeganDesserts.Count > 0)
        {
            bool makeOrder = true;
            while (makeOrder == true)
            {
                Console.Clear();
                Console.WriteLine("When ordering please use the index numbers\n");
                Console.WriteLine("The vegan desserts are:");
                foreach (var Item in VeganDesserts)
                {
                    Console.WriteLine($"[{index}] {Item.Key} = ${Item.Value}");
                    index++;
                }
                index = 0;

                Console.WriteLine("\nWould you like to make an order?\nPress 1 for yes\nPress 2 for no");
                string orderAnswer = Console.ReadLine();
                if (orderAnswer == "1")
                {
                    int order = OrderDetails();
                    if (order <= (VeganDesserts.Count - 1))
                    {
                        int amount = AmountDetails();
                        string dish = VeganDesserts.ElementAt(order).Key;
                        MakeOrder.Add(dish, amount);
                    }
                }
                else if (orderAnswer == "2")
                {
                    PrintOrder();
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }
        else
        {
            Console.WriteLine("There are no vegan desserts on the menu");
        }
    }
    public static void PrintDrinks()
    {
        int index = 0;
        if (Drinks.Count > 0)
        {
            bool makeOrder = true;
            while (makeOrder == true)
            {
                Console.Clear();
                Console.WriteLine("When ordering please use the index numbers\n");
                Console.WriteLine("The Drinks are:");
                foreach (var Item in Drinks)
                {
                    Console.WriteLine($"[{index}] {Item.Key} = ${Item.Value}");
                    index++;
                }
                index = 0;

                Console.WriteLine("\nWould you like to make an order?\nPress 1 for yes\nPress 2 for no");
                string orderAnswer = Console.ReadLine();
                if (orderAnswer == "1")
                {
                    int order = OrderDetails();
                    if (order <= (Drinks.Count - 1))
                    {
                        int amount = AmountDetails();
                        string dish = Drinks.ElementAt(order).Key;
                        MakeOrder.Add(dish, amount);
                    }
                }
                else if (orderAnswer == "2")
                {
                    PrintOrder();
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }
        else
        {
            Console.WriteLine("There are no drinks on the menu");
        }
    }
}
