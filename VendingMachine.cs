using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingMachine : Products
    {


        
        public static void ProductsMenu()
        {
            
            Console.WriteLine("Please chose the product by selecting number from the menu: \n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1.Cola, 13 Kr.                  2.Fun juice, 20 kr.\n" +
                             "3.Water, 25 Kr                   4.Banana, 5 Kr.\n" +
                             "5.Cheese Sandwitch, 55 Kr.       6.Pan pizza, 50 kr.\n" +
                             "7.Chips, 21 Kr.                  8.Twix, 20 Kr.\n" +
                             "9.PopCorn, 35 Kr.\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Insert ( 10 ) when you finish buying.\n" +
                              "Insert ( 11 ) for cancel and refund.");
            Console.ResetColor();
                                    
        }

        public static void InvalidMsg()
        {
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid selection! try again from products menu.");
            Console.ResetColor();

        }


        public static void Machine()
        {
            //Creating main object for each class.
            Drinks drink = new Drinks();
            Snack snack = new Snack();
            Food food = new Food();

            //Creating an objects for money class and assigned the fields with variables.
            Money User = new Money();
            int Moneypool = User.Wallet;
            int Balance = User.Balance;
            int Change = User.Change;
            int purchases = User.Purchases;

            //An inherited methods to display the products.
            drink.ProductS(); snack.ProductS(); food.ProductS();

            //Money denominations should be defined as an array of integers
            int[] MoneyCategory = { 1, 5, 10, 20, 50, 100, 500, 1000 };

            Console.WriteLine("Please! notice the machine only accept these categories:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[{0} Kr]\n", String.Join(" Kr , ", MoneyCategory));
            Console.ResetColor();


            // loop to take amounts from user.
            int go = 0;
            bool stop = true;
            while (go < 12 && stop)
            {
                //This condition to break the loop and for preventing the user from inserting 0 amount after 3 tries.
                if (go == 3 && Balance == 0)
                {
                    break;
                }

                
                else if (go == 1 && Balance == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please insert amount or the program will shutdown!");
                    Console.ResetColor();

                }

                //A useful information for user when start inserting money.
                else if (go == 1 && Balance != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("You can continue inserting amounts or insert 0 " +
                        "or hit enter to go to the products menu for purchase!.");
                    Console.ResetColor();
                }
                
                Console.WriteLine("Insert amount :");

                int userinput; int.TryParse(Console.ReadLine(), out userinput);
                Money insert = new Money(); 
                insert.aKron = userinput; //An object with private property for money fixed denominations.
                if (userinput == 0 && Balance != 0)
                {

                    stop = false;
                 
                }
                

                Balance += insert.aKron; // Adding amount to balance to calculate the change.
                Moneypool += insert.aKron; // Adding amount also to main wallet in case user cancel purchase for refund.
                
                go += 1;

            }


            //Creating objects products for Drinks class.
            var cola = new Drinks("Coca Cola", 13);
            var juice = new Drinks("Fun Juice", 20);
            var water = new Drinks("Aqua Fresh", 23);

            //Creating objects products for food class.
            var Banana = new Food("Banana", 5);
            var Sandwitch = new Food("Cheese Sandwitch", 55);
            var pizza = new Food("Pan pizza Pie", 65);

            //Creating objects products for snacks class.
            var Chips = new Snack("Pringels", 21);
            var Choco = new Snack("Twix", 10);
            var popc = new Snack("Caramel Popcorn", 15);



            // List to collect what user's purchase.
            var purchaseslist = new List<string>();

            //Craeting loop to purchase the products.
            int selc = 0;
            bool keep = true;
            while (selc < 15 && keep)
            {
                //Condition for checking if there is amount in the balance or not before to start the loop for buying.
                if (Balance == 0)
                {
                    Money.GetBalance(Balance);
                    
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Sorry! you can not proceed!\n");
                    Console.ResetColor();
                    Console.WriteLine("Have a nice day GoodBye!....");
                    
                    break;
                }

                if (selc == 0)
                {
                    Money.GetBalance(Balance);
                    VendingMachine.ProductsMenu();
                }

                //Calculation for change money back when the user end the purchase.
                Change = purchases - Moneypool;

                //Starting the loop for purchasing.
                int select; int.TryParse(Console.ReadLine(), out select);

                switch (select)
                {

                    case 1:
                        cola.ProductPriceInfo(cola.Name, cola.Price);
                        drink.Purchase(cola.Name);
                        string confirm = Console.ReadLine().ToUpper();


                        if (confirm == "Y" && Balance < cola.Price)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry! You don't have enough balance to proceed..");
                            Console.ResetColor();
                            Console.WriteLine("Check for another products OR insert number 10 to exit," +
                                " or 11 for cancel and refund.");
                            
                            Money.GetBalance(Balance);
                            
                        }
                        else if (confirm == "N")
                        {
                            Console.WriteLine("Continue shopping..");
                        }

                        else if (confirm == "Y" && Balance >= cola.Price)
                        {
                            purchases += cola.Price;
                            Balance -= cola.Price;
                            cola.ProdcutUserGuide(cola.Name);
                            purchaseslist.Add(cola.Name);
                            Console.WriteLine("The item moved to your basket!");
                        }
                        else
                        {
                            VendingMachine.InvalidMsg();
                        }

                        break;



                    case 2:
                        juice.ProductPriceInfo(juice.Name, juice.Price);
                        drink.Purchase(juice.Name);
                        string confirm1 = Console.ReadLine().ToUpper();
                        if (confirm1 == "Y" && Balance < juice.Price)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry! You don't have enough balance to proceed..");
                            Console.ResetColor();
                            Console.WriteLine("Check for another products OR insert number 10 to exit.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Money.GetBalance(Balance);
                            Console.ResetColor();
                        }
                        else if (confirm1 == "N")
                        {
                            Console.WriteLine("Continue shopping..");
                        }
                        else if (confirm1 == "Y" && Balance >= juice.Price)
                        {
                            purchases += juice.Price;
                            Balance -= juice.Price;
                            cola.ProdcutUserGuide(juice.Name);
                            purchaseslist.Add(juice.Name);
                            Console.WriteLine("The item moved to your basket!");
                        }
                        else
                        {
                            VendingMachine.InvalidMsg();
                        }

                        break;




                    case 3:
                        water.ProductPriceInfo(water.Name, water.Price);
                        drink.Purchase(water.Name);
                        string confirm2 = Console.ReadLine().ToUpper();
                        if (confirm2 == "Y" && Balance < water.Price)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry! You don't have enough balance to proceed..");
                            Console.ResetColor();
                            Console.WriteLine("Check for another products OR insert number 10 to exit.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Money.GetBalance(Balance);
                            Console.ResetColor();
                        }
                        else if (confirm2 == "N")
                        {
                            Console.WriteLine("Continue shopping..");
                        }
                        else if (confirm2 == "Y" && Balance >= water.Price)
                        {
                            purchases += water.Price;
                            Balance -= water.Price;
                            water.ProdcutUserGuide(water.Name);
                            purchaseslist.Add(water.Name);
                            Console.WriteLine("The item moved to your basket!");
                        }
                        else
                        {
                            VendingMachine.InvalidMsg();
                        }

                        break;

                    case 4:
                        Banana.ProductPriceInfo(Banana.Name, Banana.Price);
                        food.Purchase(Banana.Name);
                        var confirm3 = Console.ReadLine().ToUpper();

                        if (confirm3 == "Y" && Balance < Banana.Price)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry! You don't have enough balance to proceed..");
                            Console.ResetColor();
                            Console.WriteLine("Check for another products OR insert number 10 to exit.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Money.GetBalance(Balance);
                            Console.ResetColor();
                        }
                        else if (confirm3 == "N")
                        {
                            Console.WriteLine("Continue shopping..");
                        }
                        else if (confirm3 == "Y" && Balance >= Banana.Price)
                        {
                            purchases += Banana.Price;
                            Balance -= Banana.Price;
                            Sandwitch.ProdcutUserGuide(Banana.Name);
                            purchaseslist.Add(Banana.Name);
                            Console.WriteLine("The item moved to your basket!");
                        }
                        else
                        {
                            VendingMachine.InvalidMsg();
                        }



                        break;
                    case 5:
                        Sandwitch.ProductPriceInfo(Sandwitch.Name, Sandwitch.Price);
                        food.Purchase(Sandwitch.Name);
                        var confirm4 = Console.ReadLine().ToUpper();
                        if (confirm4 == "Y" && Balance < Sandwitch.Price)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry! You don't have enough balance to proceed..");
                            Console.ResetColor();
                            Console.WriteLine("Check for another products OR insert number 10 to exit.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Money.GetBalance(Balance);
                            Console.ResetColor();
                        }
                        else if (confirm4 == "N")
                        {
                            Console.WriteLine("Continue shopping..");
                        }
                        else if (confirm4 == "Y" && Balance >= Sandwitch.Price)
                        {
                            purchases += Sandwitch.Price;
                            Balance -= Sandwitch.Price;
                            Sandwitch.ProdcutUserGuide(Sandwitch.Name);
                            purchaseslist.Add(Sandwitch.Name);
                            Console.WriteLine("The item moved to your basket!");
                        }
                        else
                        {
                            VendingMachine.InvalidMsg();
                        }
                        break;

                    case 6:
                        pizza.ProductPriceInfo(pizza.Name, pizza.Price);
                        food.Purchase(pizza.Name);
                        var confirm5 = Console.ReadLine().ToUpper();
                        if (confirm5 == "Y" && Balance < pizza.Price)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry! You don't have enough balance to proceed..");
                            Console.ResetColor();
                            Console.WriteLine("Check for another products OR insert number 10 to exit.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Money.GetBalance(Balance);
                            Console.ResetColor();
                        }
                        else if (confirm5 == "N")
                        {
                            Console.WriteLine("Continue shopping..");
                        }
                        else if (confirm5 == "Y" && Balance >= pizza.Price)
                        {
                            purchases += pizza.Price;
                            Balance -= pizza.Price;
                            food.ProdcutUserGuide(pizza.Name);
                            purchaseslist.Add(pizza.Name);
                            Console.WriteLine("The item moved to your basket!");
                        }
                        else
                        {
                            VendingMachine.InvalidMsg();
                        }

                        break;


                    case 7:
                        Chips.ProductPriceInfo(Chips.Name, Chips.Price);
                        snack.Purchase(Chips.Name);
                        var confirm6 = Console.ReadLine().ToUpper();
                        if (confirm6 == "Y" && Balance < Chips.Price)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry! You don't have enough balance to proceed..");
                            Console.ResetColor();
                            Console.WriteLine("Check for another products OR insert number 10 to exit.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Money.GetBalance(Balance);
                            Console.ResetColor();
                        }
                        else if (confirm6 == "N")
                        {
                            Console.WriteLine("Continue shopping..");
                        }
                        else if (confirm6 == "Y" && Balance >= Chips.Price)
                        {
                            purchases += Chips.Price;
                            Balance -= Chips.Price;
                            Chips.ProdcutUserGuide(Chips.Name);
                            purchaseslist.Add(Chips.Name);
                            Console.WriteLine("The item moved to your basket!");
                        }
                        else
                        {
                            VendingMachine.InvalidMsg();
                        }

                        break;

                    case 8:
                        Choco.ProductPriceInfo(Choco.Name, Choco.Price);
                        snack.Purchase(Choco.Name);
                        var confirm7 = Console.ReadLine().ToUpper();
                        if (confirm7 == "Y" && Balance < Choco.Price)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry! You don't have enough balance to proceed..");
                            Console.ResetColor();
                            Console.WriteLine("Check for another products OR insert number 10 to exit.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Money.GetBalance(Balance);
                            Console.ResetColor();
                        }
                        else if (confirm7 == "N")
                        {
                            Console.WriteLine("Continue shopping..");
                        }
                        else if (confirm7 == "Y" && Balance >= Choco.Price)
                        {
                            purchases += Choco.Price;
                            Balance -= Choco.Price;
                            Chips.ProdcutUserGuide(Choco.Name);
                            purchaseslist.Add(Choco.Name);
                            Console.WriteLine("The item moved to your basket!");
                        }
                        else
                        {
                            VendingMachine.InvalidMsg();
                        }

                        break;

                    case 9:
                        popc.ProductPriceInfo(popc.Name, popc.Price);
                        snack.Purchase(popc.Name);
                        var confirm8 = Console.ReadLine().ToUpper();
                        if (confirm8 == "Y" && Balance < popc.Price)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry! You don't have enough balance to proceed..");
                            Console.ResetColor();
                            Console.WriteLine("Check for another products OR insert number 10 to exit.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Money.GetBalance(Balance);
                            Console.ResetColor();
                        }
                        else if (confirm8 == "N")
                        {
                            Console.WriteLine("Continue shopping..");
                        }
                        else if (confirm8 == "Y" && Balance >= popc.Price)
                        {
                            purchases += popc.Price;
                            Balance -= popc.Price;
                            Chips.ProdcutUserGuide(popc.Name);
                            purchaseslist.Add(popc.Name);
                            Console.WriteLine("The item moved to your basket!");
                        }
                        else
                        {
                            VendingMachine.InvalidMsg();
                        }

                        break;

                    case 10:
                        //condition to prevent printing empty purchases list in case user exit without buying any product.
                        if (purchaseslist.Count > 0)
                        {
                            Console.WriteLine("Your Purchases: ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            purchaseslist.ForEach(item => Console.WriteLine($"{item}."));
                            Console.ResetColor();
                        }
                        
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your change is : {0} kr.", Math.Abs(Change));
                        Console.ResetColor();
                        Console.WriteLine("Thanks for using bot vending machine!!.\n" +
                            "Good Bye!!!");

                        keep = false;
                        break;

                    case 11:
                        
                        Console.WriteLine("Sorry for that you are leaving..thanks for trying bot vending machine!!.\n" +
                            "Have a nice day and Good Bye!!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your refund is: {0} Kr.",Moneypool);
                        Console.ResetColor();

                        keep = false;
                        break;
                        


                    default:
                        Console.WriteLine("Invalid selection! try again or insert number 10 to exit");
                        break;
                }

              
                selc += 1;


            }



           
        }


    }
}
