using Backend.ApiModel;
using Backend.DomainModel;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("/api")]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("account")]
        public async Task<IActionResult> Create([FromBody] BankAccount account)
        {
            //var account = new BankAccount(requestModel.UserName);
            var wasCreated = await _accountService.CreateBankAccount(account);

            if(wasCreated)
            {
                return Ok(new { Id = account.Id, Message = "Bank account was created successfully" });
            }

            return BadRequest(new { Message = "Bank acount could not be created" });
        }

        [HttpGet]
        [Route("account/{accountId}")]
        public async Task<IActionResult> GetAccountById([FromRoute] string accountId)
        {
            var account = await _accountService.GetAccountById(Guid.Parse(accountId));

            if (account == null)
                return NotFound(new { Message = "Account not found" });

            //var response = new BankAccountResponse(account);
            return Ok(account);
        }

    }
}