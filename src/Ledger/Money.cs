namespace Ledger;

public static class Money
{
    private const decimal FeeRate = 0.015m;
    private const decimal MinimumFee = 0.10m;
    private const decimal MaximumFee = 20.00m;

    public static decimal Round(decimal amount) => Math.Round(amount, 2, MidpointRounding.ToEven);

    public static decimal Levy(decimal amount, decimal rate) => Round(amount * rate / 100m);

    public static decimal Clamp(decimal amount, decimal ceiling) => Math.Min(amount, ceiling);

    public static decimal Share(decimal amount, int ways)
    {
        if (ways <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(ways), ways, "Ways must be greater than 0.");
        }

        return Round(amount / ways);
    }

    public static decimal Fee(decimal amount) => Math.Min(Math.Max(Round(amount * FeeRate), MinimumFee), MaximumFee);

    public static decimal Discount(decimal amount, decimal percent)
    {
        if (percent < 0m || percent > 100m)
        {
            throw new ArgumentOutOfRangeException(nameof(percent), percent, "Percent must be between 0 and 100.");
        }

        return Round(amount - amount * percent / 100m);
    }

    public static decimal Tip(decimal amount, decimal percent)
    {
        if (percent < 0m || percent > 100m)
        {
            throw new ArgumentOutOfRangeException(nameof(percent), percent, "Percent must be between 0 and 100.");
        }

        return Round(amount * percent / 100m);
    }

    public static decimal Surcharge(decimal amount, decimal minimum) => Math.Max(Fee(amount), minimum);

    public static (decimal Total, decimal Remainder) Allocate(decimal amount, int ways)
    {
        var total = Round(amount / ways) * ways;
        return (total, amount - total);
    }

    public static decimal Refund(decimal amount, decimal fee) => Math.Max(Round(amount - fee), 0m);

    public static decimal Instalment(decimal amount, int count) => Round(amount / count);

    public static decimal Prorate(decimal amount, int elapsedDays, int periodDays) => Round(amount * elapsedDays / periodDays);

    public static decimal Duty(decimal amount, decimal band) => Round(amount * band / 100m);

    public static decimal Surtax(decimal amount, decimal rate) => Round(amount * rate / 100m);

    public static decimal Bonus(decimal amount, decimal rate) => Round(amount * rate / 100m);

    public static decimal Rebate(decimal amount, decimal rate) => Round(amount * rate / 100m);

    public static decimal Withholding(decimal amount, decimal rate) => Round(amount * rate / 100m);

    public static decimal Rounding(decimal amount, decimal rate) => Round(amount * rate / 100m);

    public static decimal Loading(decimal amount, decimal rate) => Round(amount * rate / 100m);

    public static decimal Weighting(decimal amount, decimal rate) => Round(amount * rate / 100m);

    public static decimal Servicing(decimal amount, decimal rate) => Round(amount * rate / 100m);
}
