using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Common.JWT
{
    /// <summary>
    /// Генератор токенов
    /// </summary>
    public static class GeneratorJWTTokens
    {
        private const string PREFIX = "Bearer ";

        /// <summary>
        /// Генерация токена доступа
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Возвращает токен доступа</returns>
        public static TokenModel GenerateJWTToken(int accountId, int lifetimeInMinutes)
        {
            var securityKey = AuthOptions.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, accountId.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(lifetimeInMinutes),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            var result = new TokenModel
            {
                Token = PREFIX + tokenString,
                ExpirationTime = lifetimeInMinutes
            };

            return result;
        }
    }
}
