namespace ATM.ATM.Tests;

using System.Security.Cryptography.X509Certificates;
using Xunit;

public class AccountTest
{
    [Fact]
    public void AccountHasBalanceTest()
    {
        int testBalanceVal = 5000;
        Account account = new Account(testBalanceVal);
        // Assert.True(account.Balance == 6000 "Expected 6000 but got " + account.Balance);
        Assert.Equal(testBalanceVal, account.Balance);

    }


    [Fact]
    public void InsertCardTest()
    {
        // Setup
        Account account = new Account(5000);
        // Given
        Card card = new Card("1234-5678", "1234", account);
        AtmService atm = new AtmService(5000);
        // When
        atm.InsertCard(card);
        // Then
        Assert.True(atm.HasCardInserted);
    }
    
    [Theory]
    [InlineData(5000, 5000, 0)]
    [InlineData(5000, 100, 4900)]
    [InlineData(5000, 6000, 5000)] // om jag tar ut..
    [InlineData(5000, 0, 5000)]
    [InlineData(5000, -1000, 5000)]
    [InlineData(5000, 75, 5000)]
    public void WithdrawTest(int accountBalance, int withdraw, int expectedAccountBalance)
    {
        // Setup
        Account account = new Account(accountBalance);
        Card card = new Card("1234-5678", "1234", account);
        AtmService atm = new AtmService(10000);
        atm.InsertCard(card);
        atm.EnterPin("1234");
        // When
        atm.Withdraw(withdraw);
        // Then
        int actualAccountBalance = account.GetBalance();
        Assert.Equal(expectedAccountBalance, actualAccountBalance);
    }

}
