namespace Ledger;

public static class Money
{
    private const decimal FeeRate = 0.015m;

    public static decimal Round(decimal amount) => Math.Round(amount, 2, MidpointRounding.ToEven);

    public static decimal Clamp(decimal amount, decimal ceiling) => Math.Min(amount, ceiling);

    public static decimal Share(decimal amount, int ways) => Round(amount / ways);

    public static decimal Fee(decimal amount) => Round(amount * FeeRate);
}
