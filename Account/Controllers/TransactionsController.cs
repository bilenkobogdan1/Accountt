using Acount.Entities.Models;
using BusinessLogic.Logic;
using Microsoft.AspNetCore.Mvc;
using Accountt = Acount.Entities.Models.Account;
namespace Account.WebApi.Controllers
{
    public class TransactionsController : BaseControl
    {
        //private readonly ILogger<TransactionsController> _logger;

        //public TransactionsController(ILogger<TransactionsController> logger)
        //{
        //    _logger = logger;
        //}
        public TransactionsController()
        {

        }
        [HttpPost]
        public void DepositMoneyToAccount(string accountNumber, decimal money)  
        {
           var account =  new AccountLogic().GetAccount(accountNumber);
           new TransitAccountLogic().DepositMoneyToAccount(account, money);
        }
        [HttpPost]
        public void WithdrawMoneyToAccount(string accountNumber, decimal money)
        {
            var account = new AccountLogic().GetAccount(accountNumber);
            new TransitAccountLogic().WithdrawMoneyToAccount(account, money);
        }
        [HttpPost]
        public void TransferMoneyToAccount(string accountNumberDebit, string accountNumberCredit,decimal money)
        {
            var accountCredit = new AccountLogic().GetAccount(accountNumberCredit);
            var accountDebit = new AccountLogic().GetAccount(accountNumberDebit);
            new TransitAccountLogic().TransferMoneyToAccount(accountDebit, accountCredit, money);

        }

    }
}
