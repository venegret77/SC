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
        private readonly IAuthorizationRepository authorizationRepository;

        public AuthorizationService(IAuthorizationRepository authorizationRepository)
        {
            this.authorizationRepository = authorizationRepository;
        }

        public async Task<ResultContainer<AccountViewModel>> LoginAsync(LoginOrRegistrationModel model)
        {
            var result = new ResultContainer<AccountViewModel>();

            try
            {
            }
            catch (Exception exception)
            {
                result.Message = exception.Message;
            }

            return result;
        }

        public async Task<ResultContainer<AccountViewModel>> RegistrationAsync(LoginOrRegistrationModel model)
        {
            var result = new ResultContainer<AccountViewModel>();

            try
            {
            }
            catch (Exception exception)
            {
                result.Message = exception.Message;
            }

            return result;
        }

        public async Task<ResultContainer<TokenModel>> GenerateNewAccessTokenAsync(int accountId)
        {
            var result = new ResultContainer<TokenModel>();

            try
            {
            }
            catch (Exception exception)
            {
                result.Message = exception.Message;
            }

            return result;
        }

        public async Task<ResultContainer<AccountViewModel>> GetAccountInfoAsync(int accountId)
        {
            var result = new ResultContainer<AccountViewModel>();

            try
            {
            }
            catch (Exception exception)
            {
                result.Message = exception.Message;
            }

            return result;
        }

        public async Task<ResultContainer> LogoutAsync(int accountId)
        {
            var result = new ResultContainer();

            try
            {
                await authorizationRepository.RemoveTokensByAccountIdAsync(accountId);

                result.Success = true;
                result.SnackbarType = "";
            }
            catch (Exception exception)
            {
                result.Message = exception.Message;
            }

            return result;
        }
    }
}
