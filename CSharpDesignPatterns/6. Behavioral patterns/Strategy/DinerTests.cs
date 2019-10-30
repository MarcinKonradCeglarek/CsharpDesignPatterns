namespace CSharpDesignPatterns._6._Behavioral_patterns.Strategy
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class DinerTests
    {
        private const    double           Delta              = 0.000001;
        private readonly IBillingStrategy happyHourStrategy  = new HappyHourBillingStrategy();
        private readonly IBillingStrategy normalStrategy     = new DefaultBillingStrategy();
        private readonly ITippingStrategy flaTippingStrategy = new FlatTippingStrategy();
        private readonly ITippingStrategy fivePercentTip     = new PercentageTippingStrategy(0.05);

        [Test]
        public void DinerWithDefaultBillingAndFlatTippingStrategy()
        {
            var diner = new Diner(this.normalStrategy, this.flaTippingStrategy);

            diner.Order(25);
            diner.Order(5);

            Assert.AreEqual(30 + 10, diner.GetTotalAmount(), Delta);
        }

        [Test]
        public void DinerWithHappyHoursBillingAndFlatTippingStrategy()
        {
            var diner = new Diner(this.happyHourStrategy, this.flaTippingStrategy);

            diner.Order(25);
            diner.Order(5);

            Assert.AreEqual(17.5 + 7.5, diner.GetTotalAmount(), Delta);
        }

        [Test]
        public void DinerWithDefaultBillingAndPercentageTippingStrategy()
        {
            var diner = new Diner(this.normalStrategy, this.fivePercentTip);

            diner.Order(25);
            diner.Order(5);

            // 25 * 105% + 5 * 105%
            Assert.AreEqual((25 + 5) * 1.05, diner.GetTotalAmount(), Delta);
        }

        [Test]
        public void DinerWithHappyHoursBillingAndPercentageTippingStrategy()
        {
            var diner = new Diner(this.happyHourStrategy, this.fivePercentTip);

            diner.Order(25);
            diner.Order(5);

            // 25 * 50% * 105% + 5 * 50% * 105%
            Assert.AreEqual((12.5 + 2.5) * 1.05, diner.GetTotalAmount(), Delta);
        }

        [Test]
        public void SwitchingStrategiesPaysValidAmount()
        {
            var diner = new Diner(this.normalStrategy, this.flaTippingStrategy);

            diner.Order(25); // 25 + 5
            diner.Order(5);  // 5 + 5

            diner.BillingStrategy = this.happyHourStrategy;

            diner.Order(15); // 7.5 + 5
            diner.Order(10); // 5 + 5

            diner.TippingStrategy = this.fivePercentTip;

            diner.Order(20); // 10 + 0.5

            diner.BillingStrategy = this.normalStrategy;

            diner.Order(30); // 30 + 1.5

            Assert.AreEqual(30 + 10 + 12.5 + 10 + 10.5 + 31.5, diner.GetTotalAmount());
        }
    }
}