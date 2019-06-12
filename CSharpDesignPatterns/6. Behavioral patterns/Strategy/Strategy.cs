namespace CSharpDesignPatterns._6._Behavioral_patterns.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Customer
    {
        private readonly IList<double> drinksPrices;

        public Customer(IBillingStrategy strategy)
        {
            this.drinksPrices = new List<double>();
            this.Strategy     = strategy;
        }

        public IBillingStrategy Strategy { get; set; }

        public void Add(double price, int quantity)
        {
            this.drinksPrices.Add(this.Strategy.GetPrice(price * quantity));
        }

        public double GetTotalAmount()
        {
            return this.drinksPrices.Sum();
        }
    }

    public interface IBillingStrategy
    {
        double GetPrice(double originalPrice);
    }

    public class NormalStrategy : IBillingStrategy
    {
        public double GetPrice(double originalPrice)
        {
            return originalPrice;
        }
    }

    public class HappyHourStrategy : IBillingStrategy
    {
        public double GetPrice(double originalPrice)
        {
            return originalPrice * 0.5;
        }
    }
}