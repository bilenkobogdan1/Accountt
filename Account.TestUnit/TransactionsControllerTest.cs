using Account.WebApi.Controllers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
namespace Account.TestUnit
{
    public class TransactionsControllerTest
    {
        [Fact]
        public void IncreaseMoneyToAccount()
        {
            IncreaseDecreaseToAccount(true);
        }
        [Fact]
        public void DecreaseMoneyToAccount()
        {
            IncreaseDecreaseToAccount(false);
        }
        private void IncreaseDecreaseToAccount(bool icrease)
        {
            //Arrange
            AccountController accountController = new();
            decimal sum = 40;
            decimal depositSum = 30;
            decimal allSum;
            if (icrease)
            {
                 allSum = sum + depositSum;
            }
            else
            {
                allSum = sum - depositSum;
            }
            var accountTest = accountController.CreateAccont(sum);
            TransactionsController transactionsController = new ();

            //Act
            if (icrease)
            {
                transactionsController.DepositMoneyToAccount(accountTest.AccountNumber, depositSum);
            }
            else
            {
                transactionsController.WithdrawMoneyToAccount(accountTest.AccountNumber, depositSum);
            }
            var sumAcount = accountController.GetAccountFromNumber(accountTest.AccountNumber).Sum;

            //Assert
            Assert.Equal(sumAcount, allSum);
        }
        [Fact]

        public void IsTransferMoneyBetweenAccount()
        {
            //Arrange
            decimal StartSum = 100;
            decimal sumDebit, sumCredit;
            decimal transferSum = 50;
            AccountController accountController = new();
            var accountCreditTest = accountController.CreateAccont(StartSum);
            var accountDebitTest = accountController.CreateAccont(StartSum);
            TransactionsController transactionsController = new ();
            //Act

            transactionsController.TransferMoneyToAccount(accountCreditTest.AccountNumber, accountDebitTest.AccountNumber, transferSum);
            sumCredit = StartSum - transferSum;
            sumDebit = StartSum + transferSum;
            accountCreditTest = accountController.GetAccountFromNumber(accountCreditTest.AccountNumber);
            accountDebitTest = accountController.GetAccountFromNumber(accountDebitTest.AccountNumber);

            //Assert
            Assert.Equal(sumCredit, accountCreditTest.Sum);
            Assert.Equal(sumDebit, accountDebitTest.Sum);
        }
    }
}
