using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Drinks : Products
    {

        public Drinks(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public Drinks()
        {

        }


        public override void ProductS()
        {
            Console.WriteLine("The list of drink's products: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1.Coca Cola.\n" +
                             "2.Fun Juice.\n" +
                             "3.Aqua Fresh.\n");
            Console.ResetColor();

        }


        public override void Purchase(string name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You chose the drink's product {name} please confirm: Y/N");
            Console.ResetColor();
        }


        public override void ProductPriceInfo(string name, int num)
        {
            Console.WriteLine("The Drink product is: {0} and the cost is: {1} Kr.", name, num);


        }

        public override void ProdcutUserGuide(string name)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Enjoy your drink {name}! and satisfy your thirst");
            Console.ResetColor();
        }



    }
}
