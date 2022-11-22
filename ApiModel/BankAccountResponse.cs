
using Backend.DomainModel;

namespace Backend.ApiModel
{
    public class BankAccountResponse
    {
        public string Id { get; set; }

        public string User { get; set; }

        public string Status { get; set; }

        public decimal Balance { get; set; }

        public BankAccountResponse(BankAccount account)
        {
            Id = account.Id.ToString();
            User = account.UserName;
            Status = account.Status.ToString();
            Balance = account.Balance;
        }
    }
}