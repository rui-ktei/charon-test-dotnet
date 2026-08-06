namespace Ledger;

public static class Money
{
    private const decimal FeeRate = 0.015m;

    public static decimal Round(decimal amount) => Math.Round(amount, 2, MidpointRounding.ToEven);

    public static decimal Clamp(decimal amount, decimal ceiling) => Math.Min(amount, ceiling);

    public static decimal Share(decimal amount, int ways) => Round(amount / ways);

    public static decimal Fee(decimal amount) => Round(amount * FeeRate);

    public static decimal Discount(decimal amount, decimal percent)
    {
        if (percent < 0m || percent > 100m)
        {
            throw new ArgumentOutOfRangeException(nameof(percent), percent, "Percent must be between 0 and 100.");
        }

        return Round(amount - amount * percent / 100m);
    }
}
