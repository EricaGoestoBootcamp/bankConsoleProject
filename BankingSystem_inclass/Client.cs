using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankingSystem_inclass
{
    class Client
    {

        //Fields
        string name = "Scrooge McDuck";
        string dateOfBirth = "Jan 1, 1950";
        string clientSince = "March 2, 1975";
        string address = "123 GoLightly Lane, Wherever, CA, 99121";

        //Properties

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string DateOfBirth
        {
            get { return this.dateOfBirth; }
            set { this.dateOfBirth = value; }
        }
        public string ClientSince
        {
            get { return this.clientSince; }
            set { this.clientSince = value; }
        }
        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        //methods
        public void ViewClientInfo()
        {
            Console.WriteLine("Information for client {0}, born on {1}", this.name, this.dateOfBirth);
            Console.WriteLine("{0} has been a client since: {1}.",this.name,this.clientSince);
            Console.WriteLine("The address on file for {0} is: \r\n{1}.", this.name, this.address);
        }

        //Constructors 
        public Client()
        {
            //default constructor
        }

        public Client(string name)
        {
            this.Name = name;
        }

        public Client(string name, string dateOfBirth)
        {
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
        }

        public Client(string name, string dateOfBirth, string clientSince)
            { 
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
            this.ClientSince = clientSince;
             }
        public Client (string name, string dateOfBirth, string clientSince, string address)
        {
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
            this.ClientSince = clientSince;
            this.Address = address;
        }
    }
}
