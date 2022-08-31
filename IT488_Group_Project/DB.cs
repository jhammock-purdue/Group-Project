using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;

namespace IT488_Group_Project
{
    public class DB
    {
        public string connectionString;
        public SqlConnection conn;
        public List<Book> books = new List<Book>();
        public List<Account> accounts = new List<Account>();
        public List<Rental> rental = new List<Rental>();
        private string searchTerm = "";

        public DB()
        {
            connectionString = "Data Source = advancesoftware.database.windows.net; Initial Catalog= BookRental; User ID = defaultSite; Password = p@ssw0rd; Connect Timeout = 60; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

        }

        public DB(string conn)
        {
            connectionString = conn;
        }

        public List<Book> getBooks(string searchTerm)
        {


            SqlDataReader reader;

            conn = new SqlConnection(connectionString);
            conn.Open();

            string bookQuery = "SELECT Author, ISBN, Genre, Title, Amount, Release FROM[Books] where author like '%" + searchTerm + "%' or isbn like '%" + searchTerm + "%'or Genre like '%" + searchTerm + "%'or Title like '%" + searchTerm + "%'or Release like '%" + searchTerm + "%'";
            SqlCommand cmd = new SqlCommand(bookQuery, conn);

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string author = (string)reader.GetValue(0);
                int isbn = (int)reader.GetValue(1);
                string genre = (string)reader.GetValue(2);
                string title = (string)reader.GetValue(3);
                int amount = (int)reader.GetValue(4);
                int release = (int)reader.GetValue(5);

                books.Add(new Book(title, genre, author, isbn, release, amount));
            }
            conn.Close();

            return books;
        }

        public List<Book> getMyBooks(string searchTerm)
        {


            SqlDataReader reader;

            conn = new SqlConnection(connectionString);
            conn.Open();

            string bookQuery = "SELECT Author, ISBN, Genre, Title, Amount, Release FROM[Books] where account_number = '" + searchTerm + "'";
            SqlCommand cmd = new SqlCommand(bookQuery, conn);

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string author = (string)reader.GetValue(0);
                int isbn = (int)reader.GetValue(1);
                string genre = (string)reader.GetValue(2);
                string title = (string)reader.GetValue(3);
                int amount = (int)reader.GetValue(4);
                int release = (int)reader.GetValue(5);

                books.Add(new Book(title, genre, author, isbn, release, amount));
            }
            conn.Close();

            return books;
        }

        public List<Book> getAvailableBooks()
        {


            SqlDataReader reader;

            conn = new SqlConnection(connectionString);
            conn.Open();

            string bookQuery = "SELECT Author, ISBN, Genre, Title, Amount, Release FROM[Books] where amount > 0 order by Title";
            SqlCommand cmd = new SqlCommand(bookQuery, conn);

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string author = (string)reader.GetValue(0);
                int isbn = (int)reader.GetValue(1);
                string genre = (string)reader.GetValue(2);
                string title = (string)reader.GetValue(3);
                int amount = (int)reader.GetValue(4);
                int release = (int)reader.GetValue(5);

                books.Add(new Book(title, genre, author, isbn, release, amount));
            }
            conn.Close();

            return books;
        }


        public List<Book> getTopBooks()
        {


            SqlDataReader reader;

            conn = new SqlConnection(connectionString);
            conn.Open();

            string bookQuery = "SELECT Top 3 Author, ISBN, Genre, Title, Amount, Release FROM[Books] order by top_sellers desc";
            SqlCommand cmd = new SqlCommand(bookQuery, conn);

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string author = (string)reader.GetValue(0);
                int isbn = (int)reader.GetValue(1);
                string genre = (string)reader.GetValue(2);
                string title = (string)reader.GetValue(3);
                int amount = (int)reader.GetValue(4);
                int release = (int)reader.GetValue(5);

                books.Add(new Book(title, genre, author, isbn, release, amount));
            }
            conn.Close();

            return books;
        }

        public List<Account> getAccounts()
        {
            

            SqlDataReader reader;

            conn = new SqlConnection(connectionString);
            conn.Open();

            string accountQuery = "SELECT firstname, lastname, account_number FROM[dbo].[Accounts]";
            SqlCommand cmd = new SqlCommand(accountQuery, conn);

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string first = (string)reader.GetValue(0);
                string last = (string)reader.GetValue(1);
                int account = (int)reader.GetValue(2);

                accounts.Add(new Account(first, last, account));

            }
            conn.Close();

            return accounts;
        }

 
        public List<Rental> GetAssignedRentals(int account_number)
        {
            SqlDataReader reader;

            conn = new SqlConnection(connectionString);
            conn.Open();

            string rentalQuery = "SELECT ISBN, Check_Out FROM [dbo].[Borrow] where [check_in] is null and account_number = " + account_number;
            SqlCommand cmd = new SqlCommand(rentalQuery, conn);

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int isbn = (int)reader.GetValue(0);
                DateTime date = (DateTime)reader.GetValue(1);


                rental.Add(new Rental(isbn, date));

            }
            conn.Close();

            return rental;

        }
        public string AssignRental(int ISBN, int account_number, string username)
        {
            string assignQuery;
            string returnString;

            if (username == "LibraryAdmin")
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                assignQuery = "Insert into [dbo].[Borrow] (Check_Out, ISBN, Account_number) Values ( @date , @ISBN, @account_number)";

                SqlCommand cmd = new SqlCommand(assignQuery, conn);
                cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(DateTime.Now));
                cmd.Parameters.AddWithValue("@ISBN", ISBN);
                cmd.Parameters.AddWithValue("@account_number", account_number);

                cmd.ExecuteReader();

                conn.Close();

                return returnString = "Book was successfully assigned.";
            }
            else
            {
                return returnString = "You do not have the necessary privileges to assign books. ";
            }

        }

        public string ReturnRental(int ISBN, int account_number, string username)
        {
            string assignQuery;
            string returnString;

            if (username == "LibraryAdmin")
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                assignQuery = "Update Borrow Set check_in = @date where ISBN = @ISBN and account_number = @account_number ";

                SqlCommand cmd = new SqlCommand(assignQuery, conn);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@ISBN", ISBN);
                cmd.Parameters.AddWithValue("@account_number", account_number);

                cmd.ExecuteReader();

                conn.Close();

                return returnString = "Book was successfully returned.";
            }
            else
            {
                return returnString = "You do not have the necessary privileges to return books. ";
            }

        }

    }

    


}