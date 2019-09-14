namespace CSharpDesignPatterns._6._Behavioral_patterns.Strategy
{
    using NUnit.Framework;

    [TestFixture]
    public class StrategyTests
    {
        private readonly IBillingStrategy happyHourStrategy = new HappyHourStrategy();
        private readonly IBillingStrategy normalStrategy    = new NormalStrategy();

        [Test]
        public void UsingNormalStrategyPaysNormalAmount()
        {
            var customer = new Diner(this.normalStrategy);

            customer.Order(5, 5); // 25
            customer.Order(1, 5); // 5
            customer.Order(3, 5); // 15

            Assert.AreEqual(25 + 5 + 15, customer.GetTotalAmount());
        }

        [Test]
        public void UsingHappyHourStrategyPaysHalf()
        {
            var customer = new Diner(this.happyHourStrategy);

            customer.Order(5, 5); // 25 / 2
            customer.Order(1, 5); // 5 / 2
            customer.Order(3, 5); // 15 / 2

            Assert.AreEqual((25.0 + 5 + 15) / 2, customer.GetTotalAmount());
        }

        [Test]
        public void SwitchingStrategiesPaysValidAmount()
        {
            var customer = new Diner(this.happyHourStrategy);

            customer.Order(5, 5); // 25.0 / 2 = 12.5
            customer.Order(1, 5); // 5.0 / 2 = 2.5

            customer.Strategy = this.normalStrategy;

            customer.Order(3, 5); // 15
            customer.Order(2, 5); // 10

            Assert.AreEqual(12.5 + 2.5 + 15 + 10, customer.GetTotalAmount());
        }
    }
}