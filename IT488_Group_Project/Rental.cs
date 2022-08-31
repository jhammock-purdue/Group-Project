using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT488_Group_Project
{
    public class Rental
    {
        private int isbn;
        private DateTime date;

    public Rental(int isbn, DateTime date)
    {
        this.isbn = isbn;
        this.date = date;
    }

    public int ISBN
        {
        get { return isbn; }
        set { isbn = value; }
    }

    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

}
}