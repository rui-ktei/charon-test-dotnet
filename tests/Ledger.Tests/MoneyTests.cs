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
    public void CapsTheFeeOnALargeAmount() => Assert.Equal(20.00m, Money.Fee(10000m));

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
    public void AllocatesTheWholeAmountWhenItDividesEvenly()
    {
        var (total, remainder) = Money.Allocate(10m, 2);
        Assert.Equal(10m, total);
        Assert.Equal(0m, remainder);
    }

    [Fact]
    public void AllocatesWhatTheSharesAddUpTo()
    {
        var (total, remainder) = Money.Allocate(10m, 3);
        Assert.Equal(9.99m, total);
        Assert.Equal(0.01m, remainder);
    }

    [Fact]
    public void RefundsWhatIsLeftAfterTheFee() => Assert.Equal(9.85m, Money.Refund(10m, 0.15m));

    [Fact]
    public void ClampsTheRefundToZeroWhenTheFeeExceedsTheAmount() => Assert.Equal(0m, Money.Refund(10m, 12m));

    [Fact]
    public void RejectsNonPositiveWays() => Assert.Throws<ArgumentOutOfRangeException>(() => Money.Share(10m, 0));

    [Fact]
    public void ProratesAcrossThePeriod()
    {
        Assert.Equal(25.00m, Money.Prorate(100m, 1, 4));
    }

    [Fact]
    public void SurtaxesAtTheGivenRate()
    {
        Assert.Equal(2.50m, Money.Surtax(100m, 2.5m));
    }

    [Fact]
    public void PaysABonusAtTheGivenRate()
    {
        Assert.Equal(5.00m, Money.Bonus(100m, 5m));
    }
}
