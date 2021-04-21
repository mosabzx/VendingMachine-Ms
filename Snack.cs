using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Snack : Products
    {
        
        
        public Snack(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public Snack()
        {

        }

        public override void ProductS()
        {
            Console.WriteLine("The list of snack's products : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("1.Chips.\n" +
                              "2.Chocalte.\n" +
                              "3.Popcorn.\n");
            Console.ResetColor();

        }

        public override void Purchase(string name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You chose the Snack's product {name} please confirm: Y/N");
            Console.ResetColor();

        }


        public override void ProductPriceInfo(string name, int num)
        {
            Console.WriteLine("The Snacks product is: {0} and the cost is: {1} Kr.", name, num);

        }

        public override void ProdcutUserGuide(string name)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"No matter how busy! there always time for snacks, enjoy with {name} ");
            Console.ResetColor();
        }




    }
}
