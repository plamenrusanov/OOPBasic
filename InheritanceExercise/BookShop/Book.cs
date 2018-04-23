using System;
using System.Collections.Generic;
using System.Text;

public class Book
{
    protected string title;
    protected string author;
    protected decimal price;

    public Book(string author, string title, decimal price)
    {
        Author = author;
        Title = title;
        Price = price;
    }

    private bool IsValidAuthor(string author)
    {
        string[] names = author.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (names.Length > 1 && Char.IsDigit(names[1][0]))
        {
            return false;
        }
        return true;
    }

    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }

    public string Author
    {
        get { return author; }
        set
        {
            if (!IsValidAuthor(value))
            {
                throw new ArgumentException("Author not valid!");
            }
            author = value;
        }
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }

    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:f2}");

        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }

}


