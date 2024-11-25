using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acount.Entities.Models;
using Acount.AccessLayer.Data;
namespace BusinessLogic.Logic
{
    public class TransitAccountLogic
    {
        public TransitAccountLogic() { }

        public void DepositMoneyToAccount(Account acount,decimal sum)
        {
            DataControl.accounts.Where(x => x == acount).FirstOrDefault().Sum += sum;
        }
        public void WithdrawMoneyToAccount(Account acount, decimal sum)
        {
            if (acount.Sum > sum)
            {
                DataControl.accounts.Where(x => x == acount).FirstOrDefault().Sum -= sum;
            }
            else
            {
                throw new Exception("not enough money");
            }
        }

        public void TransferMoneyToAccount(Account accountDebit, Account accountCredit, decimal sum)
        {
            WithdrawMoneyToAccount(accountDebit, sum);
            DepositMoneyToAccount(accountCredit, sum);
        }

    }
}
