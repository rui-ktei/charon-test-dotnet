using Ledger;
using Xunit;

public class MoneyTests
{
    [Fact]
    public void RoundsToTheNearestCent() => Assert.Equal(1.24m, Money.Round(1.235m));

    [Fact]
    public void ClampsToTheCeiling() => Assert.Equal(5m, Money.Clamp(9m, 5m));
}
