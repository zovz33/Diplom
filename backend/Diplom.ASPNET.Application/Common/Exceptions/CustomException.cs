namespace Diplom.ASPNET.Application.Common.Exceptions;

public class CustomException : Exception
{
    public CustomException(string message) : base(message)
    {
    }
}