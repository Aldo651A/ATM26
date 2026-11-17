using System.Runtime.InteropServices;

namespace ATM;

public class Card
{
    public string CardNumber { get; }
    public string PinCode { get; }
    public Account Account { get; }
    public bool IsBlocked { get; private set; } = false;

    private int failedAttempts = 0;

    public Card(string cardNumber, string pinCode, Account account)
    {
        CardNumber = cardNumber;
        PinCode = pinCode;
        Account = account;
    }

    public bool MatchesPin(string pinCode)
    {
        if (IsBlocked)
        {
            return false;
        }
        if (PinCode == pinCode)
        {
            failedAttempts = 0;
            return true;
        }
        failedAttempts++;
        if (failedAttempts >= 3)
        {
            IsBlocked = true;
        }

        return false;
    }
}
