using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace IT488_Group_Project
{
    public class DB
    {
        public string connectionString;
        public SqlConnection conn;
        public List<Book> books = new List<Book>();
        public List<Account> accounts = new List<Account>();
        private string searchTerm = "";

        public DB()
        {
            connectionString = "Data Source = advancesoftware.database.windows.net; Initial Catalog= BookRental; User ID = Group1; Password = IT488IT488!!; Connect Timeout = 60; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

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
            reader.Close();

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
            reader.Close();

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
            reader.Close();

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
            reader.Close();

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
            reader.Close();

            return accounts;
        }





    }




}