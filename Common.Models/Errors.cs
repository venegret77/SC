using System.ComponentModel;

namespace Common.Models
{
    public enum Errors
    {
        [Description("Учетная запись с указанными данными не найдена")]
        AccountNotFound,

        [Description("Учетная запись с таким именем уже существует")]
        LoginExists,

        [Description("Некорректный Refresh токен")]
        RefreshTokenError,

        [Description("Модель не прошла валидацию")]
        ModelValidationError
    }
}
