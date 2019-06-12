namespace CSharpDesignPatterns._6._Behavioral_patterns.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Customer
    {
        public Customer(IBillingStrategy strategy)
        {
            throw new NotImplementedException();
        }

        public IBillingStrategy Strategy { get; set; }

        public void Add(double price, int quantity)
        {
            throw new NotImplementedException();
        }

        public double GetTotalAmount()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }

    public class HappyHourStrategy : IBillingStrategy
    {
        public double GetPrice(double originalPrice)
        {
            throw new NotImplementedException();
        }
    }
}