using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store
{
    class Program
    {
        static void Main(string[] args)
        {
            



            string ITEM_NAME, account_String = "", END = "";
            int itemName_MaxLength = 8, ITEM_NUMBER = 0, ACCOUNT_NUMBER, ACCOUNT_LENGTH = 4, FIRST_THREE, LAST_NUMBER, CHECK_NUMBER = 7, remainder, customer = 1;
            double ITEM_PRICE, TOTAL_PRICE = 0, DISCOUNT = 0, DISCOUNT_PERCENT = 0, PRICE_AFTER_DISCOUNT = 0;
            bool PRICE_CHECK, ACCOUNT_CHECK, END_OF_ITEMS = true, NO_CREDIT_CARD = true, PAYMENT_ACCEPTED = true, SYSTEM_GO = true;

            WriteLine("Hello, welcome to the system. Please proceed or enter END to end the system.\n");
            do
            {
                WriteLine("Customer {0}\n", customer); //Keeps track on number of customers
                do
                {
                    do
                    {
                        //Get cashier to input item's name
                        WriteLine("Please enter the item's name: ");
                        ITEM_NAME = ReadLine().ToLower();

                        //Quits the items while loop
                        if (ITEM_NAME == "end")
                        {
                            break;
                        }

                        //Checks if item name is less than 8 letters. If >=8, cashier asked to input again.
                        while (ITEM_NAME.Length >= itemName_MaxLength)
                        {
                            WriteLine("Error: The name cannot be more than or equal to 8 letters. Please enter the item's name again: ");
                            ITEM_NAME = ReadLine().ToLower();
                        }

                        //Get cashier to input item's price.
                        WriteLine("Please enter the item's price: ");
                        PRICE_CHECK = double.TryParse(ReadLine(), out ITEM_PRICE);

                        //Checks to make sure price input are numbers AND >=0
                        while (PRICE_CHECK == false || ITEM_PRICE < 0)
                        {
                            WriteLine("Error: The price must be more than $0. Please enter the price again: ");
                            PRICE_CHECK = double.TryParse(ReadLine(), out ITEM_PRICE);
                        }

                        ITEM_NUMBER++; //keep track of number of items
                        TOTAL_PRICE += ITEM_PRICE;  //keep track of total price


                        //Check if cashier still wants to continue
                        WriteLine("Do you wish add another item? Y or N.");
                        END = ReadLine().ToLower(); //changes string input to lower case

                        //If cashier enters any letters other than y or n, they will need to try again
                        while (!(END == "y" || END == "n"))
                        {
                            WriteLine("\nError: Only Y or N accepted. Please try again: ");
                            END = ReadLine().ToLower();
                        }

                        if (END == "y")
                        {
                            WriteLine("");
                        }
                        else
                        {
                            END_OF_ITEMS = false; //ends the items loop.
                            WriteLine("");
                        }

                    } while (END_OF_ITEMS);


                    //Quits credit card while loop
                    if (ITEM_NAME == "end")
                    {
                        break;
                    }

                    //Invoice
                    WriteLine("");
                    WriteLine("Customer's Invoice");
                    WriteLine("-------------------------------");
                    WriteLine("Number of items purchased: {0}", ITEM_NUMBER);
                    WriteLine("Total cost of items: {0:c}", TOTAL_PRICE);

                    //Discounts
                    if (TOTAL_PRICE < 100)  //no discounts given 
                    {
                        PRICE_AFTER_DISCOUNT = TOTAL_PRICE;
                    }
                    else
                        if (TOTAL_PRICE >= 100 && TOTAL_PRICE <= 300) //gives 1.5% discount
                    {
                        DISCOUNT = TOTAL_PRICE * 0.015;
                        DISCOUNT_PERCENT = 1.5;
                        PRICE_AFTER_DISCOUNT = TOTAL_PRICE - DISCOUNT;
                        WriteLine("You've earned a {0}% discount on your purchase!", DISCOUNT_PERCENT);
                        WriteLine("Discount: {0:c}", DISCOUNT);
                        WriteLine("Total cost of items after discount: {0:c}", PRICE_AFTER_DISCOUNT);
                    }
                    else    //gives 2.5% discount
                    {
                        DISCOUNT = TOTAL_PRICE * 0.025;
                        DISCOUNT_PERCENT = 2.5;
                        PRICE_AFTER_DISCOUNT = TOTAL_PRICE - DISCOUNT;
                        WriteLine("You've earned a {0}% discount on your purchase!", DISCOUNT_PERCENT);
                        WriteLine("Discount: {0:c}", DISCOUNT);
                        WriteLine("Total cost of items after discount: {0:c}", PRICE_AFTER_DISCOUNT);
                    }

                    WriteLine("\n\nOnly credit cards accepted for payment. \nPress Y to proceed to payment, press N to add more items or type END to quit.");
                    END = ReadLine().ToLower(); //changes string input to lower case

                    //If cashier enters any letters other than y, n or end, they will need to try again
                    while (!(END == "y" || END == "n" || END == "end"))
                    {
                        WriteLine("\nError: Only Y, N or END accepted. Please try again: ");
                        END = ReadLine().ToLower();
                    }

                    if (END == "y") //ends credit card loop and proceeds to payment
                    {
                        NO_CREDIT_CARD = false;
                        WriteLine("");
                    }
                    else
                        if (END == "n") //Let's cashier go back to add more items 
                    {
                        WriteLine("\n");
                    }
                    else
                    {
                        break;  //ends credit card loop
                    }

                } while (NO_CREDIT_CARD);


                do
                {
                    //Quits payment while loop
                    if (ITEM_NAME == "end")
                    {
                        break;
                    }
                    else
                        if (END == "end")
                    {
                        break;
                    }

                    //Get customer to enter credit card number
                    WriteLine("\nPlease enter your four digit card number: ");
                    account_String = ReadLine();
                    ACCOUNT_CHECK = int.TryParse(account_String, out ACCOUNT_NUMBER);

                    //if customer enters end, payment loop ends
                    if (account_String.ToLower() == "end")
                        break;

                    //Checks that customer enters 4 digits, and enters numbers only
                    while (account_String.Length != ACCOUNT_LENGTH || ACCOUNT_CHECK != true)
                    {
                        WriteLine("Error: Account number must be 4 digits. Please enter number again: ");
                        account_String = ReadLine();
                        ACCOUNT_CHECK = int.TryParse(account_String, out ACCOUNT_NUMBER);
                    }

                    //Validating credit card number
                    FIRST_THREE = ACCOUNT_NUMBER / 10;
                    LAST_NUMBER = ACCOUNT_NUMBER % 10;
                    remainder = FIRST_THREE % CHECK_NUMBER;

                    if (LAST_NUMBER == remainder)
                    {
                        PAYMENT_ACCEPTED = false;
                    }
                    else
                    {
                        WriteLine("Error: Account number invalid. Please try again or type END to quit the system.");
                    }


                } while (PAYMENT_ACCEPTED);

                //Checks for specific input that breaks all loops to end system
                if (ITEM_NAME == "end")
                {
                    break;
                }
                else
                     if (END == "end")
                {
                    break;
                }
                else
                    if (account_String.ToLower() == "end")
                {
                    break;
                }

                //Payment accepted message
                WriteLine("\nYour payment has been accepted.");
                WriteLine("");
                WriteLine("Customer's Invoice");
                WriteLine("-------------------------------");
                WriteLine("Total amount paid: {0:c}", PRICE_AFTER_DISCOUNT);
                WriteLine("Amount owed: $0.00");

                //Message to prompt user to continue or quit
                WriteLine("\nThank you for your payment. Press Y to enter the next customer's items, or type END to quit the system.");
                END = ReadLine().ToLower(); //changes string input to lower case

                //If cashier enters any letters other than y or end, they will need to try again
                while (!(END == "y" || END == "end"))
                {
                    WriteLine("\nError: Only Y, N or END accepted. Please try again: ");
                    END = ReadLine().ToLower();
                }

                if (END == "y") //system restarts from the top
                {
                    ITEM_NUMBER = 0;
                    TOTAL_PRICE = 0;
                    PRICE_AFTER_DISCOUNT = 0;
                    WriteLine("\n");
                    END_OF_ITEMS = true;
                    NO_CREDIT_CARD = true;
                    PAYMENT_ACCEPTED = true;
                    ++customer;

                }
                else //ends systems loop and get out of all loops
                {
                    SYSTEM_GO = false;
                }



            } while (SYSTEM_GO);

            WriteLine("\n\nThank you for using this system. We hope to see you again!");



            Console.Read();



        }





    }
}
