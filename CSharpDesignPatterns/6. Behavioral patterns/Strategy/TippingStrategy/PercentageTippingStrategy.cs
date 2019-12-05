namespace CSharpDesignPatterns._6._Behavioral_patterns.Strategy
{
    using System;

    public class PercentageTippingStrategy : ITippingStrategy
    {
        public PercentageTippingStrategy(double percentage)
        {
        }

        public double GetTip(double originalPrice)
        {
            throw new NotImplementedException();
        }
    }
}