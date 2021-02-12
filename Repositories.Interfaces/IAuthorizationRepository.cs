using Data.EntityFramework.Models;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IAuthorizationRepository
    {
        Task<AccountDto> GetAccountAsync(int accountId);

        Task<AccountDto> AddAccountAsync(string login, string hash);

        Task RemoveTokensByAccountIdAsync(int accountId);
    }
}
