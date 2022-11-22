using Backend.DomainModel;
using System;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IAccountService
    {
        Task<bool> CreateBankAccount(BankAccount account);

        Task<bool> UpdateBankAccount(BankAccount account);

        Task<BankAccount> GetAccountById(Guid accountId);
    }
}