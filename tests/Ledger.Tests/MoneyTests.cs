using System;
using Ledger;
using Xunit;

public class MoneyTests
{
    [Fact]
    public void RoundsToTheNearestCent() => Assert.Equal(1.24m, Money.Round(1.235m));

    [Fact]
    public void ClampsToTheCeiling() => Assert.Equal(5m, Money.Clamp(9m, 5m));

    [Fact]
    public void SharesAnAmountEvenly() => Assert.Equal(3.33m, Money.Share(10m, 3));

    [Fact]
    public void ChargesATransactionFee() => Assert.Equal(0.15m, Money.Fee(10m));

    [Fact]
    public void AppliesADiscount() => Assert.Equal(9m, Money.Discount(10m, 10m));

    [Fact]
    public void RejectsANegativePercent() => Assert.Throws<ArgumentOutOfRangeException>(() => Money.Discount(10m, -50m));

    [Fact]
    public void RejectsAPercentAboveOneHundred() => Assert.Throws<ArgumentOutOfRangeException>(() => Money.Discount(10m, 200m));

    [Fact]
    public void CalculatesATip() => Assert.Equal(1.50m, Money.Tip(10m, 15));
}
