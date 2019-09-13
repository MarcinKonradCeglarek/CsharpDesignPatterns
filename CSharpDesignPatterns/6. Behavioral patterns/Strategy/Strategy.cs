namespace CSharpDesignPatterns._6._Behavioral_patterns.Strategy
{
    using System.Collections.Generic;
    using System.Linq;

    public class Diner
    {
        private readonly IList<double> amounts = new List<double>();

        public Diner(IBillingStrategy strategy)
        {
            this.Strategy = strategy;
        }

        public IBillingStrategy Strategy { get; set; }

        public void Order(double price, int quantity)
        {
            this.amounts.Add(quantity * this.Strategy.GetPrice(price));
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
        // Price is 50% off
        public double GetPrice(double originalPrice)
        {
            return originalPrice / 2;
        }
    }
}