﻿namespace RecipesShare.BLL.Security
{
    public class JwtOptions
    {
        public string Issuer { get; init; }
        public string Audience { get; init; }
        public int ExpirationSeconds { get; init; }
        public string SigningKey { get; init; }
    }
}
