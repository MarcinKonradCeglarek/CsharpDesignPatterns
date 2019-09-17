using System;

namespace CSharpDesignPatterns._6._Behavioral_patterns.Strategy
{
    public class DefaultBillingStrategy : IBillingStrategy
    {
        public double GetPrice(double originalPrice)
        {
            return originalPrice;
        }
    }
}