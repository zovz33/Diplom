using System;

namespace PrimeTableware.ASPNET.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key) : base($"Сущность \"{name}\" ({key}) не найдена.") { }
    }
}
