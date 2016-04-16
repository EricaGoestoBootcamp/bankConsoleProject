using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankingSystem_inclass
{
    //known issues: Balance resets between each transaction
    //streamwriter append appears to be writing newer transactions first O.o
    class Program
    {
        static void Main(string[] args)
        {
        
            
            //transaction list - the road not taken
            //List<decimal> transactionList = new List<decimal>();
            //decimal summedBalance = transactionList.Sum();

            //BANNER, establish strinwriter file
            Console.WriteLine(Banner());
            string text = "AccountSummary.txt";
            StreamWriter write = new StreamWriter(@"AccountSummary.txt");

            using (write)
            {
                write.WriteLine(Banner());
            }

            //Main menu method
            MainMenu();
            
        }

        static public void MainMenu()
        {
            DateTime thisDay = DateTime.Now;
            string todaysDate = thisDay.ToString("F");
            string sbDone;

            //MAIN MENU
            Console.WriteLine("Please pick a service:");
            Console.WriteLine("");
            Console.WriteLine("1 | View Victim -- er, CLIENT Information");
            Console.WriteLine("2 | View Account Balance");
            Console.WriteLine("3 | Deposit Funds ");
            Console.WriteLine("4 | Withdraw Funds");
            Console.WriteLine("5 | Exit");
            Console.WriteLine("");
            Console.WriteLine(" *  *  *  *  *  *  *  *  *  *  *");
            int menuItem = int.Parse(Console.ReadLine());



            switch (menuItem)
            {
                case 1:
                    Console.Clear();
                    Banner();
                    Console.WriteLine("VIEW CLIENT INFORMATION");
                    Client clientinfo = new Client();
                    clientinfo.ViewClientInfo();
                    break;
                case 2:
                    Console.Clear();
                    Banner();
                    Console.WriteLine("VIEW ACCOUNT NUMBER AND BALANCE");
                    Account vbalance = new Account();
                    vbalance.ViewAccount();
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("DEPOSIT FUNDS");
                    Account transDeposit = new Account();
                    transDeposit.Deposit();
                    //stringbuilder, then dumping result to streamwriter
                    StringBuilder sb = new StringBuilder();
                    sb.Append(todaysDate);
                    sb.Append("\t+\t");
                    sb.Append(transDeposit.LastDeposit + "\t");
                    sb.Append(transDeposit.NewBalance + "\r\n");
                    sbDone = sb.ToString();

                    using (StreamWriter sw = File.AppendText(@"AccountSummary.txt"))
                    {
                        sw.WriteLine(sbDone);
                    }

                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("WITHDRAW FUNDS");
                    Account transaction = new Account();
                    transaction.Withdraw();
                    Console.WriteLine("LastWithdrawal is " + transaction.LastWithdrawal);

                    StringBuilder sbw = new StringBuilder();
                    sbw.Append(todaysDate);
                    sbw.Append("\t-\t");
                    sbw.Append(transaction.LastWithdrawal + "\t");
                    sbw.Append(transaction.NewBalance + "\r\n");
                    sbDone = sbw.ToString();

                    using (StreamWriter sw = File.AppendText(@"AccountSummary.txt"))
                    {
                        sw.WriteLine(sbDone);
                    }


                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("THANK YOU, COME AGAIN.");
                    break;

                default:
                    Console.WriteLine("Do not speak crazy nonsense. Try again.");
                    MainMenu();
                    break;
            }
        }
        static public string Banner()
        {

            string[] head = new string[] {
                                            "-==-==-==-==-==-==-==--==-==-==-==-==-==-==-",
                                            "|                                          |",
                                            "|        Cynthia and Erica's               |",
                                            "|  Get to the Back of the Line Bank        |",
                                            "|                                          |",
                                            "-==-==-==-==-==-==-==--==-==-==-==-==-==-==-",
                                            
                                            };
            StringBuilder sb = new StringBuilder();
            foreach (string value in head)
            {
                sb.Append(value);
                sb.Append("\r\n");
            }
            string headDone = sb.ToString();
            return headDone;

        }

        //STREAMWRITER METHOD
        //public static void Writer()
        //{
        //    string text = "AccountSummary.txt";
        //    StreamWriter write = new StreamWriter(text);

        //    using (write)
        //    {
        //        write.WriteLine(Banner());
        //       // write.WriteLine();
        //    }
        //}
    }
}

