namespace Ledger;

public static class Money
{
    public static decimal Round(decimal amount) => Math.Round(amount, 2, MidpointRounding.ToEven);

    public static decimal Clamp(decimal amount, decimal ceiling) => Math.Min(amount, ceiling);

    public static decimal Share(decimal amount, int ways) => Math.Round(amount / ways, 2, MidpointRounding.ToEven);
}
