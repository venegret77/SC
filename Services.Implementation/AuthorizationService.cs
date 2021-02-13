using Common.Configuration;
using Common.JWT;
using Common.Models;
using Common.Models.Authorization;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IHashService hashService;

        private readonly IAuthorizationRepository authorizationRepository;

        private readonly int accessTokenLifetime;
        private readonly int refreshTokenLifetime;


        public AuthorizationService(IHashService hashService, IAuthorizationRepository authorizationRepository)
        {
            this.hashService = hashService;

            this.authorizationRepository = authorizationRepository;

            int.TryParse(ConfigurationManager.AppSettings["jwt:accessExpirationTimeInMinutes"], out accessTokenLifetime);
            int.TryParse(ConfigurationManager.AppSettings["jwt:refreshExpirationTimeInMinutes"], out refreshTokenLifetime);
        }

        public async Task<ResultContainer<AccountViewModel>> LoginAsync(LoginOrRegistrationModel model)
        {
            var result = new ResultContainer<AccountViewModel>();

            try
            {
                var hash = hashService.ComputeHash(model.Login + model.Password);

                var isAccountExists = await authorizationRepository.IsAccountExistsAsync(model.Login, hash);

                if (!isAccountExists)
                {
                    result.SetError(Errors.AccountNotFound, SnackbarTypes.Warning);
                    return result;
                }

                var account = await authorizationRepository.GetAccountAsync(model.Login);

                var accountModel = await GenerateTokensAsync(model, account);

                result.SetResult(InfoMessages.LoginSuccess, accountModel);
            }
            catch (Exception exception)
            {
                result.SetError(exception);
            }

            return result;
        }

        public async Task<ResultContainer<AccountViewModel>> RegistrationAsync(LoginOrRegistrationModel model)
        {
            var result = new ResultContainer<AccountViewModel>();

            try
            {
                var isLoginExists = await authorizationRepository.IsLoginExistsAsync(model.Login);

                if (!isLoginExists)
                {
                    result.SetError(Errors.LoginExists, SnackbarTypes.Warning);
                    return result;
                }

                var hash = hashService.ComputeHash(model.Login + model.Password);

                var account = await authorizationRepository.AddAccountAsync(model.Login, hash);

                var accountModel = await GenerateTokensAsync(model, account);

                result.SetResult(InfoMessages.RegistrationSuccess, accountModel);
            }
            catch (Exception exception)
            {
                result.SetError(exception);
            }

            return result;
        }

        public async Task<ResultContainer<TokenModel>> GenerateNewAccessTokenAsync(long accountId, string authorizationHeader)
        {
            var result = new ResultContainer<TokenModel>();

            try
            {
                var isRefreshTokenValid = await authorizationRepository.IsRefreshTokenValidAsync(accountId, authorizationHeader);

                if (!isRefreshTokenValid)
                {
                    result.SetError(Errors.RefreshTokenError, SnackbarTypes.Warning);
                    return result;
                }

                var acceessToken = GeneratorJWTTokens.GenerateJWTToken(accountId, accessTokenLifetime);

                result.SetResult("", acceessToken);
            }
            catch (Exception exception)
            {
                result.SetError(exception);
            }

            return result;
        }

        public async Task<ResultContainer<AccountViewModel>> GetAccountInfoAsync(long accountId)
        {
            var result = new ResultContainer<AccountViewModel>();

            try
            {
                var isAccountExists = await authorizationRepository.IsAccountExistsAsync(accountId);

                if (!isAccountExists)
                {
                    result.SetError(Errors.AccountNotFound, SnackbarTypes.Warning);
                    return result;
                }

                var account = await authorizationRepository.GetAccountAsync(accountId);

                var accountModel = new AccountViewModel
                {
                    Login = account.Login
                };

                result.SetResult(InfoMessages.LoginSuccess, accountModel);
            }
            catch (Exception exception)
            {
                result.SetError(exception);
            }

            return result;
        }

        public async Task<ResultContainer> LogoutAsync(long accountId)
        {
            var result = new ResultContainer();

            try
            {
                await authorizationRepository.RemoveTokensByAccountIdAsync(accountId);

                result.SetResult(InfoMessages.LogoutSuccess);
            }
            catch (Exception exception)
            {
                result.SetError(exception);
            }

            return result;
        }

        private async Task<AccountViewModel> GenerateTokensAsync(LoginOrRegistrationModel model, Data.EntityFramework.Models.AccountDto account)
        {
            var acceessToken = GeneratorJWTTokens.GenerateJWTToken(account.Id, accessTokenLifetime);
            var refreshToken = GeneratorJWTTokens.GenerateJWTToken(account.Id, refreshTokenLifetime);

            var expirationDateTime = DateTime.UtcNow.AddMinutes(refreshToken.ExpirationTime);

            await authorizationRepository.AddToken(account.Id, refreshToken.Token, expirationDateTime.ToUniversalTime());

            var accountModel = new AccountViewModel
            {
                Login = model.Login,
                AccessToken = acceessToken,
                RefreshToken = refreshToken
            };

            return accountModel;
        }
    }
}
