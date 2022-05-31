using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public static class FoodMenu
{
    private static readonly string OrderFile = "Orders.json";
    public static List<Dictionary<string, int>> Orders = new() { };
    public static Dictionary<string, int> MakeOrder = new() { };
    public static Dictionary<string, int> OrderList = new() { };

    public static void ListMenu()
    {
        Console.WriteLine("****** Menu ******");
        Console.WriteLine("\nAppetizers");
        foreach (var item in Appetizers) Console.WriteLine($"{item.Key} - Price: {item.Value}");
        Console.WriteLine("\nMain courses");
        foreach (var item in MainCourses) Console.WriteLine($"{item.Key} - Price: {item.Value}");
        Console.WriteLine("\nVegan main courses");
        foreach (var item in VeganMainCourses) Console.WriteLine($"{item.Key} - Price: {item.Value}");
        Console.WriteLine("\nDesserts");
        foreach (var item in Desserts) Console.WriteLine($"{item.Key} - Price: {item.Value}");
        Console.WriteLine("\nVegan desserts");
        foreach (var item in VeganDesserts) Console.WriteLine($"{item.Key} - Price: {item.Value}");
        Console.WriteLine("\nDrinks");
        foreach (var item in Drinks) Console.WriteLine($"{item.Key} - Price: {item.Value}");
    }

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
        { "Vegan Apple Pie", 8.00 }
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
    public static int CheckIndex()
    {
        while (true)
        {
            var index = Console.ReadLine();
            int indexNumber;
            bool isCorrect = int.TryParse(index, out indexNumber);
            if (isCorrect)
            {
                if (indexNumber >= 1 && indexNumber <= Orders.Count)
                {
                    return indexNumber;
                }
                else
                {
                    Console.WriteLine("\nPlease enter a valid number");
                    Console.WriteLine("Which table would you like the bill of?\n");
                    Console.Write("Please enter your selection: ");
                }
            }
            else
            {
                Console.WriteLine("\nPlease enter a valid number");
                Console.WriteLine("Which table would you like the bill of?\n");
                Console.Write("Please enter your selection: ");
            }
        }
    }
    public static void PrintBill(int index)
    {
        Console.Clear();
        double totalAmount = 0.00;
        var bill = Orders[index];
        bool keepGoing = true;
        var table = bill["Table Number"];
        int i = 1;
        Console.WriteLine($"Table {table} has ordered:\n");
        foreach (KeyValuePair<string, int> Orders in bill.Skip(1))
        {
            while (keepGoing == true && i < bill.Count)
            {
                var item = bill.ElementAt(i);
                var itemKey = item.Key;
                var itemValue = item.Value;
                if (Appetizers.ContainsKey(itemKey))
                {
                    var product = bill[itemKey];
                    var price = Appetizers[itemKey];
                    totalAmount += product * price;
                    i++;
                }
                else if (MainCourses.ContainsKey(itemKey))
                {
                    var product = bill[itemKey];
                    var price = MainCourses[itemKey];
                    totalAmount += product * price;
                    i++;
                }
                else if (VeganMainCourses.ContainsKey(itemKey))
                {
                    var product = bill[itemKey];
                    var price = VeganMainCourses[itemKey];
                    totalAmount += product * price;
                    i++;
                }
                else if (Desserts.ContainsKey(itemKey))
                {
                    var product = bill[itemKey];
                    var price = Desserts[itemKey];
                    totalAmount += product * price;
                    i++;
                }
                else if (VeganDesserts.ContainsKey(itemKey))
                {
                    var product = bill[itemKey];
                    var price = VeganDesserts[itemKey];
                    totalAmount += product * price;
                    i++;
                }
                else if (Drinks.ContainsKey(itemKey))
                {
                    var product = bill[itemKey];
                    var price = Drinks[itemKey];
                    totalAmount += product * price;
                    i++;
                }
                else
                {
                    keepGoing = false;
                }
            }
            Console.WriteLine($"{Orders.Key} : {Orders.Value}");
        }
        Console.WriteLine($"\nTable bill: {totalAmount}");
    }
    public static void ListOrders()
    {
        LoadOrders();
        if (Orders.Count > 0)
        {
            int index = 1;
            foreach (Dictionary<string, int> AllOrders in Orders)
            {
                Console.WriteLine($"\nOrder number: {index}\nTable {AllOrders["Table Number"]} has ordered:");
                foreach (KeyValuePair<string, int> item in AllOrders.Skip(1))
                {
                    Console.WriteLine($"{item.Key} : {item.Value}");
                }
                index++;
            }
        }
        else
        {
            Console.WriteLine("No orders have been placed yet");
        }
    }
    public static void PrintOrder()
    {
        foreach (var Item in MakeOrder)
        {
            Console.WriteLine($"{Item.Key} = {Item.Value}");
        }
    }
    public static void LoadOrders()
    {
        string jsonString = File.ReadAllText(OrderFile);
        Orders = JsonSerializer.Deserialize<List<Dictionary<string, int>>>(jsonString);
    }
    public static void AddOrder()
    {
        foreach (var item in MakeOrder)
        {
            OrderList.Add(item.Key, item.Value);
        }
        Orders.Add(new Dictionary<string, int>(OrderList));
    }
    public static void SaveOrder()
    {
        var indent = new JsonSerializerOptions { WriteIndented = true };
        string orderString = JsonSerializer.Serialize(Orders, indent);
        File.WriteAllText(OrderFile, orderString);
    }
    public static void CheckOrders()
    {
        foreach (var item in MakeOrder)
        {
            Console.WriteLine($"{item.Key} = {item.Value}");
        }
    }

    public static int OrderDetails()
    {
        while (true)
        {
            Console.Write("What dish would you like to order?: ");
            var order = Console.ReadLine();
            int orderNumber;
            bool isCorrect = int.TryParse(order, out orderNumber);
            if (isCorrect)
            {
                return orderNumber;
            }
            else
            {
                Console.WriteLine("\nPlease enter a valid number");
            }
        }
    }
    public static int CheckAmount()
    {
        while (true)
        {
            var input = Console.ReadLine();
            int inputNumber;
            bool isCorrect = int.TryParse(input, out inputNumber);
            if (isCorrect)
            {
                if (inputNumber >= 1)
                {
                    return inputNumber;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number");
            }
        }
    }
    public static int AmountDetails()
    {
        Console.WriteLine("How many would you like?: ");
        int amount = CheckAmount();
        return amount;
    }
    public static void WhatTable()
    {
        string table = "Table Number";
        bool loop = true;
        while (loop == true)
        {
            Console.WriteLine("What is the tablenumber?");
            var number = Console.ReadLine();
            int tableNumber;
            bool isTable = int.TryParse(number, out tableNumber);
            if (isTable)
            {
                if (tableNumber >= 1 && tableNumber <= 18)
                {
                    MakeOrder.Add(table, tableNumber);
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid table number");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid table number");
            }
        }
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
