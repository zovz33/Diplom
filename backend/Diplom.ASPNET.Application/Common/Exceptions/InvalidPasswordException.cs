namespace Diplom.ASPNET.Application.Common.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string name, object key) : base($"Пароль пользователя: {key} неверен.") { }
    }
}
