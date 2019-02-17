using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticingEvents
{
    public delegate void EventDataClassHandeler(Object Sender, EventDataClass args);
    public class CustomersAcount
    {
        public event EventDataClassHandeler TransactionSuccessful;

        protected virtual void OnTransactionSuccessful(EventDataClass eventDataClass)
        {
            if (TransactionSuccessful != null)
            {
                TransactionSuccessful(this, eventDataClass);
            }
        }
        public int Balance;
        
        public CustomersAcount (int balance)
        {
            this.Balance = balance;
        }

        public void DebitingMethode( int amountToWithdraw)
        {
            Balance = Balance - amountToWithdraw;
            EventDataClass eventDataClass = new EventDataClass("Withdrawn", amountToWithdraw);
            OnTransactionSuccessful(eventDataClass);
        }

        public void CreditingMethod(int amountToDeposit)
        {
            Balance = Balance + amountToDeposit;
            EventDataClass eventDataClass = new EventDataClass("Deposited", amountToDeposit);
            OnTransactionSuccessful(eventDataClass);

        }



    }

    class Program
    {

        private static void NotificationSender(Object sender, EventDataClass @event)
        {
            if (@event.transactiontype == "Withdrawn")
            {
                Console.WriteLine("You have successfully {0} {1} Pounds from your account", @event.transactiontype, @event.transactionamout);
            }
            else
            {

                Console.WriteLine("You have successfully {0} {1} Pounds to your account", @event.transactiontype, @event.transactionamout);
            }

        }
        static void Main(string[] args)
        {
            // Now i want the user to enter is initial acount balance and then the amount they woud like to deposit or withdraw.
            int Userbalance;
            string UserAnswer;
            int UserAmountToWithdraw;
            int UserAmountToDeposit;
            string UserPressingOk;
            Console.WriteLine("What is your initial bank balance?");
          
        A: bool IsInterger = int.TryParse(Console.ReadLine(), out  Userbalance); // because the user may enter a letter// call Balance property
            CustomersAcount TheCustomer = new CustomersAcount(Userbalance);
            if (IsInterger)
            {

                
                
                    do
                    {
                        Console.WriteLine("Do you want to withdraw or deposit? \nPress \"w\" to  Withdraw, Or \"D\" to deposit");
                        UserAnswer = Console.ReadLine().ToUpper();



                    } while (UserAnswer != "W" && UserAnswer != "D");
                if (UserAnswer == "W")
                {
                  B:  Console.WriteLine("How much would you like to withdraw?");

                    bool IsuserAmountToWithdrawAnIntenger = int.TryParse(Console.ReadLine(), out UserAmountToWithdraw); // Could throw an error, will solve that later.
                    if (IsuserAmountToWithdrawAnIntenger)
                    {
                        do
                        {
                            Console.WriteLine("Now enter \"Ok\" to proced"); // could throw an error SOLVED
                            UserPressingOk = Console.ReadLine().ToUpper();




                        } while (UserPressingOk != "OK");
                        if (UserPressingOk == "OK")
                        {
                            TheCustomer.TransactionSuccessful += new EventDataClassHandeler(NotificationSender);
                            TheCustomer.DebitingMethode(UserAmountToWithdraw);
                            Console.WriteLine("Your current balance is {0}", TheCustomer.Balance);

                            Console.Read();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invaalid input, the amount must be written in Number");
                        goto B;
                        
                    }
                }
                if (UserAnswer=="D")
                {
                C: Console.WriteLine("How much would you like to Deposit?");

                    bool IsuserAmountToDepositIntenger = int.TryParse(Console.ReadLine(), out UserAmountToDeposit); // Could throw an error, will solve that later.
                    if (IsuserAmountToDepositIntenger)
                    {
                        do
                        {
                            Console.WriteLine("Now enter \"Ok\" to proced"); // could throw an error SOLVED
                            UserPressingOk = Console.ReadLine().ToUpper();




                        } while (UserPressingOk != "OK");
                        if (UserPressingOk == "OK")
                        {
                            TheCustomer.TransactionSuccessful += new EventDataClassHandeler(NotificationSender);
                            TheCustomer.CreditingMethod(UserAmountToDeposit);
                            Console.WriteLine("Your current balance is {0}", TheCustomer.Balance);

                            Console.Read();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid input, the amount must be written in Number");
                        goto C;

                    }
                }



            }
            else
            {
                Console.WriteLine("Your input is invalid, please Enter a number");

                goto A;
            }
           
        }
    }
}












using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticingEvents
{
   public class EventDataClass
    {
        private string TransactionType;
        private int TrasactionAmount;
        public EventDataClass(string TransactType, int TransactAmt)
        {
            this.TransactionType = TransactType;
            this.TrasactionAmount = TransactAmt;
        }
        public string transactiontype
        {
            get
            {
                return TransactionType;
            }
        }

        public int transactionamout
        {
            get
            {
                return TrasactionAmount;
            }
        }
    }
}







