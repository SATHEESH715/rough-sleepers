namespace SampleApi.Tests;

[TestClass]
public class StripeDataTests
{
    [TestMethod]
    public void GetAll_ReturnsThreeItems() =>
        Assert.AreEqual(3, StripeData.GetAll().Count);

    [TestMethod]
    public void GetAll_HasUniqueNumbers() =>
        Assert.AreEqual(3, StripeData.GetAll().Select(i => i.Number).Distinct().Count());

    [TestMethod]
    public void GetAll_ContainsAnPlannedItem() =>
        Assert.IsTrue(StripeData.GetAll().Any(i => i.Status == "Planned"));

    [TestMethod]
    [DataRow(0)]
    [DataRow(1)]
    [DataRow(2)]
    [DataRow(3)]
    [DataRow(4)]
    [DataRow(5)]
    [DataRow(6)]
    [DataRow(7)]
    [DataRow(8)]
    [DataRow(9)]
    [DataRow(10)]
    [DataRow(11)]
    [DataRow(12)]
    [DataRow(13)]
    [DataRow(14)]
    [DataRow(15)]
    [DataRow(16)]
    [DataRow(17)]
    [DataRow(18)]
    [DataRow(19)]
    [DataRow(20)]
    [DataRow(21)]
    [DataRow(22)]
    [DataRow(23)]
    [DataRow(24)]
    [DataRow(25)]
    [DataRow(26)]
    [DataRow(27)]
    [DataRow(28)]
    [DataRow(29)]
    [DataRow(30)]
    [DataRow(31)]
    [DataRow(32)]
    [DataRow(33)]
    [DataRow(34)]
    [DataRow(35)]
    [DataRow(36)]
    [DataRow(37)]
    [DataRow(38)]
    [DataRow(39)]
    public void Item_HasExpectedShape(int k)
    {
        var item = StripeData.GetAll()[k % 3];
        Assert.IsFalse(string.IsNullOrWhiteSpace(item.Name));
        Assert.IsFalse(string.IsNullOrWhiteSpace(item.Status));
        Assert.IsTrue(item.Number > 0);
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(1)]
    [DataRow(2)]
    [DataRow(3)]
    [DataRow(4)]
    [DataRow(5)]
    [DataRow(6)]
    public void KnownFailure_FailsOnPurpose(int k) =>
        Assert.Fail($"Check {k + 1} fails on purpose, to show a failing stripe in the report.");
}
