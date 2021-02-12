using Data.EntityFramework;
using Data.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly ApplicationContext applicationContext;

        public AuthorizationRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<AccountDto> GetAccountAsync(int accountId)
        {
            return await applicationContext.Accounts
                .FirstOrDefaultAsync();
        }

        public async Task<AccountDto> AddAccountAsync(string login, string hash)
        {
            var account = new AccountDto
            {
                Login = login,
                Hash = hash
            };

            await applicationContext.Accounts
                .AddAsync(account);

            await applicationContext.SaveChangesAsync();

            return account;
        }        

        public async Task RemoveTokensByAccountIdAsync(int accountId)
        {
            var tokens = await applicationContext.AuthorizationTokens
                .Where(a => a.AccountId == accountId)
                .ToListAsync();

            applicationContext.AuthorizationTokens.RemoveRange(tokens);

            await applicationContext.SaveChangesAsync();
        }
    }
}
