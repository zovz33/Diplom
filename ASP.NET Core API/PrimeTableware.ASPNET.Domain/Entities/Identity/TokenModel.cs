﻿namespace PrimeTableware.ASPNET.Domain.Entities.Identity
{
    public class TokenModel
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}