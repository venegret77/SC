using System.ComponentModel;

namespace Common.Models
{
    public enum InfoMessages
    {
        [Description("Вы успешно вошли в систему!")]
        LoginSuccess,

        [Description("Вы успешно зарегистрировались в системе!")]
        RegistrationSuccess,

        [Description("Вы успешно вышли из системы!")]
        LogoutSuccess,

        [Description("Студент успешно добавлен")]
        StudentAddSuccess,

        [Description("Данные о студенте успешно изменены")]
        StudentUpdateSuccess,

        [Description("Студент успешно удален")]
        StudentDeleteSuccess
    }
}
