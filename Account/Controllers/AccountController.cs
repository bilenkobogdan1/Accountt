using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Logic;
using Acount.Entities.Models;
using Accountt = Acount.Entities.Models.Account;
using Account.WebApi.Controllers;
namespace Account.WebApi.Controllers
{
    public class AccountController : BaseControl
    {
        //private readonly ILogger<AccountController> _logger;

        //public AccountController(ILogger<AccountController> logger)
        //{
        //    _logger = logger;
        //}
        public AccountController()
        {

        }
        [HttpGet]
        public IEnumerable<Accountt> GetAccounts()
        {
           return new AccountLogic().GetAccount();
        }
        [HttpGet]
        public Accountt GetAccountFromNumber(string number)
        {
            return new AccountLogic().GetAccount(number);
        }
        [HttpPost]
        public Accountt CreateAccont([FromBody] decimal sum)
        {
           return new AccountLogic().CreateNewAcount(sum);
        }


    }
}
