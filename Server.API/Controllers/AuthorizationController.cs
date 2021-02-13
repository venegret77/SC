using Common.Helpers;
using Common.JWT;
using Common.Models;
using Common.Models.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.Controllers
{
    /// <summary>
    /// Контроллер для взаимодействия с сервисом авторизации
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly Services.Interfaces.IAuthorizationService authorizationService;

        /// <summary>
        /// Конструктор DI
        /// </summary>
        /// <param name="authorizationService"></param>
        public AuthorizationController(Services.Interfaces.IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }

        /// <summary>
        /// Вход
        /// </summary>
        /// <param name="model">Модель данных</param>
        /// <returns>Результирующий контейнер</returns>
        [HttpGet("Login")]
        public async Task<ResultContainer<AccountViewModel>> LoginAsync(LoginOrRegistrationModel model)
        {
            #region Validate model
            if (!ModelState.IsValid)
            {
                return new ResultContainer<AccountViewModel> { Message = EnumHelper.GetDescription(Errors.ModelValidationError), Success = false };
            }
            #endregion

            return await authorizationService.LoginAsync(model);
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="model">Модель данных</param>
        /// <returns>Результирующий контейнер</returns>
        [HttpGet("Registration")]
        public async Task<ResultContainer<AccountViewModel>> RegistrationAsync(LoginOrRegistrationModel model)
        {
            #region Validate model
            if (!ModelState.IsValid)
            {
                return new ResultContainer<AccountViewModel> { Message = EnumHelper.GetDescription(Errors.ModelValidationError), Success = false };
            }
            #endregion

            return await authorizationService.RegistrationAsync(model);
        }

        /// <summary>
        /// Получение информации об учетной записи
        /// </summary>
        /// <returns>Результирующий контейнер</returns>
        [HttpGet("GetAccountInfo")]
        public async Task<ResultContainer<AccountViewModel>> GetAccountInfoAsync()
        {
            long.TryParse(User.Identity.Name, out long accountIdFromClaims);

            return await authorizationService.GetAccountInfoAsync(accountIdFromClaims);
        }

        /// <summary>
        /// Генерация нового access токена доступа на основе refresh токена
        /// </summary>
        /// <returns>Результирующий контейнер</returns>
        [HttpPost("GenerateNewAccessToken")]
        public async Task<object> GenerateNewAccessTokenAsync()
        {
            long.TryParse(User.Identity.Name, out long accountId);

            var authorizationHeader = Request.Headers["Authorization"].FirstOrDefault();

            var result = await authorizationService.GenerateNewAccessTokenAsync(accountId, authorizationHeader);

            if (result.Success)
                return result;
            else
                return StatusCode(401);
        }

        /// <summary>
        /// Выход
        /// </summary>
        /// <returns>Результирующий контейнер</returns>
        [Authorize]
        [HttpPost("Logout")]
        public async Task<ResultContainer> LogoutAsync()
        {
            long.TryParse(User.Identity.Name, out long accountIdFromClaims);

            return await authorizationService.LogoutAsync(accountIdFromClaims);
        }
    }
}
