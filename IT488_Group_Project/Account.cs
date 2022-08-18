using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT488_Group_Project
{
    public class Account
    {
        private string firstname;
        private string lastname;
        private int account_number;

        public Account(string firstname, string lastname, int account_number)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.account_number = account_number;
        }

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public int AccountNumber
        {
            get { return account_number; }
            set { account_number = value; }
        }
       
    }
}