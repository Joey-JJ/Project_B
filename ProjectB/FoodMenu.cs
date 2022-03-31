using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    public static class FoodMenu
    {
        readonly static Dictionary<string, double> Appetizers = new Dictionary<string, double>
        {
                {"Oeuf en Cocotte", 8.00 },
                { "French Onionsoup", 8.00 },
                { "Piperade", 8.00 }
        };

        readonly static Dictionary<string, double> MainCourses = new Dictionary<string,double>
        { 
                {"Entrecote Bordelaise", 25.00 },
                { "Coq au Vin", 25.00 },
                { "Oesters", 30.00},
                { "Confit de Canard", 25.00},
                { "Homard aux Aromates", 18.00}
        };
        readonly static Dictionary<string, double> VeganMainCourses = new Dictionary<string, double>
        {
               { "Vegan Choucroute Garnie", 14.00},
                { "Champignon Bourguignon", 20.00},
                { "Ratatouille", 18.00},
                { "French Lentil & Greens Soup", 18.00},
                { "Salad Nicoise", 25.00},
                { "Vegan Escargot", 20.00}
        };
        readonly static Dictionary<string, double> Desserts = new Dictionary<string, double>
        {
                { "Lemon Cake", 8.00},
                { "Moelleux au Chocolat", 10.00},
                { "Crepes (with: banana, strawberry, blueberry / whipped cream)", 8.00},
                { "Chocolate Souffle", 14.00},
                { "Creme Brulee", 14.00}
        };
        readonly static Dictionary<string, double> VeganDesserts = new Dictionary<string, double>
        {
                { "Vegan Icecream scoop (chocolate, vanilla, banana, strawberry, lemon and chocolate sauce)", 8.00},
                { "Vegan Brownie", 8.00},
                { "Vegan Vanille Cake", 8.00},
                { "Vegan Aplle Pie", 8.00 }
        };
        readonly static Dictionary<string, double> Drinks = new Dictionary<string,double>
        {
                { "Coca Cola", 2.50},
                { "Sprite", 2.50},
                { "Mineral Water", 2.00},
                { "Ice Tea (Peach, Green Tea, Sparkling)", 2.50},
                { "Oasis", 2.00},
                { "Chocomel", 2.00},
                { "Fristi", 2.00},
                { "Chateau Mouton Rothschild Pauillac", 8.00},
                { "Chateau Margaux", 8.00},
                { "Bordeaux red", 8.00}
        };
        public static void PrintAppetizers()
        {
            Console.WriteLine("The appetizers are:");
            foreach (var Item in Appetizers)
            {
                
                Console.WriteLine("{0} = ${1}", Item.Key, Item.Value);

            }
        }
        public static void PrintMainCourses()
        {
            Console.WriteLine("The Maincourses are:");
            foreach (var Item in MainCourses)
            {                
                Console.WriteLine("{0} = ${1}", Item.Key, Item.Value);

            }
        }
        public static void PrintVeganMainCourses()
        {
            Console.WriteLine("The vegan maincourses are:");
            foreach (var Item in VeganMainCourses)
            {
                Console.WriteLine("0} = ${1}", Item.Key, Item.Value);

            }
        }
        public static void PrintDesserts()
        {
            Console.WriteLine("The Desserts are:");
            foreach (var Item in Desserts)
            {
                Console.WriteLine("{0} = ${1}", Item.Key, Item.Value);

            }
        }
        public static void PrintVeganDesserts()
        {
            Console.WriteLine("The vegan desserts are:");
            foreach (var Item in VeganDesserts)
            {
                Console.WriteLine( "{0} = ${1}", Item.Key, Item.Value);

            }
        }
        public static void PrintDrinks()
        {
            Console.WriteLine("The Drinks are:");
            foreach (var Item in Drinks)
            {

                Console.WriteLine("{0} = ${1}", Item.Key, Item.Value);

            }

        }



    }

}
