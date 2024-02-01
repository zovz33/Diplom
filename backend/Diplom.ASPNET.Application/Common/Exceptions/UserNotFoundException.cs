namespace Diplom.ASPNET.Application.Common.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(object key) : base($"Пользователь {key} не найден.")
    {
    }
}