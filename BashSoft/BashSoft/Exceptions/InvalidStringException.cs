using System;
using System.Collections.Generic;
using System.Text;

public class InvalidStringException : Exception
{
    private const string InvalidString = "NullOrEmptyValue";

    public InvalidStringException() : base(InvalidString)
    {
    }

    public InvalidStringException(string message) : base(message)
    {
    }
}
