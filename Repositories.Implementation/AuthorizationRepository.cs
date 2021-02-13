using Data.EntityFramework;
using Data.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
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

        public async Task<bool> IsAccountExistsAsync(long accountId)
        {
            return await applicationContext.Accounts
                .AnyAsync(a => a.Id == accountId);
        }

        public async Task<bool> IsAccountExistsAsync(string login, string hash)
        {
            return await applicationContext.Accounts
                .AnyAsync(a => a.Login == login && a.Hash == hash);
        }

        public async Task<bool> IsLoginExistsAsync(string login)
        {
            return await applicationContext.Accounts
                .AnyAsync(a => a.Login == login);
        }

        public async Task<AccountDto> GetAccountAsync(long accountId)
        {
            return await applicationContext.Accounts
                .FirstOrDefaultAsync(a => a.Id == accountId);
        }

        public async Task<AccountDto> GetAccountAsync(string login)
        {
            return await applicationContext.Accounts
                .FirstOrDefaultAsync(a => a.Login == login);
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

        public async Task AddToken(long accountId, string token, DateTime expirationDateTime)
        {
            await RemoveTokensByAccountIdAsync(accountId);

            var tokenDto = new AuthorizationTokenDto
            {
                AccountId = accountId,
                Token = token,
                ExpirationDateTime = expirationDateTime
            };

            await applicationContext.AuthorizationTokens.AddAsync(tokenDto);

            await applicationContext.SaveChangesAsync();
        }

        public async Task RemoveTokensByAccountIdAsync(long accountId)
        {
            var tokens = await applicationContext.AuthorizationTokens
                .Where(a => a.AccountId == accountId)
                .ToListAsync();

            applicationContext.AuthorizationTokens.RemoveRange(tokens);

            await applicationContext.SaveChangesAsync();
        }

        public async Task<bool> IsRefreshTokenValidAsync(long accountId, string authorizationHeader)
        {
            var tokens = await applicationContext.AuthorizationTokens
                .Where(a => a.AccountId == accountId && a.Token == authorizationHeader)
                .ToListAsync();

            var removedTokens = tokens
                .Where(t => t.ExpirationDateTime < DateTime.UtcNow)
                .ToList();

            applicationContext.AuthorizationTokens
                .RemoveRange(removedTokens);

            await applicationContext.SaveChangesAsync();

            return tokens.Any() && removedTokens.Count < tokens.Count;
        }
    }
}
