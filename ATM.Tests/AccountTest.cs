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
    public void AccountWithdrawTest()
    {
        // Setup
        int testWithdrawVal = 5000;
        Account account = new Account(testWithdrawVal);
        // Assert.True(account.Withdraw == 6000 "Expected 5000")
        // When
        account.Withdraw(6000);
        // Then
        Assert.Equal(testWithdrawVal, account.GetBalance());
    
    }
    
     [Fact]
    public void AccountWithdrawNegativeAmountTest()
    {
        // Setup
        int testWithdrawVal = 5000;
        Account account = new Account(testWithdrawVal);
        // Assert.True(account.Withdraw == - 1000 "Expected 5000")
        // When
        account.Withdraw(- 1000);
        // Then
        Assert.Equal(testWithdrawVal, account.GetBalance());
    
    }

    [Fact]
    public void AccountDepositIncreasesBalanceTest()
    {
        // Setup
        int testDepositVal = 5000;
        Account account = new Account(testDepositVal);
        // Assert.True(account.Deposit == 1000 "Expected 6000")
        // When
        account.Deposit(1000);
        // Then 
        Assert.Equal(6000, account.GetBalance());

    }

     [Fact]
    public void AccountDepositNegativeBalanceTest()
    {
        // Setup
        int testDepositVal = 5000;
        Account account = new Account(testDepositVal);
        // Assert.True(account.Deposit == -500 "Expected 5000")
        // When
        account.Deposit(- 500);
        // Then 
        Assert.Equal(5000, account.GetBalance());

    }
} 

      