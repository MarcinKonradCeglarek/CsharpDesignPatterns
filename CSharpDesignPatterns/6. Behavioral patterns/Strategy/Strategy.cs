namespace CSharpDesignPatterns._6._Behavioral_patterns.Strategy
{
    using System.Collections.Generic;
    using System.Linq;

    public class Customer
    {
        private readonly IList<double> amounts = new List<double>();

        public Customer(IBillingStrategy strategy)
        {
            this.Strategy = strategy;
        }

        public IBillingStrategy Strategy { get; set; }

        public void Add(double price, int quantity)
        {
            this.amounts.Add(this.Strategy.GetPrice(price) * quantity);
        }

        public double GetTotalAmount()
        {
            return this.amounts.Sum();
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