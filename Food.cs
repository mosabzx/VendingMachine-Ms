using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Food : Products
    {
        
        
        public Food(string name, int price)
        {
            Name = name;
            Price = price;

        }

        public Food()
        {

        }

        public override void ProductS()
        {
            
            Console.WriteLine("The list of food's products: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1.Banana.\n" +
                              "2.Snadwitch.\n" +
                              "3.Pie.\n");
            Console.ResetColor();

        }

        public override void Purchase(string name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You chose the foods's product {name} please confirm: Y/N");
            Console.ResetColor();

        }


        public override void ProductPriceInfo(string name, int num)
        {
            Console.WriteLine("The Food product is: {0} and the cost is: {1} Kr.", name, num);

        }



        public override void ProdcutUserGuide(string name)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Nothing satisfy the hunger except the food, enjoy with {name} ");
            Console.ResetColor();
        }



    }
}
