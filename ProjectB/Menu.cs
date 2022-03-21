using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    class Menu
    {
        public static string Appetizer = "The Appetizers:\nOeuf en cocotte  * $8.00 *\nFrench Onionsoup * $8.00 *\nPiperade * $8.00 *";
        public static string MainCourse = "The Maincourses:\nVegetable gratin * $14.00 *\nEntrecote bordelaise * $20.00 *\nCoq au vin * $24.00 *\nOisters * $30.00 *\nConfit de canard * $25.00 *\nHomard aux aromates * $24.00 *";
        public static string Dessert = "The Desserts:\nLemon cake * $8.00 *\nMoelleux au chocolat* $10.00 *\nCrepes: (choose from:banana, strawberry, blueberry and with(out) whipped cream white/milk/dark chocolatesauce) * $8.00 *\nChocolate souffle * $14.00 *\nCreme brulee * $14.00 *";
        public static string VeganMainCourse = "The Vegan Maincourses:\nVegan choucroute garnie * $14.00 *\n Champignon bourguignon * $20.00 *\nRatatouille * $18.00 *\nFrench lentil & greens soup * $18.00 *\n Salade nicoise * $25.00 *\n Vegan Escargot * $20.00 *";
        public static string VeganDessert = "The Vegan Desserts:\nicecream of choice (blueberry, strawberry, lemon, chocolate and vanilla) * $4.00 *\nBrownie * $8.00 *\nVanilla cake * $10.00 *\nVegan Crepes * $8.00 *\nCreme Brulee * $14.00 *";
        public static string Drinks = "Drinks:\nCoca cola * $ 2.50 *\nIce Tea (sparkling, normal, peach, green tea)* $2.50 *\nFristi * $2.00 *\nChocomel * $2.00 *\nOasis * $2.00 *\nWater * $ *2.00\nChateau mouton rothschild pauillac * $12.00 *\nChateau margaux * $12.00 *\nBordeax red * $12.00 *";
        public static string FullMenu = Appetizer + "\n\n" + MainCourse + "\n\n" + VeganMainCourse + "\n\n" + Dessert + "\n\n" + VeganDessert + "\n\n" + Drinks;
     
            
    }
}
