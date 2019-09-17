namespace CSharpDesignPatterns._6._Behavioral_patterns.Strategy
{
    using System;

    public class HappyHourBillingStrategy : IBillingStrategy
    {
        // Price is 50% off
        public double GetPrice(double originalPrice)
        {
            return originalPrice / 2;
        }
    }
}