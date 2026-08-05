namespace Ledger;

public static class Money
{
    public static decimal Round(decimal amount) => Math.Round(amount, 2, MidpointRounding.ToEven);

    public static decimal Clamp(decimal amount, decimal ceiling) => Math.Min(amount, ceiling);

    public static decimal Floor(decimal amount, decimal floor) => Math.Min(amount, floor);
}
