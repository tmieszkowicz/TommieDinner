namespace TommieDinner.Domain.Common.ValueObjects;

public sealed class Rating
{
    public double Value { get; }

    private Rating(double value)
    {
        // Ensure valid rating 1 to 5;
        Value = value;
    }

    public static Rating CreateUnique(double value)
    {
        return new Rating(value);
    }
}