
using System;
using System.Text.Json.Serialization;

namespace Backend.DomainModel
{
    public class BankAccount
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BankAccountStatus Status { get; set; }

        public decimal Balance { get; set; }

        public string InternalProperty { get; set; }

        public BankAccount()
        {
            ApplyRulesToCreateBankAccount();
        }

        public BankAccount(string username)
        {
            ApplyRulesToCreateBankAccount();
            UserName = username;
        }

        public void ApplyRulesToCreateBankAccount()
        {
            Id = Guid.NewGuid();
            Status = BankAccountStatus.PENDING_APPROVAL;
            Balance = 0;
            InternalProperty = "Secret";
        }
    }
}