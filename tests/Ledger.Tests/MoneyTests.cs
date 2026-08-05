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
    public void TakesAPercentageOfAnAmount() => Assert.Equal(2.5m, Money.Percent(50m, 0.05m));

    [Fact]
    public void ChargesATransactionFee() => Assert.Equal(0.15m, Money.Fee(10m));
}
