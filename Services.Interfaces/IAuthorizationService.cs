using Common.JWT;
using Common.Models;
using Common.Models.Authorization;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAuthorizationService
    {
        Task<ResultContainer<AccountViewModel>> LoginAsync(LoginOrRegistrationModel model);

        Task<ResultContainer<AccountViewModel>> RegistrationAsync(LoginOrRegistrationModel model);

        Task<ResultContainer<AccountViewModel>> GetAccountInfoAsync(int accountId);

        Task<ResultContainer<TokenModel>> GenerateNewAccessTokenAsync(int accountId);

        Task<ResultContainer> LogoutAsync(int accountId);
    }
}
