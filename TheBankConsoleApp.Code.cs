using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegateSchool
   {
    public delegate void TransactionHandler(Object Sender, TransactionEventArgs args);
    
    public class UserAccaount
    {
        public event TransactionHandler TransactionMade;

       public int AccountBalance;
        public UserAccaount(int acountbal)
        {
            this.AccountBalance = acountbal;
        }
        public void Debiting (int deditamount)
        {
            if(deditamount < AccountBalance)
            {
                AccountBalance = AccountBalance - deditamount;
                TransactionEventArgs transactionEventArgs = new TransactionEventArgs("Debited", deditamount);
                OnTransactionMade(transactionEventArgs);
            }
        }

        public void Crediting(int creditamount)
        {
           
            AccountBalance = AccountBalance + creditamount;
            TransactionEventArgs transactionEventArgs = new TransactionEventArgs("credited", creditamount);
            OnTransactionMade(transactionEventArgs);
        }

        protected virtual void OnTransactionMade (TransactionEventArgs transactionEventArgs)
        {
            if(TransactionMade != null)
            {
                TransactionMade(this, transactionEventArgs);
            }
        }
    }

    class Program
    {

        private static void Notification(Object Sender, TransactionEventArgs args)
        {
            Console.WriteLine("Your account was {0} for {1} Pounds", args._TypeOfTransaction, args._AmounToTransact);
        }
        static void Main(string[] args)
        {

            UserAccaount Sam = new UserAccaount(50000);
            
            Sam.TransactionMade += new TransactionHandler(Notification);
            Sam.Crediting(50000);
            Console.WriteLine("Your current balance is {0} Pounds",  Sam.AccountBalance);
            Console.Read();

        }

    }
}






// the cs file created differently

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegateSchool
{
    public class TransactionEventArgs: EventArgs
    {
        private string TypeOfTransaction;
        private int AmountTotransact;

        public TransactionEventArgs(string Type, int Amt)
        {
            this.AmountTotransact = Amt;
            this.TypeOfTransaction = Type;

        }
        public string _TypeOfTransaction

        {
            get
            {
                return TypeOfTransaction;
            }
        }
        public int _AmounToTransact

        {
            get
            {
                return AmountTotransact;
            }
        }
       

    }
}
