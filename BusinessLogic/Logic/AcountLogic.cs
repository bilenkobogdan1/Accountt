using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Acount.AccessLayer.Data;
using BusinessLogic;
using Acount.Entities.Models;
namespace BusinessLogic.Logic
{
    public class AccountLogic
    {
        public AccountLogic() { }

        public Account CreateNewAcount(decimal sum)
        {
            ParamAcount paramAcount = new ParamAcount() { sum = sum };
            var acount = InicilizeAcount(paramAcount);
            DataControl.Inisilize();
            DataControl.accounts.Add(acount);
            return acount;
        }
        public class ParamAcount
        {
            public decimal sum;
        }

        private Account InicilizeAcount(ParamAcount paramAcount)
        {
            return new Account()
            {
                Sum = paramAcount.sum,
                AccountNumber = GenereteAcountNumber(),
                DateCreate = DateTime.Now,
            };
        }
        private string GenereteAcountNumber()
        {
            return Guid.NewGuid().ToString();
        }

        public Account GetAccount (string accountNumber) => DataControl.accounts?
            .Where(x=>x.AccountNumber == accountNumber)?.FirstOrDefault() ?? new Account();

        public List<Account> GetAccount() => DataControl.accounts ?? new List<Account>();
    }
}
