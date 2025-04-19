using TommieDinner.Domain.Common.Models;

namespace TommieDinner.Domain.BillAggregate.ValueObjects;

public class Price : ValueObject
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Price CreateNew(decimal amount, string currency)
    {
        return new Price(amount, currency);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}