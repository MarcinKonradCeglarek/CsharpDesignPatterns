namespace CSharpDesignPatterns._6._Behavioral_patterns.Strategy
{
    using System;

    public class FlatTippingStrategy : ITippingStrategy
    {
        // 5$ per order
        public double GetTip(double originalPrice)
        {
            throw new NotImplementedException();
        }
    }
}