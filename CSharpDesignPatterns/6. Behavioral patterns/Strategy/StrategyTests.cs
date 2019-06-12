﻿namespace CSharpDesignPatterns._6._Behavioral_patterns.Strategy
{
    using NUnit.Framework;
    using NUnit.Framework.Internal;

    [TestFixture]
    public class StrategyTests
    {
        private readonly IBillingStrategy normalStrategy = new NormalStrategy();
        private readonly IBillingStrategy happyHourStrategy = new HappyHourStrategy();

        [Test]
        public void Customer_UsingNormalStrategy_PaysExpectedAmount()
        {
            var customer = new Customer(this.normalStrategy);

            customer.Add(5, 5);  // 25
            customer.Add(1, 5);  //  5
            customer.Add(3, 5);  // 15

            Assert.AreEqual(25 + 5 + 15, customer.GetTotalAmount());
        }


        [Test]
        public void Customer_UsingHappyHourStrategy_PaysExpectedAmount()
        {
            var customer = new Customer(this.happyHourStrategy);

            customer.Add(5, 5);  // 25 / 2
            customer.Add(1, 5);  //  5 / 2
            customer.Add(3, 5);  // 15 / 2

            Assert.AreEqual((25.0 + 5 + 15) / 2, customer.GetTotalAmount());
        }

        [Test]
        public void Customer_SwitchingStrategies_PaysExpectedAmount()
        {
            var customer = new Customer(this.happyHourStrategy);

            customer.Add(5, 5);  // 25.0 / 2
            customer.Add(1, 5);  //  5.0 / 2

            customer.Strategy = this.normalStrategy;

            customer.Add(3, 5);  // 15
            customer.Add(2, 5);  // 10

            Assert.AreEqual(25.0 / 2 + 2.5 + 15 + 10, customer.GetTotalAmount());
        }
    }
}