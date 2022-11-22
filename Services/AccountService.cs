using Backend.Data;
using Backend.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class AccountService : IAccountService
    {
        private ApplicationDbContext _db;

        public AccountService(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<bool> CreateBankAccount(BankAccount account)
        {
            _db.Accounts.Add(account);
            var result = await _db.SaveChangesAsync();
            return result == 1;
        }

        public async Task<bool> UpdateBankAccount(BankAccount account)
        {
            var accountToUpdate = await GetAccountById(account.Id);
            accountToUpdate.UserName = account.UserName;

            if (accountToUpdate != null)
            {
                _db.Accounts.Update(accountToUpdate);
                var result = await _db.SaveChangesAsync();
                return result == 1;
            }

            return false;
        }

        public async Task<BankAccount> GetAccountById(Guid accountId)
        {
            var account = await _db.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);

            return account;
        }
    }
}