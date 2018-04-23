using System;
using System.Collections.Generic;
using System.Text;

public class GoldenEditionBook:Book
{

    public override  decimal Price
    {
        get { return base.price * 1.3m; }
        set { price = value; }
    }


    public GoldenEditionBook(string author, string title, decimal price):base(author, title, price)
    {
       
    }
}


