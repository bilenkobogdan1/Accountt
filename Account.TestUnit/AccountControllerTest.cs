using Account.WebApi.Controllers;

namespace Account.TestUnit
{
    public class AccountControllerTest
    {
        [Fact]
        public void GetNotNullAccount()
        {
            //Arrange
            AccountController accountController = new ();

            //Act
            var acountTest = accountController.GetAccounts();

            //Assert
            Assert.NotNull(acountTest);
        }
        [Fact]
        public void GetActualAccountTest()
        {
            //Arrange
            AccountController accountController = new ();
            decimal sum = 20;
            var accountTest = accountController.CreateAccont(sum);
            string actualAccountNumberTest = accountTest.AccountNumber;
            //Act 
            var actualAccountTest = accountController.GetAccountFromNumber(actualAccountNumberTest);

            //Assert 
            Assert.Equal(accountTest, actualAccountTest);
        }
        [Fact]
        public void CreateAccountWithActualSum()
        {
            //Arrange
            AccountController accountController = new ();
            decimal sum = 10;

            //Act
            var acountTest = accountController.CreateAccont(sum);

            //Assert
            Assert.Equal(acountTest.Sum, sum);
        }
        
    }
}