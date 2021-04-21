using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public  class Money : Products
    {
        public int Balance { get; set; }
        public int Change { get; set; }
        public int Wallet { get; set; }
        public int Purchases { get; set; }

        private int Kron;

        public Money()
        {
            Kron = aKron;
            Wallet = 0;
            Balance = 0;
            Change = 0;
            Purchases = 0;
        }

        public int aKron
        {
            get { return Kron; }

            set
            {
                if (value == 1 || value == 5 || value == 10 || value == 20 || value == 50
                    || value == 100 || value == 500 || value == 1000 || value == 0)
                {
                    Kron = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid category type!!");
                    Console.ResetColor();

                }

            }
        }

        public static int GetBalance(int get)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your balance is: {0} Kr.", get);
            Console.ResetColor();
            return get;
            
        }

    }
}
