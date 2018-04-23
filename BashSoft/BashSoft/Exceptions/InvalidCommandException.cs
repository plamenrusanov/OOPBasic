using System;



internal class InvalidCommandException : Exception
{
    public InvalidCommandException()
    {
    }

    public InvalidCommandException(string message) : base($"The command '{message}' is invalid")
    {
    }

    public InvalidCommandException(string message, Exception innerException) : base(message, innerException)
    {
    }
}