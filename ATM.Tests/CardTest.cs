namespace ATM.ATM.Tests;

using System.Reflection;
using System.Security.Principal;
using Xunit;

public class CardTest
{
    [Fact]
    public void CardIsNotBlockedInitiallyTest()
    {
        // Setup
        Account account = new Account(5000);
        // Given
        Card card = new Card("1234-5678", "1234", account);
        // Then
        Assert.False(card.IsBlocked);
    }
    
    [Fact]
    public void CardBlocksAfterThreeFailedPinAttemptTest()
    {
        Account account = new Account(5000);
        Card card = new Card("1234-5678", "1234", account);

        card.MatchesPin("0000"); // Första försök fel 1
        card.MatchesPin("0000"); // Andra försök fel 2
        Assert.False(card.IsBlocked); // Kortet är inte än spärrat
        
        card.MatchesPin("0000"); // Tredje försök fel 3
        Assert.True(card.IsBlocked); // Kortet ska vara spärrat
        Assert.False(card.MatchesPin("1234")); // Nu är kortet spärrat, öven om man skriver in rätt pin.

    }
       
}


