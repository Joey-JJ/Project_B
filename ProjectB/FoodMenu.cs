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
    }

}
