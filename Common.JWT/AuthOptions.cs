using Common.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Common.JWT
{
    /// <summary>
    /// Опции аутентификации
    /// </summary>
    public static class AuthOptions
    {
        /// <summary>
        /// Издатель токена
        /// </summary>
        public static readonly string Issuer;

        /// <summary>
        /// Потребитель токена
        /// </summary>
        public static readonly string Audience;

        /// <summary>
        /// Конструктор (получаем издателя и потребителя из конфига)
        /// </summary>
        static AuthOptions()
        {
            Issuer = ConfigurationManager.AppSettings["jwt:issuer"];
            Audience = ConfigurationManager.AppSettings["jwt:audience"];
        }

        /// <summary>
        /// Генерация ключа шифрования
        /// </summary>
        /// <returns></returns>
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            var key = ConfigurationManager.AppSettings["jwt:key"];
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
        }
    }
}
