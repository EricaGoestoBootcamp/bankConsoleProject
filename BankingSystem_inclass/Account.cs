using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankingSystem_inclass
{
    class Account
    {

        //fields - we may not use all, populating just in case
        private string name = "Scrooge McDuck";
        private double accountNumber;
        private decimal balance = 500.21M;
        private decimal newBalance;
        private decimal lastDeposit;
        private decimal lastWithdrawal;


        //setting up Random as a field like we did in crystalball
        private Random random = new Random();


        //public decimal summedBalance = transactionList.Sum();


        //properties - we may not use all, populating just in case
            
        public string Name
        { get { return this.name; } set { this.name = value; } }

        public double AccountNumber
        {
            get { return this.accountNumber; }
            set { this.accountNumber =  getAccount() ; }
        }
        public decimal Balance
        {
            get { return balance; }
            set { this.balance = value; }
        }
        public decimal LastDeposit
        {
            get { return this.lastDeposit; }
            set { this.lastDeposit = value; }
        }

        public decimal LastWithdrawal
        {
            get { return this.lastWithdrawal; }
            set { this.lastWithdrawal = value; }
        }

        public decimal NewBalance
        { get
            { return this.newBalance; }
            set
            { this.newBalance = value; }
        }

        //METHODS

        public void Withdraw()
        {
            //ingredients: Balance, customer-inputted amount to withdraw
            //output: "success, new balance", streamwriter output.

            Console.WriteLine(Program.Banner());
            //decimal summedBalance = transactionList.Sum();
            Console.WriteLine("Your current balance is {0}. Enter the amount to withdraw.",this.Balance);
            decimal userInput = decimal.Parse(Console.ReadLine());
            this.LastWithdrawal = userInput;
            decimal tempBalance = this.Balance;
            this.NewBalance = this.Balance - userInput;
            if (this.NewBalance < 0)
            {
                this.Balance = tempBalance;
                Console.WriteLine("Insufficient funds. Transaction cancelled.");
                Console.WriteLine("Current balance is {0}.", this.Balance);
            }
            else
            {
                this.Balance = this.NewBalance;
                Console.WriteLine("Transaction successful, current balance is {0}", this.Balance);
            }

            //redo or exit
            Console.WriteLine("Another transaction? Enter Y or N");
            char menu = char.Parse(Console.ReadLine().ToUpper());
            if (menu == 'Y')
            { Program.MainMenu(); }
            else return;
        }

        public void Deposit()
        {
            //same logic as withdrawal minus the if statement
            //ingredients: Balance, customer-inputted amount to deposit
            //output: "success, new balance", streamwriter output.

            Console.WriteLine(Program.Banner());
            //decimal summedBalance = transactionList.Sum();
            //Console.WriteLine("Your current balance is {0}. Enter the amount to deposit.", summedBalance);
            Console.WriteLine("Your current balance is {0}. Enter the amount to deposit.", this.Balance);
            decimal userInput = decimal.Parse(Console.ReadLine());
            this.LastDeposit = userInput;
            // transactionList.Add(userInput);
            //decimal tempBalance = Balance;
            this.NewBalance = this.Balance + userInput;
            this.Balance = this.NewBalance;
            
            //testing transactionList
            //Console.WriteLine("trasnaction list");
            //foreach (decimal i in transactionList)
            //{
            //    Console.WriteLine(i);
            //}


            // summedBalance = transactionList.Sum();
            Console.WriteLine("Transaction successful, current balance is {0}", this.Balance);

            //Date and Time

            //DateTime thisDay = DateTime.Now;
            //string todaysDate = thisDay.ToString("F");
            //Console.WriteLine(todaysDate);

            //redo or exit
            Console.WriteLine("Another transaction? Enter Y or N");
            char menu = char.Parse(Console.ReadLine().ToUpper());
            if (menu == 'Y')
            { Program.MainMenu(); }
            else return;

        }

        //this method assigns a random account number
        //6 digit random number b/c 10 digit breaks Random
        //this method is set to private. the get method below is accessible.
        private double assignAccount()
        {
            double accountNum = random.Next(100000, 999999);
            return accountNum;
        }

        protected double getAccount()
        {
            double newAccountNumber = assignAccount();
            return newAccountNumber;
        }



        //VIEW ACCOUNT INFO method

        public void ViewAccount()
        {
            //get an account number from the getAccount method.
            //this will return a new account every time view account is run
            //so it's insane, but it does what the instructions say.
            this.AccountNumber = getAccount();
            // Console.WriteLine("Customer Account Information:");
            Console.WriteLine("\nCustomer {0}\n", this.Name);
            DateAndTime();
            Console.WriteLine("===========================");
            Console.WriteLine("ACCOUNT #: {1}", this.Name, AccountNumber);
            Console.WriteLine("CURRENT BALANCE: ${0}", balance);
            Console.WriteLine("===========================\n");
            Console.WriteLine("Another transaction? Enter Y or N");
            char menu = char.Parse(Console.ReadLine().ToUpper());
            if (menu == 'Y')
            { Program.MainMenu(); }
            else return;

        }

        //DATE AND TIME METHOD to stick into other methods
        public void DateAndTime()
        {
            DateTime thisDay = DateTime.Now;
            string todaysDate = thisDay.ToString("F");
            Console.WriteLine(todaysDate);
        }
        
        //private decimal Transaction(decimal userInput)
        //{
        //    decimal userAmount = userInput;
        //    return userAmount;
        //}

        //constructors

        public Account()
        {
        }

        public Account(decimal balance)
        {
            this.Balance = balance;
        }

        public Account(decimal balance, double accountNumber)
        {
            this.Balance = balance;
            this.AccountNumber = accountNumber;
        }

    }
}
