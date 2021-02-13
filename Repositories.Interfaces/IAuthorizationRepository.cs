using Data.EntityFramework.Models;
using System;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IAuthorizationRepository
    {
        Task<bool> IsAccountExistsAsync(long accountId);
        Task<bool> IsAccountExistsAsync(string login, string hash);

        Task<bool> IsLoginExistsAsync(string login);

        Task<AccountDto> GetAccountAsync(long accountId);
        Task<AccountDto> GetAccountAsync(string login);

        Task<AccountDto> AddAccountAsync(string login, string hash);

        Task AddToken(long accountId, string token, DateTime expirationDateTime);

        Task RemoveTokensByAccountIdAsync(long accountId);

        Task<bool> IsRefreshTokenValidAsync(long accountId, string authorizationHeader);
    }
}
