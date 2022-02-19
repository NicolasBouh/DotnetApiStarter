namespace DotnetApiStarter.Application.Core.Exceptions;

public class BadRequestException : Exception
{
    private static string _defaultMessage = "Bad request";
    
    public BadRequestException() : base(_defaultMessage)
    {
    }

    public BadRequestException(string message)
        : base(message)
    {
    }

    public BadRequestException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public BadRequestException(string name, object key)
        : base($"Bad request for parameter \"{name}\"cqith value ({key}).")
    {
    }
}