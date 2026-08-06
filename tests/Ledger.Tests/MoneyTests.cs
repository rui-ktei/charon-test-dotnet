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
    public void CalculatesATip() => Assert.Equal(1.50m, Money.Tip(10m, 15m));

    [Fact]
    public void CalculatesATipWithAFractionalPercent() => Assert.Equal(1.25m, Money.Tip(10m, 12.5m));

    [Fact]
    public void RejectsANegativeTipPercent() => Assert.Throws<ArgumentOutOfRangeException>(() => Money.Tip(10m, -50m));

    [Fact]
    public void RejectsATipPercentAboveOneHundred() => Assert.Throws<ArgumentOutOfRangeException>(() => Money.Tip(10m, 200m));

    [Fact]
    public void ChargesTheMinimumSurchargeOnASmallAmount() => Assert.Equal(0.50m, Money.Surcharge(10m, 0.50m));

    [Fact]
    public void ChargesTheFeeWhenItBeatsTheMinimum() => Assert.Equal(1.50m, Money.Surcharge(100m, 0.50m));

    [Fact]
    public void RaisesAnAmountToTheFloor() => Assert.Equal(5m, Money.Floor(2m, 5m));

    [Fact]
    public void LeavesAnAmountAboveTheFloorAlone() => Assert.Equal(9m, Money.Floor(9m, 5m));
}
