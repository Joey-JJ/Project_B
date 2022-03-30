using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    public static class FullMenu
    {
        readonly static Dictionary<string, double> Menu = new()
        {
                {"Oeuf en cocotte", 8.00 },
                { "French Onionsoup", 8.00 },
                { "Piperade", 8.00 },
                { "Entrecote Bordelaise", 25.00 },
                { "Coq au Vin", 25.00 },
                { "Oesters", 30.00},
                { "Confit de Canard", 25.00},
                { "Homard aux Aromates", 18.00},
                { "Vegan Choucroute garnie", 14.00},
                { "Champignon Bourguignon", 20.00},
                { "Ratatouille", 18.00},
                { "French Lentil & greens soup", 18.00},
                { "Salad Nicoise", 25.00},
                { "Vegan Escargot", 20.00},
                { "Lemon Cake", 8.00},
                { "Moelleux au Chocolat", 10.00},
                { "Crepes (with: banana, strawberry, blueberry / whipped cream)", 8.00},
                { "Chocolate souffle", 14.00},
                { "Creme Brulee", 14.00},
                { "Vegan icecream scoop (chocolate, vanilla, banana, strawberry, lemon and chocolate sauce)", 8.00},
                { "Vegan Brownie", 8.00},
                { "Vegan Vanille cake", 8.00},
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
        public static void PrintMenu()
        {
            foreach (var Item in Menu)
            {
               Console.WriteLine("{0}, price = {1}", Item.Key, Item.Value);
                
            }
        }
         public static void PrintAppetizers()
        {
            Console.WriteLine("The Appetizers:\nOeuf en cocotte  * $8.00 *\nFrench Onionsoup * $8.00 *\nPiperade * $8.00 *");
        }
        public static void PrintMainCourse()
        {
            Console.WriteLine("The Maincourses:\nVegetable gratin * $14.00 *\nEntrecote bordelaise * $20.00 *\nCoq au vin * $24.00 *\nOisters * $30.00 *\nConfit de canard * $25.00 *\nHomard aux aromates * $24.00 *");
        }
        public static void PrintDesserts()
        {
            Console.WriteLine("The Desserts:\nLemon cake * $8.00 *\nMoelleux au chocolat* $10.00 *\nCrepes: (choose from:banana, strawberry, blueberry and with(out) whipped cream white/milk/dark chocolatesauce) * $8.00 *\nChocolate souffle * $14.00 *\nCreme brulee * $14.00 *");
        }
        public static void PrintVeganMainCourses()
        {
            Console.WriteLine("The Vegan Maincourses:\nVegan choucroute garnie * $14.00 *\n Champignon bourguignon * $20.00 *\nRatatouille * $18.00 *\nFrench lentil & greens soup * $18.00 *\n Salade nicoise * $25.00 *\n Vegan Escargot * $20.00 *");
        }
        public static void PrintVeganDesserts()
        {
            Console.WriteLine("The Vegan Desserts:\nicecream of choice (blueberry, strawberry, lemon, chocolate and vanilla) * $4.00 *\nBrownie * $8.00 *\nVanilla cake * $10.00 *\nVegan Crepes * $8.00 *\nCreme Brulee * $14.00 *");
        }
        public static void PrintDrinks()
        {
            Console.WriteLine("Drinks:\nCoca cola * $ 2.50 *\nIce Tea (sparkling, normal, peach, green tea)* $2.50 *\nFristi * $2.00 *\nChocomel * $2.00 *\nOasis * $2.00 *\nWater * $ *2.00\nChateau mouton rothschild pauillac * $12.00 *\nChateau margaux * $12.00 *\nBordeax red * $12.00 *");
        }
        
    }

}
