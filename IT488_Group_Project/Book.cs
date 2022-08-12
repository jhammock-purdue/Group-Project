using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT488_Group_Project
{
    public class Book
    {
        private string title;
        private string genre;
        private string author;
        private int isbn;
        private int releaseDate;
        private int amount;

        public Book(string title, string genre, string author, int isbn, int releaseDate, int amount)
        {
            this.title = title;
            this.genre = genre;
            this.author = author;
            this.isbn = isbn;
            this.releaseDate = releaseDate;
            this.amount = amount;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public int Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public int ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}