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

}
