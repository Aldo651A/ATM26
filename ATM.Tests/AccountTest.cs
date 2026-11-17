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


} 
      